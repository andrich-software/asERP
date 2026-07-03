using System.Globalization;
using asToolkit.Domain.Enums;
using asToolkit.SalesChannels.Abstractions;
using asToolkit.SalesChannels.Connectors.Common;
using asToolkit.SalesChannels.Contracts;
using asToolkit.SalesChannels.Models;
using asToolkit.SalesChannels.Models.WooCommerceDatabase;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace asToolkit.SalesChannels.Connectors.WooCommerceDatabase;

/// <summary>
/// WooCommerce connector that reads/writes the shop's MySQL database directly instead of going
/// through the (slow) REST API. Behaviour mirrors <see cref="WooCommerce.WooCommerceConnector"/>:
/// same capabilities, same import models, same cursor/backfill semantics — only the transport
/// differs. Product images are still downloaded over HTTP (the channel-agnostic
/// <see cref="IProductImageImportService"/> pulls the public upload URLs built here), which is why
/// the channel keeps the shop's base URL alongside the MySQL settings.
///
/// Orders are read from either storage backend: HPOS (<c>wc_orders</c> + satellite tables) when the
/// shop has <c>woocommerce_custom_orders_table_enabled</c>, legacy <c>shop_order</c> posts otherwise.
///
/// Known limitation of the write path (stock/price export): the rows are updated exactly like
/// WooCommerce writes them (postmeta + product meta lookup), but a shop running a persistent object
/// cache (Redis/Memcached) will not see the change until its cache entry for the product expires or
/// is flushed — direct DB writes cannot invalidate an external cache.
/// </summary>
public sealed class WooCommerceDatabaseConnector : ConnectorBase
{
    private readonly IProductImportRepository _productImportRepository;
    private readonly ISalesImportRepository _salesImportRepository;
    private readonly ICustomerImportRepository _customerImportRepository;
    private readonly IStockImportRepository _stockImportRepository;
    private readonly ILogger<WooCommerceDatabaseConnector> _logger;

    public WooCommerceDatabaseConnector(
        IProductImportRepository productImportRepository,
        ISalesImportRepository salesImportRepository,
        ICustomerImportRepository customerImportRepository,
        IStockImportRepository stockImportRepository,
        ILogger<WooCommerceDatabaseConnector> logger)
    {
        _productImportRepository = productImportRepository;
        _salesImportRepository = salesImportRepository;
        _customerImportRepository = customerImportRepository;
        _stockImportRepository = stockImportRepository;
        _logger = logger;
    }

    public override SalesChannelType Type => SalesChannelType.WooCommerceDatabase;

    public override SalesChannelCapabilities Capabilities =>
        SalesChannelCapabilities.ImportProducts |
        SalesChannelCapabilities.ImportSaless |
        SalesChannelCapabilities.ImportCustomers |
        SalesChannelCapabilities.ImportStock |
        SalesChannelCapabilities.UpdateStock |
        SalesChannelCapabilities.UpdatePrice;

    // Same batch geometry as the REST connector so run durations and audit rows stay comparable.
    private const int PageSize = 100;
    private const int MaxPages = 1000;
    private const int OrderBatchSize = 100;
    private static readonly TimeSpan RecentSalesSeedWindow = TimeSpan.FromDays(14);
    private static readonly TimeSpan MaxBackfillRunDuration = TimeSpan.FromMinutes(15);

    // Last-resort tax rate when the shop has no usable tax table — mirrors the REST connector.
    private const double DefaultTaxRate = 19;

    /// <summary>Resolved per-run connection info: validated config + ready connection string.</summary>
    private sealed record Db(WooCommerceDatabaseChannelConfig Config, string ConnectionString, string Prefix, string ShopBaseUrl);

    private static Db Prepare(SalesChannelContext context)
    {
        var sc = context.SalesChannel;

        var config = WooCommerceDatabaseChannelConfig.FromSalesChannel(sc);
        if (config.Validate() is { } error)
        {
            throw new InvalidOperationException(error);
        }
        if (string.IsNullOrWhiteSpace(sc.Username))
        {
            throw new InvalidOperationException("WooCommerceDatabase channel is missing the MySQL username (SalesChannel.Username)");
        }

        // The image URLs built from this base are later downloaded over HTTP by the image import
        // service — keep the SSRF guard that every HTTP-based channel URL goes through.
        SalesChannelUrlValidator.Validate(sc.Url);

        return new Db(config, config.BuildConnectionString(sc.Username, context.Password), config.TablePrefix, NormalizeShopBaseUrl(sc.Url));
    }

    /// <summary>
    /// The stored URL may still carry the REST API path when a channel was converted from the REST
    /// type — strip it so image links resolve against the plain shop base URL.
    /// </summary>
    private static string NormalizeShopBaseUrl(string url)
    {
        var trimmed = url.TrimEnd('/');
        const string apiPath = "/wp-json/wc/v3";
        if (trimmed.EndsWith(apiPath, StringComparison.OrdinalIgnoreCase))
        {
            trimmed = trimmed[..^apiPath.Length];
        }
        return trimmed;
    }

    private static async Task<MySqlConnection> OpenAsync(Db db, CancellationToken cancellationToken)
    {
        var connection = new MySqlConnection(db.ConnectionString);
        await connection.OpenAsync(cancellationToken);
        return connection;
    }

    public override async Task<ConnectionTestResult> TestConnectionAsync(SalesChannelContext context)
    {
        try
        {
            var db = Prepare(context);
            await using var connection = await OpenAsync(db, context.CancellationToken);

            // The product meta lookup table is the backbone of every import here; a missing table
            // means WooCommerce is not installed in this database or the table prefix is wrong.
            await using var cmd = new MySqlCommand(
                $"SELECT COUNT(*) FROM {db.Prefix}wc_product_meta_lookup", connection);
            var count = Convert.ToInt64(await cmd.ExecuteScalarAsync(context.CancellationToken), CultureInfo.InvariantCulture);

            return new ConnectionTestResult(true, $"{count} products/variations visible");
        }
        catch (Exception ex)
        {
            return new ConnectionTestResult(false, ex.Message);
        }
    }

    // ---------------------------------------------------------------------------------------------
    // Product import
    // ---------------------------------------------------------------------------------------------

    public override async Task<SyncResult> ImportProductsAsync(SalesChannelContext context)
    {
        Db db;
        try
        {
            db = Prepare(context);
        }
        catch (Exception ex)
        {
            return SyncResult.Failed(ex.Message);
        }

        var processed = 0;
        var failed = 0;

        try
        {
            await using var connection = await OpenAsync(db, context.CancellationToken);

            var taxRateMap = await LoadTaxRateMapAsync(connection, db, context.CancellationToken);
            var attributeLabels = await LoadAttributeLabelsAsync(connection, db, context.CancellationToken);
            var progress = new ProgressThrottle(context);

            // Keyset pagination over the post id — stable regardless of concurrent shop writes.
            ulong lastId = 0;
            for (var page = 1; page <= MaxPages; page++)
            {
                context.CancellationToken.ThrowIfCancellationRequested();

                var batch = await LoadProductPageAsync(connection, db, lastId, context.CancellationToken);
                if (batch.Count == 0)
                {
                    break;
                }
                lastId = batch[^1].Id;

                var productIds = batch.Select(p => p.Id).ToList();
                var parentIds = batch.Where(p => p.IsVariable).Select(p => p.Id).ToList();

                var imagesByProduct = await LoadImagesAsync(connection, db, productIds, context.CancellationToken);
                var variationsByParent = await LoadVariationsAsync(connection, db, parentIds, context.CancellationToken);
                var attributesByParent = await LoadParentAttributesAsync(connection, db, parentIds, context.CancellationToken);
                var termNames = await LoadTermNamesAsync(connection, db, variationsByParent, context.CancellationToken);

                foreach (var row in batch)
                {
                    context.CancellationToken.ThrowIfCancellationRequested();

                    // Variable parents occasionally have no own SKU — synthesize a stable one from the
                    // remote id so the parent (and with it all variations) is not dropped. Plain products
                    // without SKU stay skipped, matching the REST connector.
                    var sku = row.Sku;
                    if (string.IsNullOrEmpty(sku))
                    {
                        if (!row.IsVariable)
                        {
                            _logger.LogDebug("Product {Name} has no SKU, skipping", row.Name);
                            continue;
                        }
                        sku = $"WOO-{row.Id}";
                    }

                    try
                    {
                        var importProduct = new SalesChannelImportProduct
                        {
                            RemoteProductId = row.Id.ToString(CultureInfo.InvariantCulture),
                            Name = row.Name,
                            Price = row.MinPrice ?? 0m,
                            Sku = sku,
                            TaxRate = ResolveTaxRate(row.TaxStatus, row.TaxClass, taxRateMap),
                            Description = row.Description,
                            IsVariantParent = row.IsVariable,
                            Images = imagesByProduct.GetValueOrDefault(row.Id) ?? [],
                        };

                        if (row.IsVariable)
                        {
                            var variations = variationsByParent.GetValueOrDefault(row.Id) ?? [];
                            var axes = BuildVariantAxes(
                                attributesByParent.GetValueOrDefault(row.Id) ?? [], variations, attributeLabels);

                            importProduct.VariantAxes = axes.Select(a => a.DisplayName).ToList();
                            importProduct.Variants = variations.Select(v => new SalesChannelImportVariant
                            {
                                RemoteVariantId = v.Id.ToString(CultureInfo.InvariantCulture),
                                Sku = v.Sku,
                                Ean = null,
                                Price = v.Price,
                                Stock = v.Stock ?? 0,
                                SortOrder = v.MenuOrder,
                                Options = MapVariantOptions(v, axes, termNames),
                            }).ToList();
                        }

                        await _productImportRepository.ImportOrUpdateFromSalesChannel(context.SalesChannel.Id, importProduct);
                        processed++;
                    }
                    catch (Exception ex)
                    {
                        failed++;
                        _logger.LogError(ex, "WooCommerce DB product import failed for SKU {Sku}", sku);
                    }

                    await progress.MaybeReportAsync(processed, failed);
                }

                _logger.LogInformation("WooCommerce DB product import page {Page}: {Processed} imported, {Failed} failed so far", page, processed, failed);

                if (batch.Count < PageSize)
                {
                    break;
                }
            }
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "WooCommerce DB product import aborted");
            return processed > 0 ? new SyncResult(processed, failed + 1) : SyncResult.Failed(ex.Message);
        }

        return new SyncResult(processed, failed);
    }

    private sealed record ProductRow(ulong Id, string Name, string Description, string? Sku, decimal? MinPrice, string TaxStatus, string TaxClass, bool IsVariable);

    private static async Task<List<ProductRow>> LoadProductPageAsync(MySqlConnection connection, Db db, ulong lastId, CancellationToken cancellationToken)
    {
        // MAX(t.name) collapses the row fan-out of the unfiltered term_relationships join (a product
        // also relates to categories/tags, which the taxonomy-filtered tt join nulls out).
        var sql = $"""
            SELECT p.ID, p.post_title, p.post_content, l.sku, l.min_price, l.tax_status, l.tax_class,
                   MAX(t.name) AS product_type
            FROM {db.Prefix}posts p
            JOIN {db.Prefix}wc_product_meta_lookup l ON l.product_id = p.ID
            LEFT JOIN {db.Prefix}term_relationships tr ON tr.object_id = p.ID
            LEFT JOIN {db.Prefix}term_taxonomy tt ON tt.term_taxonomy_id = tr.term_taxonomy_id AND tt.taxonomy = 'product_type'
            LEFT JOIN {db.Prefix}terms t ON t.term_id = tt.term_id
            WHERE p.post_type = 'product' AND p.post_status = 'publish' AND p.ID > @lastId
            GROUP BY p.ID, p.post_title, p.post_content, l.sku, l.min_price, l.tax_status, l.tax_class
            ORDER BY p.ID
            LIMIT @pageSize
            """;

        await using var cmd = new MySqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("@lastId", lastId);
        cmd.Parameters.AddWithValue("@pageSize", PageSize);

        var rows = new List<ProductRow>();
        await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            rows.Add(new ProductRow(
                Id: ToUInt64(reader.GetValue(0)),
                Name: AsString(reader.GetValue(1)),
                Description: AsString(reader.GetValue(2)),
                Sku: AsNullableString(reader.GetValue(3)),
                MinPrice: AsNullableDecimal(reader.GetValue(4)),
                TaxStatus: AsString(reader.GetValue(5)),
                TaxClass: AsString(reader.GetValue(6)),
                IsVariable: string.Equals(AsString(reader.GetValue(7)), "variable", StringComparison.OrdinalIgnoreCase)));
        }
        return rows;
    }

    private sealed class VariationRow
    {
        public ulong Id { get; init; }
        public ulong ParentId { get; init; }
        public int MenuOrder { get; init; }
        public string? Sku { get; init; }
        public double? Stock { get; init; }
        public decimal? Price { get; set; }

        /// <summary>Sanitized attribute key (suffix of the <c>attribute_*</c> meta) → selected slug/value.</summary>
        public Dictionary<string, string> Options { get; } = new(StringComparer.OrdinalIgnoreCase);
    }

    private static async Task<Dictionary<ulong, List<VariationRow>>> LoadVariationsAsync(
        MySqlConnection connection, Db db, IReadOnlyList<ulong> parentIds, CancellationToken cancellationToken)
    {
        var result = new Dictionary<ulong, List<VariationRow>>();
        if (parentIds.Count == 0)
        {
            return result;
        }

        var byId = new Dictionary<ulong, VariationRow>();
        {
            await using var cmd = connection.CreateCommand();
            var inList = ParamList(cmd, "pid", parentIds);
            cmd.CommandText = $"""
                SELECT v.ID, v.post_parent, v.menu_order, l.sku, l.stock_quantity
                FROM {db.Prefix}posts v
                JOIN {db.Prefix}wc_product_meta_lookup l ON l.product_id = v.ID
                WHERE v.post_type = 'product_variation' AND v.post_status = 'publish' AND v.post_parent IN ({inList})
                ORDER BY v.post_parent, v.menu_order, v.ID
                """;

            await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
            while (await reader.ReadAsync(cancellationToken))
            {
                var row = new VariationRow
                {
                    Id = ToUInt64(reader.GetValue(0)),
                    ParentId = ToUInt64(reader.GetValue(1)),
                    MenuOrder = Convert.ToInt32(reader.GetValue(2), CultureInfo.InvariantCulture),
                    Sku = AsNullableString(reader.GetValue(3)),
                    Stock = AsNullableDouble(reader.GetValue(4)),
                };
                byId[row.Id] = row;
                if (!result.TryGetValue(row.ParentId, out var list))
                {
                    result[row.ParentId] = list = [];
                }
                list.Add(row);
            }
        }

        if (byId.Count == 0)
        {
            return result;
        }

        // One meta sweep for the whole page: the variation's current price plus its selected
        // attribute options ('_price' may be absent → the variant inherits the parent price).
        await using (var cmd = connection.CreateCommand())
        {
            var inList = ParamList(cmd, "vid", byId.Keys.ToList());
            cmd.CommandText = $"""
                SELECT post_id, meta_key, meta_value
                FROM {db.Prefix}postmeta
                WHERE post_id IN ({inList}) AND (meta_key = '_price' OR meta_key LIKE 'attribute\_%')
                """;

            await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
            while (await reader.ReadAsync(cancellationToken))
            {
                var postId = ToUInt64(reader.GetValue(0));
                if (!byId.TryGetValue(postId, out var row))
                {
                    continue;
                }

                var key = AsString(reader.GetValue(1));
                var value = AsString(reader.GetValue(2));
                if (key == "_price")
                {
                    row.Price = ParseDecimal(value);
                }
                else if (key.StartsWith("attribute_", StringComparison.Ordinal) && value.Length > 0)
                {
                    row.Options[key["attribute_".Length..]] = value;
                }
            }
        }

        return result;
    }

    private static async Task<Dictionary<ulong, IReadOnlyList<WooProductAttribute>>> LoadParentAttributesAsync(
        MySqlConnection connection, Db db, IReadOnlyList<ulong> parentIds, CancellationToken cancellationToken)
    {
        var result = new Dictionary<ulong, IReadOnlyList<WooProductAttribute>>();
        if (parentIds.Count == 0)
        {
            return result;
        }

        await using var cmd = connection.CreateCommand();
        var inList = ParamList(cmd, "pid", parentIds);
        cmd.CommandText = $"""
            SELECT post_id, meta_value FROM {db.Prefix}postmeta
            WHERE post_id IN ({inList}) AND meta_key = '_product_attributes'
            """;

        await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            result[ToUInt64(reader.GetValue(0))] = WooProductAttributesParser.Parse(AsNullableString(reader.GetValue(1)));
        }
        return result;
    }

    private sealed record VariantAxis(string Key, string DisplayName, bool IsTaxonomy);

    /// <summary>
    /// The variation axes of a variable product, ordered like the shop displays them. Primary source
    /// is the parent's <c>_product_attributes</c> meta (attributes flagged <c>is_variation</c>,
    /// ordered by position — matching what the REST API exposes); when that meta is missing or
    /// unparseable, the axes are derived from the variations' own attribute metas in first-seen order.
    /// </summary>
    private static List<VariantAxis> BuildVariantAxes(
        IReadOnlyList<WooProductAttribute> parentAttributes,
        IReadOnlyList<VariationRow> variations,
        IReadOnlyDictionary<string, string> attributeLabels)
    {
        var axes = new List<VariantAxis>();
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var attribute in parentAttributes.Where(a => a.IsVariation).OrderBy(a => a.Position))
        {
            if (seen.Add(attribute.Key))
            {
                axes.Add(new VariantAxis(attribute.Key, ResolveAxisName(attribute.Key, attribute.Name, attributeLabels), IsTaxonomyKey(attribute.Key)));
            }
        }

        // Fallback / completion: any attribute the variations actually select but the parent meta
        // did not yield (older shops, malformed serialization) still becomes an axis.
        foreach (var variation in variations)
        {
            foreach (var key in variation.Options.Keys)
            {
                if (seen.Add(key))
                {
                    axes.Add(new VariantAxis(key, ResolveAxisName(key, rawName: null, attributeLabels), IsTaxonomyKey(key)));
                }
            }
        }

        return axes;
    }

    private static bool IsTaxonomyKey(string key) => key.StartsWith("pa_", StringComparison.OrdinalIgnoreCase);

    private static string ResolveAxisName(string key, string? rawName, IReadOnlyDictionary<string, string> attributeLabels)
    {
        if (IsTaxonomyKey(key))
        {
            var slug = key[3..];
            return attributeLabels.TryGetValue(slug, out var label) && label.Length > 0 ? label : Humanize(slug);
        }

        // Custom (non-taxonomy) attribute: the parent meta carries the display name; the sanitized
        // key is all a variation-derived fallback has.
        return !string.IsNullOrWhiteSpace(rawName) && !IsTaxonomyKey(rawName) ? rawName : Humanize(key);
    }

    private static string Humanize(string slug)
    {
        var text = slug.Replace('-', ' ').Replace('_', ' ').Trim();
        return text.Length == 0 ? slug : char.ToUpperInvariant(text[0]) + text[1..];
    }

    private static List<SalesChannelImportVariantOption> MapVariantOptions(
        VariationRow variation,
        IReadOnlyList<VariantAxis> axes,
        IReadOnlyDictionary<(string Taxonomy, string Slug), string> termNames)
    {
        var options = new List<SalesChannelImportVariantOption>();
        foreach (var axis in axes)
        {
            // An empty/absent option means the variation matches "any" value on that axis — the REST
            // API omits it there as well.
            if (!variation.Options.TryGetValue(axis.Key, out var value) || string.IsNullOrEmpty(value))
            {
                continue;
            }

            var display = axis.IsTaxonomy && termNames.TryGetValue((axis.Key, value), out var termName)
                ? termName
                : value;

            options.Add(new SalesChannelImportVariantOption
            {
                AttributeName = axis.DisplayName,
                Value = display,
            });
        }
        return options;
    }

    /// <summary>
    /// Resolves the display names of all taxonomy attribute options selected by this page's
    /// variations: (taxonomy, term slug) → term name (e.g. ("pa_farbe", "rot") → "Rot").
    /// </summary>
    private static async Task<Dictionary<(string Taxonomy, string Slug), string>> LoadTermNamesAsync(
        MySqlConnection connection, Db db, Dictionary<ulong, List<VariationRow>> variationsByParent, CancellationToken cancellationToken)
    {
        var taxonomies = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var slugs = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var variation in variationsByParent.Values.SelectMany(v => v))
        {
            foreach (var (key, value) in variation.Options)
            {
                if (IsTaxonomyKey(key) && value.Length > 0)
                {
                    taxonomies.Add(key);
                    slugs.Add(value);
                }
            }
        }

        var result = new Dictionary<(string, string), string>();
        if (taxonomies.Count == 0 || slugs.Count == 0)
        {
            return result;
        }

        await using var cmd = connection.CreateCommand();
        var taxonomyList = ParamList(cmd, "tax", taxonomies.ToList());
        var slugList = ParamList(cmd, "slug", slugs.ToList());
        cmd.CommandText = $"""
            SELECT tt.taxonomy, t.slug, t.name
            FROM {db.Prefix}terms t
            JOIN {db.Prefix}term_taxonomy tt ON tt.term_id = t.term_id
            WHERE tt.taxonomy IN ({taxonomyList}) AND t.slug IN ({slugList})
            """;

        await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            result[(AsString(reader.GetValue(0)), AsString(reader.GetValue(1)))] = AsString(reader.GetValue(2));
        }
        return result;
    }

    /// <summary>Global attribute labels: taxonomy slug without the <c>pa_</c> prefix → display label.</summary>
    private static async Task<Dictionary<string, string>> LoadAttributeLabelsAsync(
        MySqlConnection connection, Db db, CancellationToken cancellationToken)
    {
        var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        await using var cmd = new MySqlCommand(
            $"SELECT attribute_name, attribute_label FROM {db.Prefix}woocommerce_attribute_taxonomies", connection);
        await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            var name = AsString(reader.GetValue(0));
            var label = AsString(reader.GetValue(1));
            if (name.Length > 0 && label.Length > 0)
            {
                map[name] = label;
            }
        }
        return map;
    }

    // ------------------------------------- images -----------------------------------------------

    private static async Task<Dictionary<ulong, List<SalesChannelImportImage>>> LoadImagesAsync(
        MySqlConnection connection, Db db, IReadOnlyList<ulong> productIds, CancellationToken cancellationToken)
    {
        var result = new Dictionary<ulong, List<SalesChannelImportImage>>();
        if (productIds.Count == 0)
        {
            return result;
        }

        // Featured image + gallery — ordered attachment ids per product, featured first.
        var attachmentIdsByProduct = new Dictionary<ulong, List<ulong>>();
        var allAttachmentIds = new HashSet<ulong>();
        await using (var cmd = connection.CreateCommand())
        {
            var inList = ParamList(cmd, "pid", productIds);
            cmd.CommandText = $"""
                SELECT post_id, meta_key, meta_value
                FROM {db.Prefix}postmeta
                WHERE post_id IN ({inList}) AND meta_key IN ('_thumbnail_id', '_product_image_gallery')
                """;

            var thumbnails = new Dictionary<ulong, ulong>();
            var galleries = new Dictionary<ulong, List<ulong>>();

            await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
            while (await reader.ReadAsync(cancellationToken))
            {
                var productId = ToUInt64(reader.GetValue(0));
                var key = AsString(reader.GetValue(1));
                var value = AsString(reader.GetValue(2));

                if (key == "_thumbnail_id" && ulong.TryParse(value, out var thumbnailId) && thumbnailId > 0)
                {
                    thumbnails[productId] = thumbnailId;
                }
                else if (key == "_product_image_gallery")
                {
                    var ids = value.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                        .Select(part => ulong.TryParse(part, out var id) ? id : 0)
                        .Where(id => id > 0)
                        .ToList();
                    if (ids.Count > 0)
                    {
                        galleries[productId] = ids;
                    }
                }
            }

            foreach (var productId in productIds)
            {
                var ordered = new List<ulong>();
                var seen = new HashSet<ulong>();
                if (thumbnails.TryGetValue(productId, out var thumbnailId) && seen.Add(thumbnailId))
                {
                    ordered.Add(thumbnailId);
                }
                foreach (var id in galleries.GetValueOrDefault(productId) ?? [])
                {
                    if (seen.Add(id))
                    {
                        ordered.Add(id);
                    }
                }
                if (ordered.Count > 0)
                {
                    attachmentIdsByProduct[productId] = ordered;
                    foreach (var id in ordered)
                    {
                        allAttachmentIds.Add(id);
                    }
                }
            }
        }

        if (allAttachmentIds.Count == 0)
        {
            return result;
        }

        // Attachment details. '_wp_attached_file' (path below /wp-content/uploads) is the reliable
        // source for the public URL; the guid column often still points at a pre-migration domain,
        // so it is only a fallback.
        var attachments = new Dictionary<ulong, (string? Url, string? AltText, string Title)>();
        await using (var cmd = connection.CreateCommand())
        {
            var inList = ParamList(cmd, "aid", allAttachmentIds.ToList());
            cmd.CommandText = $"""
                SELECT p.ID, p.post_title, p.guid,
                       MAX(CASE WHEN m.meta_key = '_wp_attached_file' THEN m.meta_value END) AS attached_file,
                       MAX(CASE WHEN m.meta_key = '_wp_attachment_image_alt' THEN m.meta_value END) AS alt_text
                FROM {db.Prefix}posts p
                LEFT JOIN {db.Prefix}postmeta m ON m.post_id = p.ID AND m.meta_key IN ('_wp_attached_file', '_wp_attachment_image_alt')
                WHERE p.ID IN ({inList}) AND p.post_type = 'attachment'
                GROUP BY p.ID, p.post_title, p.guid
                """;

            await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
            while (await reader.ReadAsync(cancellationToken))
            {
                var id = ToUInt64(reader.GetValue(0));
                var title = AsString(reader.GetValue(1));
                var guid = AsNullableString(reader.GetValue(2));
                var file = AsNullableString(reader.GetValue(3));
                var alt = AsNullableString(reader.GetValue(4));
                attachments[id] = (BuildImageUrl(db.ShopBaseUrl, file, guid), alt, title);
            }
        }

        foreach (var (productId, attachmentIds) in attachmentIdsByProduct)
        {
            var images = new List<SalesChannelImportImage>();
            foreach (var attachmentId in attachmentIds)
            {
                if (!attachments.TryGetValue(attachmentId, out var attachment) || string.IsNullOrEmpty(attachment.Url))
                {
                    continue;
                }
                images.Add(new SalesChannelImportImage
                {
                    RemoteImageId = attachmentId.ToString(CultureInfo.InvariantCulture),
                    Url = attachment.Url,
                    AltText = string.IsNullOrWhiteSpace(attachment.AltText) ? attachment.Title : attachment.AltText,
                    SortOrder = images.Count,
                });
            }
            if (images.Count > 0)
            {
                result[productId] = images;
            }
        }

        return result;
    }

    private static string? BuildImageUrl(string shopBaseUrl, string? attachedFile, string? guid)
    {
        if (!string.IsNullOrWhiteSpace(attachedFile))
        {
            return $"{shopBaseUrl}/wp-content/uploads/{attachedFile.TrimStart('/')}";
        }
        if (!string.IsNullOrWhiteSpace(guid) &&
            Uri.TryCreate(guid, UriKind.Absolute, out var uri) &&
            (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
        {
            return guid;
        }
        return null;
    }

    // ------------------------------------- taxes ------------------------------------------------

    /// <summary>
    /// Tax-class slug → percentage from the shop's tax table (same normalization as the REST
    /// connector: empty class → "standard", highest rate per class wins).
    /// </summary>
    private async Task<Dictionary<string, double>> LoadTaxRateMapAsync(MySqlConnection connection, Db db, CancellationToken cancellationToken)
    {
        var map = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);
        try
        {
            await using var cmd = new MySqlCommand(
                $"SELECT tax_rate_class, tax_rate FROM {db.Prefix}woocommerce_tax_rates", connection);
            await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
            while (await reader.ReadAsync(cancellationToken))
            {
                var slug = AsString(reader.GetValue(0));
                if (!double.TryParse(AsString(reader.GetValue(1)), NumberStyles.Any, CultureInfo.InvariantCulture, out var rate))
                {
                    continue;
                }
                slug = slug.Length == 0 ? "standard" : slug;
                if (!map.TryGetValue(slug, out var existing) || rate > existing)
                {
                    map[slug] = rate;
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "WooCommerce DB tax rates could not be read; falling back to default tax rate {Rate}", DefaultTaxRate);
        }
        return map;
    }

    private static double ResolveTaxRate(string taxStatus, string taxClass, IReadOnlyDictionary<string, double> taxRateMap)
    {
        if (string.Equals(taxStatus, "none", StringComparison.OrdinalIgnoreCase))
        {
            return 0;
        }

        var slug = taxClass.Length == 0 ? "standard" : taxClass;
        if (taxRateMap.TryGetValue(slug, out var rate))
        {
            return rate;
        }
        return taxRateMap.TryGetValue("standard", out var standardRate) ? standardRate : DefaultTaxRate;
    }

    // ---------------------------------------------------------------------------------------------
    // Sales (order) import
    // ---------------------------------------------------------------------------------------------

    public override async Task<SyncResult> ImportSalessAsync(SalesChannelContext context)
    {
        Db db;
        try
        {
            db = Prepare(context);
        }
        catch (Exception ex)
        {
            return SyncResult.Failed(ex.Message);
        }

        try
        {
            await using var connection = await OpenAsync(db, context.CancellationToken);
            var hpos = await UsesHposAsync(connection, db, context.CancellationToken);
            var progress = new ProgressThrottle(context);

            // Caught up: pull only orders changed since the last successful run.
            if (context.SalesChannel.InitialSalesImportCompleted)
            {
                return await ImportSalesByModifiedAsync(connection, db, hpos, context, context.IncrementalSince, progress);
            }

            // Still backfilling: a "recent" pass first so today's orders arrive within one cycle,
            // then a time-boxed chunk of the oldest-first history walk — same two-pass scheme (and
            // the same cursor fields) as the REST connector, so switching a channel between the two
            // types keeps its progress.
            var recentSince = context.IncrementalSince ?? DateTime.UtcNow - RecentSalesSeedWindow;
            var recent = await ImportSalesByModifiedAsync(connection, db, hpos, context, recentSince, progress);
            progress.AddCompletedPass(recent.ItemsProcessed, recent.ItemsFailed);
            var backfill = await ImportSalesBackfillAsync(connection, db, hpos, context, progress);

            return new SyncResult(
                recent.ItemsProcessed + backfill.ItemsProcessed,
                recent.ItemsFailed + backfill.ItemsFailed,
                backfill.ErrorSummary ?? recent.ErrorSummary);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            return SyncResult.Failed(ex.Message);
        }
    }

    /// <summary>
    /// HPOS ("high-performance order storage") keeps orders in dedicated <c>wc_orders</c> tables;
    /// legacy shops keep them as <c>shop_order</c> posts. The authoritative switch is the
    /// WooCommerce option — reading the same backend WooCommerce itself uses guarantees we see
    /// every order even while a shop syncs both stores in compatibility mode.
    /// </summary>
    private static async Task<bool> UsesHposAsync(MySqlConnection connection, Db db, CancellationToken cancellationToken)
    {
        await using var cmd = new MySqlCommand(
            $"SELECT option_value FROM {db.Prefix}options WHERE option_name = 'woocommerce_custom_orders_table_enabled' LIMIT 1",
            connection);
        var value = await cmd.ExecuteScalarAsync(cancellationToken) as string;
        return string.Equals(value, "yes", StringComparison.OrdinalIgnoreCase);
    }

    private async Task<SyncResult> ImportSalesByModifiedAsync(
        MySqlConnection connection, Db db, bool hpos, SalesChannelContext context, DateTime? modifiedSince, ProgressThrottle progress)
    {
        var processed = 0;
        var failed = 0;

        ulong lastId = 0;
        for (var page = 1; page <= MaxPages; page++)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var batch = hpos
                ? await LoadOrderBatchHposAsync(connection, db, context.CancellationToken, afterId: lastId, modifiedSince: modifiedSince)
                : await LoadOrderBatchLegacyAsync(connection, db, context.CancellationToken, afterId: lastId, modifiedSince: modifiedSince);
            if (batch.Count == 0)
            {
                break;
            }
            lastId = batch[^1].Id;

            foreach (var order in batch)
            {
                try
                {
                    await _salesImportRepository.ImportOrUpdateFromSalesChannel(context.SalesChannel, MapOrder(order));
                    processed++;
                }
                catch (Exception ex)
                {
                    failed++;
                    _logger.LogError(ex, "WooCommerce DB sales import failed for {Id}", order.Id);
                }
            }

            await progress.MaybeReportAsync(processed, failed);

            if (batch.Count < OrderBatchSize)
            {
                break;
            }
        }

        return new SyncResult(processed, failed);
    }

    /// <summary>
    /// Resumable, oldest-first backfill of the full order history, keyset-paged on the immutable
    /// (date_created, id) pair. The channel's <c>SalesImportBackfillCursor</c> is advanced per batch
    /// (frozen the moment an order fails, so failures are retried next run) and the run is
    /// time-boxed like the REST walk. When we walk off the end cleanly, the channel flips to
    /// incremental mode.
    /// </summary>
    private async Task<SyncResult> ImportSalesBackfillAsync(
        MySqlConnection connection, Db db, bool hpos, SalesChannelContext context, ProgressThrottle progress)
    {
        var processed = 0;
        var failed = 0;

        // Resume one second before the persisted cursor — cheap overlap, and upserts are idempotent.
        var cursorDate = context.SalesChannel.SalesImportBackfillCursor?.AddSeconds(-1) ?? DateTime.MinValue;
        ulong cursorId = 0;
        var cursorAdvance = context.SalesChannel.SalesImportBackfillCursor;
        var frozen = false;
        var reachedEnd = false;
        var runStart = DateTime.UtcNow;

        for (var page = 1; page <= MaxPages; page++)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var batch = hpos
                ? await LoadOrderBatchHposAsync(connection, db, context.CancellationToken, createdKeyset: (cursorDate, cursorId))
                : await LoadOrderBatchLegacyAsync(connection, db, context.CancellationToken, createdKeyset: (cursorDate, cursorId));
            if (batch.Count == 0)
            {
                reachedEnd = true;
                break;
            }
            cursorDate = batch[^1].CreatedGmt;
            cursorId = batch[^1].Id;

            foreach (var order in batch)
            {
                try
                {
                    await _salesImportRepository.ImportOrUpdateFromSalesChannel(context.SalesChannel, MapOrder(order));
                    processed++;

                    if (!frozen && (cursorAdvance is null || order.CreatedGmt > cursorAdvance))
                    {
                        cursorAdvance = order.CreatedGmt;
                    }
                }
                catch (Exception ex)
                {
                    failed++;
                    frozen = true;
                    _logger.LogError(ex, "WooCommerce DB sales backfill failed for {Id}", order.Id);
                }
            }

            if (cursorAdvance is { } advance && advance != context.SalesChannel.SalesImportBackfillCursor)
            {
                context.SalesChannel.SalesImportBackfillCursor = advance;
            }

            await progress.MaybeReportAsync(processed, failed);
            _logger.LogInformation("WooCommerce DB order backfill page {Page}: {Processed} imported, {Failed} failed, cursor {Cursor:u}", page, processed, failed, cursorAdvance);

            if (batch.Count < OrderBatchSize)
            {
                reachedEnd = true;
                break;
            }
            if (DateTime.UtcNow - runStart >= MaxBackfillRunDuration)
            {
                break;
            }
        }

        if (reachedEnd && !frozen)
        {
            context.SalesChannel.InitialSalesImportCompleted = true;
        }

        return new SyncResult(processed, failed);
    }

    private sealed class OrderRow
    {
        public ulong Id { get; init; }
        public string Status { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public decimal TotalTax { get; set; }
        public decimal ShippingTotal { get; set; }
        public ulong CustomerId { get; set; }
        public DateTime CreatedGmt { get; set; } = DateTime.UtcNow;
        public bool IsPaid { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string PaymentMethodTitle { get; set; } = string.Empty;
        public string TransactionId { get; set; } = string.Empty;
        public string CustomerNote { get; set; } = string.Empty;
        public AddressRow Billing { get; set; } = new();
        public AddressRow Shipping { get; set; } = new();
        public List<OrderItemRow> Items { get; } = [];
    }

    private sealed class AddressRow
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }

    private sealed class OrderItemRow
    {
        public ulong ItemId { get; init; }
        public string Name { get; init; } = string.Empty;
        public double Quantity { get; set; }
        public decimal? LineSubtotal { get; set; }
        public decimal? LineSubtotalTax { get; set; }
        public decimal? LineTotal { get; set; }
        public ulong ProductId { get; set; }
        public ulong VariationId { get; set; }
        public string Sku { get; set; } = string.Empty;
    }

    // Order rows WooCommerce itself hides from every list: trashed and draft/checkout-draft ones.
    private const string ExcludedOrderStatuses =
        "'trash', 'auto-draft', 'draft', 'wc-checkout-draft', 'checkout-draft'";

    private async Task<List<OrderRow>> LoadOrderBatchHposAsync(
        MySqlConnection connection, Db db, CancellationToken cancellationToken,
        ulong afterId = 0, DateTime? modifiedSince = null, (DateTime Date, ulong Id)? createdKeyset = null)
    {
        var orders = new List<OrderRow>();
        await using (var cmd = connection.CreateCommand())
        {
            var filter = createdKeyset is { } keyset
                ? "AND (o.date_created_gmt > @cursorDate OR (o.date_created_gmt = @cursorDate AND o.id > @cursorId))"
                : "AND o.id > @afterId" + (modifiedSince is not null ? " AND o.date_updated_gmt >= @modifiedSince" : string.Empty);
            var order = createdKeyset is not null ? "o.date_created_gmt, o.id" : "o.id";

            cmd.CommandText = $"""
                SELECT o.id, o.status, o.total_amount, o.tax_amount, o.customer_id, o.date_created_gmt,
                       o.payment_method, o.payment_method_title, o.transaction_id, o.customer_note,
                       od.date_paid_gmt, od.shipping_total_amount
                FROM {db.Prefix}wc_orders o
                LEFT JOIN {db.Prefix}wc_order_operational_data od ON od.order_id = o.id
                WHERE o.type = 'shop_order' AND o.status NOT IN ({ExcludedOrderStatuses})
                {filter}
                ORDER BY {order}
                LIMIT @batchSize
                """;

            if (createdKeyset is { } ks)
            {
                cmd.Parameters.AddWithValue("@cursorDate", ks.Date == DateTime.MinValue ? new DateTime(1970, 1, 1) : ks.Date);
                cmd.Parameters.AddWithValue("@cursorId", ks.Id);
            }
            else
            {
                cmd.Parameters.AddWithValue("@afterId", afterId);
                if (modifiedSince is not null)
                {
                    cmd.Parameters.AddWithValue("@modifiedSince", modifiedSince.Value);
                }
            }
            cmd.Parameters.AddWithValue("@batchSize", OrderBatchSize);

            await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
            while (await reader.ReadAsync(cancellationToken))
            {
                orders.Add(new OrderRow
                {
                    Id = ToUInt64(reader.GetValue(0)),
                    Status = StripStatusPrefix(AsString(reader.GetValue(1))),
                    Total = AsNullableDecimal(reader.GetValue(2)) ?? 0m,
                    TotalTax = AsNullableDecimal(reader.GetValue(3)) ?? 0m,
                    CustomerId = ToUInt64(reader.GetValue(4)),
                    CreatedGmt = ToUtc(AsNullableDateTime(reader.GetValue(5))),
                    PaymentMethod = AsString(reader.GetValue(6)),
                    PaymentMethodTitle = AsString(reader.GetValue(7)),
                    TransactionId = AsString(reader.GetValue(8)),
                    CustomerNote = AsString(reader.GetValue(9)),
                    IsPaid = AsNullableDateTime(reader.GetValue(10)) is not null,
                    ShippingTotal = AsNullableDecimal(reader.GetValue(11)) ?? 0m,
                });
            }
        }

        if (orders.Count == 0)
        {
            return orders;
        }

        var byId = orders.ToDictionary(o => o.Id);

        await using (var cmd = connection.CreateCommand())
        {
            var inList = ParamList(cmd, "oid", orders.Select(o => o.Id).ToList());
            cmd.CommandText = $"""
                SELECT order_id, address_type, first_name, last_name, company, address_1, city, postcode, country, email, phone
                FROM {db.Prefix}wc_order_addresses
                WHERE order_id IN ({inList})
                """;

            await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
            while (await reader.ReadAsync(cancellationToken))
            {
                if (!byId.TryGetValue(ToUInt64(reader.GetValue(0)), out var orderRow))
                {
                    continue;
                }
                var address = new AddressRow
                {
                    Firstname = AsString(reader.GetValue(2)),
                    Lastname = AsString(reader.GetValue(3)),
                    Company = AsString(reader.GetValue(4)),
                    Street = AsString(reader.GetValue(5)),
                    City = AsString(reader.GetValue(6)),
                    Zip = AsString(reader.GetValue(7)),
                    Country = AsString(reader.GetValue(8)),
                    Email = AsString(reader.GetValue(9)),
                    Phone = AsString(reader.GetValue(10)),
                };
                if (string.Equals(AsString(reader.GetValue(1)), "shipping", StringComparison.OrdinalIgnoreCase))
                {
                    orderRow.Shipping = address;
                }
                else
                {
                    orderRow.Billing = address;
                }
            }
        }

        await LoadOrderItemsAsync(connection, db, byId, cancellationToken);
        return orders;
    }

    private async Task<List<OrderRow>> LoadOrderBatchLegacyAsync(
        MySqlConnection connection, Db db, CancellationToken cancellationToken,
        ulong afterId = 0, DateTime? modifiedSince = null, (DateTime Date, ulong Id)? createdKeyset = null)
    {
        var orders = new List<OrderRow>();
        await using (var cmd = connection.CreateCommand())
        {
            var filter = createdKeyset is not null
                ? "AND (p.post_date_gmt > @cursorDate OR (p.post_date_gmt = @cursorDate AND p.ID > @cursorId))"
                : "AND p.ID > @afterId" + (modifiedSince is not null ? " AND p.post_modified_gmt >= @modifiedSince" : string.Empty);
            var order = createdKeyset is not null ? "p.post_date_gmt, p.ID" : "p.ID";

            cmd.CommandText = $"""
                SELECT p.ID, p.post_status, p.post_date_gmt, p.post_excerpt
                FROM {db.Prefix}posts p
                WHERE p.post_type = 'shop_order' AND p.post_status NOT IN ({ExcludedOrderStatuses})
                {filter}
                ORDER BY {order}
                LIMIT @batchSize
                """;

            if (createdKeyset is { } ks)
            {
                cmd.Parameters.AddWithValue("@cursorDate", ks.Date == DateTime.MinValue ? new DateTime(1970, 1, 1) : ks.Date);
                cmd.Parameters.AddWithValue("@cursorId", ks.Id);
            }
            else
            {
                cmd.Parameters.AddWithValue("@afterId", afterId);
                if (modifiedSince is not null)
                {
                    cmd.Parameters.AddWithValue("@modifiedSince", modifiedSince.Value);
                }
            }
            cmd.Parameters.AddWithValue("@batchSize", OrderBatchSize);

            await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
            while (await reader.ReadAsync(cancellationToken))
            {
                orders.Add(new OrderRow
                {
                    Id = ToUInt64(reader.GetValue(0)),
                    Status = StripStatusPrefix(AsString(reader.GetValue(1))),
                    CreatedGmt = ToUtc(AsNullableDateTime(reader.GetValue(2))),
                    CustomerNote = AsString(reader.GetValue(3)),
                });
            }
        }

        if (orders.Count == 0)
        {
            return orders;
        }

        var byId = orders.ToDictionary(o => o.Id);

        await using (var cmd = connection.CreateCommand())
        {
            var inList = ParamList(cmd, "oid", orders.Select(o => o.Id).ToList());
            cmd.CommandText = $"""
                SELECT post_id, meta_key, meta_value
                FROM {db.Prefix}postmeta
                WHERE post_id IN ({inList}) AND meta_key IN (
                    '_billing_first_name', '_billing_last_name', '_billing_company', '_billing_address_1',
                    '_billing_city', '_billing_postcode', '_billing_country', '_billing_email', '_billing_phone',
                    '_shipping_first_name', '_shipping_last_name', '_shipping_company', '_shipping_address_1',
                    '_shipping_city', '_shipping_postcode', '_shipping_country',
                    '_order_total', '_order_tax', '_order_shipping', '_order_shipping_tax',
                    '_payment_method', '_payment_method_title', '_transaction_id', '_customer_user',
                    '_date_paid', '_paid_date')
                """;

            var shippingTax = new Dictionary<ulong, decimal>();
            await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
            while (await reader.ReadAsync(cancellationToken))
            {
                if (!byId.TryGetValue(ToUInt64(reader.GetValue(0)), out var orderRow))
                {
                    continue;
                }
                var value = AsString(reader.GetValue(2));
                switch (AsString(reader.GetValue(1)))
                {
                    case "_billing_first_name": orderRow.Billing.Firstname = value; break;
                    case "_billing_last_name": orderRow.Billing.Lastname = value; break;
                    case "_billing_company": orderRow.Billing.Company = value; break;
                    case "_billing_address_1": orderRow.Billing.Street = value; break;
                    case "_billing_city": orderRow.Billing.City = value; break;
                    case "_billing_postcode": orderRow.Billing.Zip = value; break;
                    case "_billing_country": orderRow.Billing.Country = value; break;
                    case "_billing_email": orderRow.Billing.Email = value; break;
                    case "_billing_phone": orderRow.Billing.Phone = value; break;
                    case "_shipping_first_name": orderRow.Shipping.Firstname = value; break;
                    case "_shipping_last_name": orderRow.Shipping.Lastname = value; break;
                    case "_shipping_company": orderRow.Shipping.Company = value; break;
                    case "_shipping_address_1": orderRow.Shipping.Street = value; break;
                    case "_shipping_city": orderRow.Shipping.City = value; break;
                    case "_shipping_postcode": orderRow.Shipping.Zip = value; break;
                    case "_shipping_country": orderRow.Shipping.Country = value; break;
                    case "_order_total": orderRow.Total = ParseDecimal(value) ?? 0m; break;
                    case "_order_tax": orderRow.TotalTax += ParseDecimal(value) ?? 0m; break;
                    case "_order_shipping_tax":
                        // Woo's REST total_tax = cart tax + shipping tax; the legacy store keeps them apart.
                        orderRow.TotalTax += ParseDecimal(value) ?? 0m;
                        shippingTax[orderRow.Id] = ParseDecimal(value) ?? 0m;
                        break;
                    case "_order_shipping": orderRow.ShippingTotal = ParseDecimal(value) ?? 0m; break;
                    case "_payment_method": orderRow.PaymentMethod = value; break;
                    case "_payment_method_title": orderRow.PaymentMethodTitle = value; break;
                    case "_transaction_id": orderRow.TransactionId = value; break;
                    case "_customer_user": orderRow.CustomerId = ulong.TryParse(value, out var uid) ? uid : 0; break;
                    case "_date_paid": orderRow.IsPaid |= long.TryParse(value, out var ts) && ts > 0; break;
                    case "_paid_date": orderRow.IsPaid |= !string.IsNullOrWhiteSpace(value); break;
                }
            }
        }

        await LoadOrderItemsAsync(connection, db, byId, cancellationToken);
        return orders;
    }

    /// <summary>Line items live in the same two tables for both storage modes.</summary>
    private static async Task LoadOrderItemsAsync(
        MySqlConnection connection, Db db, Dictionary<ulong, OrderRow> ordersById, CancellationToken cancellationToken)
    {
        var itemsById = new Dictionary<ulong, OrderItemRow>();
        await using (var cmd = connection.CreateCommand())
        {
            var inList = ParamList(cmd, "oid", ordersById.Keys.ToList());
            cmd.CommandText = $"""
                SELECT i.order_id, i.order_item_id, i.order_item_name, m.meta_key, m.meta_value
                FROM {db.Prefix}woocommerce_order_items i
                LEFT JOIN {db.Prefix}woocommerce_order_itemmeta m ON m.order_item_id = i.order_item_id
                    AND m.meta_key IN ('_qty', '_line_subtotal', '_line_subtotal_tax', '_line_total', '_product_id', '_variation_id')
                WHERE i.order_id IN ({inList}) AND i.order_item_type = 'line_item'
                ORDER BY i.order_item_id
                """;

            await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
            while (await reader.ReadAsync(cancellationToken))
            {
                var orderId = ToUInt64(reader.GetValue(0));
                var itemId = ToUInt64(reader.GetValue(1));
                if (!itemsById.TryGetValue(itemId, out var item))
                {
                    item = new OrderItemRow { ItemId = itemId, Name = AsString(reader.GetValue(2)) };
                    itemsById[itemId] = item;
                    if (ordersById.TryGetValue(orderId, out var orderRow))
                    {
                        orderRow.Items.Add(item);
                    }
                }

                var value = AsNullableString(reader.GetValue(4));
                if (value is null)
                {
                    continue;
                }
                switch (AsString(reader.GetValue(3)))
                {
                    case "_qty": item.Quantity = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var qty) ? qty : 0; break;
                    case "_line_subtotal": item.LineSubtotal = ParseDecimal(value); break;
                    case "_line_subtotal_tax": item.LineSubtotalTax = ParseDecimal(value); break;
                    case "_line_total": item.LineTotal = ParseDecimal(value); break;
                    case "_product_id": item.ProductId = ulong.TryParse(value, out var pid) ? pid : 0; break;
                    case "_variation_id": item.VariationId = ulong.TryParse(value, out var vid) ? vid : 0; break;
                }
            }
        }

        // Resolve SKUs for the referenced products/variations (a variation's SKU wins when set).
        var lookupIds = itemsById.Values
            .SelectMany(i => new[] { i.VariationId, i.ProductId })
            .Where(id => id > 0)
            .Distinct()
            .ToList();
        if (lookupIds.Count == 0)
        {
            return;
        }

        var skus = new Dictionary<ulong, string>();
        await using (var cmd = connection.CreateCommand())
        {
            var inList = ParamList(cmd, "lid", lookupIds);
            cmd.CommandText = $"SELECT product_id, sku FROM {db.Prefix}wc_product_meta_lookup WHERE product_id IN ({inList})";
            await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
            while (await reader.ReadAsync(cancellationToken))
            {
                var sku = AsNullableString(reader.GetValue(1));
                if (!string.IsNullOrEmpty(sku))
                {
                    skus[ToUInt64(reader.GetValue(0))] = sku;
                }
            }
        }

        foreach (var item in itemsById.Values)
        {
            item.Sku = (item.VariationId > 0 ? skus.GetValueOrDefault(item.VariationId) : null)
                ?? skus.GetValueOrDefault(item.ProductId)
                ?? string.Empty;
        }
    }

    private static SalesChannelImportSales MapOrder(OrderRow order)
    {
        var subtotal = order.Total - order.TotalTax - order.ShippingTotal;
        // Guest orders carry customer id 0 — leave the remote id empty so the import falls back to
        // email matching / creation, matching the REST connector.
        var remoteCustomerId = order.CustomerId > 0 ? order.CustomerId.ToString(CultureInfo.InvariantCulture) : string.Empty;

        return new SalesChannelImportSales
        {
            RemoteSalesId = order.Id.ToString(CultureInfo.InvariantCulture),
            RemoteCustomerId = remoteCustomerId,
            DateSalesed = order.CreatedGmt,
            Status = MapSalesStatus(order.Status),
            PaymentStatus = MapPaymentStatus(order.Status, order.IsPaid),
            PaymentMethod = order.PaymentMethod,
            PaymentProvider = order.PaymentMethodTitle,
            PaymentTransactionId = order.TransactionId,
            CustomerNote = order.CustomerNote,
            Subtotal = subtotal,
            ShippingCost = order.ShippingTotal,
            TotalTax = order.TotalTax,
            Total = order.Total,
            Customer = new SalesChannelImportCustomer
            {
                RemoteCustomerId = remoteCustomerId,
                Firstname = order.Billing.Firstname,
                Lastname = order.Billing.Lastname,
                CompanyName = order.Billing.Company,
                Email = order.Billing.Email,
                Phone = order.Billing.Phone,
                CustomerStatus = CustomerStatus.Active,
                DateEnrollment = order.CreatedGmt,
            },
            BillingAddress = new SalesChannelImportCustomerAddress
            {
                Firstname = order.Billing.Firstname,
                Lastname = order.Billing.Lastname,
                CompanyName = order.Billing.Company,
                Street = order.Billing.Street,
                City = order.Billing.City,
                Zip = order.Billing.Zip,
                Country = order.Billing.Country,
                Phone = order.Billing.Phone,
            },
            ShippingAddress = new SalesChannelImportCustomerAddress
            {
                Firstname = order.Shipping.Firstname,
                Lastname = order.Shipping.Lastname,
                CompanyName = order.Shipping.Company,
                Street = order.Shipping.Street,
                City = order.Shipping.City,
                Zip = order.Shipping.Zip,
                Country = order.Shipping.Country,
            },
            SalesItems = order.Items.Select(item => new SalesChannelImportSalesItem
            {
                Name = item.Name,
                Sku = item.Sku,
                Quantity = item.Quantity,
                // Per-unit price after discounts — what the REST API reports as the line item price.
                Price = item.Quantity > 0 ? Math.Round((item.LineTotal ?? 0m) / (decimal)item.Quantity, 4) : 0m,
                TaxRate = ComputeLineTaxRate(item.LineSubtotal, item.LineSubtotalTax),
            }).ToList(),
        };
    }

    // Both order stores prefix statuses with "wc-" ("wc-processing"); normalize before mapping.
    private static string StripStatusPrefix(string status) =>
        status.StartsWith("wc-", StringComparison.OrdinalIgnoreCase) ? status[3..] : status;

    private static SalesStatus MapSalesStatus(string salesStatus) => salesStatus switch
    {
        "pending" => SalesStatus.Pending,
        "processing" => SalesStatus.Processing,
        "on-hold" => SalesStatus.OnHold,
        "completed" => SalesStatus.Completed,
        "cancelled" => SalesStatus.Cancelled,
        "refunded" => SalesStatus.Refunded,
        "failed" => SalesStatus.Failed,
        _ => SalesStatus.Unknown,
    };

    private static PaymentStatus MapPaymentStatus(string status, bool isPaid)
    {
        if (isPaid)
        {
            return PaymentStatus.CompletelyPaid;
        }
        return status switch
        {
            "completed" or "processing" => PaymentStatus.CompletelyPaid,
            "refunded" => PaymentStatus.ReCrediting,
            _ => PaymentStatus.Invoiced,
        };
    }

    private static double ComputeLineTaxRate(decimal? subtotal, decimal? subtotalTax)
    {
        var lineSubtotal = subtotal ?? 0m;
        var lineSubtotalTax = subtotalTax ?? 0m;
        if (lineSubtotal <= 0m || lineSubtotalTax <= 0m)
        {
            return 0;
        }
        return (double)Math.Round(lineSubtotalTax / lineSubtotal * 100m, 0);
    }

    // ---------------------------------------------------------------------------------------------
    // Customer import
    // ---------------------------------------------------------------------------------------------

    public override async Task<SyncResult> ImportCustomersAsync(SalesChannelContext context)
    {
        Db db;
        try
        {
            db = Prepare(context);
        }
        catch (Exception ex)
        {
            return SyncResult.Failed(ex.Message);
        }

        var processed = 0;
        var failed = 0;

        try
        {
            await using var connection = await OpenAsync(db, context.CancellationToken);
            var progress = new ProgressThrottle(context);
            var runStart = DateTime.UtcNow;

            // Same page-cursor resume semantics as the REST connector (offset paging over the
            // immutable user id order): a time-boxed run continues where the last one stopped, a
            // failed customer freezes the cursor so it is retried.
            var startPage = context.SalesChannel.CustomerImportPageCursor + 1;
            var reachedEnd = false;
            var frozen = false;

            for (var page = startPage; page <= MaxPages; page++)
            {
                context.CancellationToken.ThrowIfCancellationRequested();

                var batch = await LoadCustomerPageAsync(connection, db, page, context.CancellationToken);
                if (batch.Count == 0)
                {
                    reachedEnd = true;
                    break;
                }

                foreach (var customer in batch)
                {
                    try
                    {
                        await _customerImportRepository.ImportOrUpdateFromSalesChannel(context.SalesChannel, customer);
                        processed++;
                    }
                    catch (Exception ex)
                    {
                        failed++;
                        frozen = true;
                        _logger.LogError(ex, "WooCommerce DB customer import failed for {Id}", customer.RemoteCustomerId);
                    }
                }

                await progress.MaybeReportAsync(processed, failed);
                _logger.LogInformation("WooCommerce DB customer import page {Page}: {Processed} imported, {Failed} failed so far", page, processed, failed);

                if (!frozen)
                {
                    context.SalesChannel.CustomerImportPageCursor = page;
                }

                if (batch.Count < PageSize)
                {
                    reachedEnd = true;
                    break;
                }
                if (DateTime.UtcNow - runStart >= MaxBackfillRunDuration)
                {
                    break;
                }
            }

            if (reachedEnd && !frozen)
            {
                context.SalesChannel.InitialCustomerImportCompleted = true;
                context.SalesChannel.CustomerImportPageCursor = 0;
            }
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            return processed > 0 ? new SyncResult(processed, failed + 1) : SyncResult.Failed(ex.Message);
        }

        return new SyncResult(processed, failed);
    }

    private static async Task<List<SalesChannelImportCustomer>> LoadCustomerPageAsync(
        MySqlConnection connection, Db db, int page, CancellationToken cancellationToken)
    {
        var users = new List<(ulong Id, string Email, DateTime Registered)>();
        await using (var cmd = connection.CreateCommand())
        {
            // The role lives serialized inside the capabilities usermeta; its key carries the same
            // table prefix as the tables ('wp_capabilities'). This matches what the REST /customers
            // endpoint returns by default: users with the 'customer' role.
            cmd.CommandText = $"""
                SELECT u.ID, u.user_email, u.user_registered
                FROM {db.Prefix}users u
                JOIN {db.Prefix}usermeta cap ON cap.user_id = u.ID AND cap.meta_key = @capKey
                WHERE cap.meta_value LIKE @customerRole
                ORDER BY u.ID
                LIMIT @pageSize OFFSET @offset
                """;
            cmd.Parameters.AddWithValue("@capKey", db.Prefix + "capabilities");
            cmd.Parameters.AddWithValue("@customerRole", "%\"customer\"%");
            cmd.Parameters.AddWithValue("@pageSize", PageSize);
            cmd.Parameters.AddWithValue("@offset", (page - 1) * PageSize);

            await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
            while (await reader.ReadAsync(cancellationToken))
            {
                users.Add((
                    ToUInt64(reader.GetValue(0)),
                    AsString(reader.GetValue(1)),
                    ToUtc(AsNullableDateTime(reader.GetValue(2)))));
            }
        }

        if (users.Count == 0)
        {
            return [];
        }

        var metaByUser = new Dictionary<ulong, Dictionary<string, string>>();
        await using (var cmd = connection.CreateCommand())
        {
            var inList = ParamList(cmd, "uid", users.Select(u => u.Id).ToList());
            cmd.CommandText = $"""
                SELECT user_id, meta_key, meta_value
                FROM {db.Prefix}usermeta
                WHERE user_id IN ({inList}) AND meta_key IN (
                    'first_name', 'last_name',
                    'billing_first_name', 'billing_last_name', 'billing_company', 'billing_address_1',
                    'billing_city', 'billing_postcode', 'billing_country', 'billing_phone', 'billing_email',
                    'shipping_first_name', 'shipping_last_name', 'shipping_company', 'shipping_address_1',
                    'shipping_city', 'shipping_postcode', 'shipping_country')
                """;

            await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
            while (await reader.ReadAsync(cancellationToken))
            {
                var userId = ToUInt64(reader.GetValue(0));
                if (!metaByUser.TryGetValue(userId, out var meta))
                {
                    metaByUser[userId] = meta = new Dictionary<string, string>(StringComparer.Ordinal);
                }
                meta[AsString(reader.GetValue(1))] = AsString(reader.GetValue(2));
            }
        }

        return users.Select(user =>
        {
            var meta = metaByUser.GetValueOrDefault(user.Id) ?? [];
            string? Get(string key) => meta.GetValueOrDefault(key) is { Length: > 0 } value ? value : null;

            return new SalesChannelImportCustomer
            {
                RemoteCustomerId = user.Id.ToString(CultureInfo.InvariantCulture),
                Firstname = Get("first_name") ?? Get("billing_first_name") ?? string.Empty,
                Lastname = Get("last_name") ?? Get("billing_last_name") ?? string.Empty,
                CompanyName = Get("billing_company") ?? string.Empty,
                Email = user.Email.Length > 0 ? user.Email : Get("billing_email") ?? string.Empty,
                Phone = Get("billing_phone") ?? string.Empty,
                CustomerStatus = CustomerStatus.Active,
                DateEnrollment = user.Registered,
                BillingAddress = new SalesChannelImportCustomerAddress
                {
                    Firstname = Get("billing_first_name") ?? string.Empty,
                    Lastname = Get("billing_last_name") ?? string.Empty,
                    CompanyName = Get("billing_company") ?? string.Empty,
                    Street = Get("billing_address_1") ?? string.Empty,
                    City = Get("billing_city") ?? string.Empty,
                    Zip = Get("billing_postcode") ?? string.Empty,
                    Country = Get("billing_country") ?? string.Empty,
                    Phone = Get("billing_phone") ?? string.Empty,
                },
                ShippingAddress = new SalesChannelImportCustomerAddress
                {
                    Firstname = Get("shipping_first_name") ?? string.Empty,
                    Lastname = Get("shipping_last_name") ?? string.Empty,
                    CompanyName = Get("shipping_company") ?? string.Empty,
                    Street = Get("shipping_address_1") ?? string.Empty,
                    City = Get("shipping_city") ?? string.Empty,
                    Zip = Get("shipping_postcode") ?? string.Empty,
                    Country = Get("shipping_country") ?? string.Empty,
                },
            };
        }).ToList();
    }

    // ---------------------------------------------------------------------------------------------
    // Stock import (mirror)
    // ---------------------------------------------------------------------------------------------

    /// <summary>
    /// Mirrors the shop's stock levels into the channel's linked warehouse. Unlike the REST
    /// connector this always sweeps the full catalogue: one indexed query over the meta lookup
    /// table is cheap, and it sidesteps the REST mode's blind spot that order-driven stock changes
    /// do not bump a product's modified timestamp (and would be skipped by an incremental filter).
    /// </summary>
    public override async Task<SyncResult> ImportStockAsync(SalesChannelContext context)
    {
        Db db;
        try
        {
            db = Prepare(context);
        }
        catch (Exception ex)
        {
            return SyncResult.Failed(ex.Message);
        }

        var processed = 0;
        var failed = 0;
        var skipped = 0;

        try
        {
            await using var connection = await OpenAsync(db, context.CancellationToken);
            var progress = new ProgressThrottle(context);

            await using var cmd = new MySqlCommand($"""
                SELECT l.product_id, l.sku, l.stock_quantity
                FROM {db.Prefix}wc_product_meta_lookup l
                JOIN {db.Prefix}posts p ON p.ID = l.product_id
                WHERE l.stock_quantity IS NOT NULL
                  AND p.post_status = 'publish'
                  AND p.post_type IN ('product', 'product_variation')
                ORDER BY l.product_id
                """, connection);

            // Rows stream from MySQL while each level is booked into our own DB (separate
            // connection), so no second MySQL command runs while this reader is open.
            await using var reader = await cmd.ExecuteReaderAsync(context.CancellationToken);
            while (await reader.ReadAsync(context.CancellationToken))
            {
                context.CancellationToken.ThrowIfCancellationRequested();

                var remoteProductId = ToUInt64(reader.GetValue(0)).ToString(CultureInfo.InvariantCulture);
                var sku = AsNullableString(reader.GetValue(1));
                var quantity = AsNullableDouble(reader.GetValue(2)) ?? 0;

                try
                {
                    var outcome = await _stockImportRepository.ApplyRemoteStockAsync(
                        context.SalesChannel, remoteProductId, sku, quantity, context.CancellationToken);

                    switch (outcome)
                    {
                        case StockImportOutcome.Applied:
                        case StockImportOutcome.Unchanged:
                            processed++;
                            break;
                        case StockImportOutcome.NoWarehouse:
                            // Without a warehouse nothing in this run can be mirrored.
                            throw new InvalidOperationException("Channel has no linked warehouse for the stock mirror");
                        default:
                            skipped++;
                            break;
                    }
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (InvalidOperationException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    failed++;
                    _logger.LogError(ex, "Stock mirror failed for remote product {RemoteId}", remoteProductId);
                }

                await progress.MaybeReportAsync(processed, failed);
            }

            _logger.LogInformation("WooCommerce DB stock mirror: {Processed} mirrored, {Skipped} unlinked, {Failed} failed", processed, skipped, failed);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "WooCommerce DB stock mirror aborted");
            return processed > 0 ? new SyncResult(processed, failed + 1) : SyncResult.Failed(ex.Message);
        }

        return new SyncResult(processed, failed);
    }

    // ---------------------------------------------------------------------------------------------
    // Stock / price export (direct writes)
    // ---------------------------------------------------------------------------------------------

    public override async Task<ExportResult> UpdateStockAsync(SalesChannelContext context, StockUpdatePayload payload)
    {
        if (string.IsNullOrEmpty(payload.RemoteProductId) || !ulong.TryParse(payload.RemoteProductId, out var productId))
        {
            return ExportResult.Fail("WooCommerce product id (numeric RemoteProductId) is required for stock updates");
        }

        try
        {
            var db = Prepare(context);
            await using var connection = await OpenAsync(db, context.CancellationToken);
            await using var transaction = await connection.BeginTransactionAsync(context.CancellationToken);

            // Write both places WooCommerce reads stock from: the canonical postmeta and the
            // denormalized meta lookup row.
            var stockStatus = payload.Quantity > 0 ? "instock" : "outofstock";
            await UpsertPostMetaAsync(connection, transaction, db, productId, "_manage_stock", "yes", context.CancellationToken);
            await UpsertPostMetaAsync(connection, transaction, db, productId, "_stock", payload.Quantity.ToString(CultureInfo.InvariantCulture), context.CancellationToken);
            await UpsertPostMetaAsync(connection, transaction, db, productId, "_stock_status", stockStatus, context.CancellationToken);

            await using (var cmd = new MySqlCommand(
                $"UPDATE {db.Prefix}wc_product_meta_lookup SET stock_quantity = @quantity, stock_status = @status WHERE product_id = @id",
                connection, transaction))
            {
                cmd.Parameters.AddWithValue("@quantity", (double)payload.Quantity);
                cmd.Parameters.AddWithValue("@status", stockStatus);
                cmd.Parameters.AddWithValue("@id", productId);
                await cmd.ExecuteNonQueryAsync(context.CancellationToken);
            }

            await transaction.CommitAsync(context.CancellationToken);
            return ExportResult.Ok(payload.RemoteProductId);
        }
        catch (Exception ex)
        {
            return ExportResult.Fail(ex.Message);
        }
    }

    public override async Task<ExportResult> UpdatePriceAsync(SalesChannelContext context, PriceUpdatePayload payload)
    {
        if (string.IsNullOrEmpty(payload.RemoteProductId) || !ulong.TryParse(payload.RemoteProductId, out var productId))
        {
            return ExportResult.Fail("WooCommerce product id (numeric RemoteProductId) is required for price updates");
        }

        try
        {
            var db = Prepare(context);
            await using var connection = await OpenAsync(db, context.CancellationToken);
            await using var transaction = await connection.BeginTransactionAsync(context.CancellationToken);

            var price = payload.Price.ToString(CultureInfo.InvariantCulture);
            await UpsertPostMetaAsync(connection, transaction, db, productId, "_regular_price", price, context.CancellationToken);
            await UpsertPostMetaAsync(connection, transaction, db, productId, "_price", price, context.CancellationToken);

            await using (var cmd = new MySqlCommand(
                $"UPDATE {db.Prefix}wc_product_meta_lookup SET min_price = @price, max_price = @price WHERE product_id = @id",
                connection, transaction))
            {
                cmd.Parameters.AddWithValue("@price", payload.Price);
                cmd.Parameters.AddWithValue("@id", productId);
                await cmd.ExecuteNonQueryAsync(context.CancellationToken);
            }

            // A variation price is served from the parent's cached price range — drop that transient
            // so the shop rebuilds it on the next page view instead of showing the old price.
            if (!string.IsNullOrEmpty(payload.ParentRemoteProductId) && ulong.TryParse(payload.ParentRemoteProductId, out var parentId))
            {
                await using var cmd = new MySqlCommand(
                    $"DELETE FROM {db.Prefix}options WHERE option_name IN (@transient, @transientTimeout)",
                    connection, transaction);
                cmd.Parameters.AddWithValue("@transient", $"_transient_wc_var_prices_{parentId}");
                cmd.Parameters.AddWithValue("@transientTimeout", $"_transient_timeout_wc_var_prices_{parentId}");
                await cmd.ExecuteNonQueryAsync(context.CancellationToken);
            }

            await transaction.CommitAsync(context.CancellationToken);
            return ExportResult.Ok(payload.RemoteProductId);
        }
        catch (Exception ex)
        {
            return ExportResult.Fail(ex.Message);
        }
    }

    /// <summary>
    /// postmeta has no unique key on (post_id, meta_key), so upsert is update-then-insert. An
    /// existing duplicate set is updated as a whole — the same rows WordPress would coalesce.
    /// </summary>
    private static async Task UpsertPostMetaAsync(
        MySqlConnection connection, MySqlTransaction transaction, Db db, ulong postId, string metaKey, string metaValue, CancellationToken cancellationToken)
    {
        await using (var update = new MySqlCommand(
            $"UPDATE {db.Prefix}postmeta SET meta_value = @value WHERE post_id = @id AND meta_key = @key",
            connection, transaction))
        {
            update.Parameters.AddWithValue("@value", metaValue);
            update.Parameters.AddWithValue("@id", postId);
            update.Parameters.AddWithValue("@key", metaKey);
            if (await update.ExecuteNonQueryAsync(cancellationToken) > 0)
            {
                return;
            }
        }

        await using var insert = new MySqlCommand(
            $"INSERT INTO {db.Prefix}postmeta (post_id, meta_key, meta_value) VALUES (@id, @key, @value)",
            connection, transaction);
        insert.Parameters.AddWithValue("@id", postId);
        insert.Parameters.AddWithValue("@key", metaKey);
        insert.Parameters.AddWithValue("@value", metaValue);
        await insert.ExecuteNonQueryAsync(cancellationToken);
    }

    // ---------------------------------------------------------------------------------------------
    // Row/value helpers
    // ---------------------------------------------------------------------------------------------

    /// <summary>Appends one parameter per value and returns the matching "@p0, @p1, ..." list.</summary>
    private static string ParamList<T>(MySqlCommand cmd, string prefix, IReadOnlyList<T> values)
    {
        var names = new string[values.Count];
        for (var i = 0; i < values.Count; i++)
        {
            names[i] = $"@{prefix}{i}";
            cmd.Parameters.AddWithValue(names[i], values[i]);
        }
        return string.Join(", ", names);
    }

    private static ulong ToUInt64(object value) => value is DBNull ? 0 : Convert.ToUInt64(value, CultureInfo.InvariantCulture);

    private static string AsString(object value) => value is DBNull or null ? string.Empty : Convert.ToString(value, CultureInfo.InvariantCulture) ?? string.Empty;

    private static string? AsNullableString(object value)
    {
        var text = AsString(value);
        return text.Length == 0 ? null : text;
    }

    private static decimal? AsNullableDecimal(object value) =>
        value is DBNull or null ? null : Convert.ToDecimal(value, CultureInfo.InvariantCulture);

    private static double? AsNullableDouble(object value) =>
        value is DBNull or null ? null : Convert.ToDouble(value, CultureInfo.InvariantCulture);

    private static DateTime? AsNullableDateTime(object value) =>
        value is DBNull or null ? null : Convert.ToDateTime(value, CultureInfo.InvariantCulture);

    private static decimal? ParseDecimal(string? value) =>
        decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsed) ? parsed : null;

    // MySQL DATETIME columns come back with Kind=Unspecified; the *_gmt columns are UTC wall-clock,
    // so stamp them accordingly (Npgsql only writes offset-0 values to 'timestamptz').
    private static DateTime ToUtc(DateTime? value) =>
        value.HasValue ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) : DateTime.UtcNow;
}

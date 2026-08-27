using System.Text.Json;
using asERP.SalesChannels.Connectors.Amazon;
using asERP.SalesChannels.Connectors.Shopware6;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// Pins the delta-filter building blocks of the incremental imports: Amazon's mutually exclusive
/// CreatedAfter/LastUpdatedAfter parameters (incl. the SP-API "must lie in the past" clamp) and
/// Shopware's created-OR-updated filter (updatedAt is NULL until an entity's first update — a plain
/// updatedAt range would silently drop never-edited rows).
/// </summary>
public class ConnectorDeltaFilterTests
{
    [Fact]
    public void Amazon_WithoutWatermark_UsesCreatedAfterSeedWindow()
    {
        var filter = AmazonConnector.BuildSalesDateFilter(null);

        Assert.StartsWith("&CreatedAfter=", filter);
        Assert.DoesNotContain("LastUpdatedAfter", filter);
    }

    [Fact]
    public void Amazon_WithWatermark_UsesLastUpdatedAfter()
    {
        var since = DateTime.UtcNow.AddDays(-2);

        var filter = AmazonConnector.BuildSalesDateFilter(since);

        Assert.StartsWith("&LastUpdatedAfter=", filter);
        Assert.DoesNotContain("CreatedAfter", filter);
        Assert.Contains(since.ToString("yyyy-MM-dd"), filter);
    }

    [Fact]
    public void Amazon_WatermarkNearNow_IsClampedIntoThePast()
    {
        // SP-API rejects LastUpdatedAfter values within the last couple of minutes.
        var filter = AmazonConnector.BuildSalesDateFilter(DateTime.UtcNow);

        var value = DateTime.Parse(filter["&LastUpdatedAfter=".Length..], null, System.Globalization.DateTimeStyles.RoundtripKind);
        Assert.True(value <= DateTime.UtcNow.AddMinutes(-4), "LastUpdatedAfter must be clamped a few minutes into the past");
    }

    [Fact]
    public void Shopware_CreatedOrUpdatedFilter_CoversBothTimestamps()
    {
        var since = new DateTime(2026, 08, 20, 10, 30, 0, DateTimeKind.Utc);

        var json = JsonSerializer.Serialize(Shopware6Connector.BuildCreatedOrUpdatedSinceFilter(since));
        using var doc = JsonDocument.Parse(json);

        Assert.Equal("multi", doc.RootElement.GetProperty("type").GetString());
        Assert.Equal("or", doc.RootElement.GetProperty("operator").GetString());

        var queries = doc.RootElement.GetProperty("queries").EnumerateArray().ToList();
        Assert.Equal(2, queries.Count);
        Assert.Equal("createdAt", queries[0].GetProperty("field").GetString());
        Assert.Equal("updatedAt", queries[1].GetProperty("field").GetString());
        Assert.All(queries, q =>
            Assert.Equal("2026-08-20T10:30:00+00:00", q.GetProperty("parameters").GetProperty("gte").GetString()));
    }
}

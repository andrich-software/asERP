using System.Linq.Dynamic.Core;
using asERP.Application.Exceptions;
using asERP.Application.Specifications.Base;
using asERP.Domain.Entities.Common;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Extensions;

public static class QueryableExtensions
{
    /// <summary>Upper bound on page size so a client cannot dump an entire table in one request.</summary>
    public const int MaxPageSize = 200;

    /// <summary>
    /// Applies a client-supplied dynamic ordering (System.Linq.Dynamic.Core) restricted to an
    /// allow-list of sortable property names. Fields not on the allow-list are dropped instead of
    /// being passed to the parser, which prevents both ordering by non-DTO/secret columns and the
    /// <c>ParseException</c>-to-500 that malformed input would otherwise cause. Each term may carry
    /// an <c>asc</c>/<c>desc</c> direction. When nothing valid remains, the query is returned unchanged.
    /// </summary>
    /// <param name="allowedFields">Sortable property names, matched case-insensitively.</param>
    public static IQueryable<T> ApplySafeOrdering<T>(this IQueryable<T> query, IEnumerable<string>? sortBy, ISet<string> allowedFields)
    {
        if (sortBy == null)
        {
            return query;
        }

        var clauses = new List<string>();
        foreach (var raw in sortBy)
        {
            if (string.IsNullOrWhiteSpace(raw))
            {
                continue;
            }

            var parts = raw.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var field = parts[0];

            // Resolve against the allow-list case-insensitively but use the canonical casing.
            var allowed = allowedFields.FirstOrDefault(f => string.Equals(f, field, StringComparison.OrdinalIgnoreCase));
            if (allowed == null)
            {
                continue;
            }

            var direction = parts.Length > 1 && parts[1].StartsWith("desc", StringComparison.OrdinalIgnoreCase)
                ? "desc"
                : "asc";

            clauses.Add($"{allowed} {direction}");
        }

        return clauses.Count == 0 ? query : query.OrderBy(string.Join(",", clauses));
    }

    public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize, CancellationToken cancellationToken = default) where T : class
    {
        if (source == null) throw new SourceNullException("source is null - pagination is aborted");
        pageNumber = pageNumber < 0 ? 0 : pageNumber;
        // Clamp to [1, MaxPageSize]: 0/negative would throw on Take(), huge values would dump the table.
        pageSize = pageSize <= 0 ? 10 : Math.Min(pageSize, MaxPageSize);
        int count = await source.CountAsync(cancellationToken);
        List<T> items = await source.Skip(pageNumber * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        return PaginatedResult<T>.Success(items, count, pageNumber, pageSize);
    }

    public static IQueryable<T> Specify<T>(this IQueryable<T> query, ISpecification<T> spec) where T : class, IBaseEntity
    {
        var queryableResultWithIncludes = spec.Includes
            .Aggregate(query,
                (current, include) => current.Include(include));
        var secondaryResult = spec.IncludeStrings
            .Aggregate(queryableResultWithIncludes,
                (current, include) => current.Include(include));
        return secondaryResult.Where(spec.Criteria);
    }

    public static IQueryable<T> Specify<T>(this IQueryable<T> query, ISpecificationWithoutTenant<T> spec) where T : class, IBaseEntityWithoutTenant
    {
        var queryableResultWithIncludes = spec.Includes
            .Aggregate(query,
                (current, include) => current.Include(include));
        var secondaryResult = spec.IncludeStrings
            .Aggregate(queryableResultWithIncludes,
                (current, include) => current.Include(include));
        return secondaryResult.Where(spec.Criteria);
    }
}

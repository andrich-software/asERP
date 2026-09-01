using Microsoft.AspNetCore.Http.Extensions;

namespace asERP.Server.Middleware;

/// <summary>
/// Accepts the deprecated <c>salesBy</c> list-query parameter as an alias for <c>sortBy</c>.
/// The parameter was renamed because it sorts and never filtered by sales; third-party API clients
/// still sending the old name keep working. Sits in one place rather than in all ~29 list actions
/// so the whole deprecation can be dropped by deleting this middleware and its registration.
/// </summary>
public class LegacySortParameterMiddleware(RequestDelegate next)
{
    private const string DeprecatedName = "salesBy";
    private const string CurrentName = "sortBy";

    public async Task InvokeAsync(HttpContext context)
    {
        // When a caller sends both, sortBy wins and the stale alias is dropped.
        if (context.Request.Query.ContainsKey(DeprecatedName) &&
            !context.Request.Query.ContainsKey(CurrentName))
        {
            var rewritten = new QueryBuilder();
            foreach (var parameter in context.Request.Query)
            {
                var name = parameter.Key == DeprecatedName ? CurrentName : parameter.Key;
                foreach (var value in parameter.Value)
                {
                    rewritten.Add(name, value ?? string.Empty);
                }
            }

            context.Request.QueryString = rewritten.ToQueryString();
        }

        await next(context);
    }
}

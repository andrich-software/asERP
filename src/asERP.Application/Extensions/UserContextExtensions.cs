using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace asERP.Application.Extensions;

public static class UserContextExtensions
{
    public static string? GetUserId(this HttpContext? context)
    {
        if (context == null)
        {
            return null;
        }

        var user = context.User;
        var userId = user?.FindFirst("uid")?.Value
                     ?? user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return string.IsNullOrWhiteSpace(userId) ? null : userId;
    }
}

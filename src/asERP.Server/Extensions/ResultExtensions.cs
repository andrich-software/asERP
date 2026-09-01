using asERP.Domain.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Extensions;

/// <summary>
/// Turns a <see cref="Result"/> into an HTTP response. This is the **only** place where the
/// semantic outcome of a handler becomes a status code — nothing below <c>asERP.Server</c> knows
/// about HTTP.
/// </summary>
public static class ResultExtensions
{
    public static ActionResult ToActionResult<T>(this Result<T> result) => ToResponse(result, result);

    public static ActionResult ToActionResult(this Domain.Wrapper.IResult result) => ToResponse(result, result);

    private static ActionResult ToResponse(Domain.Wrapper.IResult result, object payload)
    {
        var statusCode = ToHttpStatusCode(result);

        return statusCode == StatusCodes.Status204NoContent
            ? new StatusCodeResult(statusCode)
            : new ObjectResult(payload) { StatusCode = statusCode };
    }

    /// <summary>
    /// The single ErrorType/ResultStatus to HTTP mapping. Public for the few endpoints that answer
    /// with a hand-built body but still take their status from the handler's result.
    /// </summary>
    public static int ToHttpStatusCode(this Domain.Wrapper.IResult result)
    {
        if (result.Succeeded)
        {
            return result.Status switch
            {
                ResultStatus.Created => StatusCodes.Status201Created,
                ResultStatus.NoContent => StatusCodes.Status204NoContent,
                _ => StatusCodes.Status200OK
            };
        }

        return result.Error?.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            ErrorType.Forbidden => StatusCodes.Status403Forbidden,
            ErrorType.Unexpected => StatusCodes.Status500InternalServerError,
            // Validation, and any failure that forgot to attach an error object
            _ => StatusCodes.Status400BadRequest
        };
    }

    /// <summary>
    /// Converts a ProblemDetailsResult to an ActionResult that follows RFC 7807.
    /// </summary>
    /// <param name="result">The problem details result to convert</param>
    /// <returns>An ObjectResult configured for RFC 7807 Problem Details format</returns>
    public static ActionResult ToActionResult(this ProblemDetailsResult result)
    {
        var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
        {
            Type = result.Type,
            Title = result.Title,
            Detail = result.Detail,
            Status = ToHttpStatusCode(result),
            Instance = result.Instance
        };

        // Add extensions if they exist
        if (result.Extensions != null)
        {
            foreach (var extension in result.Extensions)
            {
                problemDetails.Extensions[extension.Key] = extension.Value;
            }
        }

        return new ObjectResult(problemDetails)
        {
            StatusCode = ToHttpStatusCode(result),
            ContentTypes = { "application/problem+json" }
        };
    }

    /// <summary>
    /// Converts a generic ProblemDetailsResult to an ActionResult that follows RFC 7807.
    /// </summary>
    /// <typeparam name="T">The type of data contained in the result</typeparam>
    /// <param name="result">The problem details result to convert</param>
    /// <returns>An ObjectResult configured for RFC 7807 Problem Details format</returns>
    public static ActionResult ToActionResult<T>(this ProblemDetailsResult<T> result)
    {
        var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
        {
            Type = result.Type,
            Title = result.Title,
            Detail = result.Detail,
            Status = ToHttpStatusCode(result),
            Instance = result.Instance
        };

        // Add extensions if they exist
        if (result.Extensions != null)
        {
            foreach (var extension in result.Extensions)
            {
                problemDetails.Extensions[extension.Key] = extension.Value;
            }
        }

        // Add data if it exists and is not null
        if (result.Data != null)
        {
            problemDetails.Extensions["data"] = result.Data;
        }

        return new ObjectResult(problemDetails)
        {
            StatusCode = ToHttpStatusCode(result),
            ContentTypes = { "application/problem+json" }
        };
    }
}

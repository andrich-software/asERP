using System.Net;
using asERP.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asERP.Server;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problemDetails = new ProblemDetails();
        problemDetails.Instance = httpContext.Request.Path;

        if (exception is BaseException e)
        {
            httpContext.Response.StatusCode = (int)e.StatusCode;

            // Only echo the exception message to the client for client-error (4xx) statuses.
            // Server-error (5xx) messages can leak internal details (SQL/provider errors, paths,
            // token-endpoint failures) — mask them like an unknown exception and log the detail.
            if ((int)e.StatusCode >= 400 && (int)e.StatusCode < 500)
            {
                problemDetails.Title = e.Message;
            }
            else
            {
                logger.LogError(exception, "Server error at {Path}", httpContext.Request.Path);
                problemDetails.Title = "An internal server error occurred.";
            }
        }
        else if (exception is NotFoundException)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            problemDetails.Title = exception.Message;
        }
        else if (exception is DbUpdateConcurrencyException)
        {
            // Optimistic-concurrency conflict: the row was changed by another request between load
            // and save. Surface as 409 so the client can reload and retry instead of losing the edit.
            httpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
            problemDetails.Title = "The record was modified by another operation. Please reload and try again.";
        }
        else
        {
            logger.LogError(exception, "Unhandled exception at {Path}", httpContext.Request.Path);
            problemDetails.Title = "An internal server error occurred.";
        }
        logger.LogError("Exception response: {StatusCode} {Title}", problemDetails.Status, problemDetails.Title);
        problemDetails.Status = httpContext.Response.StatusCode;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken).ConfigureAwait(false);
        return true;
    }
}

public class BaseException : Exception
{
    public HttpStatusCode StatusCode { get; }
    public BaseException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        : base(message)
    {
        StatusCode = statusCode;
    }
}

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
        if (exception is ValidationException validationException)
        {
            await WriteValidationProblemAsync(httpContext, validationException, cancellationToken).ConfigureAwait(false);
            return true;
        }

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

    /// <summary>
    /// Renders a failed request validation as RFC 9457 problem details with the standard per-field
    /// <c>errors</c> dictionary. Logged as a warning, not an error: an invalid request is a client
    /// mistake, and a rejected form submission must not show up as a server fault.
    /// </summary>
    private async Task WriteValidationProblemAsync(HttpContext httpContext, ValidationException exception, CancellationToken cancellationToken)
    {
        logger.LogWarning("Validation failed at {Path}: {Errors}",
            httpContext.Request.Path,
            string.Join("; ", exception.ValidationErrors));

        var problemDetails = new ValidationProblemDetails(exception.Errors.ToDictionary(entry => entry.Key, entry => entry.Value))
        {
            Title = "One or more validation errors occurred.",
            Status = (int)HttpStatusCode.BadRequest,
            Instance = httpContext.Request.Path
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;
        await httpContext.Response
            .WriteAsJsonAsync(problemDetails, options: null, contentType: "application/problem+json", cancellationToken)
            .ConfigureAwait(false);
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

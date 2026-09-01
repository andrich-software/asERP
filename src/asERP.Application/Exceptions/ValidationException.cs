using FluentValidation.Results;

namespace asERP.Application.Exceptions;

/// <summary>
/// Thrown by the mediator's validation step when a request fails its FluentValidation rules.
/// Carries the failures grouped by property so the Server can emit an RFC 9457
/// <c>ValidationProblemDetails</c> with a per-field <c>errors</c> dictionary.
/// </summary>
public class ValidationException : Exception
{
    private const string DefaultMessage = "One or more validation errors occurred.";

    public ValidationException(string message) : base(message)
    {
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : base(DefaultMessage)
    {
        Errors = Group(failures);
    }

    public ValidationException(string message, ValidationResult validationResult) : base(message)
    {
        Errors = Group(validationResult.Errors);
    }

    /// <summary>
    /// Failure messages grouped by the property they belong to. Rules declared on the request as a
    /// whole (<c>RuleFor(x =&gt; x)</c>) have no property name; they are grouped under the empty key,
    /// matching how ASP.NET Core reports model-level errors.
    /// </summary>
    public IReadOnlyDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>(StringComparer.Ordinal);

    /// <summary>
    /// All messages as a flat list, for logging and non-HTTP consumers.
    /// </summary>
    public IReadOnlyList<string> ValidationErrors => Errors.SelectMany(entry => entry.Value).ToList();

    private static Dictionary<string, string[]> Group(IEnumerable<ValidationFailure> failures) =>
        failures
            .GroupBy(failure => failure.PropertyName ?? string.Empty, failure => failure.ErrorMessage)
            .ToDictionary(group => group.Key, group => group.Distinct().ToArray(), StringComparer.Ordinal);
}

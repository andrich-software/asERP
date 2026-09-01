namespace asERP.Domain.Wrapper;

/// <summary>
/// Outcome of a successful operation, independent of any transport. Failures are described by
/// <see cref="Error"/> instead.
/// </summary>
public enum ResultStatus
{
    /// <summary>The operation succeeded and (usually) carries data.</summary>
    Ok,

    /// <summary>The operation created a new entity; <c>Data</c> carries its id.</summary>
    Created,

    /// <summary>The operation succeeded and has nothing to return.</summary>
    NoContent
}

namespace asERP.Domain.Wrapper;

/// <summary>
/// Kind of failure a handler reports, independent of any transport. The Server maps these to HTTP
/// in exactly one place (<c>ToActionResult</c>); non-HTTP consumers — the sync orchestrator, the
/// export outbox, notification handlers — branch on them directly instead of on status codes.
/// </summary>
public enum ErrorType
{
    /// <summary>The request itself is malformed or violates a rule that needs no state to check.</summary>
    Validation,

    /// <summary>The addressed entity does not exist, or is invisible to the current tenant.</summary>
    NotFound,

    /// <summary>The request collides with existing state (duplicate key, concurrent modification).</summary>
    Conflict,

    /// <summary>No usable identity for the operation.</summary>
    Unauthorized,

    /// <summary>Identity is known but lacks permission.</summary>
    Forbidden,

    /// <summary>Anything the handler did not anticipate.</summary>
    Unexpected
}

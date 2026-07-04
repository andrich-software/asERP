namespace asERP.Domain.Enums;

/// <summary>
/// Severity of a persisted sales-channel synchronization log entry. Mirrors the subset of
/// log levels we capture (Debug/Verbose are dropped). Used both for storage and for the
/// "minimum level" filter in the Client's log explorer.
/// </summary>
public enum ChannelSyncLogLevel
{
    Debug = 0,
    Information = 1,
    Warning = 2,
    Error = 3,
    Critical = 4,
}

namespace asERP.SalesChannels;

/// <summary>
/// A failure that describes the <i>network</i> rather than the data: whether a host the tenant named
/// answered at all, and how it refused. Refused, filtered, unresolvable, a rejected TLS handshake and a
/// rejected login all belong here, and they must read the same to the caller — the tenant supplies the
/// host and the port, so a differentiated outcome is a port scanner and a credential oracle running from
/// the server's egress address. The counterpart, a remote system that answered and rejected the payload
/// (a bad SKU, a validation error, a missing category), describes the data, tells nothing about topology
/// and stays verbatim.
///
/// The split is decided where the exception is born — the connectors catch <c>Exception</c> almost
/// everywhere and could not tell the two apart afterwards. Whoever dials wraps the failure here, so
/// <see cref="Exception.Message"/> is already the constant the caller may see, and every
/// <c>catch (Exception ex) =&gt; SyncResult.Failed(ex.Message)</c> site downstream is safe without
/// knowing about any of this.
///
/// <see cref="Exception.InnerException"/> keeps the real failure for the server log. It must not reach
/// a tenant-visible surface: <c>ChannelSyncRun.ErrorSummary</c>, and the captured
/// <c>ChannelSyncLog.Exception</c> that the sync-log endpoint serves.
/// </summary>
public sealed class ChannelTransportException : Exception
{
    /// <param name="inner">
    /// The real failure, kept for the server log. Null where the outcome has no exception of its own —
    /// a DNS lookup that simply returns an address we refuse to dial raises nothing to attach, and the
    /// marker alone is what keeps that outcome out of the tenant-readable sync log.
    /// </param>
    public ChannelTransportException(string callerSafeMessage, Exception? inner = null)
        : base(callerSafeMessage, inner)
    {
    }

    /// <summary>
    /// True when <paramref name="exception"/> is, or wraps, a transport failure — so the detail behind
    /// it is the operator's and not the caller's. Only the deliberate wrap counts: a raw provider
    /// exception raised <i>after</i> a connection was established (a missing table, a broken query) is
    /// not an oracle, because the host has already proven reachable, and keeps its diagnostic text.
    /// </summary>
    public static bool Describes(Exception? exception)
    {
        for (var current = exception; current is not null; current = current.InnerException)
        {
            if (current is ChannelTransportException)
            {
                return true;
            }

            if (current is AggregateException aggregate
                && aggregate.InnerExceptions.Any(Describes))
            {
                return true;
            }
        }

        return false;
    }
}

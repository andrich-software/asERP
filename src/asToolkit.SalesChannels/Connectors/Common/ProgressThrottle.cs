using asToolkit.SalesChannels.Abstractions;

namespace asToolkit.SalesChannels.Connectors.Common;

/// <summary>
/// Throttles mid-run progress checkpoints. Connectors call <see cref="MaybeReportAsync"/> after each
/// page/batch; it forwards to <see cref="SalesChannelContext.ReportProgressAsync"/> at most once per
/// <see cref="CheckpointInterval"/> — frequent enough that the Sync-Status dashboard moves visibly,
/// sparse enough that a fast-paging import does not hammer the DB with a write per page.
/// Single-threaded per run (pages are walked sequentially), so the non-locked last-write timestamp is
/// safe. When one run spans several passes (e.g. the sales import's recent + backfill passes, each
/// counting from 0), <see cref="AddCompletedPass"/> rolls a finished pass's totals into the base so
/// the reported count keeps climbing instead of resetting between passes.
/// </summary>
internal sealed class ProgressThrottle
{
    private static readonly TimeSpan CheckpointInterval = TimeSpan.FromSeconds(10);

    private readonly SalesChannelContext _context;
    private DateTime _lastReport = DateTime.UtcNow;
    private int _baseProcessed;
    private int _baseFailed;

    public ProgressThrottle(SalesChannelContext context) => _context = context;

    /// <summary>Folds a completed pass's totals into the running base for subsequent passes.</summary>
    public void AddCompletedPass(int processed, int failed)
    {
        _baseProcessed += processed;
        _baseFailed += failed;
    }

    public async Task MaybeReportAsync(int processed, int failed)
    {
        if (_context.ReportProgressAsync is null)
        {
            return;
        }

        var now = DateTime.UtcNow;
        if (now - _lastReport < CheckpointInterval)
        {
            return;
        }

        _lastReport = now;
        await _context.ReportProgressAsync(_baseProcessed + processed, _baseFailed + failed, _context.CancellationToken);
    }
}

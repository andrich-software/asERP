using Asp.Versioning;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Contracts.Services;
using asToolkit.Application.Features.SalesChannel.Commands.SalesChannelCreate;
using asToolkit.Application.Features.SalesChannel.Commands.SalesChannelDelete;
using asToolkit.Application.Features.SalesChannel.Commands.SalesChannelUpdate;
using asToolkit.Application.Features.SalesChannel.Queries.SalesChannelDetail;
using asToolkit.Application.Features.SalesChannel.Queries.SalesChannelList;
using asToolkit.Domain.Dtos.SalesChannel;
using asToolkit.Domain.Dtos.WebAnalytics;
using asToolkit.Domain.Entities;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Services;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;
using asToolkit.Persistence.DatabaseContext;
using asToolkit.SalesChannels.Abstractions;
using asToolkit.SalesChannels.Orchestration;
using asToolkit.Server.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asToolkit.Server.Controllers.Api.V1;

[ApiController]
[Authorize]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/[controller]")]
public class SalesChannelsController(
    IMediator mediator,
    ISalesChannelRepository salesChannelRepository,
    SyncDispatcher syncDispatcher,
    SalesChannelContextFactory contextFactory,
    ISalesChannelConnectorRegistry connectorRegistry,
    ITenantContext tenantContext,
    ApplicationDbContext dbContext) : ControllerBase
{
    /// <summary>
    /// Loads a channel scoped to the current tenant. The global query filter is the primary guard, but
    /// it is disabled in the Testing environment and bypassed by some paths — so tracking mutations filter
    /// the tenant explicitly here (defense in depth), matching the repository pattern.
    /// </summary>
    private Task<SalesChannel?> FindTenantChannelAsync(Guid id, CancellationToken cancellationToken)
    {
        var currentTenantId = tenantContext.GetCurrentTenantId();
        return dbContext.SalesChannel
            .FirstOrDefaultAsync(s => s.Id == id && (s.TenantId == null || s.TenantId == currentTenantId), cancellationToken);
    }

    // GET: api/v1/<SalesChannelsController>
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<SalesChannelListDto>>> GetAll(int pageNumber = 0, int pageSize = 10, string searchString = "", string salesBy = "")
    {
        if (string.IsNullOrEmpty(salesBy))
        {
            salesBy = "DateCreated Descending";
        }

        var response = await mediator.Send(new SalesChannelListQuery(pageNumber, pageSize, searchString, salesBy));
        return StatusCode((int)response.StatusCode, response);
    }

    // GET: api/v1/<SalesChannelsController>/5
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SalesChannelDetailDto>> GetDetails(Guid id)
    {
        var response = await mediator.Send(new SalesChannelDetailQuery { Id = id });
        return StatusCode((int)response.StatusCode, response);
    }

    // POST: api/v1/<SalesChannelsController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> Create(SalesChannelCreateCommand salesChannelCreateCommand)
    {
        var response = await mediator.Send(salesChannelCreateCommand);
        return StatusCode((int)response.StatusCode, response);
    }

    // PUT: api/v1/<SalesChannelsController>/5
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update(Guid id, SalesChannelUpdateCommand salesChannelUpdateCommand)
    {
        // Validate ID consistency between URL and request body
        if (salesChannelUpdateCommand.Id != Guid.Empty && salesChannelUpdateCommand.Id != id)
        {
            var errorResult = new Result<Guid>
            {
                Succeeded = false,
                StatusCode = ResultStatusCode.BadRequest,
                Messages = { "ID in URL does not match ID in request body" }
            };
            return BadRequest(errorResult);
        }

        salesChannelUpdateCommand.Id = id;
        var response = await mediator.Send(salesChannelUpdateCommand);
        return StatusCode((int)response.StatusCode, response);
    }

    // DELETE: api/v1/<SalesChannelController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(string id)
    {
        if (!Guid.TryParse(id, out var guidId))
        {
            return BadRequest(new { Error = "Invalid ID format" });
        }

        var command = new SalesChannelDeleteCommand { Id = guidId };
        var response = await mediator.Send(command);
        return response.ToActionResult();
    }

    /// <summary>
    /// Trigger an import for a single channel + operation. Runs through the same dispatcher the
    /// orchestrator uses, so it lands in the same ChannelSyncRun audit table.
    /// </summary>
    [HttpPost("{id:guid}/sync/{operation}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> ManualSync(Guid id, string operation, CancellationToken cancellationToken)
    {
        var salesChannel = await salesChannelRepository.GetByIdAsync(id);
        if (salesChannel is null)
        {
            return NotFound();
        }

        if (!TryResolveImportOperation(operation, out var op))
        {
            return BadRequest(new { Error = $"Operation '{operation}' is not a valid import (products|saless|customers)" });
        }

        var run = await syncDispatcher.RunImportAsync(salesChannel, op, ChannelSyncTriggerSource.Manual, cancellationToken);
        return Ok(new
        {
            runId = run.Id,
            run.Status,
            run.ItemsProcessed,
            run.ItemsFailed,
            run.ErrorSummary,
        });
    }

    /// <summary>Test the channel's credentials/connectivity without doing any import.</summary>
    [HttpPost("{id:guid}/test-connection")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> TestConnection(Guid id, CancellationToken cancellationToken)
    {
        var salesChannel = await salesChannelRepository.GetByIdAsync(id);
        if (salesChannel is null)
        {
            return NotFound();
        }

        var connector = connectorRegistry.Resolve(salesChannel.Type);
        if (connector is null)
        {
            return BadRequest(new { Error = $"No connector registered for {salesChannel.Type}" });
        }

        var run = new ChannelSyncRun
        {
            Id = Guid.NewGuid(),
            TenantId = salesChannel.TenantId,
            SalesChannelId = salesChannel.Id,
            Operation = ChannelSyncOperation.ImportProducts,
            TriggerSource = ChannelSyncTriggerSource.Manual,
            Status = ChannelSyncRunStatus.Success,
            StartedAt = DateTime.UtcNow,
            FinishedAt = DateTime.UtcNow,
            CorrelationId = Guid.NewGuid(),
        };

        var context = contextFactory.Create(salesChannel, run, cancellationToken);
        var result = await connector.TestConnectionAsync(context);

        return Ok(new { success = result.Success, message = result.Message });
    }

    /// <summary>Recent sync-run audit log for the channel.</summary>
    [HttpGet("{id:guid}/sync-runs")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetSyncRuns(Guid id, int take = 50, int offset = 0, CancellationToken cancellationToken = default)
    {
        var runs = await dbContext.ChannelSyncRun
            .Where(r => r.SalesChannelId == id)
            .OrderByDescending(r => r.StartedAt)
            .Skip(offset)
            .Take(Math.Clamp(take, 1, 200))
            .ToListAsync(cancellationToken);

        return Ok(runs);
    }

    /// <summary>
    /// Synchronization log lines for the channel (last 24h). Optional <paramref name="minLevel"/>
    /// filters by minimum severity (e.g. "Warning"). Newest first. Tenant-isolated via query filter.
    /// </summary>
    [HttpGet("{id:guid}/sync-logs")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetSyncLogs(Guid id, int take = 200, int offset = 0, string? minLevel = null, CancellationToken cancellationToken = default)
    {
        var cutoff = DateTime.UtcNow.AddHours(-24);

        var query = dbContext.ChannelSyncLog
            .Where(l => l.SalesChannelId == id && l.Timestamp >= cutoff);

        if (!string.IsNullOrWhiteSpace(minLevel) && Enum.TryParse<ChannelSyncLogLevel>(minLevel, ignoreCase: true, out var level))
        {
            query = query.Where(l => l.Level >= level);
        }

        var logs = await query
            .OrderByDescending(l => l.Timestamp)
            .Skip(offset)
            .Take(Math.Clamp(take, 1, 500))
            .Select(l => new ChannelSyncLogDto
            {
                Id = l.Id,
                SalesChannelId = l.SalesChannelId,
                CorrelationId = l.CorrelationId,
                Operation = l.Operation,
                Level = l.Level,
                Message = l.Message,
                Exception = l.Exception,
                Timestamp = l.Timestamp,
            })
            .ToListAsync(cancellationToken);

        return Ok(logs);
    }

    /// <summary>Outbox rows currently in DeadLetter for the channel.</summary>
    [HttpGet("{id:guid}/outbox/dead-letter")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetDeadLetter(Guid id, CancellationToken cancellationToken)
    {
        var rows = await dbContext.ChannelExportOutbox
            .Where(o => o.SalesChannelId == id && o.Status == ChannelOutboxStatus.DeadLetter)
            .OrderBy(o => o.NextAttemptAt)
            .ToListAsync(cancellationToken);

        return Ok(rows);
    }

    /// <summary>Reset a DeadLetter outbox row back to Pending so the drainer retries it.</summary>
    [HttpPost("{id:guid}/outbox/{outboxId:guid}/retry")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RetryDeadLetter(Guid id, Guid outboxId, CancellationToken cancellationToken)
    {
        var row = await dbContext.ChannelExportOutbox
            .FirstOrDefaultAsync(o => o.Id == outboxId && o.SalesChannelId == id, cancellationToken);

        if (row is null) return NotFound();

        row.Status = ChannelOutboxStatus.Pending;
        row.AttemptCount = 0;
        row.NextAttemptAt = DateTime.UtcNow;
        row.LastError = null;
        row.CompletedAt = null;
        await dbContext.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Web-analytics tracking status for the channel (whether tracking is on and a token is configured).
    /// Tenant-isolated via the global query filter.
    /// </summary>
    [HttpGet("{id:guid}/tracking")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SalesChannelTrackingStatusDto>> GetTrackingStatus(Guid id, CancellationToken cancellationToken)
    {
        var channel = await FindTenantChannelAsync(id, cancellationToken);
        if (channel is null)
        {
            return NotFound();
        }

        return Ok(new SalesChannelTrackingStatusDto
        {
            SalesChannelId = id,
            TrackingEnabled = channel.TrackingEnabled,
            HasToken = !string.IsNullOrEmpty(channel.TrackingTokenHash)
        });
    }

    /// <summary>
    /// Generates (or rotates) the channel's web-analytics tracking token and enables tracking. Returns
    /// the plaintext token ONCE — paste it into the shop plugin. Rotating invalidates the previous token
    /// and any historical pseudonymised-customer (cid) matching. Tenant-isolated via the query filter.
    /// </summary>
    [HttpPost("{id:guid}/tracking-token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SalesChannelTrackingTokenDto>> RotateTrackingToken(Guid id, CancellationToken cancellationToken)
    {
        var channel = await FindTenantChannelAsync(id, cancellationToken);
        if (channel is null)
        {
            return NotFound();
        }

        var token = TrackingTokenHasher.GenerateToken();
        channel.TrackingToken = token;                          // encrypted at rest by the value converter
        channel.TrackingTokenHash = TrackingTokenHasher.Hash(token);
        channel.TrackingEnabled = true;
        channel.DateModified = DateTime.UtcNow;
        await dbContext.SaveChangesAsync(cancellationToken);

        return Ok(new SalesChannelTrackingTokenDto
        {
            SalesChannelId = id,
            Token = token,
            TrackingEnabled = true
        });
    }

    /// <summary>Disables web-analytics tracking for the channel (keeps the stored token).</summary>
    [HttpDelete("{id:guid}/tracking")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DisableTracking(Guid id, CancellationToken cancellationToken)
    {
        var channel = await FindTenantChannelAsync(id, cancellationToken);
        if (channel is null)
        {
            return NotFound();
        }

        channel.TrackingEnabled = false;
        channel.DateModified = DateTime.UtcNow;
        await dbContext.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    private static bool IsImportOperation(ChannelSyncOperation operation) => operation
        is ChannelSyncOperation.ImportProducts
        or ChannelSyncOperation.ImportSaless
        or ChannelSyncOperation.ImportCustomers;

    /// <summary>
    /// Resolves the {operation} route token to an import operation. Accepts both the short tokens
    /// the client sends ("products" | "saless" | "customers") and the full enum names
    /// (e.g. "ImportProducts"), so the advertised contract and the enum both work.
    /// </summary>
    private static bool TryResolveImportOperation(string? operation, out ChannelSyncOperation op)
    {
        switch (operation?.Trim().ToLowerInvariant())
        {
            case "products": op = ChannelSyncOperation.ImportProducts; return true;
            case "saless": op = ChannelSyncOperation.ImportSaless; return true;
            case "customers": op = ChannelSyncOperation.ImportCustomers; return true;
        }

        return Enum.TryParse(operation, ignoreCase: true, out op) && IsImportOperation(op);
    }
}
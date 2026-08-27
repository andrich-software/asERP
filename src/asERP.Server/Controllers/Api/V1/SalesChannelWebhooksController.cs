using System.Security.Cryptography;
using System.Text;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asERP.Server.Controllers.Api.V1;

/// <summary>
/// Anonymous ingest endpoint for shop webhooks (WooCommerce, Shopware 6). Webhooks are an ACCELERATOR,
/// not a data path: the payload is never imported directly — a verified webhook merely enqueues the
/// matching import run (orders / stock), which pulls through the regular, idempotent connector pipeline.
/// Lost webhooks therefore cost nothing (the scheduled poll remains the reconciler), and a forged
/// payload cannot inject data. Authentication is the per-channel <c>WebhookSecret</c>: WooCommerce signs
/// the raw body (HMAC-SHA256, base64, <c>X-WC-Webhook-Signature</c>); other senders pass the secret via
/// the <c>X-Webhook-Token</c> header (e.g. a Shopware Flow-Builder webhook action).
/// </summary>
[ApiController]
[AllowAnonymous]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/webhooks/saleschannels")]
public class SalesChannelWebhooksController(
    ApplicationDbContext dbContext,
    ILogger<SalesChannelWebhooksController> logger) : ControllerBase
{
    /// <summary>
    /// Receives a webhook for a channel. <paramref name="eventName"/> selects the nudge:
    /// order events → ImportSaless, product events → ImportProducts (plus ImportStock on a stock-master
    /// channel — WooCommerce fires product.updated for stock edits too), stock events → ImportStock.
    /// Every nudge is gated by the channel's matching import flag: webhooks accelerate the scheduled
    /// sync, they never run an import the admin has disabled (that stays the manual sync's privilege).
    /// </summary>
    [HttpPost("{channelId:guid}/{eventName}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Receive(Guid channelId, string eventName, CancellationToken cancellationToken)
    {
        // Anonymous path: resolve the tenant through the channel row itself, never through headers.
        var channel = await dbContext.SalesChannel
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(s => s.Id == channelId, cancellationToken);

        if (channel is null || !channel.IsEnabled)
        {
            return NotFound();
        }

        if (string.IsNullOrEmpty(channel.WebhookSecret))
        {
            // No secret configured → webhooks are disabled for this channel. 404 (not 401) so probing
            // cannot distinguish "channel exists without webhooks" from "no such channel".
            return NotFound();
        }

        string rawBody;
        using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
        {
            rawBody = await reader.ReadToEndAsync(cancellationToken);
        }

        if (!VerifySignature(channel.WebhookSecret, rawBody))
        {
            logger.LogWarning("Webhook for channel {Channel} rejected: invalid signature/token", channelId);
            return Unauthorized();
        }

        var operations = MapEventToOperations(eventName, channel);
        if (operations.Count == 0)
        {
            // Verified but uninteresting event (e.g. customer.updated), or the matching import is
            // disabled on the channel — acknowledge so the shop does not retry or disable the webhook.
            return Ok(new { queued = false });
        }

        // Nudge: enqueue a Queued run per operation unless the same operation is already waiting or
        // running — the orchestrator picks it up on its next tick (≤10s). Coalescing keeps webhook
        // bursts (one per order in a busy minute) from stacking identical runs.
        var queuedAny = false;
        foreach (var operation in operations)
        {
            var alreadyPending = await dbContext.ChannelSyncRun
                .IgnoreQueryFilters()
                .AnyAsync(r => r.SalesChannelId == channel.Id
                               && r.Operation == operation
                               && (r.Status == ChannelSyncRunStatus.Queued || r.Status == ChannelSyncRunStatus.Running),
                    cancellationToken);

            if (alreadyPending)
            {
                continue;
            }

            dbContext.ChannelSyncRun.Add(new ChannelSyncRun
            {
                Id = Guid.NewGuid(),
                TenantId = channel.TenantId,
                SalesChannelId = channel.Id,
                Operation = operation,
                TriggerSource = ChannelSyncTriggerSource.Event,
                Status = ChannelSyncRunStatus.Queued,
                StartedAt = DateTime.UtcNow,
                CorrelationId = Guid.NewGuid(),
            });
            queuedAny = true;
        }

        if (queuedAny)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        return Ok(new { queued = queuedAny });
    }

    /// <summary>
    /// Accepts either the WooCommerce body signature or a plain token header. Comparisons are
    /// constant-time so the secret cannot be probed byte-by-byte.
    /// </summary>
    private bool VerifySignature(string secret, string rawBody)
    {
        if (Request.Headers.TryGetValue("X-WC-Webhook-Signature", out var wcSignature))
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
            var expected = hmac.ComputeHash(Encoding.UTF8.GetBytes(rawBody));

            Span<byte> provided = stackalloc byte[64];
            return Convert.TryFromBase64String(wcSignature.ToString(), provided, out var written)
                   && CryptographicOperations.FixedTimeEquals(expected, provided[..written]);
        }

        if (Request.Headers.TryGetValue("X-Webhook-Token", out var token))
        {
            return CryptographicOperations.FixedTimeEquals(
                Encoding.UTF8.GetBytes(token.ToString()),
                Encoding.UTF8.GetBytes(secret));
        }

        return false;
    }

    private static List<ChannelSyncOperation> MapEventToOperations(string eventName, SalesChannel channel)
    {
        var operations = new List<ChannelSyncOperation>(2);

        switch (eventName.ToLowerInvariant())
        {
            case "order" or "orders" or "order-created" or "order-updated":
                if (channel.ImportSaless)
                {
                    operations.Add(ChannelSyncOperation.ImportSaless);
                }
                break;

            case "product" or "products" or "product-updated":
                // A product event means catalogue data changed — nudge the product import, not (only)
                // the stock mirror. WooCommerce fires product.updated for stock edits as well, so a
                // stock-master channel gets the stock nudge on top; queued-run coalescing dedupes bursts.
                if (channel.ImportProducts)
                {
                    operations.Add(ChannelSyncOperation.ImportProducts);
                }
                if (channel.ImportStock)
                {
                    operations.Add(ChannelSyncOperation.ImportStock);
                }
                break;

            case "stock":
                if (channel.ImportStock)
                {
                    operations.Add(ChannelSyncOperation.ImportStock);
                }
                break;
        }

        return operations;
    }
}

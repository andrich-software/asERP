using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Shipping.Services;

public class SalesShippingStatusService : ISalesShippingStatusService
{
    /// <summary>Manually or externally finalized orders are never resurrected by shipment changes.</summary>
    private static readonly SalesStatus[] ProtectedStatuses =
    [
        SalesStatus.Cancelled,
        SalesStatus.Returned,
        SalesStatus.Refunded,
        SalesStatus.Failed
    ];

    private readonly IAppLogger<SalesShippingStatusService> _logger;
    private readonly ISalesRepository _salesRepository;

    public SalesShippingStatusService(
        IAppLogger<SalesShippingStatusService> logger,
        ISalesRepository salesRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
    }

    public async Task RecomputeAsync(Guid salesId, CancellationToken cancellationToken = default)
    {
        var sales = await _salesRepository.GetByIdAsync(salesId);
        if (sales == null)
        {
            return;
        }

        if (ProtectedStatuses.Contains(sales.Status))
        {
            return;
        }

        var assignmentCounts = await _salesRepository.GetContext<SalesItem>()
            .Where(i => i.SalesId == salesId)
            .GroupBy(i => i.ShippingId != null)
            .Select(g => new { Assigned = g.Key, Count = g.Count() })
            .ToListAsync(cancellationToken);

        var assigned = assignmentCounts.FirstOrDefault(c => c.Assigned)?.Count ?? 0;
        var unassigned = assignmentCounts.FirstOrDefault(c => !c.Assigned)?.Count ?? 0;

        if (assigned + unassigned == 0)
        {
            return;
        }

        SalesStatus? target = (assigned, unassigned) switch
        {
            ( > 0, 0) => SalesStatus.Completed,
            ( > 0, > 0) => SalesStatus.PartiallyDelivered,
            // All shipments gone again: only revert statuses this automation set itself.
            (0, _) when sales.Status is SalesStatus.PartiallyDelivered or SalesStatus.Completed
                => SalesStatus.Processing,
            _ => null
        };

        if (target == null || target == sales.Status)
        {
            return;
        }

        var oldStatus = sales.Status;
        sales.Status = target.Value;
        await _salesRepository.UpdateAsync(sales);

        await _salesRepository.AddSalesHistoryAsync(new SalesHistory
        {
            SalesId = sales.Id,
            UserId = Guid.Empty,
            TenantId = sales.TenantId,
            SalesStatusOld = oldStatus,
            SalesStatusNew = target.Value,
            Description = "Order status updated automatically from shipment assignment",
            IsSystemGenerated = true
        });

        _logger.LogInformation("Sales {SalesId} status changed {Old} -> {New} from shipment assignment",
            salesId, oldStatus, target.Value);
    }
}

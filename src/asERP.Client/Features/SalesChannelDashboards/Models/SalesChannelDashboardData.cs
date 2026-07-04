using asERP.Domain.Enums;

namespace asERP.Client.Features.SalesChannelDashboards.Models;

/// <summary>
/// Navigation data for SalesChannel dashboard pages.
/// </summary>
public record SalesChannelDashboardData(Guid SalesChannelId, string SalesChannelName, SalesChannelType SalesChannelType);

namespace asERP.Domain.Dtos.WebAnalytics;

/// <summary>
/// Session counts for the "Web-Statistiken" dashboard tab. A session is a distinct daily-salted
/// session hash within a day bucket (UTC). All values are scoped to one tenant + sales channel.
/// </summary>
public class WebSessionsSummaryDto
{
    public Guid SalesChannelId { get; set; }

    public long SessionsToday { get; set; }
    public long SessionsYesterday { get; set; }
    public long SessionsThisWeek { get; set; }
    public long SessionsLastWeek { get; set; }
}

namespace asERP.Domain.Dtos.Feed;

public class FeedLogDto
{
    public Guid Id { get; set; }
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }

    /// <summary>Time of the access (FeedLog.DateCreated).</summary>
    public DateTime DateCreated { get; set; }
}

using asERP.Domain.Entities.Common;

namespace asERP.Domain.Entities;

/// <summary>
/// Access-log row written on every anonymous retrieval of a <see cref="Feed"/>. The access timestamp is
/// <see cref="BaseEntity.DateCreated"/>; the feed's "last accessed" is the max of these.
/// </summary>
public class FeedLog : BaseEntity, IBaseEntity
{
    public Guid FeedId { get; set; }
    public Feed? Feed { get; set; }

    /// <summary>Caller IP (X-Forwarded-For first hop when present, else the connection remote IP).</summary>
    public string? IpAddress { get; set; }

    public string? UserAgent { get; set; }
}

namespace asERP.Application.Features.Feed.Queries.FeedRender;

public class FeedRenderResult
{
    public byte[] Content { get; set; } = Array.Empty<byte>();
    public string ContentType { get; set; } = "application/octet-stream";
    public string FileName { get; set; } = "feed";
}

namespace asERP.Domain.Dtos.SalesChannel;

/// <summary>Outcome of a sales channel connection test.</summary>
public class SalesChannelConnectionTestResultDto
{
    public bool Success { get; set; }
    public string? Message { get; set; }
}

namespace asERP.Domain.Dtos.Shipping;

public class ShippingLabelDto
{
    public byte[] Data { get; set; } = Array.Empty<byte>();
    public string ContentType { get; set; } = "application/pdf";
    public string FileName { get; set; } = string.Empty;
}

using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.Sales;

public class SalesReadyToShipListDto
{
    public Guid Id { get; set; }
    public int SalesId { get; set; }
    public int CustomerId { get; set; }
    public string DeliveryAddressFirstName { get; set; } = string.Empty;
    public string DeliveryAddressLastName { get; set; } = string.Empty;
    public string DeliveryAddressCompanyName { get; set; } = string.Empty;
    public string DeliveryAddressCountry { get; set; } = string.Empty;
    public SalesStatus Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public DateTime DateSalesed { get; set; }

    /// <summary>Number of sales items not yet assigned to a shipment.</summary>
    public int OpenItemCount { get; set; }

    /// <summary>True when every open item's product exists and aggregated stock covers the open quantity.</summary>
    public bool AllItemsInStock { get; set; }

    public string FullName => $"{DeliveryAddressFirstName} {DeliveryAddressLastName}";
}

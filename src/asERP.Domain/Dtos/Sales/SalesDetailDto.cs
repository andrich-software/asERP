using asERP.Domain.Dtos.Returns;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.Sales;

public class SalesDetailDto
{
    public Guid Id { get; set; }
    public int SalesId { get; set; }
    public Guid SalesChannelId { get; set; }
    public string RemoteSalesId { get; set; } = string.Empty;
    public int CustomerId { get; set; }

    /// <summary>Entity id (Guid) of the customer — used by the client to link to the customer detail page.</summary>
    public Guid CustomerGuid { get; set; }

    public SalesStatus Status { get; set; }
    public List<SalesItemDto> SalesItems { get; set; } = new List<SalesItemDto>();
    public List<SalesHistoryDto> SalesHistory { get; set; } = new List<SalesHistoryDto>();

    public string PaymentMethod { get; set; } = string.Empty;
    public PaymentStatus PaymentStatus { get; set; }
    public string PaymentProvider { get; set; } = string.Empty;
    public string PaymentTransactionId { get; set; } = string.Empty;

    // Legacy single-shipment fields (bound by the client) — populated from the newest
    // non-cancelled shipment; the full list lives in Shippings.
    public string ShippingMethod { get; set; } = string.Empty;
    public string ShippingStatus { get; set; } = string.Empty;
    public string ShippingProvider { get; set; } = string.Empty;
    public string ShippingTrackingId { get; set; } = string.Empty;

    public List<ShippingListDto> Shippings { get; set; } = new List<ShippingListDto>();

    /// <summary>Customer returns (RMA) of this order, newest first.</summary>
    public List<ReturnShipmentListItemDto> Returns { get; set; } = new List<ReturnShipmentListItemDto>();

    public decimal Subtotal { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal TotalTax { get; set; }
    public decimal Total { get; set; }

    public string Note { get; set; } = string.Empty;

    public string DeliveryAddressFirstName { get; set; } = string.Empty;
    public string DeliveryAddressLastName { get; set; } = string.Empty;
    public string DeliveryAddressCompanyName { get; set; } = string.Empty;
    public string DeliveryAddressPhone { get; set; } = string.Empty;
    public string DeliveryAddressStreet { get; set; } = string.Empty;
    public string DeliveryAddressCity { get; set; } = string.Empty;
    public string DeliveryAddressZip { get; set; } = string.Empty;
    public string DeliveryAddressCountry { get; set; } = string.Empty;

    public string InvoiceAddressFirstName { get; set; } = string.Empty;
    public string InvoiceAddressLastName { get; set; } = string.Empty;
    public string InvoiceAddressCompanyName { get; set; } = string.Empty;
    public string InvoiceAddressPhone { get; set; } = string.Empty;
    public string InvoiceAddressStreet { get; set; } = string.Empty;
    public string InvoiceAddressCity { get; set; } = string.Empty;
    public string InvoiceAddressZip { get; set; } = string.Empty;
    public string InvoiceAddressCountry { get; set; } = string.Empty;

    public DateTime DateSalesed { get; set; }
}

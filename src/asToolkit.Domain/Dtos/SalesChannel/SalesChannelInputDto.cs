using asToolkit.Domain.Dtos.Warehouse;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Interfaces;

namespace asToolkit.Domain.Dtos.SalesChannel;

public class SalesChannelInputDto : ISalesChannelInputModel
{
    public Guid Id { get; set; }
    public SalesChannelType SalesChannelType { get; set; }
    public string Name { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public bool ImportProducts { get; set; }
    public bool ExportProducts { get; set; }
    public bool ImportCustomers { get; set; }
    public bool ExportCustomers { get; set; }
    public bool ImportSaless { get; set; }
    public bool ExportSaless { get; set; }

    /// <summary>Receive stock pushes whenever the mirrored warehouse stock changes.</summary>
    public bool ExportStock { get; set; }

    /// <summary>This channel is the stock master — its levels are mirrored into the linked warehouse.</summary>
    public bool ImportStock { get; set; }
    public bool InitialProductImportCompleted { get; set; }
    public bool InitialProductExportCompleted { get; set; }
    public bool InitialCustomerImportCompleted { get; set; }

    public List<Guid> WarehouseIds { get; set; } = new();
}


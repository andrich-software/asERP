namespace asERP.Client.Features.Shippings.Services;

/// <summary>Tenant-scoped local preferences that make repeat shipping fast: the last-used
/// shipping option is preselected, and a remembered label action runs automatically.</summary>
public interface IShippingPreferences
{
    Guid? GetLastRateId(Guid tenantId);
    void SetLastRateId(Guid tenantId, Guid rateId);

    LabelActionPreference? GetLabelAction(Guid tenantId);

    /// <summary>Null clears the remembered action.</summary>
    void SetLabelAction(Guid tenantId, LabelActionPreference? preference);

    /// <summary>Printer remembered for packing-slip printing (independent of the label printer).</summary>
    string? GetPackingSlipPrinter(Guid tenantId);

    /// <summary>Null clears the remembered printer.</summary>
    void SetPackingSlipPrinter(Guid tenantId, string? printerName);
}

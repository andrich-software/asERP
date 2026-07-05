using asERP.Client.Features.Returns.Models;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Enums;
using Microsoft.UI.Xaml.Data;

namespace asERP.Client.Features.Returns;

/// <summary>
/// Shows the "Retoure" order action while <see cref="ReturnRules.CanCreateReturn"/> allows it.
/// Bound to the whole detail DTO because the rule needs the parcels, not just the order status.
/// </summary>
public class CanCreateReturnToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language) =>
        value is SalesDetailDto sales && ReturnRules.CanCreateReturn(sales)
            ? Visibility.Visible
            : Visibility.Collapsed;

    public object ConvertBack(object value, Type targetType, object parameter, string language) =>
        throw new NotImplementedException();
}

/// <summary>Shows the receive action while <see cref="ReturnRules.CanReceive"/> allows it.</summary>
public class CanReceiveReturnToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language) =>
        value is ReturnShipmentStatus status && ReturnRules.CanReceive(status)
            ? Visibility.Visible
            : Visibility.Collapsed;

    public object ConvertBack(object value, Type targetType, object parameter, string language) =>
        throw new NotImplementedException();
}

/// <summary>Shows the cancel-return action while <see cref="ReturnRules.CanCancelReturn"/> allows it.</summary>
public class CanCancelReturnToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language) =>
        value is ReturnShipmentStatus status && ReturnRules.CanCancelReturn(status)
            ? Visibility.Visible
            : Visibility.Collapsed;

    public object ConvertBack(object value, Type targetType, object parameter, string language) =>
        throw new NotImplementedException();
}

/// <summary>
/// Shows the "parcel came back — create a return?" hint only for outbound parcels the carrier
/// sent back (<see cref="ShippingStatus.ReturnedToSender"/> — not a customer return by itself).
/// </summary>
public class ReturnedToSenderToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language) =>
        value is ShippingStatus.ReturnedToSender ? Visibility.Visible : Visibility.Collapsed;

    public object ConvertBack(object value, Type targetType, object parameter, string language) =>
        throw new NotImplementedException();
}

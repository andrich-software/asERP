using asToolkit.Client.Core.Constants;
using asToolkit.Client.Core.Exceptions;
using asToolkit.Client.Core.Models;
using asToolkit.Client.Features.Customers.Services;
using asToolkit.Client.Features.Saless;
using asToolkit.Client.Features.Saless.Services;
using asToolkit.Domain.Dtos.Customer;
using asToolkit.Domain.Dtos.Sales;

namespace asToolkit.Client.Features.Customers.Models;

/// <summary>
/// Model for customer detail page using MVUX pattern.
/// Receives customer ID from navigation data.
/// </summary>
public partial record CustomerDetailModel
{
    private readonly ICustomerService _customerService;
    private readonly ISalesService _salesService;
    private readonly INavigator _navigator;
    private readonly Guid _customerId;

    public CustomerDetailModel(
        ICustomerService customerService,
        ISalesService salesService,
        INavigator navigator,
        CustomerDetailData data)
    {
        _customerService = customerService;
        _salesService = salesService;
        _navigator = navigator;
        _customerId = data.customerId;
    }

    /// <summary>
    /// State for error messages from API operations.
    /// </summary>
    public IState<string> ErrorMessage => State<string>.Value(this, () => string.Empty);

    /// <summary>
    /// Feed that loads the customer details.
    /// </summary>
    public IFeed<CustomerDetailDto> Customer => Feed.Async(async ct =>
    {
        var customer = await _customerService.GetCustomerAsync(_customerId, ct);
        return customer ?? throw new InvalidOperationException($"Customer {_customerId} not found");
    });

    /// <summary>
    /// Feed that loads the saless placed by this customer.
    /// Depends on the customer feed to resolve the numeric customer number.
    /// </summary>
    public IListFeed<SalesListDto> Saless => Customer
        .SelectAsync(async (customer, ct) =>
        {
            var parameters = new QueryParameters
            {
                PageNumber = 0,
                PageSize = 100,
                SalesBy = "DateSalesed Descending"
            };

            var response = await _salesService.GetSalessByCustomerAsync(customer.CustomerId, parameters, ct);
            return response.Data.ToImmutableList();
        })
        .AsListFeed();

    /// <summary>
    /// Navigate to the detail page of a sales placed by this customer.
    /// </summary>
    public async Task ViewSales(SalesListDto sales)
    {
        await _navigator.NavigateDataAsync(this, new SalesDetailData(sales.Id));
    }

    /// <summary>
    /// Navigate to edit customer page.
    /// </summary>
    public async Task EditCustomer()
    {
        await _navigator.NavigateDataAsync(this, new CustomerEditData(_customerId));
    }

    /// <summary>
    /// Delete the customer and navigate back.
    /// </summary>
    public async Task DeleteCustomer(CancellationToken ct)
    {
        try
        {
            await ErrorMessage.Set(string.Empty, ct);
            await _customerService.DeleteCustomerAsync(_customerId, ct);
            await _navigator.NavigateBackAsync(this);
        }
        catch (ApiException ex)
        {
            await ErrorMessage.Set(ex.CombinedMessage, ct);
        }
        catch (Exception ex)
        {
            await ErrorMessage.Set(ex.Message, ct);
        }
    }

    /// <summary>
    /// Clear the error message.
    /// </summary>
    public async Task ClearError(CancellationToken ct)
    {
        await ErrorMessage.Set(string.Empty, ct);
    }

    /// <summary>
    /// Navigate back to customer list.
    /// </summary>
    public async Task GoBack()
    {
        await _navigator.NavigateBackAsync(this);
    }
}

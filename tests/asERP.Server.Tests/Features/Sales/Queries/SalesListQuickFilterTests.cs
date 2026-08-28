using asERP.Domain.Constants;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Xunit;

namespace asERP.Server.Tests.Features.Sales.Queries;

// Customer number range for this class: 960-979 plus 912-913.
public class SalesListQuickFilterTests : TenantIsolatedTestBase
{
    private async Task<PaginatedResult<SalesListDto>> GetListAsync(string filter)
    {
        var response = await Client.GetAsync($"/api/v1/Saless?filter={filter}");
        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<SalesListDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        return result;
    }

    [Fact]
    public async Task Filter_ReadyToShip_ReturnsOnlyShippableSalesWithOpenItems()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);

        var openSales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 960, itemCount: 2);

        var shippedSales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 961, itemCount: 2);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, shippedSales, provider, rate);
        foreach (var item in shippedSales.SalesItems)
        {
            item.ShippingId = shipping.Id;
        }

        var cancelled = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 962);
        cancelled.Status = SalesStatus.Cancelled;

        var unpaid = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 978, itemCount: 2);
        unpaid.PaymentStatus = PaymentStatus.Invoiced;

        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync(nameof(SalesQuickFilter.ReadyToShip));

        TestAssertions.AssertEqual(1, result.Data.Count);
        TestAssertions.AssertEqual(openSales.Id, result.Data[0].Id);
    }

    [Fact]
    public async Task Filter_PaymentOverdue_ReturnsOnlyUnpaidSalesOlderThanSevenDays()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var overdue = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 979);
        overdue.PaymentStatus = PaymentStatus.Invoiced;
        overdue.DateSalesed = DateTime.UtcNow.AddDays(-8);

        var recentUnpaid = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 912);
        recentUnpaid.PaymentStatus = PaymentStatus.Invoiced;
        recentUnpaid.DateSalesed = DateTime.UtcNow.AddDays(-2);

        var oldButPaid = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 913);
        oldButPaid.DateSalesed = DateTime.UtcNow.AddDays(-10);

        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync(nameof(SalesQuickFilter.PaymentOverdue));

        TestAssertions.AssertEqual(1, result.Data.Count);
        TestAssertions.AssertEqual(overdue.Id, result.Data[0].Id);
    }

    [Fact]
    public async Task Filter_Open_ReturnsPendingAndProcessingOnly()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var pending = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 963);
        pending.Status = SalesStatus.Pending;
        var processing = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 964);
        processing.Status = SalesStatus.Processing;
        var completed = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 965);
        completed.Status = SalesStatus.Completed;
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync(nameof(SalesQuickFilter.Open));

        TestAssertions.AssertEqual(2, result.Data.Count);
        var ids = result.Data.Select(d => d.Id).ToList();
        TestAssertions.AssertTrue(ids.Contains(pending.Id));
        TestAssertions.AssertTrue(ids.Contains(processing.Id));
    }

    [Fact]
    public async Task Filter_NotPaid_ExcludesPaidAndTerminalSales()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var unpaid = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 966);
        unpaid.PaymentStatus = PaymentStatus.Invoiced;
        var paid = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 967);
        paid.PaymentStatus = PaymentStatus.CompletelyPaid;
        var unpaidButCancelled = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 968);
        unpaidButCancelled.PaymentStatus = PaymentStatus.Invoiced;
        unpaidButCancelled.Status = SalesStatus.Cancelled;
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync(nameof(SalesQuickFilter.NotPaid));

        TestAssertions.AssertEqual(1, result.Data.Count);
        TestAssertions.AssertEqual(unpaid.Id, result.Data[0].Id);
    }

    [Fact]
    public async Task Filter_Cancelled_IncludesReturnedAndRefunded()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var cancelled = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 969);
        cancelled.Status = SalesStatus.Cancelled;
        var returned = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 970);
        returned.Status = SalesStatus.Returned;
        var refunded = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 971);
        refunded.Status = SalesStatus.Refunded;
        var processing = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 972);
        processing.Status = SalesStatus.Processing;
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync(nameof(SalesQuickFilter.Cancelled));

        TestAssertions.AssertEqual(3, result.Data.Count);
        TestAssertions.AssertFalse(result.Data.Any(d => d.Id == processing.Id));
    }

    [Fact]
    public async Task Filter_Problems_ReturnsOnHoldAndFailed()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var onHold = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 973);
        onHold.Status = SalesStatus.OnHold;
        var failed = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 974);
        failed.Status = SalesStatus.Failed;
        var processing = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 975);
        processing.Status = SalesStatus.Processing;
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync(nameof(SalesQuickFilter.Problems));

        TestAssertions.AssertEqual(2, result.Data.Count);
        TestAssertions.AssertFalse(result.Data.Any(d => d.Id == processing.Id));
    }

    [Fact]
    public async Task Filter_CombinesWithSearchString()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var match = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 976);
        match.Status = SalesStatus.Pending;
        match.InvoiceAddressFirstName = "Filtered";
        match.InvoiceAddressLastName = "Match976";
        var otherStatus = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 977);
        otherStatus.Status = SalesStatus.Completed;
        otherStatus.InvoiceAddressFirstName = "Filtered";
        otherStatus.InvoiceAddressLastName = "Match977";
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Saless?searchString=Filtered&filter={nameof(SalesQuickFilter.Open)}");
        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<SalesListDto>>(response);
        TestAssertions.AssertNotNull(result.Data);

        TestAssertions.AssertEqual(1, result.Data.Count);
        TestAssertions.AssertEqual(match.Id, result.Data[0].Id);
    }
}

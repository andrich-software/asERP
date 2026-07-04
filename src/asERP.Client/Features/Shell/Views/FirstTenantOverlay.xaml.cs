using asERP.Client.Core.Exceptions;
using asERP.Client.Features.Auth.Services;
using asERP.Client.Features.Tenants.Services;
using asERP.Domain.Dtos.Tenant;
using Microsoft.UI.Xaml.Controls;

namespace asERP.Client.Features.Shell.Views;

/// <summary>
/// Overlay shown when an authenticated user has no tenants yet. Owns the tenant
/// creation form and request; cancelling logs the user out. The hosting Shell switches
/// visibility and navigates to the dashboard after the tenant was created.
/// </summary>
public sealed partial class FirstTenantOverlay : UserControl
{
    /// <summary>
    /// Raised after the first tenant was created and selected. The Shell clears the
    /// no-tenants state and navigates to the dashboard.
    /// </summary>
    public event Func<Task>? TenantCreated;

    public FirstTenantOverlay()
    {
        this.InitializeComponent();
    }

    /// <summary>Clears the form, error banner and progress state.</summary>
    public void Reset()
    {
        FirstTenantName.Text = string.Empty;
        FirstTenantDescription.Text = string.Empty;
        FirstTenantSaveButton.IsEnabled = false;
        FirstTenantErrorBanner.Visibility = Visibility.Collapsed;
        FirstTenantErrorText.Text = string.Empty;
        FirstTenantProgress.Visibility = Visibility.Collapsed;
        FirstTenantProgress.IsActive = false;
    }

    private void FirstTenantName_TextChanged(object sender, TextChangedEventArgs e)
    {
        FirstTenantSaveButton.IsEnabled = !string.IsNullOrWhiteSpace(FirstTenantName.Text);
    }

    private async void FirstTenantCancel_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var app = Application.Current as App;
            if (app?.Host?.Services != null)
            {
                var auth = app.Host.Services.GetRequiredService<IAuthenticationService>();
                await auth.LogoutAsync(CancellationToken.None);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[FirstTenantOverlay] FirstTenantCancel_Click error: {ex.Message}");
        }
    }

    private async void FirstTenantSave_Click(object sender, RoutedEventArgs e)
    {
        var tenantName = FirstTenantName.Text?.Trim();
        if (string.IsNullOrWhiteSpace(tenantName)) return;

        FirstTenantSaveButton.IsEnabled = false;
        FirstTenantCancelButton.IsEnabled = false;
        FirstTenantProgress.Visibility = Visibility.Visible;
        FirstTenantProgress.IsActive = true;
        FirstTenantErrorBanner.Visibility = Visibility.Collapsed;

        try
        {
            var app = Application.Current as App;
            if (app?.Host?.Services == null)
            {
                throw new InvalidOperationException("Services not available");
            }

            var tenantService = app.Host.Services.GetRequiredService<ITenantService>();
            var tenantContext = app.Host.Services.GetRequiredService<ITenantContextService>();

            var input = new TenantInputDto
            {
                Name = tenantName,
                Description = FirstTenantDescription.Text?.Trim() ?? string.Empty
            };

            var newTenantId = await tenantService.CreateTenantAsync(input);

            await tenantContext.RefreshTokenAndTenantsAsync();

            if (newTenantId != Guid.Empty)
            {
                await tenantContext.SetCurrentTenantAsync(newTenantId);
            }

            if (TenantCreated is { } tenantCreated)
            {
                await tenantCreated();
            }
        }
        catch (ApiException ex)
        {
            FirstTenantErrorText.Text = ex.CombinedMessage;
            FirstTenantErrorBanner.Visibility = Visibility.Visible;
        }
        catch (Exception ex)
        {
            FirstTenantErrorText.Text = ex.Message;
            FirstTenantErrorBanner.Visibility = Visibility.Visible;
        }
        finally
        {
            FirstTenantProgress.Visibility = Visibility.Collapsed;
            FirstTenantProgress.IsActive = false;
            FirstTenantSaveButton.IsEnabled = !string.IsNullOrWhiteSpace(FirstTenantName.Text);
            FirstTenantCancelButton.IsEnabled = true;
        }
    }
}

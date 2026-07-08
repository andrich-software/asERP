using System.Runtime.CompilerServices;
using asERP.Client.Core.Abstractions;
using asERP.Client.Core.Exceptions;
using asERP.Client.Features.Superadmin.Services;
using asERP.Domain.Dtos.Country;
using Microsoft.Extensions.Logging;

namespace asERP.Client.Features.Superadmin.Models;

/// <summary>
/// Model for the superadmin country create/edit page.
/// A null country id means "create"; a value means "edit an existing country".
/// Inherits from AsyncInitializableModel for safe async initialization.
/// </summary>
public class SuperadminCountryEditModel : AsyncInitializableModel
{
    private readonly ISuperadminCountryService _countryService;
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;
    private readonly Guid? _countryId;

    // Country Data
    private string _name = string.Empty;
    private string _countryCode = string.Empty;

    // UI State
    private bool _isSaving;
    private bool _isDeleting;
    private string _errorMessage = string.Empty;

    public SuperadminCountryEditModel(
        ISuperadminCountryService countryService,
        INavigator navigator,
        IStringLocalizer localizer,
        ILogger<SuperadminCountryEditModel> logger,
        SuperadminCountryEditData? data = null)
        : base(logger)
    {
        _countryService = countryService;
        _navigator = navigator;
        _localizer = localizer;
        _countryId = data?.CountryId;

        // Start async initialization with proper error handling
        StartInitialization();
    }

    /// <inheritdoc />
    protected override async Task InitializeCoreAsync(CancellationToken ct)
    {
        if (_countryId.HasValue)
        {
            await LoadCountryAsync(ct);
        }
    }

    public bool IsEditMode => _countryId.HasValue;

    public string Title => IsEditMode
        ? _localizer["SuperadminCountryEditPage.TitleEdit"]
        : _localizer["SuperadminCountryEditPage.TitleNew"];

    #region Country Data

    public string Name
    {
        get => _name;
        set
        {
            if (SetProperty(ref _name, value))
            {
                OnPropertyChanged(nameof(CanSave));
            }
        }
    }

    public string CountryCode
    {
        get => _countryCode;
        set
        {
            if (SetProperty(ref _countryCode, value))
            {
                OnPropertyChanged(nameof(CanSave));
            }
        }
    }

    #endregion

    #region UI State

    /// <summary>
    /// Indicates whether a save operation is in progress.
    /// </summary>
    public bool IsSaving
    {
        get => _isSaving;
        private set
        {
            if (SetProperty(ref _isSaving, value))
            {
                OnPropertyChanged(nameof(IsLoading));
                OnPropertyChanged(nameof(IsNotLoading));
                OnPropertyChanged(nameof(CanSave));
            }
        }
    }

    /// <summary>
    /// Indicates whether a delete operation is in progress.
    /// </summary>
    public bool IsDeleting
    {
        get => _isDeleting;
        private set
        {
            if (SetProperty(ref _isDeleting, value))
            {
                OnPropertyChanged(nameof(IsLoading));
                OnPropertyChanged(nameof(IsNotLoading));
                OnPropertyChanged(nameof(CanSave));
            }
        }
    }

    /// <summary>
    /// Combined loading state (initializing, saving, or deleting).
    /// </summary>
    public bool IsLoading => IsInitializing || IsSaving || IsDeleting;

    /// <summary>
    /// Inverse of IsLoading for binding convenience.
    /// </summary>
    public bool IsNotLoading => !IsLoading;

    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public bool CanSave =>
        !string.IsNullOrWhiteSpace(Name) &&
        !string.IsNullOrWhiteSpace(CountryCode) &&
        !IsLoading;

    #endregion

    #region Delete confirmation strings (used by the code-behind dialog)

    public string DeleteConfirmTitle => _localizer["SuperadminCountryEditPage.DeleteTitle"];
    public string DeleteConfirmMessage => _localizer["SuperadminCountryEditPage.DeleteMessage"];
    public string DeleteConfirmAccept => _localizer["SuperadminCountryEditPage.DeleteAccept"];
    public string DeleteConfirmCancel => _localizer["SuperadminCountryEditPage.DeleteCancel"];

    #endregion

    private async Task LoadCountryAsync(CancellationToken ct)
    {
        if (!_countryId.HasValue) return;

        var country = await _countryService.GetCountryAsync(_countryId.Value, ct);
        if (country != null)
        {
            Name = country.Name;
            CountryCode = country.CountryCode;
        }
    }

    public async Task SaveAsync(CancellationToken ct = default)
    {
        if (!CanSave) return;

        IsSaving = true;
        ErrorMessage = string.Empty;

        try
        {
            var input = new CountryInputDto
            {
                Name = Name.Trim(),
                // ISO country codes are conventionally uppercase; normalize so imports
                // resolve regardless of how the value was typed.
                CountryCode = CountryCode.Trim().ToUpperInvariant()
            };

            if (_countryId.HasValue)
            {
                input.Id = _countryId.Value;
                await _countryService.UpdateCountryAsync(_countryId.Value, input, ct);
            }
            else
            {
                await _countryService.CreateCountryAsync(input, ct);
            }

            await _navigator.NavigateBackAsync(this);
        }
        catch (ApiException ex)
        {
            // Display detailed error messages from the API
            ErrorMessage = ex.CombinedMessage;
        }
        catch (Exception ex)
        {
            ErrorMessage = string.Format(_localizer["SuperadminCountryEditPage.Error.SaveFailed"], ex.Message);
        }
        finally
        {
            IsSaving = false;
        }
    }

    public async Task DeleteAsync(CancellationToken ct = default)
    {
        if (!_countryId.HasValue || IsLoading) return;

        IsDeleting = true;
        ErrorMessage = string.Empty;

        try
        {
            await _countryService.DeleteCountryAsync(_countryId.Value, ct);
            await _navigator.NavigateBackAsync(this);
        }
        catch (ApiException ex)
        {
            ErrorMessage = ex.CombinedMessage;
        }
        catch (Exception ex)
        {
            ErrorMessage = string.Format(_localizer["SuperadminCountryEditPage.Error.DeleteFailed"], ex.Message);
        }
        finally
        {
            IsDeleting = false;
        }
    }

    public async Task CancelAsync()
    {
        await _navigator.NavigateBackAsync(this);
    }

    /// <inheritdoc />
    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        // Handle IsInitializing changes from base class
        if (propertyName is nameof(IsInitializing))
        {
            base.OnPropertyChanged(nameof(IsLoading));
            base.OnPropertyChanged(nameof(IsNotLoading));
            base.OnPropertyChanged(nameof(CanSave));
        }
    }
}

/// <summary>
/// Navigation data for the superadmin country edit page.
/// A null <see cref="CountryId"/> starts a create flow.
/// </summary>
public record SuperadminCountryEditData(Guid? CountryId = null);

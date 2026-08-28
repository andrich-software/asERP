using System.ComponentModel;
using System.Runtime.CompilerServices;
using asERP.Client.Core.Abstractions;
using asERP.Client.Core.Exceptions;
using asERP.Client.Core.Helpers;
using asERP.Client.Core.Notifications;
using asERP.Client.Features.Countries.Services;
using asERP.Client.Features.ShippingProviders.Services;
using asERP.Domain.Dtos.ShippingProviderRate;
using asERP.Domain.Enums;

namespace asERP.Client.Features.ShippingProviders.Models;

/// <summary>Navigation data for ShippingRateEditModel. A null rate id means "create".</summary>
public record ShippingRateEditData(Guid ProviderId, ShippingProviderType ProviderType, Guid? RateId = null);

/// <summary>A selectable destination country. Selection state survives search filtering.</summary>
public sealed class CountrySelectionRow : INotifyPropertyChanged
{
    private bool _isSelected;

    public CountrySelectionRow(Guid id, string name, string countryCode)
    {
        Id = id;
        Name = name;
        CountryCode = countryCode;
    }

    public Guid Id { get; }
    public string Name { get; }
    public string CountryCode { get; }

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (_isSelected != value)
            {
                _isSelected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}

public class ShippingRateEditModel : AsyncInitializableModel
{
    private readonly IShippingProviderAdminService _providerService;
    private readonly ICountryService _countryService;
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;
    private readonly INotificationService _notifications;

    private readonly Guid _providerId;
    private readonly ShippingProviderType _providerType;
    private readonly Guid? _rateId;

    private string _name = string.Empty;
    private string _description = string.Empty;
    private bool _isActive = true;
    private int _sortOrder;
    private double _price;
    private double _maxWeight = 31.5;
    private double _maxLength = 120;
    private double _maxWidth = 60;
    private double _maxHeight = 60;
    private string _carrierProduct = string.Empty;
    private string _carrierProcedure = string.Empty;
    private string _carrierParticipation = string.Empty;

    private List<CountrySelectionRow> _allCountries = new();
    private List<CountrySelectionRow> _filteredCountries = new();
    private string _countrySearchText = string.Empty;

    private bool _isSaving;
    private string _errorMessage = string.Empty;

    public ShippingRateEditModel(
        IShippingProviderAdminService providerService,
        ICountryService countryService,
        INavigator navigator,
        IStringLocalizer localizer,
        INotificationService notifications,
        ILogger<ShippingRateEditModel> logger,
        ShippingRateEditData data)
        : base(logger)
    {
        _providerService = providerService;
        _countryService = countryService;
        _navigator = navigator;
        _localizer = localizer;
        _notifications = notifications;
        _providerId = data.ProviderId;
        _providerType = data.ProviderType;
        _rateId = data.RateId;

        StartInitialization();
    }

    protected override async Task InitializeCoreAsync(CancellationToken ct)
    {
        var countries = await _countryService.GetCountriesAsync(ct);
        _allCountries = countries
            .OrderBy(c => c.Name)
            .Select(c => new CountrySelectionRow(c.Id, c.Name, c.CountryCode))
            .ToList();

        foreach (var row in _allCountries)
        {
            row.PropertyChanged += OnCountrySelectionChanged;
        }

        if (_rateId.HasValue)
        {
            var rate = await _providerService.GetRateAsync(_providerId, _rateId.Value, ct)
                ?? throw new InvalidOperationException($"Shipping option {_rateId} not found");

            Name = rate.Name;
            Description = rate.Description ?? string.Empty;
            IsActive = rate.IsActive;
            SortOrder = rate.SortOrder;
            Price = (double)rate.Price;
            MaxWeight = (double)rate.MaxWeight;
            MaxLength = (double)rate.MaxLength;
            MaxWidth = (double)rate.MaxWidth;
            MaxHeight = (double)rate.MaxHeight;
            CarrierProduct = rate.CarrierProduct ?? string.Empty;
            CarrierProcedure = rate.CarrierProcedure ?? string.Empty;
            CarrierParticipation = rate.CarrierParticipation ?? string.Empty;

            var selected = rate.AllowedCountries.Select(c => c.CountryId).ToHashSet();
            foreach (var row in _allCountries.Where(r => selected.Contains(r.Id)))
            {
                row.IsSelected = true;
            }
        }
        else
        {
            // Germany is the overwhelmingly common default destination — preselect it.
            var germany = _allCountries.FirstOrDefault(c =>
                string.Equals(c.CountryCode, "DE", StringComparison.OrdinalIgnoreCase));
            if (germany is not null)
            {
                germany.IsSelected = true;
            }
        }

        ApplyCountryFilter();
    }

    private void OnCountrySelectionChanged(object? sender, PropertyChangedEventArgs e)
    {
        OnPropertyChanged(nameof(SelectedCountrySummary));
    }

    public bool IsEditMode => _rateId.HasValue;

    public string Title => IsEditMode
        ? _localizer["ShippingRateEditPage.TitleEdit"]
        : _localizer["ShippingRateEditPage.TitleNew"];

    public bool IsDhl => _providerType == ShippingProviderType.Dhl;

    public string CarrierProductHint => _providerType switch
    {
        ShippingProviderType.Dhl => _localizer["ShippingRateEditPage.ProductHintDhl"],
        ShippingProviderType.Dpd => _localizer["ShippingRateEditPage.ProductHintDpd"],
        ShippingProviderType.Gls => _localizer["ShippingRateEditPage.ProductHintGls"],
        ShippingProviderType.Ups => _localizer["ShippingRateEditPage.ProductHintUps"],
        _ => string.Empty
    };

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    public bool IsActive
    {
        get => _isActive;
        set => SetProperty(ref _isActive, value);
    }

    public int SortOrder
    {
        get => _sortOrder;
        set => SetProperty(ref _sortOrder, value);
    }

    public double Price
    {
        get => _price;
        set => SetProperty(ref _price, value);
    }

    public double MaxWeight
    {
        get => _maxWeight;
        set => SetProperty(ref _maxWeight, value);
    }

    public double MaxLength
    {
        get => _maxLength;
        set => SetProperty(ref _maxLength, value);
    }

    public double MaxWidth
    {
        get => _maxWidth;
        set => SetProperty(ref _maxWidth, value);
    }

    public double MaxHeight
    {
        get => _maxHeight;
        set => SetProperty(ref _maxHeight, value);
    }

    public string CarrierProduct
    {
        get => _carrierProduct;
        set => SetProperty(ref _carrierProduct, value);
    }

    public string CarrierProcedure
    {
        get => _carrierProcedure;
        set => SetProperty(ref _carrierProcedure, value);
    }

    public string CarrierParticipation
    {
        get => _carrierParticipation;
        set => SetProperty(ref _carrierParticipation, value);
    }

    public List<CountrySelectionRow> FilteredCountries
    {
        get => _filteredCountries;
        private set => SetProperty(ref _filteredCountries, value);
    }

    public string CountrySearchText
    {
        get => _countrySearchText;
        set
        {
            if (SetProperty(ref _countrySearchText, value))
            {
                ApplyCountryFilter();
            }
        }
    }

    public string SelectedCountrySummary => string.Format(
        _localizer["ShippingRateEditPage.CountriesSelected"],
        _allCountries.Count(c => c.IsSelected));

    private void ApplyCountryFilter()
    {
        var search = _countrySearchText.Trim();

        FilteredCountries = string.IsNullOrEmpty(search)
            ? _allCountries.ToList()
            : _allCountries
                .Where(c => c.Name.Contains(search, StringComparison.OrdinalIgnoreCase)
                    || c.CountryCode.Contains(search, StringComparison.OrdinalIgnoreCase))
                .ToList();

        OnPropertyChanged(nameof(SelectedCountrySummary));
    }

    /// <summary>Selects every currently visible (filtered) country.</summary>
    public void SelectVisibleCountries()
    {
        foreach (var row in FilteredCountries)
        {
            row.IsSelected = true;
        }
    }

    /// <summary>Deselects every currently visible (filtered) country.</summary>
    public void DeselectVisibleCountries()
    {
        foreach (var row in FilteredCountries)
        {
            row.IsSelected = false;
        }
    }

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

    public bool IsLoading => IsInitializing || IsSaving;
    public bool IsNotLoading => !IsLoading;

    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public bool CanSave => !IsLoading && !string.IsNullOrWhiteSpace(Name);

    public async Task SaveAsync(CancellationToken ct = default)
    {
        if (!CanSave)
        {
            return;
        }

        IsSaving = true;
        ErrorMessage = string.Empty;

        try
        {
            var selectedCountryIds = _allCountries.Where(c => c.IsSelected).Select(c => c.Id).ToList();
            var isNew = !_rateId.HasValue;

            if (_rateId.HasValue)
            {
                var update = new ShippingProviderRateUpdateDto
                {
                    ShippingProviderId = _providerId,
                    Name = Name.Trim(),
                    Description = string.IsNullOrWhiteSpace(Description) ? null : Description.Trim(),
                    IsActive = IsActive,
                    SortOrder = SortOrder,
                    CarrierProduct = string.IsNullOrWhiteSpace(CarrierProduct) ? null : CarrierProduct.Trim(),
                    CarrierProcedure = string.IsNullOrWhiteSpace(CarrierProcedure) ? null : CarrierProcedure.Trim(),
                    CarrierParticipation = string.IsNullOrWhiteSpace(CarrierParticipation) ? null : CarrierParticipation.Trim(),
                    Price = (decimal)Price,
                    MaxWeight = (decimal)MaxWeight,
                    MaxLength = (decimal)MaxLength,
                    MaxWidth = (decimal)MaxWidth,
                    MaxHeight = (decimal)MaxHeight,
                    AllowedCountryIds = selectedCountryIds
                };

                await _providerService.UpdateRateAsync(_providerId, _rateId.Value, update, ct);
            }
            else
            {
                var create = new ShippingProviderRateCreateDto
                {
                    ShippingProviderId = _providerId,
                    Name = Name.Trim(),
                    Description = string.IsNullOrWhiteSpace(Description) ? null : Description.Trim(),
                    IsActive = IsActive,
                    SortOrder = SortOrder,
                    CarrierProduct = string.IsNullOrWhiteSpace(CarrierProduct) ? null : CarrierProduct.Trim(),
                    CarrierProcedure = string.IsNullOrWhiteSpace(CarrierProcedure) ? null : CarrierProcedure.Trim(),
                    CarrierParticipation = string.IsNullOrWhiteSpace(CarrierParticipation) ? null : CarrierParticipation.Trim(),
                    Price = (decimal)Price,
                    MaxWeight = (decimal)MaxWeight,
                    MaxLength = (decimal)MaxLength,
                    MaxWidth = (decimal)MaxWidth,
                    MaxHeight = (decimal)MaxHeight,
                    AllowedCountryIds = selectedCountryIds
                };

                await _providerService.CreateRateAsync(_providerId, create, ct);
            }

            _notifications.Show(
                string.Format(_localizer[isNew ? "ShippingRateEditPage.ToastCreated" : "ShippingRateEditPage.ToastUpdated"], Name),
                NotificationSeverity.Success);

            await _navigator.NavigateBackAsync(this);
        }
        catch (ApiException ex)
        {
            ErrorMessage = ex.CombinedMessage;
        }
        catch (Exception ex)
        {
            ErrorMessage = string.Format(_localizer["ShippingRateEditPage.SaveFailed"], ex.Message);
        }
        finally
        {
            IsSaving = false;
        }
    }

    public async Task DeleteAsync(XamlRoot xamlRoot)
    {
        if (!_rateId.HasValue)
        {
            return;
        }

        var confirmed = await ConfirmDialog.ShowAsync(
            xamlRoot,
            "ShippingRateEditPage.DeleteConfirmTitle",
            "ShippingRateEditPage.DeleteConfirmMessage");
        if (!confirmed)
        {
            return;
        }

        IsSaving = true;
        ErrorMessage = string.Empty;

        try
        {
            await _providerService.DeleteRateAsync(_providerId, _rateId.Value);

            _notifications.Show(
                string.Format(_localizer["ShippingRateEditPage.ToastDeleted"], Name),
                NotificationSeverity.Success);

            await _navigator.NavigateBackAsync(this);
        }
        catch (ApiException ex)
        {
            ErrorMessage = ex.CombinedMessage;
        }
        catch (Exception ex)
        {
            ErrorMessage = string.Format(_localizer["ShippingRateEditPage.SaveFailed"], ex.Message);
        }
        finally
        {
            IsSaving = false;
        }
    }

    public async Task CancelAsync()
    {
        await _navigator.NavigateBackAsync(this);
    }

    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        // Initialization/save continuations resume on a background thread — see CategoryEditModel.
        RunOnUi(() =>
        {
            RaisePropertyChanged(propertyName);

            if (propertyName is nameof(Name))
            {
                RaisePropertyChanged(nameof(CanSave));
            }

            if (propertyName is nameof(IsInitializing))
            {
                RaisePropertyChanged(nameof(IsLoading));
                RaisePropertyChanged(nameof(IsNotLoading));
                RaisePropertyChanged(nameof(CanSave));
            }
        });
    }

    // base.OnPropertyChanged cannot be called from inside a lambda, hence the trampoline.
    private void RaisePropertyChanged(string? propertyName) => base.OnPropertyChanged(propertyName);

    private static void RunOnUi(Action action)
    {
        var dispatcher = App.UiDispatcher;
        if (dispatcher is null || dispatcher.HasThreadAccess)
        {
            action();
        }
        else
        {
            dispatcher.TryEnqueue(() => action());
        }
    }
}

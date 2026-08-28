using System.Runtime.CompilerServices;
using asERP.Client.Core.Abstractions;
using asERP.Client.Core.Exceptions;
using asERP.Client.Core.Helpers;
using asERP.Client.Core.Notifications;
using asERP.Client.Features.ShippingProviders.Services;
using asERP.Domain.Dtos.ShippingProvider;
using asERP.Domain.Dtos.ShippingProviderRate;
using asERP.Domain.Enums;

namespace asERP.Client.Features.ShippingProviders.Models;

/// <summary>Navigation data for ShippingProviderEditModel. A null id means "create".</summary>
public record ShippingProviderEditData(Guid? ProviderId = null);

/// <summary>A carrier-type option for the ComboBox — carrier brand names need no localization.</summary>
public partial record ShippingProviderTypeOption(ShippingProviderType Value, string Display);

/// <summary>A shipping option ("Versandart") row inside the carrier edit page.</summary>
public partial record ShippingRateRow(
    Guid Id,
    string Name,
    bool IsActive,
    string CarrierProduct,
    string PriceDisplay,
    string MaxWeightDisplay,
    int AllowedCountryCount);

public class ShippingProviderEditModel : AsyncInitializableModel
{
    private readonly IShippingProviderAdminService _providerService;
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;
    private readonly INotificationService _notifications;

    private Guid? _providerId;

    private string _name = string.Empty;
    private ShippingProviderTypeOption? _selectedType;
    private bool _isEnabled = true;
    private bool _useSandbox;
    private string _username = string.Empty;
    private string _password = string.Empty;
    private string _apiKey = string.Empty;
    private string _apiSecret = string.Empty;
    private string _accountNumber = string.Empty;
    private int _trackingPollIntervalSeconds = 3600;
    private bool _hasPassword;
    private bool _hasApiKey;
    private bool _hasApiSecret;

    private CarrierConfigEditor _config = new();
    private List<ShippingRateRow> _rates = new();

    private bool _isSaving;
    private string _errorMessage = string.Empty;

    public ShippingProviderEditModel(
        IShippingProviderAdminService providerService,
        INavigator navigator,
        IStringLocalizer localizer,
        INotificationService notifications,
        ILogger<ShippingProviderEditModel> logger,
        ShippingProviderEditData? data = null)
        : base(logger)
    {
        _providerService = providerService;
        _navigator = navigator;
        _localizer = localizer;
        _notifications = notifications;
        _providerId = data?.ProviderId;

        TypeOptions = new List<ShippingProviderTypeOption>
        {
            new(ShippingProviderType.Dhl, "DHL"),
            new(ShippingProviderType.Dpd, "DPD"),
            new(ShippingProviderType.Gls, "GLS"),
            new(ShippingProviderType.Ups, "UPS")
        };
        _selectedType = TypeOptions[0];

        StartInitialization();
    }

    protected override async Task InitializeCoreAsync(CancellationToken ct)
    {
        if (!_providerId.HasValue)
        {
            return;
        }

        var provider = await _providerService.GetProviderAsync(_providerId.Value, ct)
            ?? throw new InvalidOperationException($"Shipping provider {_providerId} not found");

        ApplyProvider(provider);
    }

    private void ApplyProvider(ShippingProviderDetailDto provider)
    {
        Name = provider.Name;
        SelectedType = TypeOptions.FirstOrDefault(o => o.Value == provider.Type) ?? TypeOptions[0];
        IsEnabled = provider.IsEnabled;
        UseSandbox = provider.UseSandbox;
        Username = provider.Username;
        AccountNumber = provider.AccountNumber ?? string.Empty;
        TrackingPollIntervalSeconds = provider.TrackingPollIntervalSeconds;
        HasPassword = provider.HasPassword;
        HasApiKey = provider.HasApiKey;
        HasApiSecret = provider.HasApiSecret;

        // Secrets are never echoed by the server; blank means "keep as stored".
        Password = string.Empty;
        ApiKey = string.Empty;
        ApiSecret = string.Empty;

        _config = CarrierConfigEditor.Parse(provider.AdditionalConfigJson);
        RaiseConfigProperties();

        Rates = provider.Rates.Select(ToRateRow).ToList();
    }

    private static ShippingRateRow ToRateRow(ShippingProviderRateListDto rate) => new(
        rate.Id,
        rate.Name,
        rate.IsActive,
        rate.CarrierProduct ?? string.Empty,
        string.Format("{0:N2} €", rate.Price),
        string.Format("{0:0.##} kg", rate.MaxWeight),
        rate.AllowedCountryCount);

    public List<ShippingProviderTypeOption> TypeOptions { get; }

    public bool IsEditMode => _providerId.HasValue;

    public string Title => IsEditMode
        ? _localizer["ShippingProviderEditPage.TitleEdit"]
        : _localizer["ShippingProviderEditPage.TitleNew"];

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public ShippingProviderTypeOption? SelectedType
    {
        get => _selectedType;
        set
        {
            if (SetProperty(ref _selectedType, value))
            {
                OnPropertyChanged(nameof(IsDhl));
                OnPropertyChanged(nameof(IsDpd));
                OnPropertyChanged(nameof(IsGls));
                OnPropertyChanged(nameof(IsUps));
                OnPropertyChanged(nameof(CredentialsHint));
            }
        }
    }

    /// <summary>Changing the carrier of an existing account would break its booked shipments.</summary>
    public bool CanSelectType => !IsEditMode;

    public bool IsDhl => SelectedType?.Value == ShippingProviderType.Dhl;
    public bool IsDpd => SelectedType?.Value == ShippingProviderType.Dpd;
    public bool IsGls => SelectedType?.Value == ShippingProviderType.Gls;
    public bool IsUps => SelectedType?.Value == ShippingProviderType.Ups;

    public string CredentialsHint => SelectedType?.Value switch
    {
        ShippingProviderType.Dhl => _localizer["ShippingProviderEditPage.CredentialsHintDhl"],
        ShippingProviderType.Dpd => _localizer["ShippingProviderEditPage.CredentialsHintDpd"],
        ShippingProviderType.Gls => _localizer["ShippingProviderEditPage.CredentialsHintGls"],
        ShippingProviderType.Ups => _localizer["ShippingProviderEditPage.CredentialsHintUps"],
        _ => string.Empty
    };

    public bool IsEnabled
    {
        get => _isEnabled;
        set => SetProperty(ref _isEnabled, value);
    }

    public bool UseSandbox
    {
        get => _useSandbox;
        set => SetProperty(ref _useSandbox, value);
    }

    public string Username
    {
        get => _username;
        set => SetProperty(ref _username, value);
    }

    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    public string ApiKey
    {
        get => _apiKey;
        set => SetProperty(ref _apiKey, value);
    }

    public string ApiSecret
    {
        get => _apiSecret;
        set => SetProperty(ref _apiSecret, value);
    }

    public string AccountNumber
    {
        get => _accountNumber;
        set => SetProperty(ref _accountNumber, value);
    }

    public int TrackingPollIntervalSeconds
    {
        get => _trackingPollIntervalSeconds;
        set => SetProperty(ref _trackingPollIntervalSeconds, value);
    }

    public bool HasPassword
    {
        get => _hasPassword;
        private set
        {
            if (SetProperty(ref _hasPassword, value))
            {
                OnPropertyChanged(nameof(PasswordPlaceholder));
            }
        }
    }

    public bool HasApiKey
    {
        get => _hasApiKey;
        private set
        {
            if (SetProperty(ref _hasApiKey, value))
            {
                OnPropertyChanged(nameof(ApiKeyPlaceholder));
            }
        }
    }

    public bool HasApiSecret
    {
        get => _hasApiSecret;
        private set
        {
            if (SetProperty(ref _hasApiSecret, value))
            {
                OnPropertyChanged(nameof(ApiSecretPlaceholder));
            }
        }
    }

    public string PasswordPlaceholder => HasPassword
        ? _localizer["ShippingProviderEditPage.SecretStored"]
        : _localizer["ShippingProviderEditPage.SecretEmpty"];

    public string ApiKeyPlaceholder => HasApiKey
        ? _localizer["ShippingProviderEditPage.SecretStored"]
        : _localizer["ShippingProviderEditPage.SecretEmpty"];

    public string ApiSecretPlaceholder => HasApiSecret
        ? _localizer["ShippingProviderEditPage.SecretStored"]
        : _localizer["ShippingProviderEditPage.SecretEmpty"];

    // Carrier config passthrough properties (bound by the carrier-specific sections).

    public string SenderName
    {
        get => _config.SenderName;
        set { _config.SenderName = value; OnPropertyChanged(); }
    }

    public string SenderStreet
    {
        get => _config.SenderStreet;
        set { _config.SenderStreet = value; OnPropertyChanged(); }
    }

    public string SenderZip
    {
        get => _config.SenderZip;
        set { _config.SenderZip = value; OnPropertyChanged(); }
    }

    public string SenderCity
    {
        get => _config.SenderCity;
        set { _config.SenderCity = value; OnPropertyChanged(); }
    }

    public string SenderCountryCode
    {
        get => _config.SenderCountryCode;
        set { _config.SenderCountryCode = value; OnPropertyChanged(); }
    }

    public string SenderEmail
    {
        get => _config.SenderEmail;
        set { _config.SenderEmail = value; OnPropertyChanged(); }
    }

    public string SenderPhone
    {
        get => _config.SenderPhone;
        set { _config.SenderPhone = value; OnPropertyChanged(); }
    }

    public string ConfigProduct
    {
        get => _config.Product;
        set { _config.Product = value; OnPropertyChanged(); }
    }

    public string ConfigProcedure
    {
        get => _config.Procedure;
        set { _config.Procedure = value; OnPropertyChanged(); }
    }

    public string ConfigParticipation
    {
        get => _config.Participation;
        set { _config.Participation = value; OnPropertyChanged(); }
    }

    public string ConfigTrackingApiKey
    {
        get => _config.TrackingApiKey;
        set { _config.TrackingApiKey = value; OnPropertyChanged(); }
    }

    public string ConfigReturnReceiverId
    {
        get => _config.ReturnReceiverId;
        set { _config.ReturnReceiverId = value; OnPropertyChanged(); }
    }

    public string ConfigReturnProcedure
    {
        get => _config.ReturnProcedure;
        set { _config.ReturnProcedure = value; OnPropertyChanged(); }
    }

    public string ConfigLabelSize
    {
        get => _config.LabelSize;
        set { _config.LabelSize = value; OnPropertyChanged(); }
    }

    public string ConfigReturnProduct
    {
        get => _config.ReturnProduct;
        set { _config.ReturnProduct = value; OnPropertyChanged(); }
    }

    public string ConfigContactId
    {
        get => _config.ContactId;
        set { _config.ContactId = value; OnPropertyChanged(); }
    }

    public string ConfigServiceCode
    {
        get => _config.ServiceCode;
        set { _config.ServiceCode = value; OnPropertyChanged(); }
    }

    private void RaiseConfigProperties()
    {
        OnPropertyChanged(nameof(SenderName));
        OnPropertyChanged(nameof(SenderStreet));
        OnPropertyChanged(nameof(SenderZip));
        OnPropertyChanged(nameof(SenderCity));
        OnPropertyChanged(nameof(SenderCountryCode));
        OnPropertyChanged(nameof(SenderEmail));
        OnPropertyChanged(nameof(SenderPhone));
        OnPropertyChanged(nameof(ConfigProduct));
        OnPropertyChanged(nameof(ConfigProcedure));
        OnPropertyChanged(nameof(ConfigParticipation));
        OnPropertyChanged(nameof(ConfigTrackingApiKey));
        OnPropertyChanged(nameof(ConfigReturnReceiverId));
        OnPropertyChanged(nameof(ConfigReturnProcedure));
        OnPropertyChanged(nameof(ConfigLabelSize));
        OnPropertyChanged(nameof(ConfigReturnProduct));
        OnPropertyChanged(nameof(ConfigContactId));
        OnPropertyChanged(nameof(ConfigServiceCode));
    }

    public List<ShippingRateRow> Rates
    {
        get => _rates;
        private set
        {
            if (SetProperty(ref _rates, value))
            {
                OnPropertyChanged(nameof(ShowRatesEmptyState));
            }
        }
    }

    public bool ShowRatesEmptyState => IsEditMode && Rates.Count == 0;

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

    public bool CanSave => !IsLoading && !string.IsNullOrWhiteSpace(Name) && SelectedType is not null;

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
            var configJson = _config.ToJson();
            var isNew = !_providerId.HasValue;

            if (_providerId.HasValue)
            {
                var update = new ShippingProviderUpdateDto
                {
                    Name = Name.Trim(),
                    Type = SelectedType!.Value,
                    IsEnabled = IsEnabled,
                    UseSandbox = UseSandbox,
                    Username = Username.Trim(),
                    // Blank secret fields mean "keep the stored secret".
                    Password = Password,
                    ApiKey = string.IsNullOrEmpty(ApiKey) ? null : ApiKey,
                    ApiSecret = string.IsNullOrEmpty(ApiSecret) ? null : ApiSecret,
                    AccountNumber = string.IsNullOrWhiteSpace(AccountNumber) ? null : AccountNumber.Trim(),
                    AdditionalConfigJson = configJson,
                    TrackingPollIntervalSeconds = TrackingPollIntervalSeconds
                };

                await _providerService.UpdateProviderAsync(_providerId.Value, update, ct);
            }
            else
            {
                var create = new ShippingProviderCreateDto
                {
                    Name = Name.Trim(),
                    Type = SelectedType!.Value,
                    IsEnabled = IsEnabled,
                    UseSandbox = UseSandbox,
                    Username = Username.Trim(),
                    Password = Password,
                    ApiKey = string.IsNullOrEmpty(ApiKey) ? null : ApiKey,
                    ApiSecret = string.IsNullOrEmpty(ApiSecret) ? null : ApiSecret,
                    AccountNumber = string.IsNullOrWhiteSpace(AccountNumber) ? null : AccountNumber.Trim(),
                    AdditionalConfigJson = configJson,
                    TrackingPollIntervalSeconds = TrackingPollIntervalSeconds
                };

                var newId = await _providerService.CreateProviderAsync(create, ct);
                if (newId != Guid.Empty)
                {
                    // Stay on the page in edit mode so shipping options can be added right away.
                    _providerId = newId;
                    OnPropertyChanged(nameof(IsEditMode));
                    OnPropertyChanged(nameof(Title));
                    OnPropertyChanged(nameof(CanSelectType));
                    OnPropertyChanged(nameof(ShowRatesEmptyState));
                }
            }

            _notifications.Show(
                string.Format(_localizer[isNew ? "ShippingProviderEditPage.ToastCreated" : "ShippingProviderEditPage.ToastUpdated"], Name),
                NotificationSeverity.Success);

            if (isNew)
            {
                await ReloadAsync(ct);
            }
            else
            {
                await _navigator.NavigateBackAsync(this);
            }
        }
        catch (ApiException ex)
        {
            ErrorMessage = ex.CombinedMessage;
        }
        catch (Exception ex)
        {
            ErrorMessage = string.Format(_localizer["ShippingProviderEditPage.SaveFailed"], ex.Message);
        }
        finally
        {
            IsSaving = false;
        }
    }

    public async Task ReloadAsync(CancellationToken ct = default)
    {
        if (!_providerId.HasValue)
        {
            return;
        }

        try
        {
            var provider = await _providerService.GetProviderAsync(_providerId.Value, ct);
            if (provider is not null)
            {
                ApplyProvider(provider);
            }
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    public async Task DeleteAsync(XamlRoot xamlRoot)
    {
        if (!_providerId.HasValue)
        {
            return;
        }

        var confirmed = await ConfirmDialog.ShowAsync(
            xamlRoot,
            "ShippingProviderEditPage.DeleteConfirmTitle",
            "ShippingProviderEditPage.DeleteConfirmMessage");
        if (!confirmed)
        {
            return;
        }

        IsSaving = true;
        ErrorMessage = string.Empty;

        try
        {
            await _providerService.DeleteProviderAsync(_providerId.Value);

            _notifications.Show(
                string.Format(_localizer["ShippingProviderEditPage.ToastDeleted"], Name),
                NotificationSeverity.Success);

            await _navigator.NavigateBackAsync(this);
        }
        catch (ApiException ex)
        {
            ErrorMessage = ex.CombinedMessage;
        }
        catch (Exception ex)
        {
            ErrorMessage = string.Format(_localizer["ShippingProviderEditPage.SaveFailed"], ex.Message);
        }
        finally
        {
            IsSaving = false;
        }
    }

    public async Task AddRateAsync()
    {
        if (!_providerId.HasValue || SelectedType is null)
        {
            return;
        }

        await _navigator.NavigateDataAsync(this, new ShippingRateEditData(_providerId.Value, SelectedType.Value));
    }

    public async Task EditRateAsync(ShippingRateRow row)
    {
        if (!_providerId.HasValue || SelectedType is null)
        {
            return;
        }

        await _navigator.NavigateDataAsync(this, new ShippingRateEditData(_providerId.Value, SelectedType.Value, row.Id));
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

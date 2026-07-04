using System.Runtime.CompilerServices;
using asToolkit.Client.Core.Abstractions;
using asToolkit.Client.Core.Exceptions;
using asToolkit.Client.Features.GlobalSettings.Services;
using asToolkit.Domain.Dtos.GlobalSettings;
using asToolkit.Domain.Dtos.SystemOAuthSettings;
using asToolkit.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace asToolkit.Client.Features.GlobalSettings.Models;

/// <summary>
/// Superadmin page for all global settings. The OAuth tab edits the system-wide
/// <c>OAuth.{Provider}.*</c> bundle (one provider at a time, secret write-only — ported from
/// the former SystemOAuthSettingsModel). The remaining tabs edit the generic global Setting
/// rows grouped by key prefix; secret rows are write-only the same way.
/// </summary>
public class GlobalSettingsModel : AsyncInitializableModel
{
    /// <summary>Key prefix → tab. Prefixes not listed here land on the "General" tab.</summary>
    private static readonly Dictionary<string, SettingsTab> TabByPrefix = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Email"] = SettingsTab.Email,
        ["Jwt"] = SettingsTab.Authentication,
        ["Telemetry"] = SettingsTab.Observability,
        ["Grafana"] = SettingsTab.Observability,
        ["ClickHouse"] = SettingsTab.Observability,
    };

    /// <summary>Fixed group order on the "General" tab; unknown prefixes follow alphabetically.</summary>
    private static readonly string[] GeneralGroupOrder = ["Company", "System", "Invoice", "Sales", "Notification"];

    private enum SettingsTab { General, Email, Authentication, Observability }

    private readonly IGlobalSettingsService _globalSettingsService;
    private readonly ISystemOAuthSettingsService _oauthService;
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;

    private SalesChannelType _selectedProvider = SalesChannelType.eBay;
    private string _clientId = string.Empty;
    private string _clientSecret = string.Empty;
    private bool _hasClientSecret;
    private string _ruName = string.Empty;
    private string _redirectUri = string.Empty;
    private string _authorizationEndpoint = string.Empty;
    private string _tokenEndpoint = string.Empty;
    private string _scopes = string.Empty;
    private bool _useSandbox;
    private string _publicBaseUrl = string.Empty;

    private IReadOnlyList<GlobalSettingGroup> _generalGroups = [];
    private IReadOnlyList<GlobalSettingGroup> _emailGroups = [];
    private IReadOnlyList<GlobalSettingGroup> _authenticationGroups = [];
    private IReadOnlyList<GlobalSettingGroup> _observabilityGroups = [];

    private bool _isSaving;
    private string _statusMessage = string.Empty;
    private string _errorMessage = string.Empty;

    public GlobalSettingsModel(
        IGlobalSettingsService globalSettingsService,
        ISystemOAuthSettingsService oauthService,
        INavigator navigator,
        IStringLocalizer localizer,
        ILogger<GlobalSettingsModel> logger)
        : base(logger)
    {
        _globalSettingsService = globalSettingsService;
        _oauthService = oauthService;
        _navigator = navigator;
        _localizer = localizer;
        StartInitialization();
    }

    protected override async Task InitializeCoreAsync(CancellationToken ct)
    {
        await LoadOAuthAsync(ct);
        await LoadGlobalSettingsAsync(ct);
    }

    // ---- OAuth tab (system OAuth app bundle, one provider at a time) ----

    public SalesChannelType SelectedProvider
    {
        get => _selectedProvider;
        set
        {
            if (SetProperty(ref _selectedProvider, value))
            {
                _ = LoadOAuthAsync(CancellationToken.None);
            }
        }
    }

    /// <summary>Bool wrappers for the plain RadioButton bindings on the OAuth tab.</summary>
    public bool IsEbaySelected
    {
        get => _selectedProvider == SalesChannelType.eBay;
        set { if (value) SelectedProvider = SalesChannelType.eBay; }
    }
    public bool IsAmazonSelected
    {
        get => _selectedProvider == SalesChannelType.Amazon;
        set { if (value) SelectedProvider = SalesChannelType.Amazon; }
    }

    public string ClientId { get => _clientId; set => SetProperty(ref _clientId, value); }
    public string ClientSecret { get => _clientSecret; set => SetProperty(ref _clientSecret, value); }
    public bool HasClientSecret { get => _hasClientSecret; private set => SetProperty(ref _hasClientSecret, value); }
    public string ClientSecretPlaceholder => _hasClientSecret
        ? _localizer["GlobalSettings.ClientSecretSetHint"]
        : string.Empty;

    public string RuName { get => _ruName; set => SetProperty(ref _ruName, value); }
    public string RedirectUri { get => _redirectUri; set => SetProperty(ref _redirectUri, value); }
    public string AuthorizationEndpoint { get => _authorizationEndpoint; set => SetProperty(ref _authorizationEndpoint, value); }
    public string TokenEndpoint { get => _tokenEndpoint; set => SetProperty(ref _tokenEndpoint, value); }
    public string Scopes { get => _scopes; set => SetProperty(ref _scopes, value); }
    public bool UseSandbox { get => _useSandbox; set => SetProperty(ref _useSandbox, value); }
    public string PublicBaseUrl { get => _publicBaseUrl; set => SetProperty(ref _publicBaseUrl, value); }

    public bool IsRuNameRelevant => _selectedProvider == SalesChannelType.eBay;
    public bool IsRedirectUriRelevant => _selectedProvider == SalesChannelType.Amazon;

    // ---- Generic tabs (grouped key/value rows) ----

    public IReadOnlyList<GlobalSettingGroup> GeneralGroups
    {
        get => _generalGroups;
        private set => SetProperty(ref _generalGroups, value);
    }
    public IReadOnlyList<GlobalSettingGroup> EmailGroups
    {
        get => _emailGroups;
        private set => SetProperty(ref _emailGroups, value);
    }
    public IReadOnlyList<GlobalSettingGroup> AuthenticationGroups
    {
        get => _authenticationGroups;
        private set => SetProperty(ref _authenticationGroups, value);
    }
    public IReadOnlyList<GlobalSettingGroup> ObservabilityGroups
    {
        get => _observabilityGroups;
        private set => SetProperty(ref _observabilityGroups, value);
    }

    public bool IsSaving { get => _isSaving; private set => SetProperty(ref _isSaving, value); }
    public string StatusMessage { get => _statusMessage; private set => SetProperty(ref _statusMessage, value); }
    public string ErrorMessage { get => _errorMessage; private set => SetProperty(ref _errorMessage, value); }

    public async Task SaveAsync(CancellationToken ct = default)
    {
        IsSaving = true;
        StatusMessage = string.Empty;
        ErrorMessage = string.Empty;
        try
        {
            await _globalSettingsService.UpdateAsync(BuildUpdateInput(), ct);

            await _oauthService.UpsertAsync(
                _selectedProvider.ToString().ToLowerInvariant(),
                new SystemOAuthSettingsInputDto
                {
                    ClientId = ClientId,
                    // Empty input means "do not rotate" — let it stay null on the wire.
                    ClientSecret = string.IsNullOrEmpty(ClientSecret) ? null : ClientSecret,
                    RuName = RuName,
                    RedirectUri = RedirectUri,
                    AuthorizationEndpoint = AuthorizationEndpoint,
                    TokenEndpoint = TokenEndpoint,
                    Scopes = Scopes,
                    UseSandbox = UseSandbox,
                    PublicBaseUrl = PublicBaseUrl,
                },
                ct);

            // Clear the secret field; reload to pick up the "secret is stored" hints.
            ClientSecret = string.Empty;
            await LoadOAuthAsync(ct);
            await LoadGlobalSettingsAsync(ct);
            StatusMessage = _localizer["GlobalSettings.SaveSucceeded"];
        }
        catch (ApiException ex)
        {
            ErrorMessage = ex.CombinedMessage;
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
        finally
        {
            IsSaving = false;
        }
    }

    public async Task GoBackAsync()
    {
        await _navigator.NavigateBackAsync(this);
    }

    private GlobalSettingsUpdateInputDto BuildUpdateInput()
    {
        var input = new GlobalSettingsUpdateInputDto();
        var groups = GeneralGroups.Concat(EmailGroups).Concat(AuthenticationGroups).Concat(ObservabilityGroups);
        foreach (var entry in groups.SelectMany(g => g.Entries))
        {
            // Secrets are write-only: an empty field means "keep the stored value", so it is
            // not sent at all. Non-secrets are sent as-is; the server skips unchanged values.
            if (entry.IsSecret && entry.Value.Length == 0)
            {
                continue;
            }
            input.Settings.Add(new GlobalSettingValueInputDto { Key = entry.Key, Value = entry.Value });
        }
        return input;
    }

    private async Task LoadOAuthAsync(CancellationToken ct)
    {
        try
        {
            var dto = await _oauthService.GetAsync(_selectedProvider.ToString().ToLowerInvariant(), ct);
            if (dto is null) return;

            ClientId = dto.ClientId ?? string.Empty;
            HasClientSecret = dto.HasClientSecret;
            RuName = dto.RuName ?? string.Empty;
            RedirectUri = dto.RedirectUri ?? string.Empty;
            AuthorizationEndpoint = dto.AuthorizationEndpoint ?? string.Empty;
            TokenEndpoint = dto.TokenEndpoint ?? string.Empty;
            Scopes = dto.Scopes ?? string.Empty;
            UseSandbox = dto.UseSandbox;
            PublicBaseUrl = dto.PublicBaseUrl ?? string.Empty;

            OnPropertyChanged(nameof(IsRuNameRelevant));
            OnPropertyChanged(nameof(IsRedirectUriRelevant));
            OnPropertyChanged(nameof(ClientSecretPlaceholder));
        }
        catch (ApiException ex)
        {
            ErrorMessage = ex.CombinedMessage;
        }
    }

    private async Task LoadGlobalSettingsAsync(CancellationToken ct)
    {
        try
        {
            var settings = await _globalSettingsService.GetAllAsync(ct);
            if (settings is null) return;

            var groups = settings
                .GroupBy(GroupPrefix, StringComparer.OrdinalIgnoreCase)
                .Select(g => new
                {
                    Prefix = g.Key,
                    Group = new GlobalSettingGroup(
                        ResolveGroupTitle(g.Key),
                        g.OrderBy(s => s.Key, StringComparer.OrdinalIgnoreCase)
                            .Select(s => new GlobalSettingEntry(s.Key, s.Value, s.IsSecret, s.HasValue))
                            .ToList()),
                })
                .ToList();

            GeneralGroups = groups
                .Where(g => ResolveTab(g.Prefix) == SettingsTab.General)
                .OrderBy(g => GeneralOrderIndex(g.Prefix))
                .ThenBy(g => g.Prefix, StringComparer.OrdinalIgnoreCase)
                .Select(g => g.Group)
                .ToList();
            EmailGroups = TabGroups(SettingsTab.Email);
            AuthenticationGroups = TabGroups(SettingsTab.Authentication);
            ObservabilityGroups = TabGroups(SettingsTab.Observability);

            IReadOnlyList<GlobalSettingGroup> TabGroups(SettingsTab tab) => groups
                .Where(g => ResolveTab(g.Prefix) == tab)
                .OrderBy(g => g.Prefix, StringComparer.OrdinalIgnoreCase)
                .Select(g => g.Group)
                .ToList();
        }
        catch (ApiException ex)
        {
            ErrorMessage = ex.CombinedMessage;
        }
    }

    private static string GroupPrefix(GlobalSettingDto dto)
    {
        var separator = dto.Key.IndexOf('.');
        return separator > 0 ? dto.Key[..separator] : dto.Key;
    }

    private static SettingsTab ResolveTab(string prefix) =>
        TabByPrefix.TryGetValue(prefix, out var tab) ? tab : SettingsTab.General;

    private static int GeneralOrderIndex(string prefix)
    {
        var index = Array.FindIndex(GeneralGroupOrder,
            p => p.Equals(prefix, StringComparison.OrdinalIgnoreCase));
        return index >= 0 ? index : GeneralGroupOrder.Length;
    }

    private string ResolveGroupTitle(string prefix)
    {
        // Single-dot 2-segment key per localization rules; unknown prefixes fall back to the
        // raw technical prefix so future setting groups appear without a resw change.
        var localized = _localizer[$"GlobalSettings.Group{prefix}"];
        return localized.ResourceNotFound ? prefix : localized.Value;
    }

    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == nameof(SelectedProvider))
        {
            base.OnPropertyChanged(nameof(IsEbaySelected));
            base.OnPropertyChanged(nameof(IsAmazonSelected));
            base.OnPropertyChanged(nameof(IsRuNameRelevant));
            base.OnPropertyChanged(nameof(IsRedirectUriRelevant));
        }
        if (propertyName == nameof(HasClientSecret))
        {
            base.OnPropertyChanged(nameof(ClientSecretPlaceholder));
        }
    }
}

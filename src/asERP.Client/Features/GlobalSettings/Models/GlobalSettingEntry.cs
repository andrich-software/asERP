using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace asERP.Client.Features.GlobalSettings.Models;

/// <summary>
/// One editable global Setting row. For secret rows <see cref="Value"/> starts empty (the
/// server never returns the secret); the user fills it only to set/rotate, and
/// <see cref="HasStoredValue"/> drives the "a secret is stored" hint.
/// </summary>
public class GlobalSettingEntry : INotifyPropertyChanged
{
    private string _value = string.Empty;

    public GlobalSettingEntry(string key, string value, bool isSecret, bool hasStoredValue)
    {
        Key = key;
        _value = value;
        IsSecret = isSecret;
        HasStoredValue = hasStoredValue;
        IsBoolean = !isSecret && bool.TryParse(value, out _);

        var separator = key.IndexOf('.');
        Label = separator > 0 ? key[(separator + 1)..] : key;
    }

    public string Key { get; }

    /// <summary>Key suffix after the group prefix — the visible field label.</summary>
    public string Label { get; }

    public bool IsSecret { get; }
    public bool HasStoredValue { get; }
    public bool ShowSecretHint => IsSecret && HasStoredValue;

    /// <summary>
    /// True/False rows render as a ToggleSwitch instead of a free-text box. Detected once
    /// from the stored value so a non-boolean row can never be locked out of free editing.
    /// </summary>
    public bool IsBoolean { get; }
    public bool IsPlainText => !IsSecret && !IsBoolean;

    /// <summary>ToggleSwitch binding; writes back the canonical "True"/"False" strings.</summary>
    public bool BoolValue
    {
        get => bool.TryParse(_value, out var parsed) && parsed;
        set => Value = value ? "True" : "False";
    }

    public string Value
    {
        get => _value;
        set
        {
            if (_value == value) return;
            _value = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(BoolValue));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

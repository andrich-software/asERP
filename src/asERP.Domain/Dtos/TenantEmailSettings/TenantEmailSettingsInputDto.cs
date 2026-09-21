using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.TenantEmailSettings;

/// <summary>
/// Input DTO used to create or update the email configuration of a tenant.
/// All non-ProviderType fields are optional — empty values inherit from the server-level configuration.
/// </summary>
public class TenantEmailSettingsInputDto
{
    public EmailProviderType ProviderType { get; set; } = EmailProviderType.Smtp;
    public bool IsActive { get; set; } = true;

    // SMTP
    public string? SmtpHost { get; set; }
    public int? SmtpPort { get; set; }
    public string? SmtpUsername { get; set; }
    public string? SmtpPassword { get; set; }

    /// <summary>
    /// Kept for compatibility, and no longer a way to turn encryption off: the server dials every
    /// SMTP endpoint with TLS (implicit on 465, STARTTLS elsewhere), and only the server operator's
    /// own setting can ask for a cleartext session. Setting this field at all makes the transport the
    /// tenant's choice, and a tenant's choice is encrypted, whichever value it carries. Null inherits
    /// the server-level value, as every optional field here does.
    /// </summary>
    public bool? SmtpEnableSsl { get; set; }

    // Microsoft 365
    public string? M365TenantId { get; set; }
    public string? M365ClientId { get; set; }
    public string? M365ClientSecret { get; set; }
    public string? M365SenderAddress { get; set; }

    // From / Reply-To
    public string? FromAddress { get; set; }
    public string? FromName { get; set; }
    public string? ReplyToAddress { get; set; }
    public string? ReplyToName { get; set; }
}

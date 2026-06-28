using asToolkit.Domain.Enums;

namespace asToolkit.Application.Models.Email;

/// <summary>
/// Effective email configuration used by <see cref="asToolkit.Application.Contracts.Infrastructure.IEmailProvider"/>.
/// Resolved by the email service from the tenant override merged onto the server-level defaults.
/// </summary>
public class EmailSettings
{
    public EmailProviderType ProviderType { get; set; } = EmailProviderType.Smtp;

    // SMTP
    public string? SmtpHost { get; set; }
    public int? SmtpPort { get; set; }
    public string? SmtpUsername { get; set; }
    public string? SmtpPassword { get; set; }
    public bool SmtpEnableSsl { get; set; } = true;

    // Microsoft 365 (Graph API, client credentials / app-only)
    public string? M365TenantId { get; set; }
    public string? M365ClientId { get; set; }
    public string? M365ClientSecret { get; set; }
    public string? M365SenderAddress { get; set; }

    // From / Reply-To
    public string FromAddress { get; set; } = string.Empty;
    public string FromName { get; set; } = string.Empty;
    public string? ReplyToAddress { get; set; }
    public string? ReplyToName { get; set; }
}

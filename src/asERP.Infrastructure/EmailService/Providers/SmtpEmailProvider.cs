using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Models.Email;
using asERP.Domain.Enums;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace asERP.Infrastructure.EmailService.Providers;

public class SmtpEmailProvider : IEmailProvider
{
    private readonly ILogger<SmtpEmailProvider> _logger;
    private readonly SmtpEndpointGuard _endpointGuard;

    public SmtpEmailProvider(ILogger<SmtpEmailProvider> logger, SmtpEndpointGuard endpointGuard)
    {
        _logger = logger;
        _endpointGuard = endpointGuard;
    }

    public EmailProviderType ProviderType => EmailProviderType.Smtp;

    public async Task<bool> SendAsync(EmailMessage email, EmailSettings settings)
    {
        try
        {
            if (string.IsNullOrEmpty(settings.SmtpHost) || !settings.SmtpPort.HasValue)
            {
                _logger.LogError("SMTP configuration is incomplete. Host: {Host}, Port: {Port}",
                    settings.SmtpHost, settings.SmtpPort);
                return false;
            }

            // SmtpHost/SmtpPort are tenant-writable through a plain [Authorize] endpoint, so the
            // socket below is aimed by the caller unless the operator's policy agrees with the
            // target. The reason stays in the log: the caller gets the same false as any other
            // failed send and learns nothing about what is listening where.
            var refusal = await _endpointGuard.EvaluateAsync(settings);
            if (refusal != null)
            {
                _logger.LogError("Refusing to send email via SMTP to {To}: {Reason}", email.To, refusal);
                return false;
            }

            using var message = BuildMessage(email, settings);

            using var smtpClient = new SmtpClient();

            // Preserve the legacy semantics of the SmtpEnableSsl flag: when disabled, connect in the clear
            // (e.g. Mailpit on port 1025); when enabled, let MailKit pick implicit SSL (465) or STARTTLS.
            var secureSocketOptions = settings.SmtpEnableSsl
                ? SecureSocketOptions.Auto
                : SecureSocketOptions.None;

            // Verbatim, exactly as SmtpEndpointGuard saw it: neither side normalizes this string, so
            // the value that was validated is the value that is dialled.
            await smtpClient.ConnectAsync(settings.SmtpHost, settings.SmtpPort.Value, secureSocketOptions);

            if (!string.IsNullOrEmpty(settings.SmtpUsername) && !string.IsNullOrEmpty(settings.SmtpPassword))
            {
                await smtpClient.AuthenticateAsync(settings.SmtpUsername, settings.SmtpPassword);
            }

            await smtpClient.SendAsync(message);
            await smtpClient.DisconnectAsync(true);

            _logger.LogInformation("Email sent successfully via SMTP to {To}", email.To);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send email via SMTP to {To}. Error: {Error}",
                email.To, ex.Message);
            return false;
        }
    }

    private static MimeMessage BuildMessage(EmailMessage email, EmailSettings settings)
    {
        var message = new MimeMessage
        {
            Subject = email.Subject
        };

        message.From.Add(new MailboxAddress(settings.FromName, settings.FromAddress));
        message.To.Add(new MailboxAddress(email.ToName ?? email.To, email.To));

        // Add CC recipients
        foreach (var cc in email.Cc)
        {
            message.Cc.Add(MailboxAddress.Parse(cc));
        }

        // Add BCC recipients
        foreach (var bcc in email.Bcc)
        {
            message.Bcc.Add(MailboxAddress.Parse(bcc));
        }

        // Add Reply-To if configured
        if (!string.IsNullOrEmpty(settings.ReplyToAddress))
        {
            message.ReplyTo.Add(new MailboxAddress(settings.ReplyToName ?? settings.ReplyToAddress, settings.ReplyToAddress));
        }

        var bodyBuilder = new BodyBuilder();
        if (email.IsHtml)
        {
            bodyBuilder.HtmlBody = email.Body;
        }
        else
        {
            bodyBuilder.TextBody = email.Body;
        }

        // Add attachments
        foreach (var attachment in email.Attachments)
        {
            bodyBuilder.Attachments.Add(attachment.FileName, attachment.Content, ContentType.Parse(attachment.ContentType));
        }

        message.Body = bodyBuilder.ToMessageBody();

        // Add custom headers
        foreach (var header in email.Headers)
        {
            message.Headers.Add(header.Key, header.Value);
        }

        return message;
    }
}

using System.Net;
using System.Text;
using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Models.Email;

namespace asERP.Infrastructure.EmailService;

public class EmailTemplateService : IEmailTemplateService
{
    public Task<string> GeneratePasswordResetEmailAsync(string recipientName, string resetToken, string resetUrl)
    {
        // Recipient name and URL come from user input — HTML-encode everything interpolated (mirror the shipping templates).
        var encodedRecipientName = WebUtility.HtmlEncode(recipientName);
        var encodedResetUrl = WebUtility.HtmlEncode(resetUrl);
        var encodedToken = WebUtility.HtmlEncode(Uri.EscapeDataString(resetToken));

        var html = $@"
<!DOCTYPE html>
<html lang='de'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Passwort zurücksetzen</title>
</head>
<body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333; max-width: 600px; margin: 0 auto; padding: 20px;'>
    <div style='background-color: #f8f9fa; Border-radius: 10px; padding: 30px;'>
        <h1 style='color: #0066cc; margin-top: 0;'>Passwort zurücksetzen</h1>

        <p>Hallo {encodedRecipientName},</p>

        <p>Sie haben eine Anfrage zum Zurücksetzen Ihres Passworts gestellt. Klicken Sie auf die Schaltfläche unten, um Ihr Passwort zurückzusetzen:</p>

        <div style='text-align: center; margin: 30px 0;'>
            <a href='{encodedResetUrl}?token={encodedToken}'
               style='background-color: #0066cc; color: white; padding: 12px 30px; text-decoration: none; Border-radius: 5px; display: inline-block;'>
                Passwort zurücksetzen
            </a>
        </div>

        <p style='color: #666; font-size: 14px;'>Falls die Schaltfläche nicht funktioniert, kopieren Sie bitte den folgenden Link in Ihren Browser:</p>
        <p style='background-color: #f1f1f1; padding: 10px; Border-radius: 5px; word-break: break-all; font-size: 12px;'>
            {encodedResetUrl}?token={encodedToken}
        </p>

        <p style='margin-top: 30px; padding-top: 20px; Border-top: 1px solid #ddd; color: #666; font-size: 14px;'>
            <strong>Wichtig:</strong> Wenn Sie diese E-Mail nicht angefsalest haben, können Sie sie einfach ignorieren.
            Ihr Passwort wird nicht geändert.
        </p>

        <p style='color: #666; font-size: 14px;'>
            Dieser Link ist aus Sicherheitsgründen nur für eine begrenzte Zeit gültig.
        </p>

        <p style='margin-top: 30px; color: #999; font-size: 12px;'>
            Mit freundlichen Grüßen,<br>
            Ihr asERP Team
        </p>
    </div>
</body>
</html>";

        return Task.FromResult(html);
    }

    public Task<string> GenerateWelcomeEmailAsync(string recipientName)
    {
        // Recipient name comes from user input — HTML-encode before interpolating.
        var encodedRecipientName = WebUtility.HtmlEncode(recipientName);

        var html = $@"
<!DOCTYPE html>
<html lang='de'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Willkommen bei asERP</title>
</head>
<body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333; max-width: 600px; margin: 0 auto; padding: 20px;'>
    <div style='background-color: #f8f9fa; Border-radius: 10px; padding: 30px;'>
        <h1 style='color: #0066cc; margin-top: 0;'>Willkommen bei asERP!</h1>

        <p>Hallo {encodedRecipientName},</p>

        <p>Vielen Dank für Ihre Registrierung bei asERP. Wir freuen uns, Sie als neuen Benutzer begrüßen zu dürfen!</p>

        <p>Mit asERP haben Sie Zugriff auf eine umfassende ERP-Lösung für Ihr Unternehmen.</p>

        <h2 style='color: #0066cc; font-size: 18px; margin-top: 30px;'>Nächste Schritte:</h2>
        <ul style='padding-left: 20px;'>
            <li>Richten Sie Ihr Unternehmensprofil ein</li>
            <li>Laden Sie Ihre Teammitglieder ein</li>
            <li>Konfigurieren Sie Ihre Einstellungen</li>
            <li>Beginnen Sie mit der Nutzung von asERP</li>
        </ul>

        <p style='margin-top: 30px; color: #666; font-size: 14px;'>
            Bei Fragen stehen wir Ihnen gerne zur Verfügung.
        </p>

        <p style='margin-top: 30px; color: #999; font-size: 12px;'>
            Mit freundlichen Grüßen,<br>
            Ihr asERP Team
        </p>
    </div>
</body>
</html>";

        return Task.FromResult(html);
    }

    public Task<string> GenerateShippingNotificationEmailAsync(ShippingNotificationEmailData data)
    {
        var html = BuildShippingNotificationHtml(
            data,
            title: "Ihre Bestellung ist unterwegs",
            intro: $"gute Nachrichten — Ihre Bestellung <strong>{data.SalesNumber}</strong> " +
                   (data.IsPartialShipment ? "ist teilweise unterwegs zu Ihnen." : "ist unterwegs zu Ihnen."),
            showTracking: true);

        return Task.FromResult(html);
    }

    public Task<string> GenerateDeliveryNotificationEmailAsync(ShippingNotificationEmailData data)
    {
        var html = BuildShippingNotificationHtml(
            data,
            title: "Ihre Bestellung wurde zugestellt",
            intro: $"Ihre Sendung zur Bestellung <strong>{data.SalesNumber}</strong> wurde zugestellt.",
            showTracking: false);

        return Task.FromResult(html);
    }

    // Item names and customer names can come from channel imports — HTML-encode everything interpolated.
    private static string BuildShippingNotificationHtml(ShippingNotificationEmailData data, string title, string intro, bool showTracking)
    {
        var greeting = string.IsNullOrWhiteSpace(data.CustomerName)
            ? "Hallo,"
            : $"Hallo {WebUtility.HtmlEncode(data.CustomerName)},";

        var carrier = WebUtility.HtmlEncode(data.CarrierName);
        if (!string.IsNullOrWhiteSpace(data.RateName))
        {
            carrier += $" ({WebUtility.HtmlEncode(data.RateName)})";
        }

        var trackingNumber = WebUtility.HtmlEncode(data.TrackingNumber);
        var trackingValue = !string.IsNullOrWhiteSpace(data.TrackingUrl)
            ? $"<a href='{WebUtility.HtmlEncode(data.TrackingUrl)}' style='color: #0066cc;'>{trackingNumber}</a>"
            : trackingNumber;

        var trackingSection = string.Empty;
        if (showTracking && !string.IsNullOrWhiteSpace(data.TrackingNumber))
        {
            trackingSection = $@"
        <p style='margin: 20px 0;'>
            Versand mit: <strong>{carrier}</strong><br>
            Sendungsverfolgung: {trackingValue}
        </p>";
        }

        var itemRows = new StringBuilder();
        foreach (var item in data.Items)
        {
            var sku = string.IsNullOrWhiteSpace(item.Sku)
                ? string.Empty
                : $"<br><span style='color: #666; font-size: 12px;'>Art.-Nr. {WebUtility.HtmlEncode(item.Sku)}</span>";
            itemRows.Append($@"
            <tr>
                <td style='padding: 8px; Border-bottom: 1px solid #eee; text-align: right; white-space: nowrap;'>{item.Quantity:0.##}&times;</td>
                <td style='padding: 8px; Border-bottom: 1px solid #eee;'>{WebUtility.HtmlEncode(item.Name)}{sku}</td>
            </tr>");
        }

        var itemsSection = data.Items.Count > 0
            ? $@"
        <table style='width: 100%; Border-collapse: collapse; margin: 20px 0;'>
            <thead>
                <tr>
                    <th style='padding: 8px; Border-bottom: 2px solid #ddd; text-align: right;'>Menge</th>
                    <th style='padding: 8px; Border-bottom: 2px solid #ddd; text-align: left;'>Artikel</th>
                </tr>
            </thead>
            <tbody>{itemRows}
            </tbody>
        </table>"
            : string.Empty;

        var partialHint = data.IsPartialShipment
            ? @"
        <p style='color: #666; font-size: 14px;'>
            Diese Sendung enthält einen Teil Ihrer Bestellung. Weitere Artikel werden separat versendet.
        </p>"
            : string.Empty;

        var html = $@"
<!DOCTYPE html>
<html lang='de'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>{title}</title>
</head>
<body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333; max-width: 600px; margin: 0 auto; padding: 20px;'>
    <div style='background-color: #f8f9fa; Border-radius: 10px; padding: 30px;'>
        <h1 style='color: #0066cc; margin-top: 0;'>{title}</h1>

        <p>{greeting}</p>

        <p>{intro}</p>
{trackingSection}{itemsSection}{partialHint}
        <p style='margin-top: 30px; color: #999; font-size: 12px;'>
            Mit freundlichen Grüßen,<br>
            Ihr asERP Team
        </p>
    </div>
</body>
</html>";

        return html;
    }

    public Task<string> GenerateEmailConfirmationAsync(string recipientName, string confirmationToken, string confirmationUrl)
    {
        // Recipient name and URL come from user input — HTML-encode everything interpolated.
        var encodedRecipientName = WebUtility.HtmlEncode(recipientName);
        var encodedConfirmationUrl = WebUtility.HtmlEncode(confirmationUrl);
        var encodedToken = WebUtility.HtmlEncode(Uri.EscapeDataString(confirmationToken));

        var html = $@"
<!DOCTYPE html>
<html lang='de'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>E-Mail-Adresse bestätigen</title>
</head>
<body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333; max-width: 600px; margin: 0 auto; padding: 20px;'>
    <div style='background-color: #f8f9fa; Border-radius: 10px; padding: 30px;'>
        <h1 style='color: #0066cc; margin-top: 0;'>E-Mail-Adresse bestätigen</h1>

        <p>Hallo {encodedRecipientName},</p>

        <p>Bitte bestätigen Sie Ihre E-Mail-Adresse, indem Sie auf die Schaltfläche unten klicken:</p>

        <div style='text-align: center; margin: 30px 0;'>
            <a href='{encodedConfirmationUrl}?token={encodedToken}'
               style='background-color: #28a745; color: white; padding: 12px 30px; text-decoration: none; Border-radius: 5px; display: inline-block;'>
                E-Mail bestätigen
            </a>
        </div>

        <p style='color: #666; font-size: 14px;'>Falls die Schaltfläche nicht funktioniert, kopieren Sie bitte den folgenden Link in Ihren Browser:</p>
        <p style='background-color: #f1f1f1; padding: 10px; Border-radius: 5px; word-break: break-all; font-size: 12px;'>
            {encodedConfirmationUrl}?token={encodedToken}
        </p>

        <p style='margin-top: 30px; color: #999; font-size: 12px;'>
            Mit freundlichen Grüßen,<br>
            Ihr asERP Team
        </p>
    </div>
</body>
</html>";

        return Task.FromResult(html);
    }
}

using asERP.Application.Models.Email;

namespace asERP.Application.Contracts.Infrastructure;

public interface IEmailTemplateService
{
    /// <summary>
    /// Generates a password reset email HTML
    /// </summary>
    Task<string> GeneratePasswordResetEmailAsync(string recipientName, string resetToken, string resetUrl);

    /// <summary>
    /// Generates a welcome email HTML
    /// </summary>
    Task<string> GenerateWelcomeEmailAsync(string recipientName);

    /// <summary>
    /// Generates an email confirmation email HTML
    /// </summary>
    Task<string> GenerateEmailConfirmationAsync(string recipientName, string confirmationToken, string confirmationUrl);

    /// <summary>
    /// Generates the "your order is on the way" customer notification HTML
    /// </summary>
    Task<string> GenerateShippingNotificationEmailAsync(ShippingNotificationEmailData data);

    /// <summary>
    /// Generates the "your order was delivered" customer notification HTML
    /// </summary>
    Task<string> GenerateDeliveryNotificationEmailAsync(ShippingNotificationEmailData data);
}

using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Models.Email;

namespace asERP.Server.Tests.Infrastructure;

/// <summary>
/// Recording replacement for <see cref="IEmailService"/> — no SMTP, no network. Registered as a
/// singleton in <see cref="TestWebApplicationFactory{TProgram}"/> so sent mails survive scope
/// boundaries and can be asserted after handlers ran.
/// </summary>
public sealed class FakeEmailService : IEmailService
{
    private readonly object _lock = new();
    private readonly List<(EmailMessage Message, Guid? TenantId)> _sent = new();

    /// <summary>When true, <see cref="SendEmailAsync"/> reports failure without recording.</summary>
    public bool FailNextSend { get; set; }

    /// <summary>When true, <see cref="SendEmailAsync"/> throws — simulates a hard SMTP crash.</summary>
    public bool ThrowOnSend { get; set; }

    public IReadOnlyList<(EmailMessage Message, Guid? TenantId)> Sent
    {
        get
        {
            lock (_lock)
            {
                return _sent.ToList();
            }
        }
    }

    public Task<bool> SendEmailAsync(EmailMessage email, Guid? tenantId = null)
    {
        if (ThrowOnSend)
        {
            throw new InvalidOperationException("FakeEmailService: simulated send crash");
        }

        if (FailNextSend)
        {
            FailNextSend = false;
            return Task.FromResult(false);
        }

        lock (_lock)
        {
            _sent.Add((email, tenantId));
        }

        return Task.FromResult(true);
    }

    public Task<bool> SendPasswordResetEmailAsync(string toEmail, string toName, string resetToken, Guid? tenantId = null)
        => SendEmailAsync(new EmailMessage { To = toEmail, ToName = toName, Subject = "Password reset" }, tenantId);

    public Task<bool> SendWelcomeEmailAsync(string toEmail, string toName, Guid? tenantId = null)
        => SendEmailAsync(new EmailMessage { To = toEmail, ToName = toName, Subject = "Welcome" }, tenantId);
}

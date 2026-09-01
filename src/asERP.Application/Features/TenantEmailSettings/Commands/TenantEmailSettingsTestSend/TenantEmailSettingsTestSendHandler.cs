using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Services;
using asERP.Application.Mediator;
using asERP.Application.Models.Email;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.TenantEmailSettings.Commands.TenantEmailSettingsTestSend;

public class TenantEmailSettingsTestSendHandler : IRequestHandler<TenantEmailSettingsTestSendCommand, Result<bool>>
{
    private readonly IAppLogger<TenantEmailSettingsTestSendHandler> _logger;
    private readonly IEmailService _emailService;
    private readonly ITenantContext _tenantContext;

    public TenantEmailSettingsTestSendHandler(
        IAppLogger<TenantEmailSettingsTestSendHandler> logger,
        IEmailService emailService,
        ITenantContext tenantContext)
    {
        _logger = logger;
        _emailService = emailService;
        _tenantContext = tenantContext;
    }

    public async Task<Result<bool>> Handle(TenantEmailSettingsTestSendCommand request, CancellationToken cancellationToken)
    {
        var result = new Result<bool>();

        var tenantId = _tenantContext.GetCurrentTenantId();
        if (!tenantId.HasValue)
        {
            result.Fail(ErrorType.Validation, ErrorCodes.TenantEmailSettings.Invalid, "No active tenant in context.");
            return result;
        }

        var message = new EmailMessage
        {
            To = request.Recipient,
            ToName = request.Recipient,
            Subject = string.IsNullOrWhiteSpace(request.Subject) ? "asERP — Test E-Mail" : request.Subject!,
            Body = string.IsNullOrWhiteSpace(request.Body)
                ? "Dies ist eine Test-Nachricht zur Überprüfung der Email-Konfiguration."
                : request.Body!,
            IsHtml = false
        };

        var sent = await _emailService.SendEmailAsync(message, tenantId);

        result.Succeeded = sent;
        result.Data = sent;

        if (!sent)
        {
            result.Fail(ErrorType.Unexpected, ErrorCodes.TenantEmailSettings.Unexpected,
                "Failed to send the test email. Check the server logs for provider errors.");
            _logger.LogWarning("Test send failed for tenant {TenantId}", tenantId.Value);
        }
        else
        {
            _logger.LogInformation("Test send succeeded for tenant {TenantId} to {Recipient}", tenantId.Value, request.Recipient);
        }

        return result;
    }
}

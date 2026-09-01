using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Superadmin.Commands.SuperadminUpdate;

public class SuperadminUpdateHandler : IRequestHandler<SuperadminUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<SuperadminUpdateHandler> _logger;
    private readonly ITenantRepository _tenantRepository;

    public SuperadminUpdateHandler(
        IAppLogger<SuperadminUpdateHandler> logger,
        ITenantRepository tenantRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _tenantRepository = tenantRepository ?? throw new ArgumentNullException(nameof(tenantRepository));
    }

    public async Task<Result<Guid>> Handle(SuperadminUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating tenant with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        var tenantToUpdate = await _tenantRepository.GetByIdAsync(request.Id);

        if (tenantToUpdate == null)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Superadmin.NotFound, "Tenant not found.");

            _logger.LogWarning("Tenant with ID {Id} not found for update", request.Id);
            return result;
        }

        tenantToUpdate.Name = request.Name;
        tenantToUpdate.Description = request.Description;
        tenantToUpdate.CompanyName = request.CompanyName;
        tenantToUpdate.ContactEmail = request.ContactEmail;
        tenantToUpdate.Phone = request.Phone;
        tenantToUpdate.Website = request.Website;
        tenantToUpdate.Street = request.Street;
        tenantToUpdate.Street2 = request.Street2;
        tenantToUpdate.PostalCode = request.PostalCode;
        tenantToUpdate.City = request.City;
        tenantToUpdate.State = request.State;
        tenantToUpdate.Country = request.Country;
        tenantToUpdate.Iban = request.Iban;
        tenantToUpdate.BankName = request.BankName;
        tenantToUpdate.Bic = request.Bic;
        tenantToUpdate.TaxId = request.TaxId;
        tenantToUpdate.VatId = request.VatId;
        tenantToUpdate.LogoPath = request.LogoPath;

        await _tenantRepository.UpdateAsync(tenantToUpdate);

        result.Succeeded = true;
        result.Status = ResultStatus.Ok;
        result.Data = tenantToUpdate.Id;

        _logger.LogInformation("Successfully updated tenant with ID: {Id}", tenantToUpdate.Id);

        return result;
    }
}

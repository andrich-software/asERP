using FluentValidation;
using asERP.Application.Contracts.Persistence;
using asERP.Domain.Validators;

namespace asERP.Application.Features.Superadmin.Commands.SuperadminCreate;

public class SuperadminCreateValidator : TenantBaseValidator<SuperadminCreateCommand>
{
    private readonly ITenantRepository _tenantRepository;

    public SuperadminCreateValidator(ITenantRepository tenantRepository)
    {
        _tenantRepository = tenantRepository;
    }
}
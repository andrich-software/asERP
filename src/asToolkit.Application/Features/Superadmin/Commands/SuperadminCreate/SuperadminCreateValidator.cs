using FluentValidation;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Domain.Validators;

namespace asToolkit.Application.Features.Superadmin.Commands.SuperadminCreate;

public class SuperadminCreateValidator : TenantBaseValidator<SuperadminCreateCommand>
{
    private readonly ITenantRepository _tenantRepository;

    public SuperadminCreateValidator(ITenantRepository tenantRepository)
    {
        _tenantRepository = tenantRepository;
    }
}
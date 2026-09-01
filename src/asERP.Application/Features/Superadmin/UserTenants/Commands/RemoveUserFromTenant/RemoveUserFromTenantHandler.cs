using System.Linq;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Superadmin.UserTenants.Commands.RemoveUserFromTenant;

public class RemoveUserFromTenantHandler : IRequestHandler<RemoveUserFromTenantCommand, Result<bool>>
{
    private readonly IUserTenantRepository _userTenantRepository;

    public RemoveUserFromTenantHandler(IUserTenantRepository userTenantRepository)
    {
        _userTenantRepository = userTenantRepository;
    }

    public async Task<Result<bool>> Handle(RemoveUserFromTenantCommand request, CancellationToken cancellationToken)
    {
        // Find the assignment
        var userTenant = await _userTenantRepository.Entities
            .FirstOrDefaultAsync(ut => ut.UserId == request.UserId && ut.TenantId == request.TenantId, cancellationToken);

        if (userTenant == null)
        {
            return Result<bool>.Invalid(ErrorCodes.Superadmin.Invalid, "User is not assigned to this tenant");
        }

        try
        {
            await _userTenantRepository.DeleteAsync(userTenant);
        }
        catch (DbUpdateConcurrencyException)
        {
            return Result<bool>.Invalid(ErrorCodes.Superadmin.Invalid, "User is not assigned to this tenant");
        }

        var success = Result<bool>.Success(true, "User successfully removed from tenant");
        success.Status = ResultStatus.Ok;
        return success;
    }
}

using System.Linq;
using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.User;
using asERP.Domain.Entities;
using asERP.Domain.Wrapper;
using Microsoft.AspNetCore.Identity;

namespace asERP.Application.Features.Superadmin.Users.Queries.UserList;

/// <summary>
/// Handler for processing user list queries.
/// Implements IRequestHandler from the custom mediator to handle UserListQuery requests
/// and return a paginated list of users wrapped in a PaginatedResult.
/// </summary>
public class UserListHandler : IRequestHandler<UserListQuery, PaginatedResult<UserListDto>>
{
    private readonly IAppLogger<UserListHandler> _logger;

    // Ordering runs on the projected UserListDto; restrict to display columns so clients cannot sort by
    // (and thereby probe) secret ApplicationUser columns such as PasswordHash or security tokens.
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(UserListDto.Id),
        nameof(UserListDto.Email),
        nameof(UserListDto.Firstname),
        nameof(UserListDto.Lastname),
        nameof(UserListDto.DateCreated)
    };

    private readonly UserManager<ApplicationUser> _userManager;

    public UserListHandler(
        IAppLogger<UserListHandler> logger,
        UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public async Task<PaginatedResult<UserListDto>> Handle(UserListQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handle UserListQuery: {Request}", request);

        var sanitizedPageSize = request.PageSize <= 0 ? 10 : request.PageSize;
        var sanitizedPage = request.PageNumber <= 0 ? 1 : request.PageNumber;
        var pageIndex = sanitizedPage - 1;

        // Superadmin: Show ALL users (with and without tenant assignments)
        // No tenant filtering - this endpoint is protected by [Authorize(Roles = "Superadmin")]
        var query = _userManager.Users
            .Select(u => new UserListDto
            {
                Id = u.Id,
                Email = u.Email ?? string.Empty,
                Firstname = u.Firstname,
                Lastname = u.Lastname,
                DateCreated = u.DateCreated
            });

        query = query.ApplySafeOrdering(request.SortBy, AllowedSortFields);

        var page = await query.ToPaginatedListAsync(pageIndex, sanitizedPageSize);

        // Unlike the rest of the project this endpoint reports a one-based CurrentPage; the result
        // is rebuilt rather than patched because a result is immutable once created.
        return new PaginatedResult<UserListDto>(page.Data)
        {
            Succeeded = page.Succeeded,
            Messages = page.Messages,
            TotalCount = page.TotalCount,
            TotalPages = page.TotalPages,
            CurrentPage = sanitizedPage,
            PageSize = sanitizedPageSize
        };
    }
}

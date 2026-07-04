using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface IUserService
{
    Task<List<ApplicationUser>> GetUsers();
    Task<ApplicationUser> GetUser(string userId);
}
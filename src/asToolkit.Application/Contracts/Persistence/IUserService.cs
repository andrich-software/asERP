using asToolkit.Domain.Entities;

namespace asToolkit.Application.Contracts.Persistence;

public interface IUserService
{
    Task<List<ApplicationUser>> GetUsers();
    Task<ApplicationUser> GetUser(string userId);
}
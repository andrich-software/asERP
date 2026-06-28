using asToolkit.Domain.Entities;

namespace asToolkit.Application.Contracts.Persistence;

public interface ICountryRepository : IGenericRepository<Country>
{
    Task<Country?> GetCountryByString(string country);
}
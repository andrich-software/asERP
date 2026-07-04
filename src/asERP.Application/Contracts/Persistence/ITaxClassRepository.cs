using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface ICountryRepository : IGenericRepository<Country>
{
    Task<Country?> GetCountryByString(string country);
}
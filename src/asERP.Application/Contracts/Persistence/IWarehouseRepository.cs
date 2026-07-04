using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface IWarehouseRepository : IGenericRepository<Warehouse>
{
    // bool IsUnique(string name);
}
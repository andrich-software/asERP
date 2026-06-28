using asToolkit.Domain.Entities;

namespace asToolkit.Application.Contracts.Persistence;

public interface IWarehouseRepository : IGenericRepository<Warehouse>
{
    // bool IsUnique(string name);
}
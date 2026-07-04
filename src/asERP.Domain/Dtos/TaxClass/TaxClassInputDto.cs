using asERP.Domain.Interfaces;

namespace asERP.Domain.Dtos.TaxClass;

public class TaxClassInputDto : ITaxClassInputModel
{
    public Guid Id { get; set; }
    public double TaxRate { get; set; }
}
using asToolkit.Domain.Interfaces;

namespace asToolkit.Domain.Dtos.TaxClass;

public class TaxClassInputDto : ITaxClassInputModel
{
    public Guid Id { get; set; }
    public double TaxRate { get; set; }
}
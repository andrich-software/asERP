using asToolkit.Domain.Interfaces;

namespace asToolkit.Domain.Dtos.Country;

public class CountryInputDto : ICountryInputModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
}

using asERP.Domain.Interfaces;

namespace asERP.Domain.Dtos.Country;

public class CountryInputDto : ICountryInputModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
}

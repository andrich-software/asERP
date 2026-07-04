using System.ComponentModel.DataAnnotations;
using asERP.Domain.Entities.Common;

namespace asERP.Domain.Entities;

public class Country : BaseEntity, IBaseEntity
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string CountryCode { get; set; } = null!;
}
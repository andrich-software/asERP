using System.ComponentModel.DataAnnotations;
using asToolkit.Domain.Entities.Common;

namespace asToolkit.Domain.Entities;

public class Country : BaseEntity, IBaseEntity
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string CountryCode { get; set; } = null!;
}
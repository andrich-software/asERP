using System.ComponentModel.DataAnnotations;
using asToolkit.Domain.Entities.Common;

namespace asToolkit.Domain.Entities;

public class ShippingProvider : BaseEntity, IBaseEntity
{
    [Required, Display(Name = "Name")]
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<ShippingProviderRate>? ShippingRates { get; set; }
}
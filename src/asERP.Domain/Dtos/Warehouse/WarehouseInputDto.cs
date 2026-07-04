using System.ComponentModel.DataAnnotations;
using asERP.Domain.Interfaces;

namespace asERP.Domain.Dtos.Warehouse;

public class WarehouseInputDto : IWarehouseInputModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Name")]
    public string Name { get; set; } = string.Empty;
}
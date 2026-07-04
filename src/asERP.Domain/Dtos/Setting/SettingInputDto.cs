using System.ComponentModel.DataAnnotations;
using asERP.Domain.Interfaces;

namespace asERP.Domain.Dtos.Setting;

public class SettingInputDto : ISettingInputModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Key is required")]
    [Display(Name = "Key")]
    public string Key { get; set; } = string.Empty;

    [Display(Name = "Value")]
    public string Value { get; set; } = string.Empty;
}

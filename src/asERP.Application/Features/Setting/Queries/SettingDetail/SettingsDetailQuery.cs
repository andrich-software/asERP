using asERP.Application.Mediator;
using asERP.Domain.Dtos.Setting;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Setting.Queries.SettingDetail;

/// <summary>
/// Query for retrieving detailed information about a specific setting.
/// Implements IRequest to work with the custom mediator, returning setting details wrapped in a Result.
/// </summary>
public class SettingDetailQuery : IRequest<Result<SettingDetailDto>>
{
    /// <summary>
    /// The unique identifier of the setting to retrieve
    /// </summary>
    public Guid Id { get; set; }
}

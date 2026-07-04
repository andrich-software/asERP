using asERP.Domain.Dtos.Setting;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Setting.Queries.SettingDetail;

/// <summary>
/// Query for retrieving detailed information about a specific setting.
/// Implements IRequest to work with MediatR, returning setting details wrapped in a Result.
/// </summary>
public class SettingDetailQuery : IRequest<Result<SettingDetailDto>>
{
    /// <summary>
    /// The unique identifier of the setting to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
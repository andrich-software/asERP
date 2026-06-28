using Asp.Versioning;
using asToolkit.Application.Features.Customer.Commands.CustomerDedupe;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Customer;
using asToolkit.Domain.Wrapper;
using asToolkit.Server.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asToolkit.Server.Controllers.Api.V1;

/// <summary>
/// Cross-tenant customer-deduplication. Detects (TenantId, lower-cased Email) collisions and
/// either previews or executes a merge into the oldest customer of each group.
/// Required before the filtered unique index on Customer.Email is added (PR 5).
/// </summary>
[ApiController]
[Authorize(Roles = "Superadmin")]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/superadmin/customer-dedupe")]
public class CustomerDedupeController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Run the dedupe sweep. With <c>dryRun=true</c> (default) no writes happen — the response
    /// describes what *would* be merged. With <c>dryRun=false</c> the merge is applied.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Result<CustomerDedupeResultDto>>> Run([FromQuery] bool dryRun = true)
    {
        var response = await mediator.Send(new CustomerDedupeCommand { DryRun = dryRun });
        return response.ToActionResult();
    }
}

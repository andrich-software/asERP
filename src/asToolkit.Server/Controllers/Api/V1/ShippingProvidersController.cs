using Asp.Versioning;
using asToolkit.Application.Features.ShippingProvider.Commands.ShippingProviderCreate;
using asToolkit.Application.Features.ShippingProvider.Commands.ShippingProviderDelete;
using asToolkit.Application.Features.ShippingProvider.Commands.ShippingProviderUpdate;
using asToolkit.Application.Features.ShippingProvider.Queries.ShippingProviderDetail;
using asToolkit.Application.Features.ShippingProvider.Queries.ShippingProviderList;
using asToolkit.Application.Features.ShippingProviderRate.Commands.ShippingProviderRateCreate;
using asToolkit.Application.Features.ShippingProviderRate.Commands.ShippingProviderRateDelete;
using asToolkit.Application.Features.ShippingProviderRate.Commands.ShippingProviderRateUpdate;
using asToolkit.Application.Features.ShippingProviderRate.Queries.ShippingProviderRateDetail;
using asToolkit.Application.Features.ShippingProviderRate.Queries.ShippingProviderRateList;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.ShippingProvider;
using asToolkit.Domain.Dtos.ShippingProviderRate;
using asToolkit.Domain.Wrapper;
using asToolkit.Server.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asToolkit.Server.Controllers.Api.V1;

[ApiController]
[Authorize]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/[controller]")]
public class ShippingProvidersController(IMediator mediator) : ControllerBase
{
    // GET: api/v1/<ShippingProvidersController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginatedResult<ShippingProviderListDto>>> GetAll(int pageNumber = 0, int pageSize = 10, string searchString = "", string salesBy = "")
    {
        if (string.IsNullOrEmpty(salesBy))
        {
            salesBy = "Name Ascending";
        }

        var response = await mediator.Send(new ShippingProviderListQuery(pageNumber, pageSize, searchString, salesBy));
        return response.ToActionResult();
    }

    // GET: api/v1/<ShippingProvidersController>/5
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ShippingProviderDetailDto>> GetDetails(Guid id)
    {
        var response = await mediator.Send(new ShippingProviderDetailQuery { Id = id });
        return response.ToActionResult();
    }

    // POST: api/v1/<ShippingProvidersController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> Create(ShippingProviderCreateCommand shippingProviderCreateCommand)
    {
        var response = await mediator.Send(shippingProviderCreateCommand);
        return response.ToActionResult();
    }

    // PUT: api/v1/<ShippingProvidersController>/5
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update(Guid id, ShippingProviderUpdateCommand shippingProviderUpdateCommand)
    {
        // Validate ID consistency between URL and body if ID is provided in body and differs
        if (shippingProviderUpdateCommand.Id != Guid.Empty && shippingProviderUpdateCommand.Id != id)
        {
            var errorResponse = ProblemDetailsResult.BadRequest(
                "Invalid Request",
                $"ID in URL ({id}) must match ID in request body ({shippingProviderUpdateCommand.Id})",
                "https://tools.ietf.org/html/rfc9110#section-15.5.1",
                $"/api/v1/shippingproviders/{id}"
            );
            return errorResponse.ToActionResult();
        }

        shippingProviderUpdateCommand.Id = id;
        var response = await mediator.Send(shippingProviderUpdateCommand);
        return response.ToActionResult();
    }

    // DELETE: api/v1/<ShippingProvidersController>/5
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new ShippingProviderDeleteCommand { Id = id };
        var response = await mediator.Send(command);
        return response.ToActionResult();
    }

    // GET: api/v1/<ShippingProvidersController>/5/rates
    [HttpGet("{providerId:guid}/rates")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ShippingProviderRateListDto>>> GetRates(Guid providerId)
    {
        var response = await mediator.Send(new ShippingProviderRateListQuery { ShippingProviderId = providerId });
        return response.ToActionResult();
    }

    // GET: api/v1/<ShippingProvidersController>/5/rates/6
    [HttpGet("{providerId:guid}/rates/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ShippingProviderRateDetailDto>> GetRateDetails(Guid providerId, Guid id)
    {
        var response = await mediator.Send(new ShippingProviderRateDetailQuery { Id = id });
        return response.ToActionResult();
    }

    // POST: api/v1/<ShippingProvidersController>/5/rates
    [HttpPost("{providerId:guid}/rates")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> CreateRate(Guid providerId, ShippingProviderRateCreateCommand shippingProviderRateCreateCommand)
    {
        shippingProviderRateCreateCommand.ShippingProviderId = providerId;
        var response = await mediator.Send(shippingProviderRateCreateCommand);
        return response.ToActionResult();
    }

    // PUT: api/v1/<ShippingProvidersController>/5/rates/6
    [HttpPut("{providerId:guid}/rates/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateRate(Guid providerId, Guid id, ShippingProviderRateUpdateCommand shippingProviderRateUpdateCommand)
    {
        // Validate ID consistency between URL and body if ID is provided in body and differs
        if (shippingProviderRateUpdateCommand.Id != Guid.Empty && shippingProviderRateUpdateCommand.Id != id)
        {
            var errorResponse = ProblemDetailsResult.BadRequest(
                "Invalid Request",
                $"ID in URL ({id}) must match ID in request body ({shippingProviderRateUpdateCommand.Id})",
                "https://tools.ietf.org/html/rfc9110#section-15.5.1",
                $"/api/v1/shippingproviders/{providerId}/rates/{id}"
            );
            return errorResponse.ToActionResult();
        }

        shippingProviderRateUpdateCommand.Id = id;
        shippingProviderRateUpdateCommand.ShippingProviderId = providerId;
        var response = await mediator.Send(shippingProviderRateUpdateCommand);
        return response.ToActionResult();
    }

    // DELETE: api/v1/<ShippingProvidersController>/5/rates/6
    [HttpDelete("{providerId:guid}/rates/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteRate(Guid providerId, Guid id)
    {
        var command = new ShippingProviderRateDeleteCommand { Id = id };
        var response = await mediator.Send(command);
        return response.ToActionResult();
    }
}

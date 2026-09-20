using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Features.Country.Commands.CountryCreate;
using asERP.Application.Features.Country.Commands.CountryDelete;
using asERP.Application.Features.Country.Commands.CountryUpdate;
using asERP.Application.Features.Country.Queries.CountryDetail;
using asERP.Application.Features.Country.Queries.CountryList;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Country;
using asERP.Domain.Wrapper;
using asERP.Server.Extensions;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Controllers.Api.V1;

[ApiController]
[Authorize]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ITenantContext _tenantContext;
    private readonly ICountryRepository _countryRepository;

    public CountriesController(
        IMediator mediator,
        ITenantContext tenantContext,
        ICountryRepository countryRepository)
    {
        _mediator = mediator;
        _tenantContext = tenantContext;
        _countryRepository = countryRepository;
    }

    /// <summary>
    /// Country is the only entity that may legitimately live without a tenant: rows with
    /// <c>TenantId == null</c> are installation-wide reference data that every tenant reads through
    /// the <c>TenantId == null</c> arm of the global query filter. Creating, changing or deleting
    /// such a row hits every tenant on the installation, so it is reserved for Superadmins.
    /// Writes that stay inside the caller's own tenant are not affected by this check.
    /// </summary>
    /// <param name="countryId">The targeted row for update/delete, <c>null</c> for a create.</param>
    /// <returns><c>null</c> when the write may proceed, otherwise the 401/403 result to return.</returns>
    private async Task<ActionResult?> EnsureSharedCountryWriteAllowedAsync(Guid? countryId = null)
    {
        if (_tenantContext.GetCurrentTenantId() is null)
        {
            // Without a tenant context a create is persisted with TenantId == null, and an
            // update/delete can only resolve TenantId == null rows through the query filter —
            // every write on this path is a shared-row write.
            return await this.EnsureSuperadminAccessAsync();
        }

        if (countryId is null)
        {
            // Create inside the caller's own tenant: stamped with the current TenantId.
            return null;
        }

        var target = await _countryRepository.GetByIdAsync(countryId.Value, asNoTracking: true);
        if (target is null || target.TenantId is not null)
        {
            // Invisible to the caller (the handler answers 404) or owned by the caller's tenant —
            // both keep their previous behaviour.
            return null;
        }

        return await this.EnsureSuperadminAccessAsync();
    }

    // GET: api/v1/<CountriesController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginatedResult<CountryListDto>>> GetAll(
        int pageNumber = 0,
        int pageSize = 300,
        string searchString = "",
        string sortBy = "")
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            sortBy = "Name";
        }

        var response = await _mediator.Send(new CountryListQuery(pageNumber, pageSize, searchString, sortBy));
        return response.ToActionResult();
    }

    // GET api/<CountriesController>/5
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CountryDetailDto>> GetDetails(Guid id)
    {
        var response = await _mediator.Send(new CountryDetailQuery { Id = id });
        return response.ToActionResult();
    }

    // POST: api/v1/<CountriesController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<Guid>> Create(CountryCreateCommand countryCreateCommand)
    {
        if (await EnsureSharedCountryWriteAllowedAsync() is { } accessError)
        {
            return accessError;
        }

        var response = await _mediator.Send(countryCreateCommand);
        return response.ToActionResult();
    }

    // PUT: api/v1/<CountriesController>/5
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update(Guid id, CountryUpdateCommand countryUpdateCommand)
    {
        if (await EnsureSharedCountryWriteAllowedAsync(id) is { } accessError)
        {
            return accessError;
        }

        countryUpdateCommand.Id = id;
        var response = await _mediator.Send(countryUpdateCommand);
        return response.ToActionResult();
    }

    // DELETE: api/v1/<CountriesController>/5
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        if (await EnsureSharedCountryWriteAllowedAsync(id) is { } accessError)
        {
            return accessError;
        }

        var command = new CountryDeleteCommand { Id = id };
        var response = await _mediator.Send(command);
        return response.ToActionResult();
    }
}

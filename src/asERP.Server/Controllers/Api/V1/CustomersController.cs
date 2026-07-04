using Asp.Versioning;
using asERP.Application.Features.Customer.Commands.CustomerCreate;
using asERP.Application.Features.Customer.Commands.CustomerDelete;
using asERP.Application.Features.Customer.Commands.CustomerUpdate;
using asERP.Application.Features.Customer.Queries.CustomerDetail;
using asERP.Application.Features.Customer.Queries.CustomerList;
using asERP.Application.Features.Customer.Queries.CustomerListWithAddress;
using asERP.Domain.Dtos.Customer;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;
using asERP.Server.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Controllers.Api.V1;

[ApiController]
[Authorize]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/[controller]")]
public class CustomersController(IMediator mediator) : ControllerBase
{
    // GET: api/v1/<CustomersController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginatedResult<CustomerListDto>>> GetAll(int pageNumber = 0, int pageSize = 10, string searchString = "", string salesBy = "")
    {
        if (string.IsNullOrEmpty(salesBy))
        {
            salesBy = "DateEnrollment Descending";
        }

        var response = await mediator.Send(new CustomerListQuery(pageNumber, pageSize, searchString, salesBy));
        return response.ToActionResult();
    }

    // GET: api/v1/<CustomersController>/search
    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginatedResult<CustomerListWithAddressDto>>> Search(int pageNumber = 0, int pageSize = 10, string searchString = "", string salesBy = "")
    {
        if (string.IsNullOrEmpty(salesBy))
        {
            salesBy = "Lastname Ascending";
        }

        var response = await mediator.Send(new CustomerListWithAddressQuery(pageNumber, pageSize, searchString, salesBy));
        return response.ToActionResult();
    }

    // GET: api/v1/<CustomersController>/5
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CustomerDetailDto>> GetDetails(Guid id)
    {
        var response = await mediator.Send(new CustomerDetailQuery { Id = id });
        return response.ToActionResult();
    }

    // POST: api/v1/<CustomersController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CustomerDetailDto>> Create(CustomerCreateCommand customerCreateCommand)
    {
        var response = await mediator.Send(customerCreateCommand);
        return response.ToActionResult();
    }

    // PUT: api/v1/<CustomersController>/5
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update(Guid id, CustomerUpdateCommand customerUpdateCommand)
    {
        // Validate ID consistency between URL and body if ID is provided in body and differs
        if (customerUpdateCommand.Id != Guid.Empty && customerUpdateCommand.Id != id)
        {
            var errorResponse = ProblemDetailsResult.BadRequest(
                "Invalid Request", 
                $"ID in URL ({id}) must match ID in request body ({customerUpdateCommand.Id})",
                "https://tools.ietf.org/html/rfc9110#section-15.5.1",
                $"/api/v1/customers/{id}"
            );
            return errorResponse.ToActionResult();
        }

        customerUpdateCommand.Id = id;
        var response = await mediator.Send(customerUpdateCommand);
        return response.ToActionResult();
    }

    // DELETE: api/v1/<CustomerController>/5
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new CustomerDeleteCommand { Id = id };
        var response = await mediator.Send(command);
        return response.ToActionResult();
    }
}
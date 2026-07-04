using FluentValidation;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Exceptions;
using asERP.Domain.Validators;

namespace asERP.Application.Features.Sales.Commands.SalesUpdate;

public class SalesUpdateValidator : SalesBaseValidator<SalesUpdateCommand>
{
    private readonly ISalesRepository _salesRepository;
    private readonly ICustomerRepository _customerRepository;

    public SalesUpdateValidator(ISalesRepository salesRepository, ICustomerRepository customerRepository)
    {
        _salesRepository = salesRepository;
        _customerRepository = customerRepository;


        RuleFor(p => p.Id)
            .NotNull()
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} cannot be empty.");

        RuleFor(p => p.Id)
            .NotNull().WithMessage("{PropertyName} is required.")
            .NotEmpty().WithMessage("{PropertyName} is required.");

        // Sales existence is handled in the Handler for proper NotFound vs BadRequest logic
    }


}
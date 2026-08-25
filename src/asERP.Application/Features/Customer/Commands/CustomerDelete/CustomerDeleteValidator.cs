using asERP.Application.Contracts.Persistence;
using FluentValidation;

namespace asERP.Application.Features.Customer.Commands.CustomerDelete;

public class CustomerDeleteValidator : AbstractValidator<CustomerDeleteCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerDeleteValidator(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;

        RuleFor(p => p.Id)
            .NotNull()
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} cannot be empty.");
    }
}

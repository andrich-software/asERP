using asERP.Domain.Validators;
using FluentValidation;

namespace asERP.Application.Features.Invoice.Commands.InvoiceUpdate;

/// <summary>
/// Validator for invoice update commands.
/// Extends InvoiceBaseValidator to inherit common validation rules for invoice data
/// and adds specific validation for invoice update operations.
/// </summary>
public class InvoiceUpdateValidator : InvoiceBaseValidator<InvoiceUpdateCommand>
{
    public InvoiceUpdateValidator()
    {
        RuleFor(p => p.Id)
            .NotNull().WithMessage("{PropertyName} ist erforderlich.")
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} darf nicht leer sein.");
    }
}

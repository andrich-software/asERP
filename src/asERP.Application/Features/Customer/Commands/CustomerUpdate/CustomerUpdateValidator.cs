using asERP.Domain.Validators;
using FluentValidation;

namespace asERP.Application.Features.Customer.Commands.CustomerUpdate;

/// <summary>
/// Server-seitiger Validator für Customer Update Commands.
///
/// Erweitert CustomerBaseValidator (aus asERP.Domain) um Server-spezifische Validierungen:
/// - ID-Validierung (nicht Guid.Empty)
/// - Address-Validierung (CountryId muss gültig sein)
///
/// WICHTIG:
/// - Basis-Regeln (Feldvalidierungen) sind in CustomerBaseValidator definiert
/// - Client verwendet CustomerClientValidator (nur synchrone Regeln)
/// - Server verwendet diesen Validator
/// - Keine Eindeutigkeitsprüfung auf Firstname+Lastname, da Namensgleichheit möglich ist
/// - Keine Existenzprüfung: ob der Kunde existiert, entscheidet der Handler, damit daraus ein
///   404 statt einer Validierungsmeldung wird
/// </summary>
public class CustomerUpdateValidator : CustomerBaseValidator<CustomerUpdateCommand>
{
    public CustomerUpdateValidator()
    {
        // Add ID validation for Zero-GUID first
        RuleFor(c => c.Id)
            .NotEqual(Guid.Empty).WithMessage("Customer ID cannot be empty.");

        // Validate each address in the collection
        RuleForEach(c => c.CustomerAddresses)
            .SetValidator(new CustomerAddressBaseValidator());
    }
}

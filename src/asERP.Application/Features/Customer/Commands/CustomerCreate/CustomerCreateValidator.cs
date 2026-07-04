using FluentValidation;
using asERP.Application.Contracts.Persistence;
using asERP.Domain.Validators;

namespace asERP.Application.Features.Customer.Commands.CustomerCreate;

/// <summary>
/// Server-seitiger Validator für Customer Create Commands.
///
/// Erweitert CustomerBaseValidator (aus asERP.Domain) um Server-spezifische Validierungen:
/// - Address-Validierung (CountryId muss gültig sein)
///
/// WICHTIG:
/// - Basis-Regeln (Feldvalidierungen) sind in CustomerBaseValidator definiert
/// - Client verwendet CustomerClientValidator (nur synchrone Regeln)
/// - Server verwendet diesen Validator (mit DB-Zugriff)
/// - Keine Eindeutigkeitsprüfung auf Firstname+Lastname, da Namensgleichheit möglich ist
/// </summary>
public class CustomerCreateValidator : CustomerBaseValidator<CustomerCreateCommand>
{
    /// <summary>
    /// Constructor that initializes the validator with required dependencies
    /// </summary>
    /// <param name="customerRepository">Repository for customer data access</param>
    public CustomerCreateValidator(ICustomerRepository customerRepository)
    {
        // Validate each address in the collection
        RuleForEach(c => c.CustomerAddresses)
            .SetValidator(new CustomerAddressBaseValidator());
    }
}

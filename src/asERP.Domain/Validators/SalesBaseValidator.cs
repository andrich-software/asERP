using System;
using asERP.Domain.Enums;
using asERP.Domain.Interfaces;
using FluentValidation;

namespace asERP.Domain.Validators;

public class SalesBaseValidator<T> : AbstractValidator<T> where T : ISalesInputModel
{
    public SalesBaseValidator()
    {
        // Basic sales validation
        RuleFor(x => x.CustomerId)
            .GreaterThanOrEqualTo(1).WithMessage("Please select a customer.");

        RuleFor(x => x.SalesChannelId)
            .NotEqual(Guid.Empty).WithMessage("Please select a sales channel.");

        RuleFor(x => x.Status)
            .NotEqual(SalesStatus.Unknown).When(x => x.Status != SalesStatus.Pending)
            .WithMessage("Please select a valid order status.")
            .Must(BeAValidSalesStatus)
            .WithMessage("Please select a valid order status.");

        RuleFor(x => x.DateSalesed)
            .NotEmpty().WithMessage("The order date must not be empty.");

        // Payment information validation
        RuleFor(x => x.PaymentStatus)
            .Must(BeAValidPaymentStatus)
            .WithMessage("Please select a valid payment status.");

        RuleFor(x => x.PaymentMethod)
            .NotEmpty().When(x => x.PaymentStatus != PaymentStatus.Unknown)
            .WithMessage("Please provide a payment method when a payment status is set.");

        // Invoice address validation
        RuleFor(x => x.InvoiceAddressFirstName)
            .NotEmpty().WithMessage("The first name for the invoice address is required.");

        RuleFor(x => x.InvoiceAddressLastName)
            .NotEmpty().WithMessage("The last name for the invoice address is required.");

        RuleFor(x => x.InvoiceAddressStreet)
            .NotEmpty().WithMessage("The street for the invoice address is required.");

        RuleFor(x => x.InvoiceAddressCity)
            .NotEmpty().WithMessage("The city for the invoice address is required.");

        RuleFor(x => x.InvoiceAddressZip)
            .NotEmpty().WithMessage("The postal code for the invoice address is required.");

        RuleFor(x => x.InvoiceAddressCountry)
            .NotEmpty().WithMessage("The country for the invoice address is required.");

        // Delivery address validation - only required if different from invoice address
        When(x => DeliveryAddressDiffersFromInvoice(x), () =>
        {
            RuleFor(x => x.DeliveryAddressFirstName)
                .NotEmpty().WithMessage("The first name for the delivery address is required.");

            RuleFor(x => x.DeliveryAddressLastName)
                .NotEmpty().WithMessage("The last name for the delivery address is required.");

            RuleFor(x => x.DeliveryAddressStreet)
                .NotEmpty().WithMessage("The street for the delivery address is required.");

            RuleFor(x => x.DeliveryAddressCity)
                .NotEmpty().WithMessage("The city for the delivery address is required.");

            RuleFor(x => x.DeliveryAddressZip)
                .NotEmpty().WithMessage("The postal code for the delivery address is required.");

            RuleFor(x => x.DeliveryAddressCountry)
                .NotEmpty().WithMessage("The country for the delivery address is required.");
        });

        // Totals validation
        RuleFor(x => x.Subtotal)
            .GreaterThanOrEqualTo(0).WithMessage("The subtotal must be greater than or equal to 0.");

        RuleFor(x => x.ShippingCost)
            .GreaterThanOrEqualTo(0).WithMessage("The shipping cost must be greater than or equal to 0.");

        RuleFor(x => x.TotalTax)
            .GreaterThanOrEqualTo(0).WithMessage("The tax amount must be greater than or equal to 0.");

        RuleFor(x => x.Total)
            .GreaterThanOrEqualTo(0).WithMessage("The total must be greater than or equal to 0.");

        // Validate that total equals subtotal + shipping cost + tax
        RuleFor(x => x.Total)
            .Equal(x => x.Subtotal + x.ShippingCost + x.TotalTax)
            .WithMessage("The total does not match the sum of subtotal, shipping cost and tax.");
    }

    private bool DeliveryAddressDiffersFromInvoice(T model)
    {
        return model.DeliveryAddressFirstName != model.InvoiceAddressFirstName ||
               model.DeliveryAddressLastName != model.InvoiceAddressLastName ||
               model.DeliveryAddressStreet != model.InvoiceAddressStreet ||
               model.DeliveryAddressCity != model.InvoiceAddressCity ||
               model.DeliveryAddressZip != model.InvoiceAddressZip ||
               model.DeliveryAddressCountry != model.InvoiceAddressCountry;
    }

    private bool BeAValidSalesStatus(SalesStatus status)
    {
        return Enum.IsDefined(typeof(SalesStatus), status);
    }

    private bool BeAValidPaymentStatus(PaymentStatus status)
    {
        return Enum.IsDefined(typeof(PaymentStatus), status);
    }
}

using FluentValidation;

namespace asToolkit.Application.Features.ProductImage.Commands.ProductImageUpload;

public class ProductImageUploadValidator : AbstractValidator<ProductImageUploadCommand>
{
    public ProductImageUploadValidator()
    {
        RuleFor(c => c.ProductId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(c => c.File)
            .NotNull().WithMessage("A file is required.");

        RuleFor(c => c.File.Length)
            .GreaterThan(0).When(c => c.File != null)
            .WithMessage("The uploaded file is empty.");
    }
}

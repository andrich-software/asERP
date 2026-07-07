using asERP.Application.Contracts.Persistence;
using asERP.Domain.Dtos.Feed;
using asERP.Domain.Enums;
using FluentValidation;

namespace asERP.Application.Features.Feed;

/// <summary>
/// Shared validation rules for feed create/update commands (both inherit <see cref="FeedInputDto"/>).
/// </summary>
public abstract class FeedInputValidator<T> : AbstractValidator<T> where T : FeedInputDto
{
    private static readonly SalesChannelType[] LinkableChannelTypes =
    {
        SalesChannelType.Shopware6,
        SalesChannelType.WooCommerce,
        SalesChannelType.WooCommerceDatabase
    };

    private readonly ISalesChannelRepository _salesChannelRepository;

    protected FeedInputValidator(ISalesChannelRepository salesChannelRepository)
    {
        _salesChannelRepository = salesChannelRepository;

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Currency)
            .NotEmpty()
            .Length(3)
            .WithMessage("Currency must be a 3-letter ISO 4217 code.");

        RuleFor(x => x.Template)
            .IsInEnum();

        RuleFor(x => x)
            .MustAsync(LinkedSalesChannelIsValid)
            .WithMessage("The linked sales channel must be an existing Shopware6 or WooCommerce channel.");
    }

    private async Task<bool> LinkedSalesChannelIsValid(T command, CancellationToken cancellationToken)
    {
        if (command.SalesChannelId is null)
        {
            return true;
        }

        var channel = await _salesChannelRepository.GetByIdAsync(command.SalesChannelId.Value, asNoTracking: true);
        return channel != null && LinkableChannelTypes.Contains(channel.Type);
    }
}

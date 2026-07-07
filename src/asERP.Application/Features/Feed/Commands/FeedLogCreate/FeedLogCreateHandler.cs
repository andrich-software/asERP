using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Entities;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Commands.FeedLogCreate;

public class FeedLogCreateHandler : IRequestHandler<FeedLogCreateCommand, Result<Guid>>
{
    private const int MaxIpLength = 45;
    private const int MaxUserAgentLength = 512;

    private readonly IAppLogger<FeedLogCreateHandler> _logger;
    private readonly IGenericRepository<FeedLog> _feedLogRepository;

    public FeedLogCreateHandler(IAppLogger<FeedLogCreateHandler> logger, IGenericRepository<FeedLog> feedLogRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _feedLogRepository = feedLogRepository ?? throw new ArgumentNullException(nameof(feedLogRepository));
    }

    public async Task<Result<Guid>> Handle(FeedLogCreateCommand request, CancellationToken cancellationToken)
    {
        var result = new Result<Guid>();

        try
        {
            var log = new FeedLog
            {
                FeedId = request.FeedId,
                IpAddress = Truncate(request.IpAddress, MaxIpLength),
                UserAgent = Truncate(request.UserAgent, MaxUserAgentLength)
            };

            await _feedLogRepository.CreateAsync(log);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Created;
            result.Data = log.Id;
        }
        catch (Exception ex)
        {
            // Logging must never break feed delivery — swallow into a failed Result the caller can ignore.
            result.FromException(_logger, ex,
                "An error occurred while recording the feed access.",
                "Error recording access for feed {Id}.", request.FeedId);
        }

        return result;
    }

    private static string? Truncate(string? value, int maxLength) =>
        string.IsNullOrEmpty(value) || value.Length <= maxLength ? value : value[..maxLength];
}

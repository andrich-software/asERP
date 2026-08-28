using asERP.Application.Mediator;
using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Statistic.Queries.DashboardTodos;

public record DashboardTodosQuery : IRequest<Result<DashboardTodosDto>>;

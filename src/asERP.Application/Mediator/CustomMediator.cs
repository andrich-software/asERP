using System.Collections;
using System.Collections.Concurrent;
using System.Reflection;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using ValidationException = asERP.Application.Exceptions.ValidationException;

namespace asERP.Application.Mediator;

/// <summary>
/// Custom mediator implementation to replace MediatR
/// </summary>
public class CustomMediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    // Resolved handler type + Handle MethodInfo cached per request/notification type to avoid
    // reflecting (MakeGenericType + GetMethod) on every Send/Publish on the request hot path.
    private static readonly ConcurrentDictionary<(Type RequestType, Type ResponseType), (Type HandlerType, MethodInfo HandleMethod)> SendCache = new();
    private static readonly ConcurrentDictionary<Type, (Type HandlerType, Type EnumerableType, MethodInfo HandleMethod)> PublishCache = new();

    // IEnumerable<IValidator<TRequest>> per request type, cached for the same reason as SendCache.
    private static readonly ConcurrentDictionary<Type, Type> ValidatorCache = new();

    public CustomMediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    /// <summary>
    /// Send a request to its handler. Registered <see cref="IValidator{T}"/> instances for the
    /// request run first; if any of them fails the handler is never invoked and a
    /// <see cref="ValidationException"/> is thrown.
    /// </summary>
    /// <typeparam name="TResponse">The type of response expected</typeparam>
    /// <param name="request">The request to send</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The response from the handler</returns>
    /// <exception cref="ValidationException">The request failed one of its validators.</exception>
    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var requestType = request.GetType();

        await ValidateAsync(request, requestType, cancellationToken);

        var (handlerType, handleMethod) = SendCache.GetOrAdd((requestType, typeof(TResponse)), static key =>
        {
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(key.RequestType, key.ResponseType);
            var handleMethod = handlerType.GetMethod("Handle")
                ?? throw new InvalidOperationException($"Handle method not found on handler for {key.RequestType.Name}");
            return (handlerType, handleMethod);
        });

        var handler = _serviceProvider.GetService(handlerType);
        if (handler == null)
        {
            throw new InvalidOperationException($"No handler found for request type {requestType.Name}");
        }

        var task = (Task<TResponse>)handleMethod.Invoke(handler, new object[] { request, cancellationToken })!;
        return await task;
    }

    /// <summary>
    /// Runs every validator registered for the request's runtime type and throws if any rule fails.
    /// Failures from all validators are collected so the caller sees the complete picture rather
    /// than only the first validator's errors.
    /// </summary>
    private async Task ValidateAsync(object request, Type requestType, CancellationToken cancellationToken)
    {
        if (request is ISkipPipelineValidation)
            return;

        var validatorEnumerableType = ValidatorCache.GetOrAdd(requestType, static type =>
            typeof(IEnumerable<>).MakeGenericType(typeof(IValidator<>).MakeGenericType(type)));

        if (_serviceProvider.GetService(validatorEnumerableType) is not IEnumerable<IValidator> validators)
            return;

        List<ValidationFailure>? failures = null;
        ValidationContext<object>? context = null;

        foreach (var validator in validators)
        {
            // Built lazily so requests without validators never allocate a context.
            context ??= new ValidationContext<object>(request);

            var validationResult = await validator.ValidateAsync(context, cancellationToken);
            if (validationResult.IsValid)
                continue;

            (failures ??= new List<ValidationFailure>()).AddRange(validationResult.Errors);
        }

        if (failures is not null)
            throw new ValidationException(failures);
    }

    /// <summary>
    /// Publish a notification to all registered handlers. Handlers run sequentially; exceptions
    /// are collected and rethrown as an <see cref="AggregateException"/> after all handlers complete.
    /// Resolution uses the runtime type of the notification, so the call site can pass a concrete
    /// notification through a base type without losing handler dispatch.
    /// </summary>
    public async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
        where TNotification : INotification
    {
        if (notification is null)
            throw new ArgumentNullException(nameof(notification));

        var notificationType = notification.GetType();
        var (_, enumerableType, handleMethod) = PublishCache.GetOrAdd(notificationType, static type =>
        {
            var handlerType = typeof(INotificationHandler<>).MakeGenericType(type);
            var enumerableType = typeof(IEnumerable<>).MakeGenericType(handlerType);
            var handleMethod = handlerType.GetMethod("Handle")
                ?? throw new InvalidOperationException($"Handle method not found on {handlerType.Name}");
            return (handlerType, enumerableType, handleMethod);
        });

        var handlers = _serviceProvider.GetService(enumerableType) as IEnumerable;
        if (handlers is null)
            return;

        List<Exception>? exceptions = null;
        var args = new object[] { notification, cancellationToken };

        foreach (var handler in handlers)
        {
            try
            {
                var task = (Task)handleMethod.Invoke(handler, args)!;
                await task;
            }
            catch (TargetInvocationException tie) when (tie.InnerException is not null)
            {
                (exceptions ??= new List<Exception>()).Add(tie.InnerException);
            }
            catch (Exception ex)
            {
                (exceptions ??= new List<Exception>()).Add(ex);
            }
        }

        if (exceptions is null)
            return;
        if (exceptions.Count == 1)
            throw exceptions[0];
        throw new AggregateException(exceptions);
    }
}

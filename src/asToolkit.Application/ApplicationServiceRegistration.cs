using System.Reflection;
using asToolkit.Application.Contracts.Identity;
using asToolkit.Application.Contracts.Services;
using asToolkit.Application.Features.Shipping.Services;
using asToolkit.Application.Mediator;
using asToolkit.Application.Services.Identity;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace asToolkit.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register custom mediator
        services.AddScoped<IMediator, CustomMediator>();

        // Register services
        services.AddScoped<IUserTenantService, UserTenantService>();
        services.AddScoped<IShippingStatusUpdater, ShippingStatusUpdater>();
        services.AddScoped<ISalesShippingStatusService, SalesShippingStatusService>();
        services.AddScoped<IShippingDestinationResolver, ShippingDestinationResolver>();
        services.AddScoped<IShippingDocumentDataService, ShippingDocumentDataService>();

        // Register FluentValidation validators
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Register all handlers
        RegisterHandlers(services);

        return services;
    }

    private static void RegisterHandlers(IServiceCollection services)
    {
        RegisterHandlersFromAssembly(services, Assembly.GetExecutingAssembly());
    }

    /// <summary>
    /// Scans the given assembly for <see cref="IRequestHandler{TRequest,TResponse}"/> and
    /// <see cref="INotificationHandler{TNotification}"/> implementations and registers them
    /// in DI. Layers outside <c>asToolkit.Application</c> (e.g. <c>asToolkit.SalesChannels</c>) call
    /// this from their own <c>*ServiceRegistration</c> so notification handlers defined there
    /// are picked up by the mediator's <see cref="CustomMediator.Publish{TNotification}"/>.
    /// </summary>
    public static IServiceCollection RegisterHandlersFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        var concreteTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .ToArray();

        foreach (var type in concreteTypes)
        {
            var handlerInterfaces = type.GetInterfaces()
                .Where(i => i.IsGenericType &&
                    (i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) ||
                     i.GetGenericTypeDefinition() == typeof(INotificationHandler<>)));

            foreach (var handlerInterface in handlerInterfaces)
            {
                services.AddScoped(handlerInterface, type);
            }
        }

        return services;
    }
}

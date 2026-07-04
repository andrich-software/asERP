using System.Reflection;
using asERP.Application.Contracts.Identity;
using asERP.Application.Contracts.Services;
using asERP.Application.Features.Shipping.Services;
using asERP.Application.Mediator;
using asERP.Application.Services.Identity;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace asERP.Application;

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
    /// in DI. Layers outside <c>asERP.Application</c> (e.g. <c>asERP.SalesChannels</c>) call
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

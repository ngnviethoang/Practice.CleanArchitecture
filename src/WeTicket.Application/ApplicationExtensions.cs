using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WeTicket.Application.Shared.Common;
using WeTicket.Application.Shared.Dispatchers;

namespace WeTicket.Application;

public static class ApplicationExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddApplication()
        {
            services.AddScoped<IDispatcher, Dispatcher>();
            services.AddHandlers();
            services.AddValidatorsFromAssembly(AssemblyReference.Assembly);
            return services;
        }

        private void AddHandlers()
        {
            IEnumerable<Type> handlers = AssemblyReference.Assembly
                .GetTypes()
                .Where(type => type.GetInterfaces().Any(interfaceType => interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                .Where(type => !type.IsAbstract && !type.IsInterface && !type.IsGenericType);

            foreach (Type handler in handlers)
            {
                services.AddScoped(handler);
            }
        }
    }
}
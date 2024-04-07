using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MediatorPractice.Application
{
    public static class DependencyInjection
    {
        public static void RegisterExternalApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}

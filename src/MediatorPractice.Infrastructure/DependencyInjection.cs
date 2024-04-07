using MediatorPractice.Application.Common.Repositories;
using MediatorPractice.Infrastructure.Repositories;
using MediatorPractice.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPractice.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();

        }
    }
}

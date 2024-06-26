using Microsoft.Extensions.DependencyInjection;
using Portfolio.Core.Abstractions.IServices;
using Portfolio.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.DIContainer
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,string webrootPath)
        {
            services.AddScoped<IUsersService,UsersService>();
            services.AddScoped<IProjectsService,ProjectService>();
            services.AddSingleton<IStorageService>(new StorageService(webrootPath));
            return services;
        }
    }
}

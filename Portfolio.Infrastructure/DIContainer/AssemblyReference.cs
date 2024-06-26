using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Core.Abstractions.IServices;
using Portfolio.Domain.Models;
using Portfolio.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Infrastructure.DIContainer
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddInfraStructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IJwtService, JwtService>();
            services.Configure<Jwt>(configuration.GetSection(nameof(Jwt)));
            return services;
        }
    }
}

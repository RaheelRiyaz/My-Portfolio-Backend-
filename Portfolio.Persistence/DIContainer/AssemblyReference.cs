using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Core.Abstractions.IRepository;
using Portfolio.Persistence.Database;
using Portfolio.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Persistence.DIContainer
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContextPool<RaheelPortfolioDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("PortfolioRaheelDbContext")); 
            });

            services.AddScoped<ISkillsRepository, SkillsRepository>();
            services.AddScoped<IProjectsRepository, ProjectsRepository>();
            services.AddScoped<IExperiencesRepository, ExperiencesRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            return services;
        }
    }
}

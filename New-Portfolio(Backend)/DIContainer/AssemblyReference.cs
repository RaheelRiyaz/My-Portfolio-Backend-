using Microsoft.Extensions.Configuration;

namespace New_Portfolio_Backend_.DIContainer
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services,IConfiguration configuration)
        {
            
            return services;
        }
    }
}

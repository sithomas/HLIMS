using HLIMS_API_MicroServices.Data;
using HLIMS_API_MicroServices.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
namespace HLIMS_API_MicroServices.Domain.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerDao, CustomerDao>();
         
        }
    }
}
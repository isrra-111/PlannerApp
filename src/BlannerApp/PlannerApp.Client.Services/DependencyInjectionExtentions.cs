
using Microsoft.Extensions.DependencyInjection;
using PlannerApp.Client.Services.Interfaces;
using System.ComponentModel.Design;

namespace PlannerApp.Client.Services
{
    public static class DependencyInjectionExtentions
    {
        public static IServiceCollection AddHttpClientService(this IServiceCollection services)
        {

            return services.AddScoped<IAuthenticationService,HttpAuthenticationService>();
        }
    }
}

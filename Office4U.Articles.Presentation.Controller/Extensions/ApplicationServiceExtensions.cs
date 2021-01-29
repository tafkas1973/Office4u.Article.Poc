using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Office4U.Articles.Data.Ef.SqlServer.Extensions;
using Office4U.Articles.Presentation.Controller.Services;
using Office4U.Articles.Presentation.Controller.Services.Interfaces;
using Office4U.Articles.WriteApplication.Extensions;

namespace Office4U.Articles.Presentation.Controller.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            // Application layer (Read & Write)
            services.AddScoped<ITokenService, TokenService>();
            services.RegisterApplicationServices();

            // Persistence layer
            services.RegisterDataServices(configuration);

            return services;
        }
    }
}
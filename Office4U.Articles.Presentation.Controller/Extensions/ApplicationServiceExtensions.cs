using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Office4U.Articles.Data.Ef.SqlServer;
using Office4U.Articles.Data.Ef.SqlServer.Extensions;
using Office4U.Articles.Data.Ef.SqlServer.Interfaces;
using Office4U.Articles.Data.Ef.SqlServer.Repositories;
using Office4U.Articles.Data.Ef.SqlServer.UnitOfWork;
using Office4U.Articles.ImportExport.Api.Services;
using Office4U.Articles.ImportExport.Api.Services.Interfaces;

namespace Office4U.Articles.ImportExport.Api.Extensions
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
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.RegisterReadApplicationServices();
            services.RegisterWriteApplicationServices();

            // Persistence layer
            services.RegisterDataServices(configuration);

            return services;
        }
    }
}
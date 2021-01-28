using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Office4U.Articles.Data.Ef.SqlServer;
using Office4U.Articles.Data.Ef.SqlServer.Interfaces;
using Office4U.Articles.Data.Ef.SqlServer.Repositories;
using Office4U.Articles.Data.Ef.SqlServer.UnitOfWork;
using Office4U.Articles.ImportExport.Api.Helpers;
using Office4U.Articles.ImportExport.Api.Services;
using Office4U.Articles.ImportExport.Api.Services.Interfaces;
using Office4U.Articles.ReadApplication.Article.Interfaces;
using Office4U.Articles.ReadApplication.Article.Queries;
using Office4U.Articles.WriteApplication.Article.Commands;
using Office4U.Articles.WriteApplication.Article.Interfaces;

namespace Office4U.Articles.ImportExport.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            services.AddScoped<ITokenService, TokenService>();

            // TODO: move to application layer
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddScoped<IGetArticlesListQuery, GetArticlesListQuery>();
            services.AddScoped<ICreateArticleCommand, CreateArticleCommand>();
            services.AddScoped<IUpdateArticleCommand, UpdateArticleCommand>();

            // TODO: move to EF layer
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
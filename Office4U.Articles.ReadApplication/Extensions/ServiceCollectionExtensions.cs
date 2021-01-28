using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Office4U.Articles.ReadApplication.Article.Interfaces;
using Office4U.Articles.ReadApplication.Article.Queries;

namespace Office4U.Articles.Data.Ef.SqlServer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterReadApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddScoped<IGetArticlesListQuery, GetArticlesListQuery>();
            services.AddScoped<IGetArticleQuery, GetArticleQuery>();
        }
    }
}

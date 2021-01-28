using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Office4U.Articles.WriteApplication.Article.Commands;
using Office4U.Articles.WriteApplication.Article.Interfaces;
using Office4U.Articles.WriteApplication.Helpers;

namespace Office4U.Articles.WriteApplication.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterWriteApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddScoped<ICreateArticleCommand, CreateArticleCommand>();
            services.AddScoped<IUpdateArticleCommand, UpdateArticleCommand>();
            services.AddScoped<IDeleteArticleCommand, DeleteArticleCommand>();
        }
    }
}

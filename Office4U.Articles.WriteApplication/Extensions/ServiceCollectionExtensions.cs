using Microsoft.Extensions.DependencyInjection;
using Office4U.Articles.WriteApplication.Article.Commands;
using Office4U.Articles.WriteApplication.Article.Interfaces;

namespace Office4U.Articles.Data.Ef.SqlServer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterWriteApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateArticleCommand, CreateArticleCommand>();
            services.AddScoped<IUpdateArticleCommand, UpdateArticleCommand>();
            services.AddScoped<IDeleteArticleCommand, DeleteArticleCommand>();
        }
    }
}

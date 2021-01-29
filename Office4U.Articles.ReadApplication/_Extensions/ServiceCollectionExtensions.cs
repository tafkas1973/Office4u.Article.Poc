//using AutoMapper;
//using Microsoft.Extensions.DependencyInjection;
//using Office4U.Articles.ReadApplication.Article.Interfaces;
//using Office4U.Articles.ReadApplication.Article.Interfaces.IOC;
//using Office4U.Articles.ReadApplication.Article.Queries;
//using Office4U.Articles.ReadApplication.Helpers;

//namespace Office4U.Articles.ReadApplication.Extensions
//{
//    public static class ServiceCollectionExtensions
//    {
//        public static void RegisterReadApplicationServices(this IServiceCollection services)
//        {
//            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
//            services.AddScoped<IReadOnlyArticleRepository, IReadOnlyArticleRepository>();
//            services.AddScoped<IGetArticlesListQuery, GetArticlesListQuery>();
//            services.AddScoped<IGetArticleQuery, GetArticleQuery>();
//        }
//    }
//}

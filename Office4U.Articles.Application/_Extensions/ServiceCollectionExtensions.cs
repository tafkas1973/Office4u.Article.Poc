﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Office4U.Articles.Data.Ef.SqlServer.Repositories;
using Office4U.Articles.Data.Ef.SqlServer.UnitOfWork;
using Office4U.Articles.ReadApplication.Article.Interfaces;
using Office4U.Articles.ReadApplication.Article.Interfaces.IOC;
using Office4U.Articles.ReadApplication.Article.Queries;
using Office4U.Articles.WriteApplication.Article.Commands;
using Office4U.Articles.WriteApplication.Article.Interfaces;
using Office4U.Articles.WriteApplication.Article.Interfaces.IOC;
using Office4U.Articles.WriteApplication.Helpers;
using Office4U.Articles.WriteApplication.Interfaces.IOC;

namespace Office4U.Articles.WriteApplication.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            services.AddScoped<IReadOnlyArticleRepository, ReadOnlyArticleRepository>();
            services.AddScoped<IGetArticlesListQuery, GetArticlesListQuery>();
            services.AddScoped<IGetArticleQuery, GetArticleQuery>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<ICreateArticleCommand, CreateArticleCommand>();
            services.AddScoped<IUpdateArticleCommand, UpdateArticleCommand>();
            services.AddScoped<IDeleteArticleCommand, DeleteArticleCommand>();
        }
    }
}

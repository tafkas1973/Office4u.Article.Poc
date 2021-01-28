//https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/platform-specific-configuration?view=aspnetcore-3.1#class-library

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Office4U.Articles.Data.Ef.SqlServer;
using Office4U.Articles.Data.Ef.SqlServer.SeedData;
using Office4U.Articles.Domain.Model.Entities;
using System;

[assembly: HostingStartup(typeof(HostingStartupLibrary.ServiceKeyInjection))]

namespace HostingStartupLibrary
{
    public class ServiceKeyInjection : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                try
                {
                    //services.AddDbContext<DataContext>(options =>
                    //{
                    //    options.UseSqlServer(Config.GetConfiguration().GetConnectionString("DefaultConnection"));
                    //});
                }
                catch (Exception ex)
                {
                    var logger = ((IServiceProvider)services).GetRequiredService<ILogger<ServiceKeyInjection>>();
                    logger.LogError(ex, "An error occured during migration");
                }


                //try
                //{
                //    var ctx = ((IServiceProvider)services).GetRequiredService<DataContext>();
                //    var userManager = ((IServiceProvider)services).GetRequiredService<UserManager<AppUser>>();
                //    var roleManager = ((IServiceProvider)services).GetRequiredService<RoleManager<AppRole>>();
                //    ctx.Database.MigrateAsync().Wait();
                //    Seed.SeedUsers(userManager, roleManager).Wait();
                //    Seed.SeedArticles(ctx).Wait();
                //}
                //catch (Exception ex)
                //{
                //    var logger = ((IServiceProvider)services).GetRequiredService<ILogger<ServiceKeyInjection>>();
                //    logger.LogError(ex, "An error occured during migration");
                //}                
            });
        }
    }
}
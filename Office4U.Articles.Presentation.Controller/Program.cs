using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Office4U.Articles.Presentation.Controller
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args).Build();

            using var scope = hostBuilder.Services.CreateScope();

            var services = scope.ServiceProvider;

            // TODO: replace to EF layer
            //try
            //{
            //    var context = services.GetRequiredService<DataContext>();
            //    var userManager = services.GetRequiredService<UserManager<AppUser>>();
            //    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
            //    await context.Database.MigrateAsync();
            //    await Seed.SeedUsers(userManager, roleManager);
            //    await Seed.SeedArticles(context);
            //}
            //catch (Exception ex)
            //{
            //    var logger = services.GetRequiredService<ILogger<Program>>();
            //    logger.LogError(ex, "An error occured during migration");
            //}

            await hostBuilder.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

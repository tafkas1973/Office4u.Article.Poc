//https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/platform-specific-configuration?view=aspnetcore-3.1#class-library

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

[assembly: HostingStartup(typeof(HostingStartupLibrary.ServiceKeyInjection))]

namespace HostingStartupLibrary
{
    public static class Config
    {
        private static IConfiguration _configuration;
        static Config()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }

        public static string Get(string name)
        {
            string appSettings = _configuration[name];
            return appSettings;
        }

        public static IConfiguration GetConfiguration()
        {
            return _configuration;
        }
    }
}
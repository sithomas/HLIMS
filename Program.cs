using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
namespace HLIMS_API_MicroServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                 .ConfigureAppConfiguration(ConfigureAppConfiguration)
                 .ConfigureServices(services => { services.AddMvc(); })
                .UseUrls("http://*:5000")
                 .UseStartup<Startup>();
        }
          private static void ConfigureAppConfiguration(WebHostBuilderContext context, IConfigurationBuilder builder)
        {
            var env = context.HostingEnvironment;

            builder
                .SetBasePath(Environment.CurrentDirectory)
                .AddEnvironmentVariables(prefix: "ASPNETCORE_");
        }
    }
}

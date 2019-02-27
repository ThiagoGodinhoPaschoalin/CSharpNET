using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebApiMVC_Example1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            logger.LogInformation(Logging.LoggingEvents.ProgramLevel,"@@ With Dependency injection in Main, this appears!");
                
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    //Now you can use scope "using (_logger.BeginScope("start"))"
                    logging.AddConsole(options => options.IncludeScopes = true);
                })
                .UseStartup<Startup>();
    }
}
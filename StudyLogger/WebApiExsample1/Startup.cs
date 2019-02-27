using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebApiMVC_Example1.Models;

namespace WebApiMVC_Example1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly ILogger _logger;

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<WebApiMVC_Example1Context>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("WebApiMVC_Example1Context")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            BaseExampleForLogger();
        }

        private void BaseExampleForLogger()
        {
            _logger.LogInformation  (Logging.LoggingEvents.StartupLevel, "@@ This is a INFORMATION");
            _logger.LogWarning      (Logging.LoggingEvents.StartupLevel, "@@ This is a WARNING");
            _logger.LogDebug        (Logging.LoggingEvents.StartupLevel, "@@ This is a DEBUG");
            _logger.LogCritical     (Logging.LoggingEvents.StartupLevel, "@@ This is a CRITICAL");
            _logger.LogError        (Logging.LoggingEvents.StartupLevel, "@@ This is a ERROR");
            _logger.LogTrace        (Logging.LoggingEvents.StartupLevel, "@@ This is a TRACE");
        }
    }
}

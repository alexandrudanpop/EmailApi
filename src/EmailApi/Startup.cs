using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmailApi
{
    class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true);

            builder.AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
            app.UseMvc();
            app.UseCors("EmailApi");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().AddJsonFormatters();
            services.AddMvc();

            services.AddCors(
                o => o.AddPolicy("EmailApi", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.Configure<MvcOptions>(
                options => { options.Filters.Add(new CorsAuthorizationFilterFactory("EmailApi")); });

            services.AddOptions();
            services.Configure<Settings>(this.Configuration);
        }

    }
}

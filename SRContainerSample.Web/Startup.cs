using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SRContainerSample.Web.Models;
using SRContainerSample.Web.Services;
using System;
using System.Net;
using System.Net.Http;

namespace SRContainerSample.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCaching();
            services.AddControllers();
            services.AddHealthChecks();
            services.AddHttpClient<IWeatherService, AccuweatherService>().ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            });

            services.Configure<AccuweatherSettings>(Configuration.GetSection(nameof(AccuweatherSettings)));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/api/Error/500");
            app.UseStatusCodePagesWithReExecute("/api/Error/{0}");            
            
            app.UseRouting();
            
            app.UseResponseCaching();
            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(60)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };

                await next();
            });

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseHealthChecks("/api/healthcheck");
        }
    }
}


using System.IO;
using CascadianAerialRobotics.Website.DependencyProfiles.DevelopmentLocal;
using CascadianAerialRobotics.Website.DependencyProfiles.Production;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;

namespace mvc_website
{
    public class Startup
    {
        private const string Http404Text = "<!DOCTYPE html>\r\n<html lang=\"en\" class=\"no-js\">\r\n<head>\r\n    <meta charset=\"utf-8\">\r\n    <title>Page not found</title>\r\n    <meta name=\"description\" content=\"\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, maximum-scale=1\">\r\n    <meta property=\"og:image\" content=\"https://cascadian-aerial-robotics-cdn1.azureedge.net/img/404.webp\">\r\n    <!--Favicon-->\r\n    <link rel=\"icon\" href=\"https://cascadian-aerial-robotics-cdn1.azureedge.net/img/favicon/favicon.ico\">\r\n    <!--Libs css-->\r\n    <link rel=\"stylesheet\" href=\"https://cascadian-aerial-robotics-cdn1.azureedge.net/v1-0/css/libs.css\">\r\n    <!--Main css-->\r\n    <link rel=\"stylesheet\" href=\"https://cascadian-aerial-robotics-cdn1.azureedge.net/v1-0/css/main.css\">\r\n</head>\r\n<body>\r\n    <header id=\"top-nav\" class=\"top-nav page-header\">\r\n        <div class=\"container\">\r\n            <a href=\"/\" class=\"logo smooth-scroll\"><img src=\"https://cascadian-aerial-robotics-cdn1.azureedge.net/img/cascadian-logo.png\" alt=\"logo\" class=\"logo-white\"><img src=\"https://cascadian-aerial-robotics-cdn1.azureedge.net/img/cascadian-logo-dark.png\" alt=\"logo\" class=\"logo-dark\"></a>\r\n        </div>\r\n    </header>\r\n        \r\n    <!-- End full screen top nav-->\r\n    <div id=\"top\" class=\"slider\">\r\n        <div class=\"wrap-header\">\r\n            <!-- Start slide-->\r\n            <div data-image=\"https://cascadian-aerial-robotics-cdn1.azureedge.net/img/404.webp\" class=\"slide bg-mask background-image full-vh\" style=\"background-image: url('https://cascadian-aerial-robotics-cdn1.azureedge.net/img/404.webp');\">\r\n                <div class=\"container-slide vertical-align center\">\r\n                    <div class=\"container\">\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-12\">\r\n                                <h1 class=\"heading-title-big\">\r\n\r\n                                    Page not <span>found</span>\r\n                                </h1>\r\n                                <div class=\"description-slide\">It seems you are a little lost <span>Need some mapping maybe?</span></div>\r\n                                <div class=\"buttons-section\"><a href=\"https://www.cascadianaerialrobotics.com/\" class=\" btn dark-btn large-btn\">Go to the main page</a></div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>\r\n    ";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        #region Default
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddApplicationInsightsTelemetry();
            services.AddSingleton<ILogger>(new ApplicationInsightsLogger("cascadian-mainpage", new Microsoft.ApplicationInsights.TelemetryClient(), new ApplicationInsightsLoggerOptions() { IncludeScopes = false }));


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            // Custom services

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.EnvironmentName.Contains("development", System.StringComparison.InvariantCultureIgnoreCase))
            {
                app.UseDeveloperExceptionPage();


            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        #endregion


        #region DevelopmentLocal

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureDevelopmentLocalServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            // Custom services
            services.AddDevelopmentLocalProfile();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureDevelopmentLocal(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseDefaultFiles(); //Uncomment to use precompiled versions of static pages.
            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseStatusCodePages(async context =>
            {
                if (context.HttpContext.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    //  TODO: Issue #10 : What a fugly solution, I know, but I need to do this for the release, I'll attach the razor renderer.
                    await context.HttpContext.Response.WriteAsync(Http404Text);
                }

            });

            app.UseMvc(routes =>
              {
                  routes.MapRoute(
                      name: "default",
                      template: "{controller=Home}/{action=Index}/{id?}");
              });
        }
        #endregion

        #region Production

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            // Custom services
            services.AddProductionProfile();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureProduction(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseExceptionHandler("/Home/Error");

            app.UseStatusCodePages(async context =>
            {
                if (context.HttpContext.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    //  TODO: Issue #10 : What a fugly solution, I know, but I need to do this for the release, I'll attach the razor renderer.
                    await context.HttpContext.Response.WriteAsync(Http404Text);
                }

            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        #endregion

        #region DevelopmentAzure

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureDevelopmentAzureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            // Custom services
            services.AddProductionProfile();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureDevelopmentAzure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            //app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseExceptionHandler("/Home/Error");

            app.UseStatusCodePages(async context =>
            {
                if (context.HttpContext.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    //  TODO: Issue #10 : What a fugly solution, I know, but I need to do this for the release, I'll attach the razor renderer.
                    await context.HttpContext.Response.WriteAsync(Http404Text);
                }

            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        #endregion
    }
}

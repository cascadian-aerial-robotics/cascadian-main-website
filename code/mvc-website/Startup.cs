
using System.IO;
using CascadianAerialRobotics.Website.DependencyProfiles.Production;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mvc_website
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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


            // Custom services
            services.AddProductionProfile();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            }

            app.UseStatusCodePages(async context =>
            {
                if(context.HttpContext.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    //var viewEngineResult = ViewEngines.Engines.FindView(new System.Web.Mvc.ControllerContext(), "Http404//Index", null);






                    ////new RazorViewEngine(new DefaultRazorPageFactoryProvider(RazorViewEngine. // app.ApplicationServices.GetService(typeof(IViewEngine)) as IViewEngine;


                    ////var tempDataProvider = app.ApplicationServices.GetService(typeof(ITempDataProvider)) as ITempDataProvider;
                    //var actionContext = new ActionContext(context.HttpContext, new RouteData(), new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());
                    ////var view = viewEngine.FindView(actionContext, "Http404//Index", true);
                    //var sw = new StringWriter();

                    //var view = viewEngineResult.View;

                    //var viewDictionary = new System.Web.Mvc.ViewDataDictionary();


                    //var viewContext = new System.Web.Mvc.ViewContext(new System.Web.Mvc.ControllerContext(), viewEngineResult.View, viewDictionary, new System.Web.Mvc.TempDataDictionary(), sw);




                    //view.Render(viewContext, sw);




                    ////var viewContext = new ViewContext(actionContext, viewEngineResult.View, viewDictionary, new TempDataDictionary(actionContext.HttpContext, tempDataProvider), sw, new HtmlHelperOptions());



                    ////await view.View.RenderAsync(viewContext);
                    ///


                    //  TODO: Issue #10 : What a fugly solution, I know, but I need to do this for the release, I'll attach the razor renderer.
                    await context.HttpContext.Response.WriteAsync("<!DOCTYPE html>\r\n<html lang=\"en\" class=\"no-js\">\r\n<head>\r\n    <meta charset=\"utf-8\">\r\n    <title>Page not found</title>\r\n    <meta name=\"description\" content=\"\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, maximum-scale=1\">\r\n    <!--<meta property=\"og:image\" content=\"path/to/image.jpg\">-->\r\n    <!--Favicon-->\r\n    <link rel=\"icon\" href=\"https://localhost:44381//img/favicon/favicon.ico\">\r\n    <!--Libs css-->\r\n    <link rel=\"stylesheet\" href=\"https://localhost:44381//css/libs.css\">\r\n    <!--Main css-->\r\n    <link rel=\"stylesheet\" href=\"https://localhost:44381//css/main.css\">\r\n</head>\r\n<body>\r\n    <header id=\"top-nav\" class=\"top-nav page-header\">\r\n        <div class=\"container\">\r\n            <a href=\"/\" class=\"logo smooth-scroll\"><img src=\"https://localhost:44381//img/cascadian-logo.png\" alt=\"logo\" class=\"logo-white\"><img src=\"https://localhost:44381//img/cascadian-logo-dark.png\" alt=\"logo\" class=\"logo-dark\"></a>\r\n        </div>\r\n    </header>\r\n        \r\n    <!-- End full screen top nav-->\r\n    <div id=\"top\" class=\"slider\">\r\n        <div class=\"wrap-header\">\r\n            <!-- Start slide-->\r\n            <div data-image=\"https://localhost:44381/img/404.jpg\" class=\"slide bg-mask background-image full-vh\">\r\n                <div class=\"container-slide vertical-align center\">\r\n                    <div class=\"container\">\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-12\">\r\n                                <h1 class=\"heading-title-big\">\r\n\r\n                                    Page not <span>found</span>\r\n                                </h1>\r\n                                <div class=\"description-slide\">It seems you are a little lost <span>Need some mapping maybe?</span></div>\r\n                                <div class=\"buttons-section\"><a href=\"https://localhost:44381/\" class=\" btn dark-btn large-btn\">Go to the main page</a></div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>\r\n");
                        
                        }

            });

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
    }
}

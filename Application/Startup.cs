using Application.Controllers;
using Application.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace Application
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
            /*services.AddDbContext<ApplicationDbContext>(options => 
                options.UseM)*/

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
                
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Home/Error");

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "signin",
                    "signin",
                    new { controller = "Home", action = "Index" }
                );

                routes.MapRoute(
                    "registration",
                    "registration",
                    new { controller = "Home", action = "Index" }
                );

                routes.MapRoute(
                    "orders",
                    "orders",
                    new { controller = "Home", action = "Index" }
                );

                routes.MapRoute(
                    "order-overview",
                    "order-overview",
                    new { controller = "Home", action = "Index" }
                );

                routes.MapRoute(
                    "cart",
                    "cart",
                    new { controller = "Home", action = "Index" }
                );

                routes.MapRoute(
                    "settings",
                    "settings",
                    new { controller = "Home", action = "Index" }
                );

                routes.MapRoute(
                    "store",
                    "store",
                    new { controller = "Home", action = "Index" }
                );

                routes.MapRoute(
                    "contact",
                    "contact",
                    new { controller = "Home", action = "Index" }
                );

                routes.MapRoute(
                    "cases",
                    "cases",
                    new { controller = "Home", action = "Index" }
                );

                routes.MapRoute(
                    "case",
                    "case",
                    new { controller = "Home", action = "Index" }
                );

                routes.MapRoute(
                    "overview",
                    "overview",
                    new { controller = "Home", action = "Index" }
                );

                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");

       
                routes.MapRoute("administrative", "administrative/{*pages}",
                    new
                    {
                        controller = "Administrative",
                        action = "Index"
                    });

                /*routes.MapRoute(
                    "administrative",
                    "{controller=Administrative}/{action=Administrative}/{view?}");*/
            });
        }
    }
}
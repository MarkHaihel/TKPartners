using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TKPartnersV2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace TKPartnersV2
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:TKPartnersNews:ConnectionString"]));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:TKPartnersIdentity:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<INewsRepository, EFNewsRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes => {

                routes.MapRoute(
                name: null,
                template: "News/{search}/Page{newsPage:int}",
                defaults: new { controller = "Home", action = "List" }
                );

                routes.MapRoute(
                name: null,
                template: "News/Page{newsPage:int}",
                defaults: new { controller = "Home", action = "List", newsPage = 1 }
                );

                routes.MapRoute(
                    name: null,
                    template: "News/{search}",
                    defaults: new { controller = "Home", action = "List" }
                );

                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Home", action = "Index" });

                routes.MapRoute(
                    name: null,
                    template: "Practices",
                    defaults: new { controller = "Home", action = "Practices" });

                routes.MapRoute(
                    name: null,
                    template: "Practices/1",
                    defaults: new { controller = "Home", action = "Practices1" });

                routes.MapRoute(
                    name: null,
                    template: "Practices/2",
                    defaults: new { controller = "Home", action = "Practices2" });

                routes.MapRoute(
                    name: null,
                    template: "Practices/3",
                    defaults: new { controller = "Home", action = "Practices3" });


                routes.MapRoute(
                    name: null,
                    template: "Practices/4",
                    defaults: new { controller = "Home", action = "Practices4" });

                routes.MapRoute(
                    name: null,
                    template: "Practices/5",
                    defaults: new { controller = "Home", action = "Practices5" });

                routes.MapRoute(
                    name: null,
                    template: "Practices/6",
                    defaults: new { controller = "Home", action = "Practices6" });

                routes.MapRoute(
                   name: null,
                   template: "People",
                   defaults: new { controller = "Home", action = "People" });

                routes.MapRoute(
                   name: null,
                   template: "Careers",
                   defaults: new { controller = "Home", action = "Careers" });

                routes.MapRoute(
                   name: null,
                   template: "Contact",
                   defaults: new { controller = "Home", action = "Contact" });

                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });
            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportStore.Models;

namespace SportStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IRepository, EFProductRepository>();
            services.AddSingleton<CartRepository, CartRepository>();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<UsersDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UsersConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<UsersDbContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            SeedData.Seed(app);
            app.UseStaticFiles();
            app.UseMvc(
                routes =>
                {
                    routes.MapRoute(
                        name: null,
                        template: "Product/{category}/Page{page}",
                        defaults: new { controller = "Product", action = "Index" });

                    routes.MapRoute(
                        name: null,
                        template: "Product/Page{page}",
                        defaults: new { controller = "Product", action = "Index" });

                    routes.MapRoute(
                        name: null,
                        template: "Product/{category}",
                        defaults: new { controller = "Product", action = "Index" });

                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Product}/{action=Index}/{id?}");

                });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ice_Cream.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ice_Cream
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddControllersWithViews();
            services.AddDbContext<StoreDbContext>(
                opts =>
                {
                    opts.UseSqlServer(Configuration["ConnectionStrings:Ice_CreamConnection"]);
                });

            services.AddScoped<IStoreRepository, EFStoreRepository>();
            services.AddRazorPages();
            services.AddMvc();


            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();



            app.UseSession();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //name: "default",
                //pattern: "{controller=Recipe}/{action=Index}/{id?}");

                endpoints.MapControllerRoute("Id", "{Id}",
                    new { Controller = "Recipe", action = "Detail" });

                // Ân add
                endpoints.MapControllerRoute("catepage", "{category}/Page{productPage:int}",
                   new { Controller = "Recipe", action = "CateRecipe", productPage = 1 });

                endpoints.MapControllerRoute("pagination", "Recipe/Page{productPage}",
                    new { Controller = "Recipe", action = "CateRecipe", productPage = 1 });

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();

            });
            SeedData.EnsurePopulated(app);
        }
    }
}
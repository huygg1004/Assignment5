using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment5_Database.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Assignment5_Database
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
            services.AddControllersWithViews();
            //establishing connection with database using connection string and calling necessary services to querry the database
            services.AddDbContext<BookstoreDbContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookstoreConnection"]);
            });
            //Using sqlite database

            //adding a scope of the database to our user
            services.AddScoped<BookRepository, EFBookRepository>();

            //add the razor pages we just create to run when startup
            services.AddRazorPages();

            //Creating sessions to view for shopping books
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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

            //configuring endpoint with P1 or P2 or P3

            app.UseEndpoints(endpoints =>
            {
                //mapping different url such as catpage, page or category endpoint
                endpoints.MapControllerRoute("catpage",
                    "{category}/{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("page",
                    "{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", pageNum = 1 });

                endpoints.MapControllerRoute(
                    "pagination",
                    "P{pageNum}",
                    new { Controller = "Home", action = "Index" });
                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });

            //grabbing data from seeddata class
            SeedData.EnsurePopulated(app);
        }
    }
}

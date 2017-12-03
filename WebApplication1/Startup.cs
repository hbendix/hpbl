using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Services;
using AutoMapper;
using Models;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables(); // could add connection strings here.
            // here it is.q
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<WebsiteContext>(options => options.UseSqlServer(Configuration.GetConnectionString("WebsiteConnection")));
            services.AddAutoMapper();
            //----- SERVICES -----\\
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IBlogService, BlogService>();

            //----- REPOSITORIES -----\\
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

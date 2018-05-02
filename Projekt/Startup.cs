using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Projekt.Models;
using Projekt.FlickrData;
using Projekt.GmapsData;

namespace Projekt
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
            services.AddMvc();

            services.AddDbContext<ProjektContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ProjektContext")));

            services.Configure<FlickrSettings>(Configuration.GetSection("FlickrSettings"));
            services.Configure<GmapsSettings>(Configuration.GetSection("GmapsSettings"));

            services.AddTransient<IFlickrService, FlickrService>();
            services.AddTransient<IGmapsService, GmapsService>();
            
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
                    template: "{controller=DiningExperiences}/{action=Index}/{id?}");
            });
        }
    }
}

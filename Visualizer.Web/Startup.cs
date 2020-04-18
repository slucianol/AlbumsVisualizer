using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Visualizer.Core.Interfaces;
using Visualizer.Infrastructure.DTO;
using Visualizer.Infrastructure.Services;
using Visualizer.Web.MappingProfiles;

namespace Visualizer.Web {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.Configure<ServicesEndpoints>(Configuration.GetSection("ServicesEndpoints"));

            services.AddScoped<IAlbumsService, AlbumsService>();
            services.AddScoped<IPhotosService, PhotosService>();
            services.AddScoped<ICommentsService, CommentsService>();

            services.AddResponseCaching();
            services.AddResponseCompression(options => {
                options.EnableForHttps = true;
            });

            services.AddControllersWithViews();

            services.AddSingleton(provider => new MapperConfiguration(mapperConfigurations => {
                mapperConfigurations.AddProfile<DefaultMappingProfile>();
            }).CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseResponseCaching();
            app.UseResponseCompression();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Albums}/{action=GetAlbumsByUserId}/{id?}");
            });
        }
    }
}

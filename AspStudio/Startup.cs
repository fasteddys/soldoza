using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
//using AspStudio.Data;
using Infraestructure.Data.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Domain.Interfaces;
using Infraestructure.Data.Repositories;

namespace AspStudio
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
            string cnn = Configuration.GetConnectionString("DefaultConnection"); // "Server=localhost;Database=dbsoldoza;User Id= postgres; Password=admin;";

            services.AddMvc(options => options.EnableEndpointRouting = false);  
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(cnn);
            });
            services.AddTransient<ISOLDOZA_MST_MATERIALES, R_SOLDOZA_MST_MATERIALES>();
            services.AddTransient<ISOLDOZA_MST_GRL_CLIENTES, R_SOLDOZA_MST_GRL_CLIENTES>();
            services.AddTransient<ISOLDOZA_MST_PAIS, R_SOLDOZA_MST_PAIS>();
            services.AddTransient<ISOLDOZA_MST_TIPO_DOCUMENTO, R_SOLDOZA_MST_TIPO_DOCUMENTO>();
            services.AddTransient<ISOLDOZA_MST_GRL_PROYECTOS, R_SOLDOZA_MST_GRL_PROYECTOS>();
            services.AddTransient<ISOLDOZA_MST_TIPO_CONTACTO, R_SOLDOZA_MST_TIPO_CONTACTO>();
            services.AddTransient<ISOLDOZA_MST_GRL_CONTACTOS, R_SOLDOZA_MST_GRL_CONTACTOS>();
            services.AddTransient<ISOLDOZA_MST_CONTACTOS_PROYECTO, R_SOLDOZA_MST_CONTACTOS_PROYECTO>();
            services.AddTransient<ISOLDOZA_MST_ZONAS, R_SOLDOZA_MST_ZONAS>();
            services.AddTransient<ISOLDOZA_ADM_MST_LADOS, R_SOLDOZA_ADM_MST_LADOS>();
            services.AddTransient<ISOLDOZA_MST_RESULT_END, R_SOLDOZA_MST_RESULT_END>();
            services.AddTransient<ISOLDOZA_MST_POS_SOLDEO, R_SOLDOZA_MST_POS_SOLDEO>();

            services.AddMemoryCache();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
            		endpoints.MapAreaControllerRoute(  
										name: "Identity",  
										areaName: "Identity",  
										pattern: "Identity/{controller=Home}/{action=Index}");  
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
                endpoints.MapRazorPages();
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolamundoMVC1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HolamundoMVC1
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
            services.AddControllersWithViews();
            // usamos el configurador de servicios para añadir una base de datos :)
            // services.AddDbContext<EscuelaContext>(
            //     // espeficicasmos que usamos la base de datos em memoria UseInMemoryDatabase
            //     options => options.UseInMemoryDatabase(databaseName:"testDb")
            // );

            // conectarse a una base de dato local
            string connString = ConfigurationExtensions.GetConnectionString(this.Configuration, "DefaultConnection");
            services.AddDbContext<EscuelaContext>(
                options => options.UseSqlServer(connString)
            );
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Escuela}/{action=Index}/{id?}");
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolamundoMVC1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HolamundoMVC1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope()){

            var serv = scope.ServiceProvider;
            try{
            var context = serv.GetRequiredService<EscuelaContext>();
            context.Database.EnsureCreated(); // aseguaramos que la base de datos se crea antes de arrancaar la aplicacion
            } catch (Exception ex){

            }
           host.Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}



/// https://platzi.com/clases/1395-aspnet-core/14516-usando-una-base-de-datos-de-verdad/
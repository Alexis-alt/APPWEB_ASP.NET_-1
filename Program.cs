using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Program
    {

        //Durante este proyecto se necesitaron los paquetes Nuguet
        //EntityFrameworkCore --Clases necesarias para gestionar la estructura 
        //EntityFrameworkCore.SqlServer --Proveedor de base de datos
        //EntityFrameworkCore.Tools --Para hacer la gestión de nuestro modelo desde consola (add migration, list migration, etc)


        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

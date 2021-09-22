using AbimMall.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbimMall
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using(var servicScope = host.Services.CreateScope())
            {
                var services = servicScope.ServiceProvider;
                try
                {
                    AbimMallDbContext context = services.GetRequiredService<AbimMallDbContext>();
                    SeedData.SeedCustomerData(context).Wait();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            host.Run();
        }

        

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

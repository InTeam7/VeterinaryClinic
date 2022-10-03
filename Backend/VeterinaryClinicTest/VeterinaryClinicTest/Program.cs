using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using VeterinaryClinicTest.DataAccess;

namespace VeterinaryClinicTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder
            .ConfigureNLog("nlog.config")
            .GetCurrentClassLogger();

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<ClinicDBContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception exception)
                {
                    logger.Error(exception);
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                   .UseStartup<Startup>()
                   .UseNLog();  // Подключаем NLog


                });
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Reactivities.Persistence;

namespace Reactivities.API
{
    public class Program
    {
        public static async Task Main(string[] args) // TODO : Read about ASYNC
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;

            try
            {   // [Service Locator Pattern]
                var context = services.GetRequiredService<DataContext>(); // DataContext As Service => Refer to Startup.cs
                await context.Database.MigrateAsync();
                await Seed.SeedData(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error is occurred during database migration"); // todo : Refactor into Resource file for Globalization
                throw;
            }

            await host.RunAsync();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

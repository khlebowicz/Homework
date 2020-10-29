using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework.Data;
using Homework.Data.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Homework.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<HomeWorkDbContext>();
                var inMemoryDb = new InMemoryDb();
                
                // context.Seat.AddRange(inMemoryDb.Performances.SelectMany(s=>s.Seats).Distinct());
                // context.Reservation.AddRange(inMemoryDb.Performances.SelectMany(s => s.Seats).SelectMany(s => s.Reservations).Distinct());
                context.Performance.AddRange(inMemoryDb.Performances);
                context.User.AddRange(inMemoryDb.Users);
                context.SaveChanges();
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

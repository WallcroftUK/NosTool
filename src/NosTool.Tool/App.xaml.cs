using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NosTool.DataAccess.Interfaces;
using NosTool.DataAccess.MSSQL.Context;
using NosTool.DataAccess.MSSQL.Helpers;
using NosTool.DataAccess.MSSQL.Repositories;
using System.Windows;

namespace NosTool.Tool
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Console.WriteLine("Application starting up...");

            var services = new ServiceCollection();

            // Register repositories
            services.AddScoped<IShopRepository, ShopRepository>();

            // Set up Entity Framework Core with SQL Server
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(DataAccessHelper.GetConnectionString())
                       .EnableSensitiveDataLogging()
                       .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information));

            // Register MainWindow
            services.AddTransient<MainWindow>();

            // Build the service provider
            var serviceProvider = services.BuildServiceProvider();

            Console.WriteLine("Application startup completed.");
        }
    }
}
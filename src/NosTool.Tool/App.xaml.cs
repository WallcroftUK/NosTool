using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NosTool.DataAccess.Interfaces;
using NosTool.DataAccess.MSSQL.Context;
using NosTool.DataAccess.MSSQL.Helpers;
using NosTool.DataAccess.MSSQL.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;

namespace NosTool.Tool
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            var services = new ServiceCollection();

            // Register repositories
            services.AddScoped<IShopRepository, ShopRepository>();

            // Set the connection string
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer());

            // Register MainWindow
            services.AddTransient<MainWindow>();

            // Build the service provider
            var serviceProvider = services.BuildServiceProvider();

            // Create the main window with injected services
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}

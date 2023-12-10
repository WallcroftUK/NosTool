using Microsoft.EntityFrameworkCore;
using NosTool.DataAccess.Interfaces;
using NosTool.DataAccess.MSSQL.Context;
using NosTool.DataAccess.MSSQL.Helpers;
using NosTool.DataAccess.MSSQL.Repositories;
using System.Windows;

namespace NosTool.Tool
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ManageShops_Click(object sender, RoutedEventArgs e)
        {
            // Create DbContextOptions for ApplicationDbContext
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(DataAccessHelper.GetConnectionString())
                .Options;

            // Instantiate ApplicationDbContext with the options
            var dbContext = new ApplicationDbContext(options);

            // Instantiate IShopRepository
            IShopRepository shopRepository = new ShopRepository(dbContext);

            // Open the window for managing shops
            var shopWindow = new ShopWindow(shopRepository);
            shopWindow.Show();

            // Optionally, close the main window
            Close();
        }

        private void OtherFunctionality_Click(object sender, RoutedEventArgs e)
        {
            // Open the window for other functionality
            //var otherFunctionalityWindow = new OtherFunctionalityWindow();
            //otherFunctionalityWindow.Show();
        }
    }
}
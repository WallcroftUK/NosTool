using NosTool.DataAccess.Interfaces;
using NosTool.DataAccess.MSSQL.Entities;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;

namespace NosTool.Tool
{
    public partial class MainWindow : Window
    {
        private readonly IShopRepository _shopRepository;

        public ObservableCollection<ShopEntity> Shops { get; set; }

        public MainWindow(IShopRepository shopRepository)
        {
            InitializeComponent();

            _shopRepository = shopRepository;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadShopsData();
            // Load other data as needed
        }

        private void LoadShopsData()
        {
            var shopDtos = _shopRepository.GetShops();
            Shops = new ObservableCollection<ShopEntity>(shopDtos);
            ShopsDataGrid.ItemsSource = Shops;
        }

        // Button click event handler for debug logs
        private void ShowDebugLogs_Click(object sender, RoutedEventArgs e)
        {
            // Add your debug log statements here
            Debug.WriteLine("Debug logs for reading from the database, etc.");

            // You can also use a logging library like Serilog or NLog for more advanced logging
        }
    }
}

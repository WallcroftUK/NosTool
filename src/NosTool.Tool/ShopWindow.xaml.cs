using NosTool.DataAccess.Interfaces;
using NosTool.DataAccess.MSSQL.Entities;
using System.Windows;
using System.Windows.Controls;

namespace NosTool.Tool
{
    public partial class ShopWindow : Window
    {
        private readonly IShopRepository _shopRepository;

        public ShopWindow(IShopRepository shopRepository)
        {
            InitializeComponent();
            _shopRepository = shopRepository;
            Loaded += ShopWindow_Loaded;
        }

        private void ShopWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadShopsData();
        }

        private void LoadShopsData()
        {
            var shopDtos = _shopRepository.GetShops();
            ShopsDataGrid.ItemsSource = shopDtos;
        }

        private void ShopsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ShopsDataGrid.SelectedItem is ShopEntity selectedShop)
            {
                // Populate the details section with selected shop's data
                ShopNameTextBox.Text = selectedShop.Name;
                // Populate other details as needed
            }
        }

        private ShopEntity editedShop; // Use this variable to track the shop being edited

        private void SaveShop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Retrieve values from textboxes
                var shopName = ShopNameTextBox.Text;
                var mapNpcId = int.Parse(MapNpcIdTextBox.Text);
                var menuType = byte.Parse(MenuTypeTextBox.Text);
                var shopType = byte.Parse(ShopTypeTextBox.Text);

                // Check if there's an edited shop
                if (editedShop != null)
                {
                    // Update the existing shop with the retrieved values
                    editedShop.Name = shopName;
                    editedShop.MapNpcId = mapNpcId;
                    editedShop.MenuType = menuType;
                    editedShop.ShopType = shopType;

                    // Save the changes to the database
                    _shopRepository.UpdateShop(editedShop);

                    // Notify the user that changes were saved
                    MessageBox.Show("Changes saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    // Notify the user that no shop is being edited
                    MessageBox.Show("No shop is being edited.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions related to parsing or database operations
                MessageBox.Show($"Error saving changes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddShop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Retrieve values from textboxes
                var shopName = ShopNameTextBox.Text;
                var mapNpcId = int.Parse(MapNpcIdTextBox.Text);
                var menuType = byte.Parse(MenuTypeTextBox.Text);
                var shopType = byte.Parse(ShopTypeTextBox.Text);

                // Create a new ShopEntity object with the retrieved values
                var newShop = new ShopEntity
                {
                    Name = shopName,
                    MapNpcId = mapNpcId,
                    MenuType = menuType,
                    ShopType = shopType
                };

                // Add the new shop to the database
                _shopRepository.AddShop(newShop);

                // Notify the user that the shop was added
                MessageBox.Show("Shop added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Handle exceptions related to parsing or database operations
                MessageBox.Show($"Error adding shop: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            // Optionally, open the main window again
            var mainWindow = new MainWindow();
            mainWindow.Show();

            // Close the current window
            Close();
        }
    }
}
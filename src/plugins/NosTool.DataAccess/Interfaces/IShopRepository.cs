using NosTool.DataAccess.MSSQL.Entities;

namespace NosTool.DataAccess.Interfaces
{
    /// <summary>
    /// Represents a repository for managing shops.
    /// </summary>
    public interface IShopRepository
    {
        /// <summary>
        /// Retrieves a list of shops from the database.
        /// </summary>
        /// <returns>A list of shop entities.</returns>
        List<ShopEntity> GetShops();

        /// <summary>
        /// Adds a new shop to the database.
        /// </summary>
        /// <param name="shop">The shop entity to add.</param>
        void AddShop(ShopEntity shop);

        /// <summary>
        /// Updates an existing shop in the database.
        /// </summary>
        /// <param name="shop">The updated shop entity.</param>
        void UpdateShop(ShopEntity shop);

        /// <summary>
        /// Deletes a shop from the database based on its ID.
        /// </summary>
        /// <param name="shopId">The ID of the shop to delete.</param>
        void DeleteShop(int shopId);
    }
}
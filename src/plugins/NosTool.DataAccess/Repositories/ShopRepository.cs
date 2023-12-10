// ShopRepository.cs
using Microsoft.EntityFrameworkCore;
using NosTool.DataAccess.Interfaces;
using NosTool.DataAccess.MSSQL.Context;
using NosTool.DataAccess.MSSQL.Entities;

namespace NosTool.DataAccess.MSSQL.Repositories
{
    /// <summary>
    /// Repository for managing shops in the database.
    /// </summary>
    public class ShopRepository : IShopRepository
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ShopRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <inheritdoc/>
        public List<ShopEntity> GetShops()
        {
            // Implement logic to fetch shops from the database
            return _dbContext.Shop.ToList();
        }

        /// <inheritdoc/>
        public void AddShop(ShopEntity shop)
        {
            if (shop == null)
                throw new ArgumentNullException(nameof(shop));

            _dbContext.Shop.Add(shop);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public void UpdateShop(ShopEntity shop)
        {
            if (shop == null)
                throw new ArgumentNullException(nameof(shop));

            _dbContext.Entry(shop).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public void DeleteShop(int shopId)
        {
            var shop = _dbContext.Shop.Find(shopId);

            if (shop != null)
            {
                _dbContext.Shop.Remove(shop);
                _dbContext.SaveChanges();
            }
        }
    }
}
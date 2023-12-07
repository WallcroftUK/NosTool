using Microsoft.Extensions.Configuration;
using NosTool.DataAccess.Interfaces;
using NosTool.DataAccess.MSSQL.Context;
using NosTool.DataAccess.MSSQL.Entities;
using NosTool.DataAccess.MSSQL.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NosTool.DataAccess.MSSQL.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ShopRepository()
        {

            _dbContext = new ApplicationDbContext();
        }

        public List<ShopEntity> GetShops()
        {        
            // Example debug log
            Debug.WriteLine("Fetching shops from the database.");

            return _dbContext.Shops.ToList();
        }
    }
}

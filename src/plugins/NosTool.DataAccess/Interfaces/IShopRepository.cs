using NosTool.DataAccess.MSSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NosTool.DataAccess.Interfaces
{
    public interface IShopRepository
    {
        List<ShopEntity> GetShops();
        // Add more methods for other entities or operations as needed
    }
}

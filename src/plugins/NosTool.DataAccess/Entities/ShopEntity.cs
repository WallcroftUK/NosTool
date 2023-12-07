using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NosTool.DataAccess.MSSQL.Entities
{
    public class ShopEntity
    {
        public int MapNpcId { get; set; }
        public byte MenuType { get; set; }
        public string Name { get; set; }
        public int ShopId { get; set; }
        public byte ShopType { get; set; }
    }
}

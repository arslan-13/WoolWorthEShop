using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoolWorthEShop.Entities;

namespace WoolWorthEShop.DB
{
    public class WWContext : DbContext, IDisposable
    {
        public WWContext() : base("Name=WWCon")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Config> configs { get; set; }
    }


}

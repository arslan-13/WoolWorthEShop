using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoolWorthEShop.Entities
{
    public class Product : BaseEntities
    {

        public Category category { get; set; }

        public decimal Price { get; set; }

    }
}

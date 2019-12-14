using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WoolWorthEShop.Entities;

namespace WoolWorthEShop.Web.ViewModels
{
    public class HomeViewModel
    {
        public List<Category> Featuredcategories { get; set; }
        public List<Product> Featuredproducts { get; set; }
    }
}
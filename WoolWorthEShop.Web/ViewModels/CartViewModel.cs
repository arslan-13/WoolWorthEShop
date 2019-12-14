using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WoolWorthEShop.Entities;

namespace WoolWorthEShop.Web.ViewModels
{
    public class CartViewModel
    {
        public List<Product> Cartproducts { get; set; }
        public List<int> CartProductIDs { get; set; }
    }
}
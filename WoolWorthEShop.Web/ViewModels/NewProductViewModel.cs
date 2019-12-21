using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WoolWorthEShop.Entities;

namespace WoolWorthEShop.Web.ViewModels
{
    public class NewProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
    }
}
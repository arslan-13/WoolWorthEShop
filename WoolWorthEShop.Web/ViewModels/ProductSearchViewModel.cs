using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WoolWorthEShop.Entities;

namespace WoolWorthEShop.Web.ViewModels
{
    public class ProductSearchViewModel
    {
        public int PageNo { get; set; }
        public List<Product> products { get; set; }
        public string SearchTerm { get; set; }
    }
}
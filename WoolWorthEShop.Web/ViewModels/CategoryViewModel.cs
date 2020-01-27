using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WoolWorthEShop.Entities;

namespace WoolWorthEShop.Web.ViewModels
{
    public class CategorySearchViewModel
    {
        public List<Category> categories { get; set; }
        public string SearchTerm { get; set; }

        public Pager Pager { get; set; }
    }

    public class CategoryNewViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public bool isFeatured { get; set; }
    }

    public class CategoryEditViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public bool isFeatured { get; set; }
    }
}
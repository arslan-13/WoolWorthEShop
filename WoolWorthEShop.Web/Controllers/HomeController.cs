using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoolWorthEShop.Services;
using WoolWorthEShop.Web.ViewModels;

namespace WoolWorthEShop.Web.Controllers
{
    public class HomeController : Controller
    {
        CategoriesService categoriesService = new CategoriesService();

        // GET: Home
        public ActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel();
            hvm.Featuredcategories = categoriesService.GetFeaturedCategory();

            return View(hvm);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoolWorthEShop.Services;
using WoolWorthEShop.Web.ViewModels;

namespace WoolWorthEShop.Web.Controllers
{
    public class ShopController : Controller
    {

        // productService productService = new productService();

        // GET: Shop
        public ActionResult Checkout()
        {
            CartViewModel cartViewModel = new CartViewModel();
            var CartProductsCookies = Request.Cookies["CartProduct"];

            if (CartProductsCookies != null)
            {
                cartViewModel.CartProductIDs = CartProductsCookies.Value.Split('-').Select(x => int.Parse(x)).ToList();
                cartViewModel.Cartproducts = productService.Instance.GetProductsByID(cartViewModel.CartProductIDs);
            }
            return View(cartViewModel);
        }
    }
}
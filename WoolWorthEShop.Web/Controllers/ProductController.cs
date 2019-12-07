using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoolWorthEShop.Entities;
using WoolWorthEShop.Services;

namespace WoolWorthEShop.Web.Controllers
{
    public class ProductController : Controller
    {

        productService productService = new productService();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable(string Search)
        {
            var product = productService.GetProduct();
            if (string.IsNullOrEmpty(Search) == false)
            {
                product = product.Where(p => p.Name != null && p.Name.ToLower().Contains(Search.ToLower())).ToList();
            }

            return PartialView(product);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            productService.SaveProduct(product);
            return RedirectToAction("ProductTable");
        }


        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var product = productService.GetProductID(ID);
            return PartialView(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            productService.UpdateProduct(product);
            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            productService.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }
    }
}
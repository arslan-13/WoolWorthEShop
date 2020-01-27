using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoolWorthEShop.Entities;
using WoolWorthEShop.Services;
using WoolWorthEShop.Web.ViewModels;

namespace WoolWorthEShop.Web.Controllers
{
    public class ProductController : Controller
    {

        // productService productService = new productService();
        // CategoriesService CategoriesService = new CategoriesService();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult ProductTable(string Search, int? PageNo)
        {
            ProductSearchViewModel model = new ProductSearchViewModel();
            model.PageNo = PageNo.HasValue ? PageNo.Value > 0 ? PageNo.Value : 1 : 1;
            model.products = productService.Instance.GetProduct(model.PageNo);
            if (string.IsNullOrEmpty(Search) == false)
            {
                model.SearchTerm = Search;
                model.products = model.products.Where(p => p.Name != null && p.Name.ToLower().Contains(Search.ToLower())).ToList();
            }
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ProductNewViewModel model = new ProductNewViewModel();
            model.AvailableCategories = CategoriesService.Instance.GetCategory();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(ProductNewViewModel model)
        {
            var newPorduct = new Product();
            newPorduct.Name = model.Name;
            newPorduct.Description = model.Description;
            newPorduct.Price = model.Price;
            newPorduct.categoryID = model.CategoryID;
            newPorduct.ImageURL = model.ImageURL;
            productService.Instance.SaveProduct(newPorduct);
            return RedirectToAction("ProductTable");
        }


        [HttpGet]
        public ActionResult Edit(int ID)
        {
            ProductEditViewModel model = new ProductEditViewModel();
            var product = productService.Instance.GetProductID(ID);
            model.ID = product.ID;
            model.Name = product.Name;
            model.Description = product.Description;
            model.Price = product.Price;
            model.CategoryID = product.category != null ? product.category.ID : 0;
            model.ImageURL = product.ImageURL;

            model.AvailableCategories = CategoriesService.Instance.GetCategory();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(ProductEditViewModel model)
        {
            var updateProduct = productService.Instance.GetProductID(model.ID);
            updateProduct.Name = model.Name;
            updateProduct.Description = model.Description;
            updateProduct.Price = model.Price;
            updateProduct.category = CategoriesService.Instance.GetCategoryID(model.CategoryID);
            updateProduct.ImageURL = model.ImageURL;

            productService.Instance.UpdateProduct(updateProduct);
            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            productService.Instance.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }
    }
}
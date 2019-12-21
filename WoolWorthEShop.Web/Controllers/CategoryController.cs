using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoolWorthEShop.Entities;
using WoolWorthEShop.Services;

namespace WoolWorthEShop.Web.Controllers
{
    public class CategoryController : Controller
    {
        //CategoriesService categoryService = new CategoriesService();

        public ActionResult CategoryTable(string Search)
        {
            var cate = CategoriesService.Instance.GetCategory();
            if (string.IsNullOrEmpty(Search) == false)
            {
                cate = cate.Where(p => p.Name != null && p.Name.ToLower().Contains(Search.ToLower())).ToList();
            }

            return PartialView(cate);
        }


        [HttpGet]
        public ActionResult Index()
        {
            var categories = CategoriesService.Instance.GetCategory();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            CategoriesService.Instance.SaveCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var category = CategoriesService.Instance.GetCategoryID(ID);
            return PartialView(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            CategoriesService.Instance.UpdateCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            var category = CategoriesService.Instance.GetCategoryID(ID);
            return PartialView(category);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {

            CategoriesService.Instance.DeleteCategory(category.ID);
            return RedirectToAction("Index");
        }
    }
}
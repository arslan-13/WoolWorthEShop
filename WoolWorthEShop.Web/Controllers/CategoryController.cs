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
    public class CategoryController : Controller
    {
        //CategoriesService categoryService = new CategoriesService();

        public ActionResult CategoryTable(string Search, int? pageno)
        {
            CategorySearchViewModel model = new CategorySearchViewModel();

            var cate = CategoriesService.Instance.GetCategory();

            if (string.IsNullOrEmpty(Search) == false)
            {
                model.SearchTerm = Search;
                model.categories = model.categories.Where(p => p.Name != null && p.Name.ToLower().Contains(Search.ToLower())).ToList();
            }

            model.Pager = new Pager(model.categories.Count, pageno);
            return PartialView(model);
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
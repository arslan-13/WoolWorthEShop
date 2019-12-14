﻿using System;
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
        CategoriesService categoryService = new CategoriesService();

        [HttpGet]
        public ActionResult Index()
        {
            var categories = categoryService.GetCategory();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoryService.SaveCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var category = categoryService.GetCategoryID(ID);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            categoryService.UpdateCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            var category = categoryService.GetCategoryID(ID);
            return View(category);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {

            categoryService.DeleteCategory(category.ID);
            return RedirectToAction("Index");
        }
    }
}
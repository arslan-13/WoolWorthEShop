﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WoolWorthEShop.Web.Controllers
{
    public class SharedController : Controller
    {

        public JsonResult UploadImage()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            try
            {
                var file = Request.Files[0];

                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);

                file.SaveAs(path);
                result.Data = new { Success = true, ImageURL = string.Format("/Content/images/{0}", fileName) };

            }
            catch
            {

            }
            return result;
        }

        // GET: Shared
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WoolWorthEShop.Web.Controllers
{
    public class SharedController : Controller
    {

        //public JsonResult UploadImage()
        //{
        //    JsonResult result = new JsonResult();


        //    try
        //    {
        //        var file = Request.Files[0];

        //        var fileName = Guid.NewGuid() + Path.
        //    }
        //}

        // GET: Shared
        public ActionResult Index()
        {
            return View();
        }
    }
}
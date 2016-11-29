using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        //[HttpPost]
        public ActionResult Index()
        {
          
            return View();
        }
        [Authorize]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Create");
          
        }

        [HttpDelete]
        //public ActionResult Delete (int id)
        //{
        //    return
        //}

        //public ActionResult Create()
        //{

        //    return View();
        //}
        public ActionResult Delete()
        {

            return View();
        }

    }
}
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
        public ActionResult Index()
        {
          
            return View();
        }
        public ActionResult Create()
        {

            return View();
        }
        public ActionResult Delete()
        {

            return View();
        }

    }
}
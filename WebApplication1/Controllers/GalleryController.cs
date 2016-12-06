using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GalleryController : Controller
    {
        public static List<Photo> photos = new List<Photo>();

        // GET: Gallery
        public GalleryController()
        {
            if (!photos.Any())
            {
                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "9202_nature-1.jpg", PhotoComment = new List<Comment> { new Comment { CommentOnPicture = "Nature is beautiful" } } });
                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "Beauty-of-nature-random-4884759-1280-800-1024x640-e1443406682619-300x150.jpg", PhotoComment = new List<Comment> { new Comment { CommentOnPicture = "Nature is beautiful" } } });
                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "nature-300x150.jpg", PhotoComment = new List<Comment> { new Comment { CommentOnPicture = "Nature is beautiful" } } });
                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "nature2-300x150.jpg", PhotoComment = new List<Comment> { new Comment { CommentOnPicture = "Nature is beautiful" } } });
            }
        }
        public ActionResult Gallery()
        {
            return View(photos);
        }

        public ActionResult ShowImage(Guid id)
        {
            var showphoto = photos.FirstOrDefault(x => x.PhotoID == id);
            return View(showphoto);
        }
        public ActionResult UploadPicture()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadPicture(string comment, HttpPostedFileBase[] files, Photo photo)
        {
            if (!ModelState.IsValid)
            {
                return View(photo);
            }
            if (files == null)
            {
                ModelState.AddModelError("error", "No picture");
                return View(photo);
            }
            foreach (var file in files)
            {
                file.SaveAs(
                Path.Combine(Server.MapPath("~/Content/Images"), file.FileName));
                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = file.FileName, PhotoComment = new List<Comment> { new Comment { CommentOnPicture = comment } } });
            }

            return View();
        }
        public ActionResult DeletePicture(Guid id)
        {
            var photo = photos.FirstOrDefault(x => x.PhotoID == id);
            return View(photo);
        }
        [HttpPost]
        public ActionResult DeletePicture(Guid id, Photo photo)
        {

            var p = photos.FirstOrDefault(x => x.PhotoID == id);
            string fullPath = Request.MapPath("~/Content/Images/" + p.PhotoName);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                //Session["DeleteSuccess"] = "Yes";
                photos.Remove(p);
            }
            return RedirectToAction("Gallery");
        }
        public ActionResult AddComment(Guid id)
        {
            var p = photos.FirstOrDefault(x => x.PhotoID == id);
            return View(p);
        }

        [HttpPost]
        public ActionResult AddComment(Guid id, string photoComment)
        {
            var p = photos.FirstOrDefault(x => x.PhotoID == id);
            p.PhotoComment.Add(new Comment { CommentOnPicture = photoComment });
            return View(p);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AlbumController : Controller
    {
  
        public static List<Album> albums = new List<Album>();
        // GET: Album
        public AlbumController()
        {
            if (!albums.Any())
            {
                albums.Add(new Album { AlbumID = Guid.NewGuid(), AlbumName = "Album1", Photos = new List<Photo>(), AlbumComment = new List<Comment> { new Comment { CommentOnAlbum = "1" } } });
                albums.Add(new Album { AlbumID = Guid.NewGuid(), AlbumName = "Album2", Photos = new List<Photo>(), AlbumComment = new List<Comment> { new Comment { CommentOnAlbum = "2" } } });
            }

        }
    }
}
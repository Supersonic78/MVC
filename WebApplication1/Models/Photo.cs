﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Photo
    {
      
            public Guid PhotoID { get; set; }
            public string PhotoName { get; set; }
            public List<Comment> PhotoComment { get; set; }
            public Guid AlbumID { get; set; }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class DBModel : DbContext
    {
        DbSet<Photo> Photos { get; set; }
    }
}
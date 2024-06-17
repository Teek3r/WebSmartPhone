using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebSmartPhone.Areas.Admin.Controllers;

namespace WebSmartPhone.Models
{
    public class MyDB :DbContext
    {
        public MyDB() : base("myCS") { }
        public DbSet<Product> Product { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }


    }
}
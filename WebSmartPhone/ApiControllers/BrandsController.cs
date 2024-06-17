using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebSmartPhone.Models;

namespace WebSmartPhone.ApiControllers
{
    public class BrandsController : ApiController
    {
        public List<Brand> Get()
        {
            MyDB db = new MyDB();
            List<Brand> brands = db.Brand.ToList();
            return brands;
        }

        public Brand GetBrandById(long id)
        {
            MyDB db = new MyDB();
            Brand brand = db.Brand.Where(r => r.BrandId == id).FirstOrDefault();
            return brand;
        }
        public void PostBrand(Brand newBr)
        {
            MyDB db = new MyDB();
            db.Brand.Add(newBr);
            db.SaveChanges();
        }

        public void PutBrand(Brand b)
        {
            MyDB db = new MyDB();
            Brand oldBr = db.Brand.Where(r => r.BrandId == b.BrandId).FirstOrDefault();
            oldBr.Name = b.Name;
            db.SaveChanges();
        }
    }
}
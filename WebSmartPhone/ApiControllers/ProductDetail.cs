using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSmartPhone.Models;

namespace WebSmartPhone.ApiControllers
{
    public class ProductDetail
    {
        public void PostProductDetail(ProductDetail pD)
        {
            MyDB db = new MyDB();
            //db.ProductDetails.Add(pD);
            db.SaveChanges();
        }
    }
}
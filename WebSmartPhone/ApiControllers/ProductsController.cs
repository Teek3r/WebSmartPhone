using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebSmartPhone.Models;

namespace WebSmartPhone.ApiControllers
{
    public class ProductsController : ApiController
    {
        MyDB db = new MyDB();
        public List<Product> Get()
        {
            List<Product> products = db.Product.ToList();
            return products;
        }
    }
}

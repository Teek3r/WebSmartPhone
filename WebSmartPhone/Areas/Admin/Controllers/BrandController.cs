using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSmartPhone.Models;
using WebSmartPhone.Filter;
namespace WebSmartPhone.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class BrandController : Controller
    {
        // GET: Admin/Brand
        MyDB db = new MyDB();

        public ActionResult Index()
        {
            List<Product> lst = db.Product.ToList();
            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Brand b)
        {
            db.Brand.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
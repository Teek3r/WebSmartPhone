using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI;
using WebSmartPhone.Models;

namespace WebSmartPhone.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        MyDB db = new MyDB();
        public ActionResult Index(string search = "",int brand= -1, int page = 1)
        {
            List<Product> lst = db.Product.ToList();
            ViewBag.Search = search;
            if (brand!=-1)
            {
                lst = db.Product.Where(p => p.BrandId == brand).ToList();
            }
            if (search != "")
            {
                lst = db.Product.Where(p => p.Name.Contains(search)).ToList();
            }
            int RowInPage = 12;
            double sumProduct = lst.Count;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sumProduct) / Convert.ToDouble(RowInPage)));
            int NoOfSkip = (page - 1) * RowInPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            List<Brand> lstBrand = db.Brand.ToList();
            ViewBag.Brand = brand;
            ViewBag.lstBrand = lstBrand;
            lst = lst.Skip(NoOfSkip).Take(RowInPage).ToList();
            return View(lst);
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
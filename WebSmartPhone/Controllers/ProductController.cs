using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSmartPhone.Filter;
using WebSmartPhone.Models;

namespace WebSmartPhone.Controllers
{
    public class ProductController : Controller
    {
        MyDB db = new MyDB();
        // GET: Product
        public ActionResult Index(string search = "", string Sort = "Name", string Icon = "", int page = 1)
        { 
            List<Product> lst = db.Product.Where(p => p.Name.Contains(search)).ToList();
            ViewBag.Search = search;
            ViewBag.Sort = Sort;
            ViewBag.Icon = Icon;
            if (Sort == "Name")
            {
                if (Icon == "fa fa-sort-down")
                {
                    lst = lst.OrderByDescending(r => r.Name).ToList();
                }
                else
                {
                    lst = lst.OrderBy(r => r.Name).ToList();

                }
            }
            if (Sort == "Price")
            {
                if (Icon == "fa fa-sort-down")
                {
                    lst = lst.OrderByDescending(r => r.Price).ToList();
                }
                else
                {
                    lst = lst.OrderBy(r => r.Price).ToList();

                }
            }
            int RowInPage = 12;
            double sumProduct = lst.Count;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sumProduct) / Convert.ToDouble(RowInPage)));
            int NoOfSkip = (page - 1) * RowInPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            lst = lst.Skip(NoOfSkip).Take(RowInPage).ToList();
            return View(lst);
        }
        public ActionResult Detail(int? id)
        {
            if (id == null) 
            {
                return RedirectToAction("Index");
            }
            Product p = db.Product.Where(r => r.Id == id).FirstOrDefault();
            List<ProductDetail> lst = db.ProductDetail.Where(r => r.Product.Id == p.Id).ToList();
            ViewBag.proDetail = lst;
            return View(p);

        }
    }
}
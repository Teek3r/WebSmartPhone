using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSmartPhone.Filter;
using WebSmartPhone.Models;

namespace WebSmartPhone.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ProductController : Controller
    {
        MyDB db = new MyDB();
        // GET: Admin/Product
        public ActionResult Index(string search = "", string Sort = "Name", string Icon = "", int page = 1)
        {
            List<Product> lst = db.Product.Where(r => r.Name.Contains(search)).ToList();
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
            int RowInPage = 5;
            double sumProduct = lst.Count;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sumProduct) / Convert.ToDouble(RowInPage)));
            int NoOfSkip = (page - 1) * RowInPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            lst = lst.Skip(NoOfSkip).Take(RowInPage).ToList();
            return View(lst);
        }
        public ActionResult Create()
        {
            List<Brand> lst = db.Brand.ToList();
            ViewBag.Brand = lst;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p, HttpPostedFileBase imageFile)
        {
            if (p == null)
            {
                return View();
            }
            else
            {
                db.Product.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(int? id)
        {

            Product p = db.Product.Where(r => r.Id == id).FirstOrDefault();
            List<Brand> lst = db.Brand.ToList();
            ViewBag.Hang = lst;
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (p == null)
            {
                return RedirectToAction("Index");
            }
            else

            {
                Product pNew = db.Product.Where(row => row.Id == p.Id).FirstOrDefault();
                pNew.Name = p.Name;
                pNew.Price = p.Price;
                pNew.Img_URL = p.Img_URL;
                pNew.Description = p.Description;
                pNew.BrandId = p.BrandId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int? id)
        {
            Product p = db.Product.Where(r => r.Id == id).FirstOrDefault();
            if (p == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                db.Product.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult AddDetail(int? id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddDetail(ProductDetail pD)
        {
            if (pD == null)
            {
                return View();
            }
            else
            {
                db.ProductDetail.Add(pD);
                db.SaveChanges();
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }

        }

    }
}
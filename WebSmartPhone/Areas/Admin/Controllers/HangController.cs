using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSmartPhone.Filter;
using WebSmartPhone.Models;

namespace WebSmartPhone.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class HangController : Controller
    {
        // GET: Admin/Hang
        MyDB db = new MyDB();
        public ActionResult Index()
        {
            List<Brand> lst = db.Brand.AsNoTracking().ToList();
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
        public ActionResult Edit(int? id)
        {

            Brand b = db.Brand.Where(r => r.BrandId == id).FirstOrDefault();
            return View(b);
        }
        [HttpPost]
        public ActionResult Edit(Brand b)
        {
            if (b == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Brand bNew = db.Brand.Where(row => row.BrandId == b.BrandId).FirstOrDefault();
                bNew.Name = b.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int? id)
        {
            Brand b = db.Brand.Where(r => r.BrandId == id).FirstOrDefault();
            if (b == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                db.Brand.Remove(b);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
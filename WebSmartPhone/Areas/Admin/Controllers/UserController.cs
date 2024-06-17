using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSmartPhone.Filter;
using WebSmartPhone.Identity;

namespace WebSmartPhone.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class UserController : Controller
    {
        // GET: Admin/User
        AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            List<AppUser> users = db.Users.ToList();
            return View(users);
        }
        public ActionResult Delete(string id)
        {
            AppUser u = db.Users.Where(r => r.Id == id).FirstOrDefault();
            if (u == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                db.Users.Remove(u);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using WebSmartPhone.Identity;
using WebSmartPhone.Models;
using WebSmartPhone.ViewModel;

namespace WebSmartPhone.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        AppDbContext db = new AppDbContext();
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Register(RegisterVM rsv)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new AppDbContext();
                var userStore = new AppUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);
                var passWordHash = Crypto.HashPassword(rsv.Password);
                var user = new AppUser()
                {
                    Email = rsv.Email,
                    UserName = rsv.UserName,
                    PasswordHash = passWordHash,
                    City = rsv.City,
                    BirthDay = rsv.DateOfBirth,
                    Address = rsv.Address,
                };
                IdentityResult identityResult = userManager.Create(user);
                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "User"); ;
                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(),
                        userIdentity);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM lg)
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.Find(lg.UserName, lg.Password);

            if (user != null)
            {
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenManager.SignIn(new AuthenticationProperties(),
                        userIdentity);
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new
                    { area = "Admin" });
                }else return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("myError", "Invalid username and password");
                return View();

            }
        }
        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Profile(string id)
        {
            AppUser u = db.Users.Where(r => r.UserName.CompareTo(id) == 0 ).FirstOrDefault();
            return View(u);
        }
    }
}
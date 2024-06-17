using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSmartPhone.Filter;
using WebSmartPhone.Models;

namespace WebSmartPhone.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        MyDB db = new MyDB();
        [MyAuthenFilter]
        public ActionResult Index()
        {
            List<Cart> carts = db.Cart.ToList();
            return View(carts);
        }

        public ActionResult Add(int id = 0)
        {
            if (id > 0)
            {
                Cart cartItem = db.Cart.Where(c => c.Id == id).FirstOrDefault();
                if (cartItem != null)
                {
                    cartItem.Quantity += 1;
                }
                else
                {
                    Cart cart = new Cart();
                    cart.Id = id;
                    cart.Quantity = 1;
                    db.Cart.Add(cart);
                }
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult UpdateQuantity(int quan = 0, int proid = 0)
        {
            if (quan > 0)
            {
                Cart cartItem = db.Cart.Where(c => c.Id == proid).FirstOrDefault();
                if (cartItem != null)
                {
                    cartItem.Quantity = quan;
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
        public ActionResult Remove(int? id )
        {
            if (id > 0)
            {
                Cart cartItem = db.Cart.Where(c => c.IdCart == id).FirstOrDefault();
                db.Cart.Remove(cartItem);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Pay()
        {
            List<Cart> carts = db.Cart.ToList();
            foreach (var item in carts)
            {
                db.Cart.Remove(item);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
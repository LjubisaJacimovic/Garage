using Garage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Garage.Controllers
{
    public class CartController : Controller
    {
        GarageDB2Entities db = new GarageDB2Entities();
        //
        // GET: /Cart/
        public ActionResult GetCart()
        {
            Users user = (Users)Session["User"];
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var carts = db.Cart.Where(x => x.ClientId == user.Id).ToList();
            List<GetCart> getCarts = new List<GetCart>();
            ViewBag.TotalPrice = 0;
            foreach (var item in carts)
            {
                GetCart cart = new GetCart();
                cart.Id = item.Id;
                cart.ProductId = item.ProductId;
                cart.ClientId = item.ClientId;
                cart.IsInCart = item.IsInCart;
                cart.Amount = item.Amount;
                cart.DatePurchased = item.DatePurchased;
                cart.Product = item.Product;
                cart.Users = item.Users;
                cart.FullPrice = cart.Amount * cart.Product.Price;
                ViewBag.TotalPrice += cart.FullPrice;
                getCarts.Add(cart);
            }
            return View(getCarts);
        }

        public ActionResult DeleteCart(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cart = db.Cart.Where(x => x.Id == id).FirstOrDefault();
            if (cart == null)
            {
                return HttpNotFound();
            }

            db.Cart.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("GetCart");
        }

        public ActionResult BuyProducts()
        {
            Users user = (Users)Session["User"];
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var carts = db.Cart.Where(x => x.ClientId == user.Id).ToList();
            List<GetCart> getCarts = new List<GetCart>();
            foreach (var item in carts)
            {
                db.Cart.Remove(item);
                db.SaveChanges();
            }

            return RedirectToAction("ProductsBought");
        }

        public ActionResult ProductsBought()
        {
            return View();
        }
	}
}
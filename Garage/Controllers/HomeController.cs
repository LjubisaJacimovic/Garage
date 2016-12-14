using Garage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage.Controllers
{
    public class HomeController : Controller
    {
        GarageDB2Entities db = new GarageDB2Entities();
        //
        // GET: /Home/
        public ActionResult Management()
        {
            var products = db.Product.ToList();
            return View(products);
        }

        public ActionResult Parts()
        {
            var productType = db.ProductType.ToList();
            return View(productType);
        }

        public ActionResult Index()
        {
            var products = db.Product.ToList();
            return View(products);
        }

        public ActionResult Details(int? id)
        {
            var products = db.Product.FirstOrDefault(x => x.Id == id);
            return View(products);
        }

        [HttpPost]

        public ActionResult Details(int productId, int amount)
        {
            ViewBag.Message = null;
            //get signed in user from session
            var User = (Users)Session["User"];
            var product = db.Product.FirstOrDefault(x => x.Id == productId);

            //check if there is user signed in
            if (User == null)
            {
                //if not return error message
                ViewBag.Message = "Please sing in first before adding product to you cart";
                return View(product);
            }

            //if user is signed in continue making the cart object
            Cart cart = new Cart();
            cart.ClientId = User.Id;
            cart.ProductId = productId;
            cart.Amount = amount;
            cart.DatePurchased = DateTime.Now;
            cart.IsInCart = true;

            db.Cart.Add(cart);
            db.SaveChanges();

            ViewBag.Message = "Product is added to cart";

            return View(product);
        }


        public ActionResult SignIn(UserSignIn user)
        {
            if (ModelState.IsValid)
            {
                var checkUser = db.Users.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();
                if (checkUser != null)
                {
                    Session["User"] = checkUser;
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        public ActionResult SignUp()
        {
            var users = db.Users.Create();
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "Id,FirstName,LastName,Email,Username,Password,ConfirmPassword")] Users users)
        {
            if (ModelState.IsValid)
            {
                Session["User"] = users;
                users.isAdmin = false;
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        public ActionResult signOut()
        {
            //izbrisi od session
            Session.Abandon();
            return RedirectToAction("Index");// redirect to Home/Index
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult About()
        {
            ViewBag.MyDate = DateTime.Now.ToString();
            return View();
        }

        public string AjaxReload()
        {
            return DateTime.Now.ToString();
        }
	}
}
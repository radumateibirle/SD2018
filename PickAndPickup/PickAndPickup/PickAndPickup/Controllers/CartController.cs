using DAL;
using DAL.Contracts;
using PagedList;
using PagedList.Mvc;
using PickAndPickup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PickAndPickup.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Cart()
        {
            List<MealModel> CartItems = (List<MealModel>)Session["CartItems"];

            return View(CartItems);
        }

        public ActionResult Delete(int? i)
        {
            List<MealModel> CartItems = (List<MealModel>)Session["CartItems"];
            if (i != null)
            {
                foreach (MealModel item in CartItems)
                {
                    if (item.ID == i)
                    {
                        CartItems.Remove(item);
                        break;
                    }
                }
            }
            return RedirectToAction("Cart", "Cart");
        }

        [HttpPost]
        public ActionResult Checkout()
        {
            Session["fromCheckout"] = "yes";
            return RedirectToAction("Login", "Home");
        }
    }
}
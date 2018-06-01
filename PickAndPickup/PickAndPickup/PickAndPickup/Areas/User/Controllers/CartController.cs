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


namespace PickAndPickup.Areas.User.Controllers
{
    public class CartController : Controller
    {
        IOrderRepo oRepo;
        IOrderProductRepo opRepo;
        IMealRepo mRepo;

        public CartController(IOrderRepo oR, IOrderProductRepo opR, IMealRepo mR)
        {
            oRepo = oR;
            opRepo = opR;
            mRepo = mR;
        }
        // GET: Cart
        public ActionResult UserCart()
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "user")
            {
                List<MealModel> CartItems = (List<MealModel>)Session["CartItems"];

                return View(CartItems);
            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }

        public ActionResult Delete(int? i)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "user")
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
                return RedirectToAction("Cart", "UserCart");
            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }

        [HttpPost]
        public ActionResult Checkout()
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "user")
            {
                if (Session["fromCheckout"] != null && Session["fromCheckout"].ToString() != "yes")
                    return RedirectToAction("Login", "Home");


                List<MealModel> cart = (List<MealModel>)Session["CartItems"];

                Order ord = new Order();
                ord.Date = DateTime.Now;
                ord.IsDeleted = false;


                ord.QRCodePath = genQR();
                ViewBag.QR = ord.QRCodePath;


                ord.TotalPrice = 0;
                ord.EstimatedTime = DateTime.Now;
                int delay = 0;
                foreach (MealModel m in cart)
                {
                    ord.TotalPrice += m.Quantity * m.Price;
                    if (m.Quantity > mRepo.GetByID(m.ID).Stock)
                    {
                        delay++;
                    }
                }

                ord.EstimatedTime = DateTime.Now.AddMinutes(delay * 5);
                ord.UserID = Int32.Parse(Session["UserID"].ToString());
                ord.VoucherID = null;

                oRepo.Add(ord);

                foreach (MealModel m in cart)
                {
                    OrderProduct op = new OrderProduct();
                    op.IsDeleted = false;
                    op.MealID = m.ID;
                    op.OrderID = ord.ID;
                    op.Quantity = m.Quantity;
                    opRepo.Add(op);
                }

                return View();
            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }


        private string genQR()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        public ActionResult GoBack()
        {
            return RedirectToAction("Index", "User");
        }

    }
}

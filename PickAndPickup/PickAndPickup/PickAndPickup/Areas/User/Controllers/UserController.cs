using DAL;
using DAL.Contracts;
using PagedList;
using PickAndPickup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickAndPickup.Areas.User.Controllers
{
    public class UserController : Controller
    {
        IUserRepo uRepo;
        IMealRepo mRepo;
        public UserController(IUserRepo uR, IMealRepo mR)
        {
            uRepo = uR;
            mRepo = mR;
        }
        // GET: User/User
        public ActionResult Index()
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "user")
            {
                List<Meal> meals = mRepo.GetCurrent();
                List<MealModel> mealmodels = new List<MealModel>();
                meals.ForEach(m => mealmodels.Add(new MealModel { ID = m.ID, Description = m.Description, Name = m.Name, PhotoPath = m.PhotoPath, Quantity = (int)m.Stock, Price = (int)m.Price }));
                return View(mealmodels.ToPagedList(1, 1000));
            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }

        public ActionResult Logout()
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "user")
            {
                Session.Clear();
                return RedirectToAction("Index", "Home", new { area = "" });

            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }

        public ActionResult AddToCart(int? id)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "user")
            {
                if (id != null)
                {
                    Meal m = mRepo.GetByID((int)id);
                    MealModel meal = new MealModel() { ID = m.ID, Description = m.Description, Name = m.Name, PhotoPath = m.PhotoPath, Quantity = 1, Price = (int)m.Price };
                    if (Session["CartItems"] == null)
                        Session["CartItems"] = new List<MealModel>();

                    List<MealModel> current_cart = (List<MealModel>)Session["CartItems"];

                    MealModel current = null;

                    foreach (MealModel mm in current_cart)
                    {
                        if (mm.ID == meal.ID)
                        {
                            current = mm;
                            break;
                        }
                    }

                    if (current != null)
                    {
                        meal.Quantity = current.Quantity + 1;
                        ((List<MealModel>)Session["CartItems"]).Remove(current);
                    }
                ((List<MealModel>)Session["CartItems"]).Add(meal);

                    List<MealModel> cart = (List<MealModel>)Session["CartItems"];
                }
                return RedirectToAction("Index", "User");
            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }
    }
}
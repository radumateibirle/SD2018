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
    public class MenuController : Controller
    {
        IUserRepo uRepo;
        IMealRepo mRepo;
        public MenuController(IUserRepo uR, IMealRepo mR)
        {
            uRepo = uR;
            mRepo = mR;
        }

        public ActionResult Index()
        {
            List<Meal> meals = mRepo.GetCurrent();
            List<MealModel> mealmodels = new List<MealModel>();
            meals.ForEach(m => mealmodels.Add(new MealModel { ID = m.ID, Description = m.Description, Name = m.Name, PhotoPath = m.PhotoPath, Quantity = (int)m.Stock, Price = (int)m.Price }));
            return View(mealmodels.ToPagedList(1, 1000));
        }

        public ActionResult AddToCart(int? id)
        {
            if (id != null)
            {
                Meal m = mRepo.GetByID((int)id);
                MealModel meal = new MealModel() { ID = m.ID, Description = m.Description, Name = m.Name, PhotoPath = m.PhotoPath, Quantity = 1, Price = (int)m.Price };
                if (Session["CartItems"] == null)
                    Session["CartItems"] = new List<MealModel>();

                List<MealModel> current_cart = (List<MealModel>)Session["CartItems"];

                MealModel current = null;

                foreach(MealModel mm in current_cart)
                {
                    if(mm.ID == meal.ID)
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
            return RedirectToAction("Index");
        }
    }
}
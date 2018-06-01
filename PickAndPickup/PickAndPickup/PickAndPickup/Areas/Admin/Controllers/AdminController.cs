using DAL;
using DAL.Contracts;
using PagedList;
using PickAndPickup.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickAndPickup.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        IUserRepo uRepo;
        IMealRepo mRepo;
        public AdminController(IUserRepo uR, IMealRepo mR)
        {
            uRepo = uR;
            mRepo = mR;
        }
        // GET: Admin/Admin
        public ActionResult Index()
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "admin")
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
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "admin")
            {
                Session.Clear();
                return RedirectToAction("Index", "Home", new { area = "" });

            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }

        public ActionResult Delete(int? i)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "admin")
            {
                if (i != null)
                    mRepo.Delete((int)i);
                return RedirectToAction("Index", "Admin");
            }

            return RedirectToAction("Login", "Home", new { area = "" });
        }

        public ActionResult Edit(int? i)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "admin")
            {
                if (i != null)
                {
                    Meal m = mRepo.GetByID((int)i);
                    MealModel mm = new MealModel() { Description = m.Description, ID = m.ID, Name = m.Name, PhotoPath = m.PhotoPath, Price = (int)m.Price, Quantity = (int)m.Stock };
                    return View(mm);
                }
            }

            return RedirectToAction("Login", "Home", new { area = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MealModel mm)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "admin")
            {
                if (mm != null)
                {
                    Meal mU = mRepo.GetByID(mm.ID);
                    mU.Name = mm.Name;
                    mU.PhotoPath = mm.PhotoPath;
                    mU.Price = mm.Price;
                    mU.Stock = mm.Quantity;
                    mU.Description = mm.Description;

                    mRepo.Update(mU);
                    return RedirectToAction("Index", "Admin");
                }
            }

            return RedirectToAction("Login", "Home", new { area = "" });
        }

        public ActionResult ChPhoto(int? i)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "admin")
            {
                if (i != null)
                {
                    Meal m = mRepo.GetByID((int)i);
                    MealModel mm = new MealModel() { Description = m.Description, ID = m.ID, Name = m.Name, PhotoPath = m.PhotoPath, Price = (int)m.Price, Quantity = (int)m.Stock };
                    return View(mm);
                }
            }

            return RedirectToAction("Login", "Home", new { area = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChPhoto(HttpPostedFileBase file, int? i)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    Meal m = mRepo.GetByID((int)i);
                    m.PhotoPath = "~/Images/" + Path.GetFileName(file.FileName);
                    mRepo.Update(m);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMeal()
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "admin")
            {
                return View(new MealModel());
            }

            return RedirectToAction("Login", "Home", new { area = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(MealModel mm)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "admin")
            {
                Meal meal = new Meal() { Description = mm.Description, IsDeleted = false, Name = mm.Name, PhotoPath = null, Price = mm.Price, Stock = mm.Quantity };

                mRepo.Add(meal);
                return RedirectToAction("Index", "Admin");
            }

            return RedirectToAction("Login", "Home", new { area = "" });
        }
    }
}
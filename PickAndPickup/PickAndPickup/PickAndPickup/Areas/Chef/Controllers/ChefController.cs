using DAL;
using DAL.Contracts;
using PickAndPickup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickAndPickup.Areas.Chef.Controllers
{
    public class ChefController : Controller
    {
        IOrderRepo oRepo;
        IOrderProductRepo opRepo;
        IUserRepo uRepo;
        IMealRepo mRepo;

        public ChefController(IUserRepo uR, IOrderRepo oR, IMealRepo mR, IOrderProductRepo opR)
        {
            oRepo = oR;
            uRepo = uR;
            mRepo = mR;
            opRepo = opR;
        }
        // GET: Chef/Chef
        public ActionResult Index()
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "chef")
            {
                Session["ordID"] = null;
                return View(new QRmodel());
            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }

        public ActionResult Logout()
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "chef")
            {
                Session.Clear();
                return RedirectToAction("Index", "Home", new { area = "" });

            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Scan(QRmodel qr)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "chef")
            {
                if (qr == null) return RedirectToAction("Index");
                List<Order> ords = oRepo.GetCurrent();
                Order ord = ords.FirstOrDefault(o => o.QRCodePath == qr.QRcode);
                if (ord == null) return RedirectToAction("Index");
                return RedirectToAction("Scan", "Chef", new { id = ord.ID });

            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }

        public ActionResult Scan(int? id)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "chef")
            {
                if (id == null) return RedirectToAction("Index");
                Order ord = oRepo.GetByID((int)id);

                List<DAL.User> users = uRepo.GetCurrent();
                List<DAL.Meal> meals = mRepo.GetCurrent();
                List<DAL.OrderProduct> orderProducts = opRepo.GetCurrent();
                OrderModel om = new OrderModel();

                if (ord.Date != null) om.Date = (DateTime)ord.Date;
                else om.Date = new DateTime();

                om.EstimatedTime = ord.EstimatedTime;
                om.ID = ord.ID;
                om.QRCodePath = ord.QRCodePath;
                om.TotalPrice = ord.TotalPrice;
                om.Voucher = null;

                UserModel um = new UserModel();
                if (ord.UserID != null)
                {
                    var usr = uRepo.GetByID((int)ord.UserID);
                    if (usr.DOB != null) um.DOB = (DateTime)usr.DOB;
                    else um.DOB = new DateTime();

                    um.ID = usr.ID;
                    um.Mail = usr.Mail;
                    um.Name = usr.Name;
                    um.NrOrders = usr.NrOrders;
                    um.Type = usr.Type;
                }

                om.User = um;

                List<MealModel> mm = new List<MealModel>();
                foreach (DAL.OrderProduct op in orderProducts)
                {
                    if (op.OrderID == ord.ID)
                    {
                        MealModel mealmodel = new MealModel();
                        Meal meal = mRepo.GetByID((int)op.MealID);
                        mealmodel.ID = meal.ID;
                        mealmodel.Name = meal.Name;
                        if (op.Quantity == null) mealmodel.Quantity = 0;
                        else mealmodel.Quantity = (int)op.Quantity;
                        mm.Add(mealmodel);
                    }
                }
                om.Meals = mm;

                Session["ordID"] = id;
                return View(om);
            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }

            public ActionResult Delete(int? i)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "chef")
            {
                if (i != null)
                    oRepo.Delete((int)i);
                return RedirectToAction("Index", "Order");
            }

            return RedirectToAction("Login", "Home", new { area = "" });
        }

        public ActionResult EditMeals(int? i)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "chef")
            {
                if (i == null)
                {
                    return RedirectToAction("Index", "Order");
                }

                List<DAL.Meal> meals = mRepo.GetCurrent();
                List<DAL.OrderProduct> orderProducts = opRepo.GetCurrent();
                MealListModel mealList = new MealListModel();

                foreach (DAL.Meal ml in meals)
                {
                    MealModel mealmodel = new MealModel();
                    mealmodel.ID = ml.ID;
                    mealmodel.Name = ml.Name;
                    mealmodel.Quantity = 0;
                    foreach (DAL.OrderProduct op in orderProducts)
                    {
                        if (op.OrderID == i && op.MealID == ml.ID)
                        {
                            mealmodel.Quantity = (int)op.Quantity;
                        }
                    }
                    mealList.mm.Add(mealmodel);
                }
                ViewBag.orderID = i;
                return View(mealList);
            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IncMeal(int? orderID, int? mealID)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "chef")
            {
                List<DAL.OrderProduct> orderProducts = opRepo.GetCurrent();
                bool found = false;
                foreach (DAL.OrderProduct op in orderProducts)
                {
                    if (op.OrderID == orderID)
                    {
                        if (op.MealID == mealID)
                        {
                            op.Quantity = op.Quantity + 1;
                            opRepo.Update(op);
                            found = true;
                        }
                    }
                }
                if (!found)
                {
                    OrderProduct op = new OrderProduct();
                    op.IsDeleted = false;
                    op.MealID = mealID;
                    op.OrderID = orderID;
                    op.Quantity = 1;
                    opRepo.Add(op);
                }

                oRepo.updatePrice((int)orderID);

                return RedirectToAction("EditMeals", "Chef", new { i = orderID });
            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DecMeal(int? orderID, int? mealID)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "chef")
            {
                List<DAL.OrderProduct> orderProducts = opRepo.GetCurrent();
                foreach (DAL.OrderProduct op in orderProducts)
                {
                    if (op.OrderID == orderID)
                    {
                        if (op.MealID == mealID)
                        {
                            if (op.Quantity != 0)
                            {
                                op.Quantity = op.Quantity - 1;
                                opRepo.Update(op);
                            }

                            if (op.Quantity == 0)
                            {
                                opRepo.Delete(op.ID);
                            }
                        }
                    }
                }

                oRepo.updatePrice((int)orderID);


                return RedirectToAction("EditMeals", "Chef", new { i = orderID });
            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }
    }
}
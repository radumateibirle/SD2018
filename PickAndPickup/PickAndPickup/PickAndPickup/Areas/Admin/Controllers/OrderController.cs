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
    public class OrderController : Controller
    {
        IOrderRepo oRepo;
        IOrderProductRepo opRepo;
        IUserRepo uRepo;
        IMealRepo mRepo;

        public OrderController(IUserRepo uR, IOrderRepo oR, IMealRepo mR, IOrderProductRepo opR)
        {
            oRepo = oR;
            uRepo = uR;
            mRepo = mR;
            opRepo = opR;
        }
        // GET: Admin/Order
        public ActionResult Index()
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "admin")
            {
                List<DAL.User> users = uRepo.GetCurrent();
                List<DAL.Order> orders = oRepo.GetCurrent();
                List<DAL.Meal> meals = mRepo.GetCurrent();
                List<DAL.OrderProduct> orderProducts = opRepo.GetCurrent();

                List<OrderModel> orderModels = new List<OrderModel>();

                foreach (DAL.Order o in orders)
                {
                    OrderModel om = new OrderModel();

                    if (o.Date != null) om.Date = (DateTime)o.Date;
                    else om.Date = new DateTime();

                    om.EstimatedTime = o.EstimatedTime;
                    om.ID = o.ID;
                    om.QRCodePath = o.QRCodePath;
                    om.TotalPrice = o.TotalPrice;
                    om.Voucher = null;

                    UserModel um = new UserModel();
                    if (o.UserID != null)
                    {
                        var usr = uRepo.GetByID((int)o.UserID);
                        if (usr.DOB != null) um.DOB = (DateTime)usr.DOB;
                        else um.DOB = new DateTime();

                        um.ID = usr.ID;
                        um.Mail = usr.Mail;
                        um.Name = usr.Name;
                        um.NrOrders = usr.NrOrders;
                        um.Type = usr.Type;
                    }

                    om.User = um;
                    om.EstimatedTime = o.EstimatedTime;

                    List<MealModel> mm = new List<MealModel>();
                    foreach (DAL.OrderProduct op in orderProducts)
                    {
                        if (op.OrderID == o.ID)
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

                    orderModels.Add(om);
                }
                return View(orderModels.ToPagedList(1, 1000));
            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }

        public ActionResult Delete(int? i)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "admin")
            {
                if (i != null)
                    oRepo.Delete((int)i);
                return RedirectToAction("Index", "Order");
            }

            return RedirectToAction("Login", "Home", new { area = "" });
        }

        public ActionResult Edit(int? i)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "admin")
            {
                if (i == null)
                {
                    return RedirectToAction("Index", "Order");
                }
                List<DAL.User> users = uRepo.GetCurrent();
                List<DAL.Order> orders = oRepo.GetCurrent();
                List<DAL.Meal> meals = mRepo.GetCurrent();
                List<DAL.OrderProduct> orderProducts = opRepo.GetCurrent();

                DAL.Order o = oRepo.GetByID((int)i);
                OrderModel om = new OrderModel();

                if (o.Date != null) om.Date = (DateTime)o.Date;
                else om.Date = new DateTime();

                om.EstimatedTime = o.EstimatedTime;
                om.ID = o.ID;
                om.QRCodePath = o.QRCodePath;
                om.TotalPrice = o.TotalPrice;
                om.Voucher = null;

                UserModel um = new UserModel();
                if (o.UserID != null)
                {
                    var usr = uRepo.GetByID((int)o.UserID);
                    if (usr.DOB != null) um.DOB = (DateTime)usr.DOB;
                    else um.DOB = new DateTime();

                    um.ID = usr.ID;
                    um.Mail = usr.Mail;
                    um.Name = usr.Name;
                    um.NrOrders = usr.NrOrders;
                    um.Type = usr.Type;
                }

                om.User = um;
                om.EstimatedTime = o.EstimatedTime;

                return View(om);
            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderModel om)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "admin")
            {
                if (om == null)
                {
                    return RedirectToAction("Index", "Order");
                }

                DAL.Order ord = new DAL.Order();
                ord = oRepo.GetByID(om.ID);
                if (om.Date != null) ord.Date = om.Date;
                oRepo.Update(ord);

                return RedirectToAction("Index", "Order");
            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }


        public ActionResult EditMeals(int? i)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "admin")
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
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "admin")
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
                
                oRepo.updatePrice((int) orderID);

                return RedirectToAction("EditMeals", "Order", new { i = orderID });
            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DecMeal(int? orderID, int? mealID)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "admin")
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

                            if(op.Quantity == 0)
                            {
                                opRepo.Delete(op.ID);
                            }
                        }
                    }
                }

                oRepo.updatePrice((int)orderID);


                return RedirectToAction("EditMeals", "Order", new { i = orderID });
            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }
    }
}
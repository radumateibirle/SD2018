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
    public class UserController : Controller
    {

        IUserRepo uRepo;
        public UserController(IUserRepo uR)
        {
            uRepo = uR;
        }
        // GET: Admin/User
        public ActionResult Index()
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "admin")
            {
                List<DAL.User> users = uRepo.GetCurrent();
                List<UserModel> usermodels = new List<UserModel>();
                foreach(DAL.User u in users)
                {
                    UserModel um = new UserModel() { ID = u.ID, Mail = u.Mail, Name = u.Name, NrOrders = u.NrOrders, Type = u.Type };


                    if (u.DOB != null) um.DOB = (DateTime)u.DOB;
                    else um.DOB = new DateTime();

                    usermodels.Add(um);
                }
                return View(usermodels.ToPagedList(1, 1000));
            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }

        public ActionResult Edit(int? i)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "admin")
            {
                if (i != null)
                {
                    DAL.User u = uRepo.GetByID((int)i);
                    UserModel um = new UserModel() {ID = u.ID, Mail = u.Mail, Name = u.Name, NrOrders = (int)u.NrOrders, Type = u.Type };

                    if (u.DOB != null) um.DOB = (DateTime)u.DOB;
                    else um.DOB = new DateTime();

                    return View(um);
                }
            }

            return RedirectToAction("Login", "Home", new { area = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserModel um)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "admin")
            {
                if (um != null)
                {
                    DAL.User uU = uRepo.GetByID(um.ID);
                    uU.DOB = um.DOB;
                    uU.ID = um.ID;
                    uU.IsDeleted = false;
                    uU.Mail = um.Mail;
                    uU.Name = um.Name;
                    uU.NrOrders = um.NrOrders;
                    uU.Type = um.Type;

                    uRepo.Update(uU);
                    return RedirectToAction("Index", "User");
                }
            }

            return RedirectToAction("Login", "Home", new { area = "" });
        }

        public ActionResult Delete(int? i)
        {
            if (Session["UserID"] != null && Session["UserType"].ToString().ToLower() == "admin")
            {
                if (i != null)
                    uRepo.Delete((int)i);
                return RedirectToAction("Index", "User");
            }

            return RedirectToAction("Login", "Home", new { area = "" });
        }


    }
}
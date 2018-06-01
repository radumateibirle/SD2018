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
    public class HomeController : Controller
    {
        IUserRepo uRepo;
        IMealRepo mRepo;
        public HomeController(IUserRepo uR, IMealRepo mR)
        {
            uRepo = uR;
            mRepo = mR;
        }
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cart()
        {
            return View(Session["CartItems"]);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel lm)
        {
            User us = uRepo.GetByEmail(lm.Email);
            if (us == null)
            {
                ViewBag.Message = "User not found. Please register!";
                return View(lm);
            }

            string pass = hash(lm.Password);

            if (pass != us.Password)
            {
                ViewBag.Message = "Incorrect password!";
                return View(lm);
            }

            Session["UserID"] = us.ID;
            Session["UserEmail"] = us.Mail;
            Session["UserType"] = us.Type;

            if (us.Type.ToLower() == "admin")
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            if (us.Type.ToLower() == "chef")
            {
                return RedirectToAction("Index", "Chef", new { area = "Chef" });
            }

            if (us.Type.ToLower() == "user")
            {
                if(Session["fromCheckout"] != null && Session["fromCheckout"].ToString() == "yes")
                {
                    return RedirectToAction("Index", "User", new { area = "User" });
                }
                return RedirectToAction("Index", "User", new { area = "User" });
            }

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel rm)
        {
            User us = uRepo.GetByEmail(rm.Mail);
            if(us != null)
            {
                ViewBag.Message = "User already exists!";
                return View(rm);
            }
            rm.Type = "user";
            User usr = new User();
            usr.Mail = rm.Mail;
            usr.Name = rm.Name;
            usr.NrOrders = 0;
            usr.Password = hash(rm.Password);
            usr.Type = rm.Type;
            usr.DOB = rm.DOB;
            usr.IsDeleted = false;

            uRepo.Add(usr);

            usr = uRepo.GetByEmail(usr.Mail);

            Session["UserID"] = usr.ID;
            Session["UserEmail"] = usr.Mail;
            Session["UserType"] = usr.Type;

            return RedirectToAction("Index", "User", new { area = "User" });
        }

        private string hash(string toHash)
        {
            string hashed;
            byte[] data = Encoding.UTF8.GetBytes(toHash);
            using (HashAlgorithm sha = new SHA256Managed())
            {
                byte[] encryptedBytes = sha.TransformFinalBlock(data, 0, data.Length);
                hashed = Convert.ToBase64String(sha.Hash);
            }
            return hashed;
        }
    }
}
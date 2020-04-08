using IMS_Entities;
using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        IMSEntities db = new IMSEntities();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(AccountViewModel vmuser)
        {
            var user = db.tbl_User.Where(c => c.Username == vmuser.Username && c.Password == vmuser.Password).FirstOrDefault();
            if (user != null)
            {
                Session["Fullname"] = user.Firstname + " " + user.Lastname;
                return RedirectToAction("Index", "Dashboard");

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Credentials Supplied! Please enter valid Username/Password");
                return View("Login");
            }
            




        }

    }
}

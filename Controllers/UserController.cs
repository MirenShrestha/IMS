using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace InventoryManagementSystem.Controllers
{
    public class UserController : Controller
    {
        IMSEntities1 db = new IMSEntities1();
        // GET: User
        public ActionResult Index()
        {
            var dbUser = db.tbl_User.Include(m => m.tbl_Role).ToList();
            var vmUser = (from u in dbUser

                          select new UserViewModel
                          {
                              Id = u.Id,
                              Username = u.Username,
                              Firstname = u.Firstname,
                              Lastname = u.Lastname,
                              Email = u.Email,
                              ContactNo = u.ContactNo,
                              Address = u.Address,
                              Status = u.Status,
                              Role = u.tbl_Role.Role
                          }).ToList();
            return View(vmUser);
        }




    }
}
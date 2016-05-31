using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Library_System.Models;

namespace Online_Library_System.Controllers
{
    public class AuthorizationController : Controller
    {
        private LibraryModel db = new LibraryModel();
        // GET: Authorization
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = db.Users.Where(e => e.Username == username && e.password == password).FirstOrDefault();


            if (user == null)
            {
                ViewBag.message = "data doesn't match!";
                return View("~/Views/Authorization/Login.cshtml");
            }

            if (username == "Crespo" && password == "12345")
            {
                Session["UserRole"] = "admin";
                return RedirectToAction("Index", "Home");
            }

            else {
                Session["UserRole"] = "user";
                return View("~/Views/Home/Index.cshtml");
             }
        }
    }
}
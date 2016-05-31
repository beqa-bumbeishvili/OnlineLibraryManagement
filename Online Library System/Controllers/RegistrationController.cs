using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Library_System.Models;

namespace Online_Library_System.Controllers
{
    public class RegistrationController : Controller
    {
        private LibraryModel db = new LibraryModel();
        // GET: Registration
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register([Bind(Include = "ID,FullName,Username,password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return View("Post_Register");
            }

            return View("~/Views/Home/Index.cshtml");
        }

    }
}

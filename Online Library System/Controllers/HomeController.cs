using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Library_System.Models;

namespace Online_Library_System.Controllers
{
    public class HomeController : Controller
    {
        LibraryModel db = new LibraryModel();
        public ActionResult Index()
        {            
            return View(db.books.ToList());
        }
        [HttpPost]
        public ActionResult Index(string category)
        {
            return View(db.books.ToList());
        }
    }
}
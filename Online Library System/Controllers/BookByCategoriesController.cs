using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Library_System.Models;

namespace Online_Library_System.Controllers
{
    public class BookByCategoriesController : Controller
    {
        LibraryModel db = new LibraryModel();
        // GET: BookByCategories
        public ActionResult Index()
        {
            var x = db.books;
            return View();
        }
    }
}
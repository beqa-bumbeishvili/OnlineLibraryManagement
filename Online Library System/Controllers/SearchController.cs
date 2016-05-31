using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Library_System.Models;

namespace Online_Library_System.Controllers
{
    public class SearchController : Controller
    {
        LibraryModel db = new LibraryModel();
        // GET: Search
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Find(string searchBookName)
        {
            var bookObject = db.books.Where(e => e.Name == searchBookName).FirstOrDefault(); //shemidzlia gamoviyeno tolist() metodi


            return View("~/Views/Home/Index.cshtml");
        }

    }
}
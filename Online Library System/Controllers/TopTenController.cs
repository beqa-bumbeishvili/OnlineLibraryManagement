using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Library_System.Models;

namespace Online_Library_System.Controllers
{
    public class TopTenController : Controller
    {
        LibraryModel db = new LibraryModel();
        // GET: topTen
        public ActionResult Index()
        {
            var x = db.books.Select(e => e.Price).ToString();
            var top = db.books.OrderByDescending(e => e.takes).ToList().Take(10);

            return View(top.ToList());
        }
    }
}
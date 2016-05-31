using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Library_System.Models;

namespace Online_Library_System.Controllers
{
    public class GoogleMapController : Controller
    {
        LibraryModel db = new LibraryModel();
        // GET: GoogleMap
        public ActionResult Index()
        {
           
            return View(db.Libraries.ToList());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Online_Library_System.Models;

namespace Online_Library_System.Controllers
{
    public class BookRatingsController : Controller
    {
        private LibraryModel db = new LibraryModel();

        // GET: BookRatings
        public ActionResult Index()
        {
            var bookRatings = db.BookRatings.Include(b => b.book);
            return View(bookRatings.ToList());
        }

        // GET: BookRatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookRating bookRating = db.BookRatings.Find(id);
            if (bookRating == null)
            {
                return HttpNotFound();
            }
            return View(bookRating);
        }

        // GET: BookRatings/Create
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(db.books, "ID", "Name");
            return View();
        }

        // POST: BookRatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BookID,RatingValue")] BookRating bookRating)
        {
            if (ModelState.IsValid)
            {
                db.BookRatings.Add(bookRating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.books, "ID", "Name", bookRating.BookID);
            return View(bookRating);
        }

        // GET: BookRatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookRating bookRating = db.BookRatings.Find(id);
            if (bookRating == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.books, "ID", "Name", bookRating.BookID);
            return View(bookRating);
        }

        // POST: BookRatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BookID,RatingValue")] BookRating bookRating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookRating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.books, "ID", "Name", bookRating.BookID);
            return View(bookRating);
        }

        // GET: BookRatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookRating bookRating = db.BookRatings.Find(id);
            if (bookRating == null)
            {
                return HttpNotFound();
            }
            return View(bookRating);
        }

        // POST: BookRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookRating bookRating = db.BookRatings.Find(id);
            db.BookRatings.Remove(bookRating);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

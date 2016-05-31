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
    public class BookLibraryLinksController : Controller
    {
        private LibraryModel db = new LibraryModel();

        // GET: BookLibraryLinks
        public ActionResult Index()
        {
            var bookLibraryLinks = db.BookLibraryLinks.Include(b => b.book ).Include(b => b.Library);
            return View(bookLibraryLinks.ToList());
        }

        // GET: BookLibraryLinks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookLibraryLink bookLibraryLink = db.BookLibraryLinks.Find(id);
            if (bookLibraryLink == null)
            {
                return HttpNotFound();
            }
            return View(bookLibraryLink);
        }

        // GET: BookLibraryLinks/Create
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(db.books, "ID", "Name");
            ViewBag.LibraryID = new SelectList(db.Libraries, "ID", "Name");
            return View();
        }

        // POST: BookLibraryLinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BookID,LibraryID")] BookLibraryLink bookLibraryLink)
        {
            if (ModelState.IsValid)
            {
                db.BookLibraryLinks.Add(bookLibraryLink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.books, "ID", "Name", bookLibraryLink.BookID);
            ViewBag.LibraryID = new SelectList(db.Libraries, "ID", "Name", bookLibraryLink.LibraryID);
            return View(bookLibraryLink);
        }

        // GET: BookLibraryLinks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookLibraryLink bookLibraryLink = db.BookLibraryLinks.Find(id);
            if (bookLibraryLink == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.books, "ID", "Name", bookLibraryLink.BookID);
            ViewBag.LibraryID = new SelectList(db.Libraries, "ID", "Name", bookLibraryLink.LibraryID);
            return View(bookLibraryLink);
        }

        // POST: BookLibraryLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BookID,LibraryID")] BookLibraryLink bookLibraryLink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookLibraryLink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.books, "ID", "Name", bookLibraryLink.BookID);
            ViewBag.LibraryID = new SelectList(db.Libraries, "ID", "Name", bookLibraryLink.LibraryID);
            return View(bookLibraryLink);
        }

        // GET: BookLibraryLinks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookLibraryLink bookLibraryLink = db.BookLibraryLinks.Find(id);
            if (bookLibraryLink == null)
            {
                return HttpNotFound();
            }
            return View(bookLibraryLink);
        }

        // POST: BookLibraryLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookLibraryLink bookLibraryLink = db.BookLibraryLinks.Find(id);
            db.BookLibraryLinks.Remove(bookLibraryLink);
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

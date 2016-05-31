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
    public class BookUserLinksController : Controller
    {
        private LibraryModel db = new LibraryModel();

        // GET: BookUserLinks
        public ActionResult Index()
        {
            var bookUserLinks = db.BookUserLinks.Include(b => b.book ).Include(b => b.User);
            return View(bookUserLinks.ToList());
        }

        // GET: BookUserLinks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookUserLink bookUserLink = db.BookUserLinks.Find(id);
            if (bookUserLink == null)
            {
                return HttpNotFound();
            }
            return View(bookUserLink);
        }

        // GET: BookUserLinks/Create
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(db.books, "ID", "Name");
            ViewBag.UserID = new SelectList(db.Users, "ID", "FullName");
            return View();
        }

        // POST: BookUserLinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BookID,UserID")] BookUserLink bookUserLink)
        {
            if (ModelState.IsValid)
            {
                db.BookUserLinks.Add(bookUserLink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.books, "ID", "Name", bookUserLink.BookID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "FullName", bookUserLink.UserID);
            return View(bookUserLink);
        }

        // GET: BookUserLinks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookUserLink bookUserLink = db.BookUserLinks.Find(id);
            if (bookUserLink == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.books, "ID", "Name", bookUserLink.BookID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "FullName", bookUserLink.UserID);
            return View(bookUserLink);
        }

        // POST: BookUserLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BookID,UserID")] BookUserLink bookUserLink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookUserLink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.books, "ID", "Name", bookUserLink.BookID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "FullName", bookUserLink.UserID);
            return View(bookUserLink);
        }

        // GET: BookUserLinks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookUserLink bookUserLink = db.BookUserLinks.Find(id);
            if (bookUserLink == null)
            {
                return HttpNotFound();
            }
            return View(bookUserLink);
        }

        // POST: BookUserLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookUserLink bookUserLink = db.BookUserLinks.Find(id);
            db.BookUserLinks.Remove(bookUserLink);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySchoolV1.Models;

namespace MySchoolV1.Controllers
{
    public class UserSubjectsController : Controller
    {
        private DBContextClass db = new DBContextClass();

        // GET: UserSubjects
        public ActionResult Index()
        {
            return View(db.UserSubjects.ToList());
        }

        // GET: UserSubjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSubject userSubject = db.UserSubjects.Find(id);
            if (userSubject == null)
            {
                return HttpNotFound();
            }
            return View(userSubject);
        }

        // GET: UserSubjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,SubjectID")] UserSubject userSubject)
        {
            if (ModelState.IsValid)
            {
                db.UserSubjects.Add(userSubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userSubject);
        }

        // GET: UserSubjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSubject userSubject = db.UserSubjects.Find(id);
            if (userSubject == null)
            {
                return HttpNotFound();
            }
            return View(userSubject);
        }

        // POST: UserSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,SubjectID")] UserSubject userSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userSubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userSubject);
        }

        // GET: UserSubjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSubject userSubject = db.UserSubjects.Find(id);
            if (userSubject == null)
            {
                return HttpNotFound();
            }
            return View(userSubject);
        }

        // POST: UserSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserSubject userSubject = db.UserSubjects.Find(id);
            db.UserSubjects.Remove(userSubject);
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

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
    [Authorize]
    public class UsersController : Controller
    {
        private DBContextClass db = new DBContextClass();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.UserType = new SelectList(db.UserTypes, "ID", "Name");
            /*get all user types in select and in <option> value set (ID) and in <option> Text set (Name) 
             * <select>
                 <option value="1">Admin</option>
                 <option value="2">Student</option>
             </select>
            */
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Password,ConfirmPassword,Gender,DateOfBirth,Address,PhoneNumber,UserTypeID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Password,ConfirmPassword,Gender,DateOfBirth,Address,PhoneNumber,UserTypeID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        /***************************************************************/
        // GET: Users/CreateUserSubject
        public ActionResult CreateUserSubject(int? id)
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

        // POST: Users/CreateUserSubject
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUserSubject([Bind(Include = "ID,UserID,SubjectID")] UserSubject userSubject)
        {
            if (ModelState.IsValid)
            {
                db.UserSubjects.Add(userSubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userSubject);
        }


        // GET: Users/Courses/5
        public ActionResult StudentCourses(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<UserSubject> UserSubjects = db.UserSubjects.Where(x => x.UserID == id).ToList();

          /*  if (user == null)
            {
                return HttpNotFound();
            }*/
            return View(UserSubjects);
        }

        // GET: Users/EditUserSubject/5
        public ActionResult EditUserSubject(int? id)
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
        // POST: Users/UserSubject/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserSubject([Bind(Include = "ID,UserID,SubjectID")] UserSubject userSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userSubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userSubject);
        }

        // GET: Users/DeleteUserSubject/5
        public ActionResult DeleteUserSubject(int? id)
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

        // POST: Users/DeleteUserSubject/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUserSubject(int id)
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

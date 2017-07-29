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
    public class QuestionsController : Controller
    {
        private DBContextClass db = new DBContextClass();

        // GET: Questions
        public ActionResult Index()
        {
            return View(db.Questions.ToList());
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        public PartialViewResult ReturnAnswers(int questionID)
        {

            List<Answer> answers = db.Answers.Where(a => a.QuestionID == questionID).ToList();
            return PartialView("_ReturnAnswers", answers);

        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            //if(HttpContext.Current.Request.HttpMethod == "GET")

            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateInput(false)]
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,userID,Text")] Question question)
        {
            ViewBag.answerNames = Request.Form.GetValues("the_answer");
            ViewBag.answerScores = Request.Form.GetValues("Score");
            ViewBag.rightAnswer = Request.Form.Get("right_answer");
           // string QuestionText = Request.Form.Get("Question");
            if (!String.IsNullOrEmpty(question.Text))
            {
                //Add the Question
                Question question2 = new Question();
                question2.Text = question.Text;
                db.Questions.Add(question2);
                db.SaveChanges();

                //Get Question ID
                ViewBag.QuestioniID = question2.ID;


                //Add Answers to the Question
                for (int i = 0; i < ViewBag.answerNames.Length; i++)
                {


                    if (!String.IsNullOrEmpty(ViewBag.answerNames[i]))
                    {
                        Answer answerObject = new Answer();
                        answerObject.QuestionID = question2.ID;
                        answerObject.Score = Convert.ToInt32(ViewBag.answerScores[i]);
                        answerObject.Text = ViewBag.answerNames[i];

                        //We suppuse that first answer is right answer
                        if (i == 0)//ViewBag.rightAnswer == "on"
                        {
                            answerObject.RightAnswer = 1;
                        }

                        db.Answers.Add(answerObject);
                        db.SaveChanges();
                    }

                }
            }
           
            return RedirectToAction("Index"); 
          // return View(question2);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,userID,Text")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
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

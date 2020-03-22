using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GMU.Models;

namespace GMU.Controllers
{
    public class StudentsController : Controller
    {
        private GMUContext db = new GMUContext();

        [Authorize]
        // GET: Students
        public ActionResult Index(string search)
        {
            int SSN = 0;
            bool isInt = int.TryParse(search, out SSN);

            if (isInt)
            {
                return View(db.Students.Where(model => model.SSN == SSN || search == null).ToList());
            }
            else
            {
                return View(db.Students.Where(model => model.LastName.Contains(search) || search == null).ToList());
            }
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,LastName,MiddleName,FirstName,SSN,EmailAddress,HomePhone,CellPhone,AddrStreet,AddrCity,AddrState,AddrZipcode,DateOfBirth,Gender,HSName,GradDate,GPA,SATMath,SATVerbal,MajorInterest,EnrollSemester,EnrollYear,EnrollTime,Decision")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        [Authorize]
        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [Authorize]
        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,LastName,MiddleName,FirstName,SSN,EmailAddress,HomePhone,CellPhone,AddrStreet,AddrCity,AddrState,AddrZipcode,DateOfBirth,Gender,HSName,GradDate,GPA,SATMath,SATVerbal,MajorInterest,EnrollSemester,EnrollYear,EnrollTime,Decision")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [Authorize]
        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [Authorize]
        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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

        public JsonResult DoesSSNExist(string ssn)
        {
            //int SSN = int.Parse(ssn);
            //var valSSN = db.Students.FirstOrDefault(model => model.SSN == SSN);
            //if (valSSN != null)
            //{
            //    return Json(false, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json(true, JsonRequestBehavior.AllowGet);
            //}
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}

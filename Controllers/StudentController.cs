using BusinessEntities;
using BusinessLayer;
using Moodle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace Moodle.Controllers
{
    public class StudentController : Controller
    {
        /// <summary>
        /// An instance of StudentBusinessLayer
        /// </summary>
        private StudentBusinessLayer stuBL = new StudentBusinessLayer();


        /// GET: Available student list
        ///
        //[Authorize]
        public ActionResult Index()
        {
            StudentListViewModel stuListVM = new StudentListViewModel();

            List<Student> students = stuBL.GetStudents();

            List<StudentViewModel> stuVMs = new List<StudentViewModel>();

            foreach (Student stu in students)
            {
                StudentViewModel stuVM = new StudentViewModel(stu);
                stuVMs.Add(stuVM);
            }

            stuListVM.Students = stuVMs;
            return View("Index", stuListVM);
        }


        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCreateStudent([Bind(Include = "StuId,StuName")] Student stu)
        {
            if (ModelState.IsValid)
            {
                stuBL.AddStudent(stu);
                return RedirectToAction("Index");
            }
            return View("Create", stu);
        }

        /// <summary>
        /// Show the details of a student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student stu = stuBL.FindStudent(id.Value);
            if (stu == null)
            {
                return HttpNotFound();
            }
            StudentViewModel stuVM = new StudentViewModel(stu);
            return View(stuVM);
        }

        /// <summary>
        /// Return the view of editing a student's information
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student stu = stuBL.FindStudent(id.Value);
            if (stu == null)
            {
                return HttpNotFound();
            }
            return View(stu);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEditStudent([Bind(Include = "Id,StuId,StuName")] Student stu)
        {
            if (ModelState.IsValid)
            {
                stuBL.SaveEditStudent(stu);
                return RedirectToAction("Index");
            }
            return View("Edit", stu);
        }

        /// <summary>
        /// Return the view of deleting a student's information
        /// GET: Student/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student stu = stuBL.FindStudent(id.Value);
            if (stu == null)
            {
                return HttpNotFound();
            }
            StudentViewModel stuVM = new StudentViewModel(stu);
            return View(stuVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            stuBL.DeleteStudent(id.Value);
            return RedirectToAction("Index");
        }
    }
}
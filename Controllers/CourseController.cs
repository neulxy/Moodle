using BusinessEntities;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace Moodle.Controllers
{
    public class CourseController : Controller
    {
        private CourseBusinessLayer courseBL = new CourseBusinessLayer();
        /// GET: Available course list
        /// 
        public ActionResult Index()
        {
            CourseListViewModel courseListVM = new CourseListViewModel();

            List<Course> courses = courseBL.GetCourses();

            List<CourseViewModel> courseVMs = new List<CourseViewModel>();

            foreach (Course course in courses)
            {
                CourseViewModel courseVM = new CourseViewModel(course);
                courseVMs.Add(courseVM);
            }

            courseListVM.Courses = courseVMs;
            return View("Index", courseListVM);
        }


        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCreateCourse([Bind(Include = "CourseCode,CourseName")] Course course)
        {
            if (ModelState.IsValid)
            {
                courseBL.AddCourse(course);
                return RedirectToAction("Index");
            }
            return View("Create", course);
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = courseBL.FindCourse(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            CourseViewModel courseVM = new CourseViewModel(course);
            return View(courseVM);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = courseBL.FindCourse(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            CourseViewModel courseVM = new CourseViewModel(course);
            return View(courseVM);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEditCourse([Bind(Include = "CourseId,CourseCode,CourseName")] Course course)
        {
            if (ModelState.IsValid)
            {
                courseBL.SaveEditCourse(course);
                return RedirectToAction("Index");
            }
            CourseViewModel courseVM = new CourseViewModel(course);
            return View("Edit", courseVM);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = courseBL.FindCourse(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            CourseViewModel courseVM = new CourseViewModel(course);
            return View(courseVM);
        }

        // POST: Courses/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int CourseId)
        {
            courseBL.DeleteCourse(CourseId);
            return RedirectToAction("Index");
        }
    }
}
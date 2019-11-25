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
    public class EnrollController : Controller
    {
        /// <summary>
        /// An instance of EnrollBusinessLayer
        /// </summary>
        private EnrollBusinessLayer enrollBL = new EnrollBusinessLayer();

        /// <summary>
        /// Return the index view of enroll
        /// </summary>
        /// <returns></returns>        
        public ActionResult Index()
        {
            EnrollListViewModel enrollListVM = new EnrollListViewModel();

            List<Enroll> enrolls = enrollBL.GetEnrolls();

            List<EnrollViewModel> enrollVMs = new List<EnrollViewModel>();

            foreach (Enroll enroll in enrolls)
            {
                EnrollViewModel enrollVM = new EnrollViewModel(enroll);
                enrollVMs.Add(enrollVM);
            }

            enrollListVM.EnrollVMs = enrollVMs;
            return View("Index", enrollListVM);
        }

        // GET: Enroll/Create
        public ActionResult Create()
        {
            var yearSelectItems = new List<SelectListItem>
            {
                new SelectListItem{Text="2019",Value="2019"},
                new SelectListItem{Text="2020",Value="2020"},
                new SelectListItem{Text="2021",Value="2021"},
            };
            ViewData["yearSelect"] = new SelectList(yearSelectItems, "Value", "Text");

            var semesterSelectItems = new List<SelectListItem>
            {
                new SelectListItem{Text="1",Value="1"},
                new SelectListItem{Text="2",Value="2"},
                new SelectListItem{Text="3",Value="3"},
            };
            ViewData["semesterSelect"] = new SelectList(semesterSelectItems, "Value", "Text");
            //SelectList yearSelList = new SelectList(yearList, "Year", "Year");

            //ViewBag.yearSelList = yearSelList.AsEnumerable();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCreateEnroll(Enroll enroll)
        {

            if (ModelState.IsValid)
            {
                //If the enrollment doesn't exist
                if (!enrollBL.EnrollExist(enroll))
                {
                    enrollBL.AddEnroll(enroll);
                    return RedirectToAction("Index");
                }
                else
                    ModelState.AddModelError("", "The enrollment has already existed.");

                //Another way to implement such an error notice
                //ModelState.AddModelError("EnrollExistError", "The enrollment has already existed.");
                //    @Html.ValidationMessage("EnrollExistError", new { @class = "text-danger" })

            }


            //Prepare the create enroll view
            //generate the year select list
            var yearSelectItems = new List<SelectListItem>
            {
                new SelectListItem{Text="2019",Value="2019"},
                new SelectListItem{Text="2020",Value="2020"},
                new SelectListItem{Text="2021",Value="2021"},
            };
            ViewData["yearSelect"] = new SelectList(yearSelectItems, "Value", "Text");

            //generate the semester select list
            var semesterSelectItems = new List<SelectListItem>
            {
                new SelectListItem{Text="1",Value="1"},
                new SelectListItem{Text="2",Value="2"},
                new SelectListItem{Text="3",Value="3"},
            };
            ViewData["semesterSelect"] = new SelectList(semesterSelectItems, "Value", "Text");

            //return the create view with enroll instance
            return View("Create", enroll);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enroll enroll = enrollBL.FindEnroll(id.Value);
            if (enroll == null)
            {
                return HttpNotFound();
            }
            EnrollViewModel enrollVM = new EnrollViewModel(enroll);
            return View(enrollVM);
        }


        /// <summary>
        /// Delete the enrollment record with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            enrollBL.DeleteEnroll(id.Value);
            return RedirectToAction("Index");
        }


        /// <summary>
        /// Show the details of an enrollment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enroll enroll = enrollBL.FindEnroll(id.Value);
            if (enroll == null)
            {
                return HttpNotFound();
            }
            EnrollViewModel enrollVM = new EnrollViewModel(enroll);
            return View(enrollVM);
        }


    }
}
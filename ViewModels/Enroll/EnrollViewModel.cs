using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer;
using BusinessLayer;

namespace ViewModels
{
    public class EnrollViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Student ID")]
        public string StuId { get; set; }

        [Display(Name = "Student Name")]
        public string StuName { get; set; }

        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }

        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Display(Name = "Year")]
        public int Year { get; set; }


        [Display(Name = "Semester")]
        public int Semester { get; set; }

        /// <summary>
        /// Generate an EnrollViewModel instance with a Enroll instance
        /// </summary>
        /// <param name="enroll"></param>
        public EnrollViewModel(Enroll enroll)
        {
            Id = enroll.Id;
            StuId = enroll.StuId;
            CourseCode = enroll.CourseCode;
            Year = enroll.Year.Value;
            Semester = enroll.Semester.Value;

            //get the course name
            CourseBusinessLayer courseBL = new CourseBusinessLayer();
            CourseName = courseBL.FindCourseName(CourseCode);

            //get the student name
            StudentBusinessLayer stuBL = new StudentBusinessLayer();
            StuName = stuBL.FindStuName(StuId);
        }
    }
}
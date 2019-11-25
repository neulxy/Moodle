using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class CourseViewModel
    {
        [Display(Name = "Course ID")]
        public int CourseId { get; set; }

        [Display(Name = "Course Code")]
        [Required(ErrorMessage = "Course Code is required")]
        public string CourseCode { get; set; }

        [Display(Name = "Course Name")]
        [Required(ErrorMessage = "Course Name is required")]
        public string CourseName { get; set; }

        /// <summary>
        /// Generate an CourseViewModel instance with a Course instance
        /// </summary>
        /// <param name="course"></param>
        public CourseViewModel(Course course)
        {
            CourseId = course.CourseId;
            CourseCode = course.CourseCode;
            CourseName = course.CourseName;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Validations;

namespace BusinessEntities
{
    public class CreateEnrollViewModel
    {
        [Required(ErrorMessage = "Student ID is required")]
        [Display(Name="Student ID")]
        [EnrollValidations.StudentIDExist]
        public string StuId { get; set; }

        [Required(ErrorMessage = "Course code is required")]
        [Display(Name="Course Code")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "The year of enrollment is required")]
        [Display(Name = "Year")]
        public int? Year { get; set; }

        [Range(1, 3, ErrorMessage="Semester should be in the range of 1 to 3.")]
        [Display(Name = "Semester")]
        [Required(ErrorMessage = "The semester of enrollment is required")]
        public int? Semester { get; set; }
    }
}

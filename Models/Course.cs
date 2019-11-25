using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessEntities
{
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        [Required(ErrorMessage="Course Code is required")]
        [Display(Name="Course Code")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        [Display(Name="Course Name")]
        public string CourseName { get; set; }

    }
}

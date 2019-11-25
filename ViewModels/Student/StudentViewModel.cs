using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class StudentViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Student ID")]
        public string StuId { get; set; }

        [Display(Name = "Student Name")]
        public string StuName { get; set; }

        /// <summary>
        /// Generate an StudentViewModel instance with a Student instance
        /// </summary>
        /// <param name="stu"></param>
        public StudentViewModel(Student stu)
        {
            Id = stu.Id;
            StuId = stu.StuId;
            StuName = stu.StuName;
        }
    }
}
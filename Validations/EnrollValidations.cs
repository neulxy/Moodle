using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Validations
{
    public class EnrollValidations
    {
        /// <summary>
        /// An annotation used to define the existance of student ID
        /// </summary>
        public class StudentIDExist : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value == null) // Checking for Empty Value
                {
                    return new ValidationResult("Student ID is required");
                }
                else
                {
                    //Search in the databases to check if the value exists in the column of StuId
                    StudentBusinessLayer stuBL = new StudentBusinessLayer();
                    string stuId = (string)value;
                    if (!stuBL.StudentExistsByStuId(stuId))
                        return new ValidationResult($"Student ID {stuId} doesn't exist.");

                }
                return ValidationResult.Success;
            }
        }

        public class CourseCodeExist : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value == null) // Checking for Empty Value
                {
                    return new ValidationResult("Course code is required");
                }
                else
                {
                    //Search in the databases to check if the value exists in the column of Course Code
                    CourseBusinessLayer courseBL = new CourseBusinessLayer();
                    string code = (string)value;
                    if (!courseBL.CourseExistByCode(code))
                        return new ValidationResult($"Course Code {code} doesn't exist.");

                }
                return ValidationResult.Success;
            }
        }
    }
}
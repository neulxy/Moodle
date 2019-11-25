using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Validations
{
    public class StudentValidations
    {
        /// <summary>
        /// An annotation used to define the uniqueness of student ID
        /// </summary>
        public class UniqueID : ValidationAttribute
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
                    if (stuBL.StudentExistsByStuId(stuId))
                        return new ValidationResult($"Student ID {stuId} already exists.");
                 
                }
                return ValidationResult.Success;
            }
        }


    }
}
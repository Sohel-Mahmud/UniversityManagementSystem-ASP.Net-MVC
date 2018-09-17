using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Please Provide Student Name!")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Please Provide Contact Number!")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Contact Number must be a natural number")]
        [StringLength(11,MinimumLength = 11,ErrorMessage = "Contact Number Must Be 11 Digit Long!")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please Provide Email Address!")]
        [EmailAddress(ErrorMessage = "Please Provide Correct Email Formate!")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:/dd/MM/yyyy}")]
        public string  Date { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Select a Department!")]
        public int DepartmentId { get; set; }
        public string RegistrationNo { get; set; }


    }
}
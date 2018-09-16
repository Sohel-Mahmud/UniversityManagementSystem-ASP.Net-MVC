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
        [StringLength(11,MinimumLength = 11,ErrorMessage = "Contact Number Must Be 11 Digit Long!")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please Provide Email Address!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string  Date { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Select a Department!")]
        public int DepartmentId { get; set; }
        public string RegistrationNo { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        [DisplayName("Teacher's Name")]
        [Required(ErrorMessage = "Please Provide Teacher's Name")]
        public string Name { get; set; }

        [DisplayName("Teacher's Address")]
        [Required(ErrorMessage = "Please Provide Teacher's Address")]
        public string Address { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Please Provide EmailAddress")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Contact Number")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Contact Number must be a natural number")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Contact Number Must Be 11 Digit Long!")]
        public string ContactNo { get; set; }

        [DisplayName("Designation")]
        [Required(ErrorMessage = "Please select a Designation")]
        public int DesignationId { get; set; }

        [DisplayName("Department")]
        [Required(ErrorMessage = "Please select aDepartment")]
        public int DepartmentId { get; set; }

        [DisplayName("Credit to be taken")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "credit must be non negative")]
        public double Credit { get; set; }
    }
}
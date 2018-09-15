using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        [Required]
        public string Name { get; set; }
         [Required]
        public string Address { get; set; }
         [Required]
         [DataType(DataType.EmailAddress)]
         [EmailAddress]
        public string Email { get; set; }
         [Required]
        public string ContactNo { get; set; }
         [Required]
        public int DesignationId { get; set; }
         [Required]
        public int DepartmentId { get; set; }
         [Required]
        [Range(1.0,Double.MaxValue,ErrorMessage = "credit must be non negative")]
        public double Credit { get; set; }
    }
}
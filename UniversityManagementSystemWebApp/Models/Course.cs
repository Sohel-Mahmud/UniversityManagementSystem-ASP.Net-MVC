using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string CourseCode { get; set; }
        [Required]
        [Range(0.5, 5.0, ErrorMessage = "Credit Must be between 0.5 to 5.0")]
        public double Credit { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int DeptId { get; set; }
        [Required]
        public int SemesterId { get; set; }
    }
}
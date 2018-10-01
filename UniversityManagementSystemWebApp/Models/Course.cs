using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Course
    {
                              
        public int CourseId { get; set; }
        [DisplayName("Course Name")]
        [Required(ErrorMessage = "Please Provide a Course Name")]
        public string CourseName { get; set; }
        [DisplayName("Course Code")]
        [Required(ErrorMessage = "Please Provide a Course Code")]
        [StringLength(int.MaxValue, MinimumLength = 7, ErrorMessage = "Code must be at least 5 characters long.")]
        public string CourseCode { get; set; }
        [Required]
        [Range(0.5, 5.0, ErrorMessage = "Credit Must be between 0.5 to 5.0")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{0,1})?$", ErrorMessage = "Only decimal positive value with 1 decimal places accepted")]
        public double Credit { get; set; }
        [DisplayName("Description")]
        [Required(ErrorMessage = "Please Provide Description")]
        public string Description { get; set; }
        [DisplayName("Department")]
        [Required(ErrorMessage = "Please Provide Department")]
        public int DeptId { get; set; }
        [DisplayName("Semester")]
        [Required(ErrorMessage = "Please Provide Department")]
        public int SemesterId { get; set; }
    }
}
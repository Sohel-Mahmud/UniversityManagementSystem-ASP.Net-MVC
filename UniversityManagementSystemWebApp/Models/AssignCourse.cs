using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class AssignCourse
    {
        public int CourseAssignId { get; set; }
        [Required]
        public int TeacherId { get; set; }
                [Required]

        public int CourseId { get; set; }
                [Required]

        public int DepartmentId { get; set; }
        [Required]
        public string Action { get; set; }
    }
}
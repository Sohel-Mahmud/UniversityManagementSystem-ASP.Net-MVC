using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class AssignCourse
    {
        public int CourseAssignId { get; set; }

        [Required(ErrorMessage = "Please Select a Teacher's Name")]
        public int TeacherId { get; set; }


        [Required(ErrorMessage = "Please Select a Course Code")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Please Select a Department")]
        public int DepartmentId { get; set; }
     
        public string Action { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models.ViewModel
{
    public class CourseStaticsViewModel
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Semester { get; set; }
        public string AssignedTeacherName { get; set; }
    }
}
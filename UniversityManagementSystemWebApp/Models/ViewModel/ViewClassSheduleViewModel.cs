using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models.ViewModel
{
    public class ViewClassSheduleViewModel
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }

        public string CourseName { get; set; }

        public List<string> Scheduleinfo = new List<string>();
    }
}
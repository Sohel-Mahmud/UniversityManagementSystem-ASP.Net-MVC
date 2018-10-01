using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models.ViewModel
{
    public class StudentDetailsViewModel
    {
        public string StudentName { get; set; }
        public string StudentRegNo { get; set; }
        public string StudntContactNo { get; set; }
        public string StudentEmail { get; set; }
        public string StudentDate { get; set; }
        public string StudentAddress { get; set; }
        public string StudentDeptCode { get; set; }
        public string StudentDeptName { get; set; }
    }
}
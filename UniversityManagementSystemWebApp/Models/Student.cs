using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string  Date { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public string RegistrationNo { get; set; }


    }
}
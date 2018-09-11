using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Department
    {
        [StringLength(7,MinimumLength = 2,ErrorMessage = "Code length must be 2 to 7 characters long")]
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
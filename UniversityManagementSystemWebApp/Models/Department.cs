using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Department
    {
        public int DeptId { get; set; }

        [DisplayName("Department Code")]
        [Required(ErrorMessage = "Please Provide Department Code")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Department Code must be 2 to 7 characters long.")]
        public string Code { get; set; }
        [DisplayName("Department Name")]
        [Required(ErrorMessage = "Please Provide Department Name")]
        public string Name { get; set; }
    }
}
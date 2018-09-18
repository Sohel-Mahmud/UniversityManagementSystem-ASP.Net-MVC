using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Enroll
    {
        public int EnrollId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:/dd/MM/yyyy}")]
        public string Date { get; set; }

        public int? GradeId { get; set; }

        public string Action { get; set; }
    }
}
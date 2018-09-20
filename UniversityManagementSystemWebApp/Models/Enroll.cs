using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace UniversityManagementSystemWebApp.Models
{
    public class Enroll
    {
        public int EnrollId { get; set; }
        [Required(ErrorMessage = "Please Select Student!")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Please Select Course!")]
        public int CourseId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:/dd/MM/yyyy}")]
        public string Date { get; set; }

        public int? GradeId { get; set; }

        public string Action { get; set; }
    }
}
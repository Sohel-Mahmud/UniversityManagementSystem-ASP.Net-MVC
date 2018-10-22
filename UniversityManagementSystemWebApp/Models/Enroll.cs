<<<<<<< HEAD
﻿using System;
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
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Enroll
    {
        [DisplayName("Student Reg No.")]
        [Required(ErrorMessage = "Please Select Student Reg No")]
        public int EnrollId { get; set; }
        public int StudentId { get; set; }

        [DisplayName("Select Course")]
        [Required(ErrorMessage = "Please Select Course")]
        public int CourseId { get; set; }

        public string Date { get; set; }

        [DisplayName("Select Grade Letter")]
        [Required(ErrorMessage = "Please Select Grade Letter")]
        public int GradeId { get; set; }

        public string Action { get; set; }
    }
>>>>>>> parent of 9ba993f... Merge branch 'master' into Forman
}
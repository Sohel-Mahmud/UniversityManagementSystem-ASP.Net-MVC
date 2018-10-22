<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string CourseCode { get; set; }
        [Required]
<<<<<<< HEAD
        [Range(0.5, 5.0, ErrorMessage = "Credit Must be between 0.5 to 5.0")]
=======
        [Range(0.5,5.0,ErrorMessage = "Credit Must be between 0.5 to 5.0")]
>>>>>>> master
        public double Credit { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int DeptId { get; set; }
        [Required]
        public int SemesterId { get; set; }
    }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public float Credit { get; set; }
        public string Description { get; set; }
        public int DeptId { get; set; }
        public int SemesterId { get; set; }
    }
>>>>>>> parent of 9ba993f... Merge branch 'master' into Forman
}
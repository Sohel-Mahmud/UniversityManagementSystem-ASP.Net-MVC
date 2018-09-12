using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        [HttpGet]
        public ActionResult RegisterStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterStudent(Student student)
        {
            return View();
        }
  
	}
}
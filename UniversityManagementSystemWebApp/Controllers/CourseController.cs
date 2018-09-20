using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class CourseController : Controller
    {
        private CourseManager courseManager;
        private DepartmentManager departmentManager;

        public CourseController()
        {
            courseManager = new CourseManager();
            departmentManager = new DepartmentManager();
        }
        //
        // GET: /Course/
        [HttpGet]
        public ActionResult SaveCourse()
        {
            ViewBag.Semester = courseManager.GetAllSemesterForDropdown();
            ViewBag.Department = departmentManager.GetAllDepartmentForDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult SaveCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Semester = courseManager.GetAllSemesterForDropdown();
                ViewBag.Department = departmentManager.GetAllDepartmentForDropdown();
                string message = courseManager.SaveCourse(course);
                ViewBag.Message = message;
                return View();

            }
            else
            {
                ViewBag.Semester = courseManager.GetAllSemesterForDropdown();
                ViewBag.Department = departmentManager.GetAllDepartmentForDropdown();
                string message = "Validation Error";
                ViewBag.Message = message;
                return View();
            }
        }
	}
}
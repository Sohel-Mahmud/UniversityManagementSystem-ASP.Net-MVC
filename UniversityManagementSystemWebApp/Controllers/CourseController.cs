using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.ViewModel;

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
        [HttpGet]
        public ActionResult CourseStatics()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            return View();
        }


        public JsonResult GetAllCourseListByDeptId(int DepartmentId)
        {
            List<CourseStaticsViewModel> courseStatics = courseManager.GetAllCourseListByDeptId(DepartmentId);
            return Json(courseStatics, JsonRequestBehavior.AllowGet);
        }
    }
}
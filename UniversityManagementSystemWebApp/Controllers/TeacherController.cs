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
    public class TeacherController : Controller
    {
        private TeacherManager teacherManager;
        private DepartmentManager departmentManager;

        public TeacherController()
        {
            teacherManager = new TeacherManager();
            departmentManager = new DepartmentManager();
        }
        //
        // GET: /Teacher/
        [HttpGet]
        public ActionResult SaveTeacher()
        {
            ViewBag.Department = departmentManager.GetAllDepartmentForDropdown();
            ViewBag.Designations = teacherManager.GetAllDesignationForDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult SaveTeacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Department = departmentManager.GetAllDepartmentForDropdown();
                ViewBag.Designations = teacherManager.GetAllDesignationForDropdown();
                string message = teacherManager.SaveTeacher(teacher);
                ViewBag.Message = message;
                return View();
            }
            else
            {
                ViewBag.Department = departmentManager.GetAllDepartmentForDropdown();
                ViewBag.Designations = teacherManager.GetAllDesignationForDropdown();
                ViewBag.Message = "Validation Error";
                return View();
            }
            
        }
	}
}
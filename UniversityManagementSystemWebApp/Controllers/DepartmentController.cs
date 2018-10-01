using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{

    public class DepartmentController : Controller
    {
        private DepartmentManager departmentManager;

        public DepartmentController()
        {
            departmentManager = new DepartmentManager();
        }
        //
        // GET: /Department/
        [HttpGet]
        public ActionResult SaveDepartments()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveDepartments(Department department)
        {
            if (ModelState.IsValid)
            {
                string message = departmentManager.Save(department);
                ViewBag.Message = message;
                return View();
            }
            else
            {
                string message = "Validation Error";
                ViewBag.Message = message;
                return View();
            }

        }

        public ActionResult DepartmentDetails()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            return View(departments);
        }
    }
}
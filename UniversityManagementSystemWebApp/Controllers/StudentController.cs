using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{

    public class StudentController : Controller
    {
        private DepartmentManager aDepartmentManager;
        private StudentManager aStudentManager;
        //
        // GET: /Student/

        public StudentController()
        {
            aDepartmentManager = new DepartmentManager();
            aStudentManager = new StudentManager();
        }
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View();
        }
        [HttpPost]
        public ActionResult Register(Student student)
        {
            student.RegistrationNo = GenerateRegNo(student);
            ViewBag.Message  = aStudentManager.Save(student);
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View();
        }

        private string GenerateRegNo(Student student)
        {
            string Year = GetYearFromDate(student.Date);
            string Department = aDepartmentManager.GetDepartmentbyId(student.DepartmentId).Code;
            string Serial = GetSerialFromRowCount(aStudentManager.GetRowCount(student.DepartmentId,Convert.ToInt32(GetYearFromDate(student.Date))));

            return Department + "-" + Year + "-" + Serial;
        }

        private string GetSerialFromRowCount(int rowCount)
        {
            rowCount++;
            string Serial = rowCount.ToString("D3");
            return Serial;
        }

        private string GetYearFromDate(string datefromdatepicker)
        {
            DateTime date = DateTime.ParseExact(datefromdatepicker, "dd/MM/yyyy", null);
            string year = date.Year.ToString();
            return year;
        }
    }
}
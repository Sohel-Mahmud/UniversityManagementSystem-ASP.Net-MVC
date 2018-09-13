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
        DepartmentManager aDepartmentManager = new DepartmentManager();
        StudentManager aStudentManager = new StudentManager();
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
            student.RegistrationNo = GenerateRegNo(student);
            string massage = aStudentManager.Save(student);
            ViewBag.Massage = massage;
            return View();
        }

        private string GenerateRegNo(Student student)
        {
            string Year = GetYearFromDate(student.Date);
            string Department = aDepartmentManager.GetDepartmentbyId(student.DepartmentId).Name;
            string Serial = GetSerialFromRowCount(aStudentManager.GetRowCount());

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
            string givenDate = datefromdatepicker;
            DateTime date = Convert.ToDateTime(givenDate);
            string year = date.Year.ToString();
            return year;
        }
    }
}
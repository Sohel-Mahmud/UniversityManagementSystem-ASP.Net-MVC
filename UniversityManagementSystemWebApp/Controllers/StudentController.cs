using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.ViewModel;
using UniversityManagementSystemWebApp.ViewModel;

namespace UniversityManagementSystemWebApp.Controllers
{

    public class StudentController : Controller
    {
        private DepartmentManager aDepartmentManager;
        private StudentManager aStudentManager;
        private CourseManager aCourseManager;
        private EnrollCourseManager aEnrollCourseManager;
        //
        // GET: /Student/

        public StudentController()
        {
            aDepartmentManager = new DepartmentManager();
            aStudentManager = new StudentManager();
            aEnrollCourseManager = new EnrollCourseManager();
            aCourseManager = new CourseManager();
        }
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
          //  ViewBag.Students = aStudentManager.GetAllStudents();
            return View();
        }
        [HttpPost]
        public ActionResult Register(Student student)
        {
            student.RegistrationNo = GenerateRegNo(student);
            ViewBag.Message  = aStudentManager.Save(student);
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();

            string deptCode = aDepartmentManager.GetDepartmentbyId(student.DepartmentId).Code;
            string deptName = aDepartmentManager.GetDepartmentbyId(student.DepartmentId).Name;
            StudentDetailsViewModel studentDetails = new StudentDetailsViewModel();
            studentDetails.StudentName = student.StudentName;
            studentDetails.StudentEmail = student.Email;
            studentDetails.StudentRegNo = student.RegistrationNo;
            studentDetails.StudntContactNo = student.ContactNo;
            studentDetails.StudentAddress = student.Address;
            studentDetails.StudentDeptCode = deptCode;
            studentDetails.StudentDeptName = deptName;
            studentDetails.StudentDate = student.Date;

            ViewBag.StudentDetails = studentDetails;

           // ViewBag.StudentDetails = aStudentManager.GetStudentbyDetailsById(student.DepartmentId, student.StudentId);
           // Session["StudentDetails"] = ViewBag.StudentDetails;


            return View();
        }
        [HttpGet]
        public ActionResult Result()
        {
            ViewBag.RegNoList = aEnrollCourseManager.GetAllStudentRegNo();
            return View();
        }

        [HttpPost]
        public ActionResult Result(Student student)
        {
            ViewBag.RegNoList = aEnrollCourseManager.GetAllStudentRegNo();
            return View();
        }

        private string GenerateRegNo(Student student)
        {
            string Year = GetYearFromDate(student.Date);
            string Department = aDepartmentManager.GetDepartmentbyId(student.DepartmentId).Code;
            string Serial = GetSerialFromRowCount(aStudentManager.GetRowCount(student.DepartmentId,Convert.ToInt32(GetYearFromDate(student.Date))));

            return Department + "-" + Year + "-" + Serial;
        }


        public JsonResult GetStudentResultById(int studentId)
        {
            List<ShowResultViewModel> resultList = aStudentManager.GetStudentResultById(studentId);
            return Json(resultList, JsonRequestBehavior.AllowGet);
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
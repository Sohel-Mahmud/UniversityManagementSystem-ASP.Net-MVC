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
    public class StudentResultController : Controller
    {
        public StudentResultManager AStudentResultManager=new StudentResultManager();
        //
        // GET: /StudentResult/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SaveResult()
        {
            ViewBag.StudentRegNo = AStudentResultManager.GetStudentRegNoForDropdown();
            ViewBag.allGradelist = AStudentResultManager.GetAllGradeForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult SaveResult(Enroll enroll)
        { 
            ViewBag.StudentRegNo = AStudentResultManager.GetStudentRegNoForDropdown();
            ViewBag.allGradelist = AStudentResultManager.GetAllGradeForDropdown();
            ViewBag.Message = AStudentResultManager.SaveStudentResult(enroll);
            return View();
        }

        public JsonResult GetCourseByStudentId(int studentId)
        {
            List<SelectListItem> courseList = AStudentResultManager.GetAllCourseByStudentId(studentId);
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllInfoByStudentId(int studentId)
        {
           
            StudenResultViewModel studentinfo = AStudentResultManager.GetAllStudentInfoByStutnetId(studentId);
            return Json(studentinfo, JsonRequestBehavior.AllowGet);
        }
	}
}
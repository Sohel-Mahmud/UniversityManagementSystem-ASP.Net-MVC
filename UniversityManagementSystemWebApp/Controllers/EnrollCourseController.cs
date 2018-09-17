using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.ViewModel;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class EnrollCourseController : Controller
    {
        private CourseManager aCourseManager;
        private EnrollCourseManager aEnrollCourseManager;
        public EnrollCourseController()
        {
            aCourseManager = new CourseManager();
            aEnrollCourseManager = new EnrollCourseManager();
        }
        //
        // GET: /Enroll/
//        public ActionResult Index()
//        {
//            return View();
//        }

        [HttpGet]
        public ActionResult Enroll()
        {
//
            ViewBag.RegNoList = aEnrollCourseManager.GetAllStudentRegNo();
            return View();
        }

//        [HttpPost]
//        public ActionResult Enroll(Enroll enroll)
//        {
//            ViewBag.RegNoList = aEnrollCourseManager.GetAllStudentRegNo();
//            return View();
//        }


        public JsonResult GetCourseByStudentId(int studentId)
        {
            List<Course> courseList = aCourseManager.GetAllCoursebyStudentId(studentId);
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllInfoByStudentId(int studentId)
        {

            StudenResultViewModel studentinfo = aEnrollCourseManager.GetAllStudentInfoByStudentId(studentId);
            return Json(studentinfo, JsonRequestBehavior.AllowGet);
        }
	}
}
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
    public class EnrollCourseController : Controller
    {

        private CourseManager aCourseManager;
        private EnrollCourseManager aEnrollCourseManager;
        private StudentManager aStudentManager;
        public EnrollCourseController()
        {
            aCourseManager = new CourseManager();
            aEnrollCourseManager = new EnrollCourseManager();
            aStudentManager = new StudentManager();
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

        [HttpPost]
        public ActionResult Enroll(Enroll enroll)
        {
            ViewBag.RegNoList = aEnrollCourseManager.GetAllStudentRegNo();
            // enroll.GradeId = 14;
            enroll.Action = "insert";
            ViewBag.Message = aEnrollCourseManager.EnrollCourse(enroll);
            return View();
        }


        public JsonResult GetCourseByStudentId(int studentId)
        {
            List<SelectListItem> courseList = aCourseManager.GetAllCourseByStudentIdForDropDownList(studentId);
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllInfoByStudentId(int studentId)
        {

            StudenResultViewModel studentinfo = aEnrollCourseManager.GetAllStudentInfoByStudentId(studentId);
            return Json(studentinfo, JsonRequestBehavior.AllowGet);
        }
    }


}
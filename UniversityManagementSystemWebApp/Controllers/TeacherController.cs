using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        [HttpGet]
        public ActionResult AssignCourse()
        {
            ViewBag.Department = departmentManager.GetAllDepartmentForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult AssignCourse(AssignCourse assignCourse)
        {

            ViewBag.Department = departmentManager.GetAllDepartmentForDropdown();
            ViewBag.Message = teacherManager.AssignCourseToTeacher(assignCourse);
            return View();
        }

        public JsonResult GetTeacherByDeptId(int DepartmentId)
        {
            List<Teacher> teacherList = teacherManager.GetAllTeacherByDeptID(DepartmentId);
            return Json(teacherList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllCourseCodeByDeptId(int DepartmentId)
        {
            List<Course> courseCodeList = teacherManager.GetAllCourseCodeByDeptId(DepartmentId);
            return Json(courseCodeList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTeacherInfoByTeacherId(int TeacherId)
        {
            Teacher teacherCreditViewModel = teacherManager.GetTeacherInfoByTeacherId(TeacherId);
            return Json(teacherCreditViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseNameCreditByCourseId(int CourseId)
        {
            Course courseNameCredit = teacherManager.GetCourseNameCreditByCourseId(CourseId);
            return Json(courseNameCredit, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCreditTakenSumOfTeacherByTeacherId(int TeacherId)
        {
            double sumOfCredit = teacherManager.GetCreditTakenSumOfTeacherByTeacherId(TeacherId);
            return Json(sumOfCredit, JsonRequestBehavior.AllowGet);
        }

    }
}
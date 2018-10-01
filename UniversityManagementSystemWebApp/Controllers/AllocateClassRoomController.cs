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
    public class AllocateClassRoomController : Controller
    {
        private AllocateClassRoomManager allocateClassRoomManager;


        public AllocateClassRoomController()
        {
            allocateClassRoomManager = new AllocateClassRoomManager();

        }
       


        [HttpGet]
        public ActionResult Save()
        {

            ViewBag.Departments = allocateClassRoomManager.GetDepartmentsForDropdown();
            ViewBag.Rooms = allocateClassRoomManager.GetRoomForDropdown();
            ViewBag.WeekDays = allocateClassRoomManager.GetWeekDaysForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Save(AllocateClassRoom allocateClassRoom)
        {
            if (allocateClassRoom.FromTime.Length == 7)
            {
                allocateClassRoom.FromTime = "0" + allocateClassRoom.FromTime;
            }
            if (allocateClassRoom.ToTime.Length == 7)
            {
                allocateClassRoom.ToTime = "0" + allocateClassRoom.ToTime;
            }
            if (ModelState.IsValid)
            {
                ViewBag.Departments = allocateClassRoomManager.GetDepartmentsForDropdown();
                ViewBag.Rooms = allocateClassRoomManager.GetRoomForDropdown();
                ViewBag.WeekDays = allocateClassRoomManager.GetWeekDaysForDropdown();
                ViewBag.Message = allocateClassRoomManager.saveAllocateClass(allocateClassRoom);
                return View();
            }
            else
            {
                ViewBag.Departments = allocateClassRoomManager.GetDepartmentsForDropdown();
                ViewBag.Rooms = allocateClassRoomManager.GetRoomForDropdown();
                ViewBag.WeekDays = allocateClassRoomManager.GetWeekDaysForDropdown();
                string message = "Validation Error";
                ViewBag.Message = message;
                return View();
            }
           
        }

        public JsonResult GetCourseByDepartmentId(int DeptId)
        {
            List<SelectListItem> courseList = allocateClassRoomManager.GetCourseByDeparmentId(DeptId);
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ViewClassShedule()
        {
            ViewBag.Departments = allocateClassRoomManager.GetDepartmentsForDropdown();
            return View();
        }

        //[HttpPost]
        //public ActionResult ViewClassShedule(Department aDeptment)
        //{
        //    ViewBag.Departments = allocateClassRoomManager.GetDepartmentsForDropdown();
        //    ViewBag.ShowDetails = allocateClassRoomManager.showClassDetails(aDeptment);
        //    return View();
        //}

        public JsonResult GetViewClassSheduleByDeptId(int DeptId)
        {
            List<ViewClassSheduleViewModel> viewClassShedulelist = allocateClassRoomManager.showClassDetails(DeptId);
            return Json(viewClassShedulelist, JsonRequestBehavior.AllowGet);
        }
    }
}
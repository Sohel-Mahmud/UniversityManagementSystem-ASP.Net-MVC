using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class UnassignAllCoursesController : Controller
    {
        public UnAssignAllCourseManager AunAllCourseManager=new UnAssignAllCourseManager();
        //
        // GET: /UnassignAllCourses/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UnAssignCourse(bool? confirm)
        {
            if (confirm==true)
            {
                AunAllCourseManager.UnAssignEnroll();
                AunAllCourseManager.UnAssignCourseAssignToTeacher();
            }
            
            return View();
        }
	}
}
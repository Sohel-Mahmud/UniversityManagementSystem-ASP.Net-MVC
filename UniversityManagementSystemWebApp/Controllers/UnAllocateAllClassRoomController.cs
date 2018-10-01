using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class UnAllocateAllClassRoomController : Controller
    {
        public UnAllocateClassRoomManager AunAllocateClassRoomManager = new UnAllocateClassRoomManager();
       

        public ActionResult UnAllocatClass(bool? confirm)
        {
            if (confirm == true)
            {
                AunAllocateClassRoomManager.UnAllocateAllClass();
            }

            return View();
        }
    }
}
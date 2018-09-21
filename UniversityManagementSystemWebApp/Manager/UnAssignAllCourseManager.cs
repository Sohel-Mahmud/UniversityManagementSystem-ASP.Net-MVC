using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;

namespace UniversityManagementSystemWebApp.Manager
{
    public class UnAssignAllCourseManager
    {
        public UnAssignAllCourseGateWay AUnAssignAllCourseGateWay;

        public UnAssignAllCourseManager()
        {
            AUnAssignAllCourseGateWay=new UnAssignAllCourseGateWay();
        }

        public string UnAssignEnroll()
        {
            int row = AUnAssignAllCourseGateWay.UnAssignEnrollCourse();
            
                return "UnAssign Successfully";
           
        }

        public string UnAssignCourseAssignToTeacher()
        {
            int row = AUnAssignAllCourseGateWay.UnAssignCourseAssignToTeacher();

            return "UnAssign Successfully";

        }
       
    }
}
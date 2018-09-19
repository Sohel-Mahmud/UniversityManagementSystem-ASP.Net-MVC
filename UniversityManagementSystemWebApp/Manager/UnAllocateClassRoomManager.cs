using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;

namespace UniversityManagementSystemWebApp.Manager
{
    public class UnAllocateClassRoomManager
    {
        public UnAllocateClassRoomGateWay AUnAllocateClassRoomGateWay;

        public UnAllocateClassRoomManager()
        {
            AUnAllocateClassRoomGateWay=new UnAllocateClassRoomGateWay();
        }
        public string UnAllocateAllClass()
        {
            int row = AUnAllocateClassRoomGateWay.UnAllocateAllClass();

            return "UnAllocateClassRoom Successfully";

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class AllocateClassRoom
    {
        public int ClassId { get; set; }
        public int DeptId { get; set; }
        public int CourseId {get;set;}  
        public int  RoomId {get;set;}      
        public int  DayId {get;set;}      
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string Action { get; set; }
    }
}
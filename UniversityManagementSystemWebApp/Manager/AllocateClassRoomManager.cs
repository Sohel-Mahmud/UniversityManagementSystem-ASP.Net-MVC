using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.ViewModel;


namespace UniversityManagementSystemWebApp.Manager
{
    public class AllocateClassRoomManager
    {

        private AllocateClassRoomGateway allocateClassRoomGateway = new AllocateClassRoomGateway();
        public List<SelectListItem> GetDepartmentsForDropdown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });

            List<Department> GetAllDepartment = allocateClassRoomGateway.GetAllDepartments();


            foreach (Department department in GetAllDepartment)
            {
                SelectListItem selectList = new SelectListItem();
                selectList.Text = department.Code;
                selectList.Value = department.DeptId.ToString();
                selectListItems.Add(selectList);
            }
            return selectListItems;
        }



        public List<SelectListItem> GetCourseByDeparmentId(int DeptId)
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });

            List<Course> GetAllCourse = allocateClassRoomGateway.GetCoursByDeparmentId(DeptId);

            foreach (Course acourse in GetAllCourse)
            {
                SelectListItem selectList = new SelectListItem();
                selectList.Text = acourse.CourseCode;
                selectList.Value = acourse.CourseId.ToString();
                selectListItems.Add(selectList);
            }
            return selectListItems;
        }

        public List<SelectListItem> GetRoomForDropdown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });

            List<Room> GetAllRoom = allocateClassRoomGateway.GetAllRooms();


            foreach (Room aroom in GetAllRoom)
            {
                SelectListItem selectList = new SelectListItem();
                selectList.Text = aroom.RoomName;
                selectList.Value = aroom.RoomID.ToString();
                selectListItems.Add(selectList);
            }
            return selectListItems;
        }


        public List<SelectListItem> GetWeekDaysForDropdown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });

            List<WeekDay> GetAllWeekDays = allocateClassRoomGateway.GetAllWeekDays();


            foreach (WeekDay aDay in GetAllWeekDays)
            {
                SelectListItem selectList = new SelectListItem();
                selectList.Text = aDay.DayName;
                selectList.Value = aDay.DayId.ToString();
                selectListItems.Add(selectList);
            }
            return selectListItems;
        }

        public string saveAllocateClass(AllocateClassRoom aAllocateClassRoom)
        {
            bool checkValid = CheckValidationAmPm(aAllocateClassRoom.FromTime, aAllocateClassRoom.ToTime);
            if (checkValid == false)
            {
                return "Input time range is not valid";
            }
            bool isExited = allocateClassRoomGateway.saveAllocateClass(aAllocateClassRoom);
            if (isExited == false)
            {
                return "Overlapping Time Shedule.Please input Valid time";
            }
            else
            {
                int row = allocateClassRoomGateway.SaveRoomForShedule(aAllocateClassRoom);
                if (row > 0)
                {
                    return "Save successfully";
                }
                else
                {
                    return "Insert Failed";  
                }
            }
        }

        public bool CheckValidationAmPm(string fromTime, string toTime)
        {
           
            string fromTimeHour = fromTime.Substring(0, 2);
            string fromTimeMinute = fromTime.Substring(3, 2);
            string fromTimeAmPm = fromTime.Substring(6, 2);
            DateTime aFromDateTime = Convert.ToDateTime(2018 + "/" + 11 + "/" + 13 + " " + fromTimeHour + ":" + fromTimeMinute + ":00 " + fromTimeAmPm);

            string toTimeHour = toTime.Substring(0, 2);
            string toTimeMinute = toTime.Substring(3, 2);
            string toTimeAmPm = toTime.Substring(6, 2);
            DateTime aToDateTime = Convert.ToDateTime(2018 + "/" + 11 + "/" + 13 + " " + toTimeHour + ":" + toTimeMinute + ":00 " + toTimeAmPm);

            if (((fromTimeAmPm == "AM" && toTimeAmPm == "AM") || (fromTimeAmPm == "PM" && toTimeAmPm == "PM")) &&(aToDateTime<aFromDateTime))
            {
                return false;
            }
            else if (fromTimeAmPm == "PM" && toTimeAmPm == "AM")
            {
                return false;
            }

            else
            {
                return true;

            }
        }

        public List<ViewClassSheduleViewModel> showClassDetails(int DeptId)
        {
            return allocateClassRoomGateway.showClassDetails(DeptId);
        }
        //public List<ViewClassSheduleViewModel> showClassDetails(Department aDeptment)
        //{
        //    return allocateClassRoomGateway.showClassDetails(aDeptment);
        //}


    }
}
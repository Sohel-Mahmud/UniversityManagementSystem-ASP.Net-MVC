using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.ViewModel;


namespace UniversityManagementSystemWebApp.Gateway
{
    public class AllocateClassRoomGateway : BaseGateway
    {
        public List<Department> GetAllDepartments()
        {
            string query = "SELECT * FROM Departments";
            Command = new SqlCommand(query, Connection); 
            Connection.Open();
            List<Department> departmentList = new List<Department>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Department aDepartment = new Department();
                aDepartment.DeptId = Convert.ToInt32(Reader["DeptId"]);
                aDepartment.Code = Reader["Code"].ToString();
                departmentList.Add(aDepartment);
            }
            Reader.Close();
            Connection.Close();
            return departmentList;
        }

        public List<Course> GetCoursByDeparmentId(int DeptId)
        {
            string query = "SELECT CourseId,CourseCode FROM Course WHERE DeptId=@DeptId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@DeptId", DeptId);
            Connection.Open();
            List<Course> courseList = new List<Course>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Course acourse = new Course();
                acourse.CourseId = Convert.ToInt32(Reader["CourseId"]);
                acourse.CourseCode = Reader["CourseCode"].ToString();
                courseList.Add(acourse);
            }
            Reader.Close();
            Connection.Close();
            return courseList;
        }


        public List<Room> GetAllRooms()
        {
            string query = "SELECT * FROM Rooms";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            List<Room> roomList = new List<Room>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Room aRoom = new Room();
                aRoom.RoomID = Convert.ToInt32(Reader["RoomID"]);
                aRoom.RoomName = Reader["RoomName"].ToString();
                roomList.Add(aRoom);
            }
            Reader.Close();
            Connection.Close();
            return roomList;
        }

        public List<WeekDay> GetAllWeekDays()
        {
            string query = "SELECT * FROM WeekDays";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            List<WeekDay> weekDayList = new List<WeekDay>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                WeekDay aweekDay = new WeekDay();
                aweekDay.DayId = Convert.ToInt32(Reader["DayId"]);
                aweekDay.DayName = Reader["DayName"].ToString();
                weekDayList.Add(aweekDay);
            }
            Reader.Close();
            Connection.Close();
            return weekDayList;
        }

        public bool saveAllocateClass(AllocateClassRoom aAllocateClassRoom)
        {
            string query = "SELECT FromTime,ToTime FROM AllocateClassroom WHERE  RoomId = @RoomId AND DayId=@DayId AND Action=@Action";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@RoomId", aAllocateClassRoom.RoomId);
            Command.Parameters.AddWithValue("@DayId", aAllocateClassRoom.DayId);
            Command.Parameters.AddWithValue("@Action","insert");
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<AllocateClassRoom> allTimeList = new List<AllocateClassRoom>();

            //Read all FromTime and ToTime from database
            while (Reader.Read())
            {
                AllocateClassRoom atime = new AllocateClassRoom();
                atime.FromTime = Reader["FromTime"].ToString();
                atime.ToTime = Reader["ToTime"].ToString();
                allTimeList.Add(atime);          
            }
            //check overlapping
            if (Reader.HasRows)
            {
                bool isExisted = TimeOverlappingCheck(allTimeList, aAllocateClassRoom);
                if (isExisted == true)
                {
                    Reader.Close();
                    Connection.Close();
                    return false;
                }
                else
                {
                   
                    Reader.Close();
                    Connection.Close();
                    return true;

                }
            }
            //If any data not found in database then simply save new data
            else
            {
                Connection.Close();
                Reader.Close();            
                return true;       
            }
            
        }

        //overlapping function to check
        public bool TimeOverlappingCheck(List<AllocateClassRoom> allTimeList,AllocateClassRoom allocatClassRoom)
        {
            DateTime BstarTime = convertDatetime(allocatClassRoom.FromTime);
            DateTime BendTime = convertDatetime(allocatClassRoom.ToTime);

            bool flag = false;
            foreach (AllocateClassRoom atime in allTimeList)
            {
                DateTime AstartTime = convertDatetime(atime.FromTime);
                DateTime AendTime = convertDatetime(atime.ToTime);
                
                if ((BstarTime >= AstartTime && BstarTime < AendTime) || (BendTime > AstartTime && BendTime <= AendTime) ||(BstarTime<AstartTime && BendTime>AendTime))
                {
                    
                    flag = true;
                    break;
                }

            }
            return flag;
        }

        //convert string to datetime formante
        public DateTime convertDatetime(string Time)
        {                  
            string hour = Time.Substring(0, 2);
            string minute = Time.Substring(3, 2);
            string amPm = Time.Substring(6, 2);
            DateTime adateTime = Convert.ToDateTime(2018 + "/" + 11 + "/" + 13 + " " + hour + ":" + minute + ":00 " + amPm);
            return adateTime;
        }
        public int SaveRoomForShedule(AllocateClassRoom aAllocateClassRoom)
        {
            string query = "INSERT INTO AllocateClassroom VALUES(@DeptId, @CourseId,@RoomId, @DayId,@FromTime,@ToTime, @Action)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@DeptId", aAllocateClassRoom.DeptId);
            Command.Parameters.AddWithValue("@CourseId", aAllocateClassRoom.CourseId);
            Command.Parameters.AddWithValue("@RoomId", aAllocateClassRoom.RoomId);
            Command.Parameters.AddWithValue("@DayId", aAllocateClassRoom.DayId);
            Command.Parameters.AddWithValue("@FromTime", aAllocateClassRoom.FromTime);
            Command.Parameters.AddWithValue("@ToTime", aAllocateClassRoom.ToTime);
            Command.Parameters.AddWithValue("@Action", "insert");



            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();          
            return rowAffected;
        }

         //public List<ViewClassSheduleViewModel> showClassDetails(Department aDepartment)
        public List<ViewClassSheduleViewModel> showClassDetails(int DeptId)
        {
            string query = "SELECT CourseId,CourseCode,CourseName FROM Course WHERE DeptId=@DeptId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@DeptId", DeptId);
            Connection.Open();
            List<ViewClassSheduleViewModel> viewClassShedule = new List<ViewClassSheduleViewModel>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ViewClassSheduleViewModel aviewClassShedule = new ViewClassSheduleViewModel();
                aviewClassShedule.CourseId = Convert.ToInt32(Reader["CourseId"]);
                aviewClassShedule.CourseCode = Reader["CourseCode"].ToString();
                aviewClassShedule.CourseName = Reader["CourseName"].ToString();
                viewClassShedule.Add(aviewClassShedule);
            }
            Reader.Close();
            Connection.Close();
 
            return CourseGroupByClassAndRoom(viewClassShedule);
        }

        // Grouping in a model list
        public List<ViewClassSheduleViewModel> CourseGroupByClassAndRoom(List<ViewClassSheduleViewModel> aviewClassShedulelist)
        {
            foreach (ViewClassSheduleViewModel aViewClassShedule in aviewClassShedulelist)
            {
                string query = "SELECT Rooms.RoomName AS RoomName,WeekDays.DayName AS DayName,AllocateClassroom.FromTime AS FromTime,AllocateClassroom.ToTime " +
                               "AS ToTime FROM AllocateClassroom INNER JOIN Rooms ON  Rooms.RoomID=AllocateClassroom.RoomId " +
                               "INNER JOIN WeekDays ON WeekDays.DayId=AllocateClassroom.DayId WHERE CourseId=@CourseId AND AllocateClassroom.Action=@Action";
                Command = new SqlCommand(query, Connection);
                Command.Parameters.AddWithValue("@CourseId", aViewClassShedule.CourseId);
                Command.Parameters.AddWithValue("@Action", "insert");
                Connection.Open();               
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    //while (Reader.Read())
                    //{
                    //    string Shedule = "R.NO: " + Reader["RoomName"].ToString() + "," + Reader["DayName"].ToString() +
                    //                     "," + Reader["FromTime"].ToString() + "-" + Reader["ToTime"].ToString() + ";";
                    //    aViewClassShedule.Scheduleinfo.Add(Shedule);
                    //}



                    while (Reader.Read())
                    {
                        string dayName = Reader["DayName"].ToString().Substring(0, 3);
                        string Shedule = "R.NO: " + Reader["RoomName"].ToString() + ",  " + dayName +
                                         ",  " + Reader["FromTime"].ToString() + "-" + Reader["ToTime"].ToString() + ";";
                        aViewClassShedule.Scheduleinfo.Add(Shedule);
                    }
                }
                else
                {
                    string Shedule = "Not Assign Yet";
                    aViewClassShedule.Scheduleinfo.Add(Shedule);
                }

                Reader.Close();
                Connection.Close();
                
            }
            return aviewClassShedulelist;

        }

    }
}
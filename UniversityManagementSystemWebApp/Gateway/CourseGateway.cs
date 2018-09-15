using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class CourseGateway:BaseGateway
    {
        public int SaveCourse(Course course)
        {
            string query = "INSERT INTO Course VALUES(@courseName,@courseCode,@credit,@description,@deptId,@semesterId)";
            Command = new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@courseName", course.CourseName);
            Command.Parameters.AddWithValue("@courseCode", course.CourseCode);
            Command.Parameters.AddWithValue("@credit", course.Credit);
            Command.Parameters.AddWithValue("@description", course.Description);
            Command.Parameters.AddWithValue("@deptId", course.DeptId);
            Command.Parameters.AddWithValue("@semesterId", course.SemesterId);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Semester> GetAllSemesters()
        {
            string query = "SELECT * FROM Semester";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            List<Semester> semesterList = new List<Semester>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Semester semester = new Semester();
                semester.SemesterId = Convert.ToInt32(Reader["SemesterId"]);
                semester.SemesterName = Reader["SemesterName"].ToString();
                semesterList.Add(semester);
            }
            Reader.Close();
            Connection.Close();
            return semesterList;
        }
    }
}
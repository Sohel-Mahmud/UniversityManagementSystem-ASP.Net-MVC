using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.ViewModel;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class CourseGateway : BaseGateway
    {
        public int SaveCourse(Course course)
        {
            string query = "INSERT INTO Course VALUES(@courseName,@courseCode,@credit,@description,@deptId,@semesterId)";
            Command = new SqlCommand(query, Connection);
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
        public string isExisted(Course course)
        {
            string query = "SELECT * FROM Course WHERE CourseName = @courseName OR CourseCode = @courseCode";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@courseName", course.CourseName);
            Command.Parameters.AddWithValue("@courseCode", course.CourseCode);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Reader.Read();
                Course aCourse = new Course();
                aCourse.CourseName = "";
                aCourse.CourseCode = "";
                aCourse.CourseName = Reader["CourseName"].ToString();
                aCourse.CourseCode = Reader["CourseCode"].ToString();
                Reader.Close();
                Connection.Close();
                return aCourse.CourseName + " " + aCourse.CourseCode + " is existed, please enter another";
            }
            Reader.Close();
            Connection.Close();
            return "success";
        }
        public List<Semester> GetAllSemesters()
        {
            string query = "SELECT * FROM Semester";
            Command = new SqlCommand(query, Connection);
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
        public List<CourseStaticsViewModel> GetAllCourseListByDeptId(int departmentId)
        {
            string query =
                "SELECT Course.CourseCode AS CourseCode, Course.CourseName AS CourseName, Semester.SemesterName AS Semester, Teacher.Name AS AssignedTeacherName From Course LEFT JOIN Departments ON  Course.DeptId = Departments.DeptId LEFT JOIN Semester on Semester.SemesterId = Course.SemesterId LEFT JOIN CourseAssignToTeacher on Course.CourseId = CourseAssignToTeacher.CourseId LEFT JOIN Teacher on Teacher.TeacherId = CourseAssignToTeacher.TeacherId AND CourseAssignToTeacher.Action=@insert WHERE Departments.DeptId = @departmentId ";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@insert", "insert");
            Command.Parameters.AddWithValue("@departmentId", departmentId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<CourseStaticsViewModel> courseStaticList = new List<CourseStaticsViewModel>();
            while (Reader.Read())
            {
                CourseStaticsViewModel aCourseStatics = new CourseStaticsViewModel();
                aCourseStatics.CourseCode = Reader["CourseCode"].ToString();
                aCourseStatics.CourseName = Reader["CourseName"].ToString();
                aCourseStatics.Semester = Reader["Semester"].ToString();
                string assignto = Reader["AssignedTeacherName"].ToString();
                if (string.IsNullOrEmpty(assignto))
                {
                    aCourseStatics.AssignedTeacherName = "Not Assigned yet";
                }
                else
                {
                    aCourseStatics.AssignedTeacherName = Reader["AssignedTeacherName"].ToString();

                }
                courseStaticList.Add(aCourseStatics);
            }
            Reader.Close();
            Connection.Close();
            return courseStaticList;
        }
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
                aDepartment.Name = Reader["Name"].ToString();
                departmentList.Add(aDepartment);
            }
            Reader.Close();
            Connection.Close();
            return departmentList;
        }

        public List<Course> GetAllCourseByStudentId(int studentId)
        {
            string query = "SELECT Course.CourseId,Course.CourseCode FROM Course INNER JOIN Student ON Course.DeptId=Student.DepartmentId AND Student.StudentId=@StudentId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@StudentId", studentId);
            Connection.Open();
            List<Course> allCourseList = new List<Course>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Course aCourse = new Course();
                aCourse.CourseId = Convert.ToInt32(Reader["CourseId"]);
                aCourse.CourseCode = Reader["CourseCode"].ToString();
                allCourseList.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return allCourseList;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.ViewModel;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class EnrollCourseGateway : BaseGateway
    {

        public int EnrollCourse(Enroll enroll)
        {
            string query = "INSERT INTO Enroll(StudentId,CourseId,Date,Action) VALUES(@StudentId , @CourseId, @Date, @Action)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@StudentId", enroll.StudentId);
            Command.Parameters.AddWithValue("@CourseId", enroll.CourseId);
            Command.Parameters.AddWithValue("@Date", DateTime.ParseExact(enroll.Date, "dd/MM/yyyy", null));
            Command.Parameters.AddWithValue("@Action", enroll.Action);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsEnrollExixts(Enroll enroll)
        {
            string query = "SELECT * FROM Enroll WHERE StudentId = @StudentId AND CourseId = @CourseId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@StudentId",enroll.StudentId);
            Command.Parameters.AddWithValue("@CourseId", enroll.CourseId);
            if (Connection.State != ConnectionState.Open)
                Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Reader.Close();
                Connection.Close();
                return true;
            }
            Reader.Close();
            Connection.Close();
            return false;
        }
        public List<Student> GetAllStudentRegNo()
        {
            string query = "SELECT StudentId,RegistrationNo FROM Student";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            List<Student> studentList = new List<Student>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Student aStudent = new Student();
                aStudent.StudentId = Convert.ToInt32(Reader["StudentId"]);
                aStudent.RegistrationNo = Reader["RegistrationNo"].ToString();
                studentList.Add(aStudent);
            }
            Reader.Close();
            Connection.Close();
            return studentList;
        }


        public StudenResultViewModel GetAllStudentInfoByStudentId(int studentId)
        {
            string query = "SELECT StudentName,Email,Code FROM Student INNER JOIN Departments ON Student.DepartmentId=Departments.DeptId AND StudentId=@StudentId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@StudentId", studentId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            StudenResultViewModel aStudentInfo = new StudenResultViewModel();
            if (Reader.HasRows)
            {


                aStudentInfo.StudentName = Reader["StudentName"].ToString();
                aStudentInfo.Email = Reader["Email"].ToString();
                aStudentInfo.DeptCode = Reader["Code"].ToString();

            }
            Reader.Close();
            Connection.Close();
            return aStudentInfo;
        }

    }
}
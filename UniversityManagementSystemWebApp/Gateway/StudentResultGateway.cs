using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.ViewModel;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class StudentResultGateway : BaseGateway
    {
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

        public List<Grade> GetAllGradeList()
        {
            string query = "SELECT GradeId,GradeName FROM Grade";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            List<Grade> allGradeList = new List<Grade>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Grade aGrade = new Grade();
                aGrade.GradeId = Convert.ToInt32(Reader["GradeId"]);
                aGrade.GradeName = Reader["GradeName"].ToString();
                allGradeList.Add(aGrade);
            }
            Reader.Close();
            Connection.Close();
            return allGradeList;
        }
          
        public List<Course> GetAllCourseByStudentId(int studentId)
        {
            string query = "SELECT Course.CourseId,Course.CourseCode FROM Course INNER JOIN Enroll ON Course.CourseId=Enroll.CourseId AND Enroll.StudentId=@StudentId";
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

        public StudenResultViewModel GetAllStudentInfoByStudentId(int studentId)
        {
            string query = "select StudentName,Email,Code FROM Student INNER JOIN Departments ON Student.DepartmentId=Departments.DeptId AND StudentId=@StudentId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@StudentId", studentId);
            Connection.Open();        
            Reader = Command.ExecuteReader();
            Reader.Read();
            StudenResultViewModel aStudenResult = new StudenResultViewModel();
            if (Reader.HasRows)
            {
                
                
                aStudenResult.StudentName = Reader["StudentName"].ToString();
                aStudenResult.Email = Reader["Email"].ToString();
                aStudenResult.DeptCode = Reader["Code"].ToString();
                
            }
            Reader.Close();
            Connection.Close();
            return aStudenResult;
        }

        public int SaveStudentResult(Enroll aenroll)
        {
            string query = "UPDATE Enroll SET GradeId = @GradeId WHERE StudentId=@StudentId AND CourseId=@CourseId AND Action=@action";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@StudentId", aenroll.StudentId);
            Command.Parameters.AddWithValue("@CourseId", aenroll.CourseId);
            Command.Parameters.AddWithValue("@GradeId", aenroll.GradeId);
            Command.Parameters.AddWithValue("@action","insert");

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

    }
}
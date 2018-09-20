using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.ViewModel;
using UniversityManagementSystemWebApp.ViewModel;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class StudentGateway : BaseGateway
    {
        //        private string TableName = "Student";
        public int Save(Student student)
        {
            string query = "INSERT INTO Student VALUES(@name, @contact, @email, @date, @address, @deptid, @regno)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@name", student.StudentName);
            Command.Parameters.AddWithValue("@contact", student.ContactNo);
            Command.Parameters.AddWithValue("@email", student.Email);
            Command.Parameters.AddWithValue("@date", DateTime.ParseExact(student.Date, "dd/MM/yyyy", null));
            Command.Parameters.AddWithValue("@address", student.Address);
            Command.Parameters.AddWithValue("@deptid", student.DepartmentId);
            Command.Parameters.AddWithValue("@regno", student.RegistrationNo);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsExists(Student student)
        {
            string query = "SELECT * FROM Student WHERE Email = @email";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@email", student.Email);
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

        public int GetRowCount(int id,int year)
        {
            int rowCount = 0;
            string query = "SELECT COUNT(*) FROM Student WHERE DepartmentId = @id AND YEAR(Date) = @year";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@id", id);
            Command.Parameters.AddWithValue("@year", year);
            Connection.Open();

            rowCount = (int)Command.ExecuteScalar();
            Connection.Close();
            return rowCount;

        }

        public StudentDetailsViewModel GetStudentbyDetailsById(int Deptid,int StudentId)
        {
            string query = "SELECT StudentName,RegistrationNo,ContactNo,Email,Date,Address,Code,Name FROM Student INNER JOIN Departments ON Student.DepartmentId = @deptId WHERE StudentId = @studentId";
            //"SELECT StudentName,Email,Code FROM Student INNER JOIN Departments ON Student.DepartmentId=Departments.DeptId AND StudentId=@StudentId"
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@deptid",Deptid);
            Command.Parameters.AddWithValue("@studentId", StudentId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            StudentDetailsViewModel aStudent = new StudentDetailsViewModel();
            if (Reader.HasRows)
            {
                aStudent.StudentName = Reader["StudentName"].ToString();
                aStudent.StudentRegNo = Reader["RegistrationNo"].ToString();
                aStudent.StudentEmail = Reader["Email"].ToString();
                aStudent.StudentDate = Reader["Date"].ToString();
                aStudent.StudentAddress = Reader["Address"].ToString();
                aStudent.StudentDeptCode =Reader["Code"].ToString();
                aStudent.StudentDeptName = Reader["Name"].ToString();

            }

            Reader.Close();
            Connection.Close();
            return aStudent;

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
            string query = "SELECT StudentName,Email,Code FROM Student I" +
                           "NNER JOIN Departments ON " +
                           "Student.DepartmentId=Departments.DeptId " +
                           "AND StudentId=@StudentId";
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



        public List<Student> GetAllStudents()
        {
            string query = "SELECT * FROM Student";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            List<Student> StudentList = new List<Student>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Student aStudent = new Student();
                aStudent.StudentName = Reader["StudentName"].ToString();
                aStudent.ContactNo = Reader["ContactNo"].ToString();
                aStudent.Email = Reader["Email"].ToString();
                aStudent.Date = Reader["Date"].ToString();
                aStudent.Address = Reader["Address"].ToString();
                aStudent.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                aStudent.RegistrationNo = Reader["RegistrationNo"].ToString();
                StudentList.Add(aStudent);
            }
            Reader.Close();
            Connection.Close();
            return StudentList;
        }


        public List<ShowResultViewModel> GetStudentResultById(int studentId)
        {
            string query =
                "SELECT Course.CourseCode AS CourseCode,Course.CourseName AS CourseName,Grade.GradeName AS Grade FROM Course " +
                "INNER JOIN Enroll ON Course.CourseId = Enroll.CourseId " +
                "LEFT JOIN Grade ON Grade.GradeId = Enroll.GradeId " +
                "WHERE  Enroll.StudentId = @studentId";

            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@studentId", studentId);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<ShowResultViewModel> Results = new List<ShowResultViewModel>();
            while (Reader.Read())
            {
                ShowResultViewModel result = new ShowResultViewModel();
                result.CourseCode = Reader["CourseCode"].ToString();
                result.CourseName = Reader["CourseName"].ToString();
                string grade = Reader["Grade"].ToString();

                if (string.IsNullOrEmpty(grade))
                {
                    result.Grade = "Not Graded Yet!";
                }

                else
                {
                    result.Grade = Reader["Grade"].ToString();
                }
               // result.Grade = string.IsNullOrEmpty(grade) ? Reader["Grade"].ToString() : "Not Graded Yet!";
                Results.Add(result);
            }
            return Results;
        }


    }
}
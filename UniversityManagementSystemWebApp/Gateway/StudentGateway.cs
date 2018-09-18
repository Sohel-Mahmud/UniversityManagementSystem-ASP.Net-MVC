using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.ViewModel;

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


    }
}
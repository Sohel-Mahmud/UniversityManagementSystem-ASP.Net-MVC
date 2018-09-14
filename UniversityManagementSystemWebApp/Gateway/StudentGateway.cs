using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using UniversityManagementSystemWebApp.Models;

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
            Command.Parameters.AddWithValue("@date", student.Date);
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

        public int GetRowCount(int id)
        {
            int rowCount = 0;
            string query = "SELECT COUNT(*) FROM Studen WHERE DepartmentId = @id";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@id", id);
            Connection.Open();

            rowCount = (int)Command.ExecuteScalar();

            return rowCount;

        }

        public Student GetStudentbyId(int id)
        {
            string query = "SELECT * FROM Student WHERE StudentId = @id";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@id", id);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Student aStudent = new Student();
            if (Reader.HasRows)
            {
                aStudent.StudentName = Reader["StudentName"].ToString();
                aStudent.ContactNo = Reader["ContactNo"].ToString();
                aStudent.Email = Reader["Email"].ToString();
                aStudent.Date = Reader["Date"].ToString();
                aStudent.Address = Reader["Address"].ToString();
                aStudent.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                aStudent.RegistrationNo = Reader["RegistrationNo"].ToString();

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
            List<Student> departmentList = new List<Student>();
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
            }
            Reader.Close();
            Connection.Close();
            return departmentList;
        }


    }
}
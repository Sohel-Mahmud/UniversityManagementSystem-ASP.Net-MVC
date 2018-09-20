using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class TeacherGateway:BaseGateway
    {
        public int SaveTeacher(Teacher teacher)
        {
            string query = "INSERT INTO Teacher VALUES(@name,@address,@email,@contactNo,@designationId,@departmentId,@credit)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@name", teacher.Name);
            Command.Parameters.AddWithValue("@address", teacher.Address);
            Command.Parameters.AddWithValue("@email", teacher.Email);
            Command.Parameters.AddWithValue("@contactNo", teacher.ContactNo);
            Command.Parameters.AddWithValue("@designationId", teacher.DesignationId);
            Command.Parameters.AddWithValue("@departmentId", teacher.DepartmentId);
            Command.Parameters.AddWithValue("@credit", teacher.Credit);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Designations> GetAllDesignation()
        {
            string query = "SELECT * FROM Designations";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Designations> designationList = new List<Designations>();
            while (Reader.Read())
            {
                Designations aDesignations = new Designations();
                aDesignations.DesignationsId = Convert.ToInt32(Reader["DesignationsId"]);
                aDesignations.DesignationName = Reader["DesignationsName"].ToString();
                designationList.Add(aDesignations);
            }
            Reader.Close();
            Connection.Close();
            return designationList;
        }
        public int AssignCourseToTeacher(AssignCourse assignCourse)
        {
            string query = "INSERT INTO CourseAssignToTeacher VALUES(@teacherId,@courseId,@action,@departmentId)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@teacherId", assignCourse.TeacherId);
            Command.Parameters.AddWithValue("@courseId", assignCourse.CourseId);
            Command.Parameters.AddWithValue("@action", "insert");
            Command.Parameters.AddWithValue("@departmentId", assignCourse.DepartmentId);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Teacher> GetAllTeacherByDeptID(int DepartmentId)
        {
            string query = "SELECT TeacherId, Name FROM Teacher WHERE DepartmentId = @departmentId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@departmentId", DepartmentId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();

            while (Reader.Read())
            {
                Teacher aTeacher = new Teacher();
                aTeacher.TeacherId = Convert.ToInt32(Reader["TeacherId"]);
                aTeacher.Name = Reader["Name"].ToString();
                teachers.Add(aTeacher);
            }
            Reader.Close();
            Connection.Close();
            return teachers;
        }
        public Teacher GetTeacherInfoByTeacherId(int TeacherId)
        {
            //string query = "SELECT Teacher.Credit AS CreditLimit, CourseAssignToTeacher.CreditTaken AS CreditTaken FROM Teacher INNER JOIN CourseAssignToTeacher ON Teacher.TeacherId= CourseAssignToTeacher.TeacherId WHERE Teacher.TeacherId = @teacherId";
            string query = "SELECT Credit FROM Teacher WHERE TeacherId = @teacherId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@teacherId", TeacherId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Teacher aTeacher = null;
            if (Reader.HasRows)
            {
                Reader.Read();
                aTeacher = new Teacher();
                aTeacher.Credit = Convert.ToDouble(Reader["Credit"]);

            }
            Reader.Close();
            Connection.Close();
            return aTeacher;
        }

        public List<Course> GetAllCourseCodeByDeptId(int departmentId)
        {
            string query = "SELECT CourseId, CourseCode FROM Course WHERE DeptId = @departmentId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@departmentId", departmentId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courseCodeList = new List<Course>();
            while (Reader.Read())
            {
                Course aCourse = new Course();
                aCourse.CourseId = Convert.ToInt32(Reader["CourseId"]);
                aCourse.CourseCode = Reader["CourseCode"].ToString();
               courseCodeList.Add(aCourse);
                
            }
            Reader.Close();
            Connection.Close();
            return courseCodeList;
        }
        public Course GetCourseNameCreditByCourseId(int courseId)
        {
            string query = "SELECT CourseName, Credit FROM Course WHERE CourseId = @courseId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@courseId", courseId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Course aCourse = null;
            if(Reader.HasRows)
            {
                Reader.Read();
                aCourse = new Course();
                aCourse.CourseName = Reader["CourseName"].ToString();
                aCourse.Credit = Convert.ToDouble(Reader["Credit"]);

            }
            Reader.Close();
            Connection.Close();
            return aCourse;
        }

        public double GetCreditTakenSumOfTeacherByTeacherId(int teacherId)
        {
            //string query =
            //    "SELECT SUM(Credit) FROM Course INNER JOIN CourseAssignToTeacher ON Course.CourseId = CourseAssignToTeacher.CourseId WHERE CourseAssignToTeacher.TeacherId=@teacherId";

            string query = "SELECT CourseId FROM CourseAssignToTeacher WHERE TeacherId = @teacherId";
            Command = new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@teacherId", teacherId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Reader.Close();
                string query2 =
                    "SELECT SUM(Credit) FROM Course INNER JOIN CourseAssignToTeacher ON Course.CourseId = CourseAssignToTeacher.CourseId WHERE CourseAssignToTeacher.TeacherId=@teacherId";
                Command = new SqlCommand(query2, Connection);
                Command.Parameters.AddWithValue("@teacherId", teacherId);
                Object sum = Command.ExecuteScalar();

                Connection.Close();
                Teacher teacher = new Teacher();
                teacher = GetTeacherInfoByTeacherId(teacherId);
                double totalCredit = Convert.ToDouble(teacher.Credit);
                double sumOfCreditTaken = Convert.ToDouble(sum);
                return totalCredit-sumOfCreditTaken;
            }
            else
            {
                Reader.Close();
                Connection.Close();
                Teacher teacher = new Teacher();
                teacher = GetTeacherInfoByTeacherId(teacherId);
                double sumofCredit = Convert.ToDouble(teacher.Credit);
                return sumofCredit;
            }
            
        }

        public bool isExisted(AssignCourse assignCourse)
        {
            string query = "SELECT * FROM CourseAssignToTeacher WHERE CourseId = @courseId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@courseId", assignCourse.CourseId);
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
    }
}
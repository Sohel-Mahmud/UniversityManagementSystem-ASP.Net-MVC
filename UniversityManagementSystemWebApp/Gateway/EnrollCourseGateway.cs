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
           // Command.Parameters.AddWithValue("@GradeId", enroll.GradeId);
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

    }
}
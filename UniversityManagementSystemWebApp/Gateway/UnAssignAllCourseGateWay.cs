using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class UnAssignAllCourseGateWay:BaseGateway
    {
        public int UnAssignEnrollCourse()
        {
            string query = "UPDATE Enroll SET  Action=@delect WHERE Action=@action";
            Command = new SqlCommand(query, Connection);        

            Command.Parameters.AddWithValue("@delect", "delete");
            Command.Parameters.AddWithValue("@action", "insert");
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public int UnAssignCourseAssignToTeacher()
        {
            string query = "UPDATE CourseAssignToTeacher SET  Action=@delect WHERE Action=@action";
            Command = new SqlCommand(query, Connection);
            

            Command.Parameters.AddWithValue("@delect", "delete");
            Command.Parameters.AddWithValue("@action", "insert");
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}
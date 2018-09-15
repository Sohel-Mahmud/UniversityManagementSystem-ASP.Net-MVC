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
    }
}
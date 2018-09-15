using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class DepartmentGateway: BaseGateway
    {
        

        public int Save(Department department)
        {
            string query = "INSERT INTO Departments VALUES(@code, @name)";
            Command = new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@code", department.Code);
            Command.Parameters.AddWithValue("@name", department.Name);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool isExisted(Department department)
        {
            string query = "SELECT * FROM Departments WHERE Code = @code OR Name = @name";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@code", department.Code);
            Command.Parameters.AddWithValue("@Name", department.Name);
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

        public List<Department> GetAllDepartments()
        {
            string query = "SELECT * FROM Departments";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            List<Department> departmentList = new List<Department>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Department aDepartment = new Department();
                aDepartment.Code = Reader["Code"].ToString();
                aDepartment.Name = Reader["Name"].ToString();
                departmentList.Add(aDepartment);
            }
            Reader.Close();
            Connection.Close();
            return departmentList;
        }
    }
}
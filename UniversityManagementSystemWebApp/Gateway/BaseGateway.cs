using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class BaseGateway
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }

        public BaseGateway()
        {
            string conString = WebConfigurationManager.ConnectionStrings["UniversityManagementDB"].ConnectionString;
            Connection = new SqlConnection(conString);
        }
    }
}
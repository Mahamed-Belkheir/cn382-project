using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CN382_Project.database
{
    public static class DBConn
    {
        static public SqlConnection getConnection()
        {
            return new SqlConnection("Server=localhost; Database=ecommerce; User Id=sa; Password=Password12345");
        }
        
    }
}
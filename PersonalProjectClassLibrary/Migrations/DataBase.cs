using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.Migrations
{
    public class DataBase
    {
        public static void EnsureDataBase(string dbName = "PersonalProjectDB")
        {
            using var conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;
                                                    Initial Catalog=master;Integrated Security=True;Connect Timeout=30;");
            
            var dp = new DynamicParameters();
            dp.Add("dbName", dbName);

            var result = conn.Query("SELECT * FROM sys.databases WHERE name=@dbName", dp);

            if(!result.Any())
            {
                conn.Execute("CREATE DATABASE PersonalProjectDB");
            }
        }
    }
}

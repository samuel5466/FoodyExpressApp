//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FoodyExpressApp.DB
//{
//    class Database
//    {
//    }
//}
using System.Data.SqlClient;

namespace FoodyExpressApp.DB
{
    public static class Database
    {
        private static readonly string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FoodyDB.mdf;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}

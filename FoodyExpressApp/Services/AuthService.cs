//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FoodyExpressApp.Services
//{
//    class AuthService
//    {
//    }
//}
using FoodyExpressApp.DB;
using FoodyExpressApp.Models;
using System;
using System.Data.SqlClient;

namespace FoodyExpressApp.Services
{
    public class AuthService
    {
        public bool Register(User user)
        {
            using (var conn = Database.GetConnection())
            {
                string query = "INSERT INTO Users VALUES (@Id, @FirstName, @LastName, @Username, @Password, @DOB, @Gender, @Role)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@DOB", user.DateOfBirth);
                cmd.Parameters.AddWithValue("@Gender", user.Gender);
                cmd.Parameters.AddWithValue("@Role", user.Role);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public User Login(string username, string password)
        {
            using (var conn = Database.GetConnection())
            {
                string query = "SELECT * FROM Users WHERE Username=@Username AND Password=@Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new User
                    {
                        Id = (Guid)reader["Id"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Password = reader["Password"].ToString(),
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Gender = reader["Gender"].ToString(),
                        Role = reader["Role"].ToString()
                    };
                }
                return null;
            }
        }
    }
}

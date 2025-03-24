using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using WebAppServerConnection.Models;


namespace WebAppServerConnection.Repositories
{
	public class UserRepository
	{
        private string connectionString = ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString;

        public int? isUserValid(string username, string password)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
                connection.Open();
				string query = "SELECT 1 FROM Users WHERE Username = @Username AND Password = @Password";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : (int?)null;
                }

            }
        }

       
	}
}
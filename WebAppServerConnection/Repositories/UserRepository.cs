using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using WebAppServerConnection.Models;
using WebAppServerConnection.DTOs;
using System.DirectoryServices.AccountManagement;
using System.Diagnostics;
using System.DirectoryServices;


namespace WebAppServerConnection.Repositories
{
	public class UserRepository
	{
        private string connectionString = ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString;

        public UserLoginResult GetUserLoginInfo(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ID, IsAdmin FROM Users WHERE Username = @Username AND Password = @Password";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserLoginResult
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                IsAdmin = Convert.ToBoolean(reader["IsAdmin"])
                            };
                        }
                        else
                        {
                            return null; // 로그인 실패
                        }
                    }
                }
            }
        }

        public void CreateUserFromAD(string username, string password)
        {
            bool isAdmin = ActiveDirectoryRepository.IsUserDomainAdmins(username, password);

            

            Debug.WriteLine("관리자 여부: " + isAdmin);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Users (Username, Password, IsAdmin) VALUES (@Username, @Password, @IsAdmin)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@IsAdmin", isAdmin ? 1 : 0);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UserLoginResult GetUserByUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ID, IsAdmin FROM Users WHERE Username = @Username";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserLoginResult
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                IsAdmin = Convert.ToBoolean(reader["IsAdmin"])
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

    }
}
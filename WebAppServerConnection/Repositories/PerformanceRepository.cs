using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Razor.Tokenizer.Symbols;
using System.Web.UI.WebControls;
using WebAppServerConnection.Models;
using WebAppServerConnection.Repositories;

namespace WebAppServerConnection.Repositories
{
	public class PerformanceRepository
	{
        private string connectionString = ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString;


        public List<Performance> GetPerformanceList(string keyword = "") {
            List<Performance> performances = new List<Performance>();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT ID, Date, Artist, Location, Details, Link 
                                 From Performances
                                 WHERE Artist Like @Keyword";

                using(SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            performances.Add(new Performance
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Date = reader["Date"].ToString(),
                                Artist = reader["Artist"].ToString(),
                                Location = reader["Location"].ToString(),
                                Details = reader["Details"].ToString(),
                                Link= reader["Link"].ToString()
                            });
                        }
                    }
                }
                return performances;
            }
        }

        public Performance GetPerformance(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ID, Date, Artist, Location, Details, Link, IsAvailableNum, ReservationNum From Performances WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        if (reader.Read())
                        {
                            return new Performance
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Date = reader["Date"].ToString(),
                                Artist = reader["Artist"].ToString(),
                                Location = reader["Location"].ToString(),
                                Details = reader["Details"].ToString(),
                                Link = reader["Link"].ToString(),
                                IsAvailableNum = Convert.ToInt32(reader["IsAvailableNum"]),
                                ReservationNum = Convert.ToInt32(reader["ReservationNum"])
                            };
                        }
                    }
                }
                return null;
            }
        }


        public bool isPerformanceValid(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT 1 FROM Performances WHERE ID = @ID";

                using(SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }
        public bool CreatePerformance(String date, String artist, String location, String details, String link, int availableNum)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Performances (Date, Artist, Location, Details, Link, IsAvailableNum, ReservationNum ) VALUES (@Date, @Artist, @Location, @Details, @Link, @IsAvailableNum, 0 )";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@Artist", artist);
                    cmd.Parameters.AddWithValue("@Location", location);
                    cmd.Parameters.AddWithValue("@Details", details);
                    cmd.Parameters.AddWithValue("@Link", link);
                    cmd.Parameters.AddWithValue("@IsAvailableNum", availableNum);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeletePerformance(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Performances WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
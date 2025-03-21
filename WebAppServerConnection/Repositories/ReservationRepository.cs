using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using WebAppServerConnection.Models;

namespace WebAppServerConnection.Repositories
{

	public class ReservationRepository
	{
        private string connectionString = ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString;

        public bool CreateReservation(int userId, int performanceId)
        {
            Debug.WriteLine(performanceId);
            Debug.WriteLine(userId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string insertQuery = "INSERT INTO User_Reservations (UserID, PerformanceID, ReservationDate) VALUES (@UserID, @PerformanceID, GETDATE())";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection, transaction))
                        {
                            insertCmd.Parameters.AddWithValue("@UserID", userId);
                            insertCmd.Parameters.AddWithValue("@PerformanceID", performanceId);
                            insertCmd.ExecuteNonQuery();
                        }

                        string updateQuery = "UPDATE Performances SET ReservationNum = ReservationNum + 1 WHERE ID = @PerformanceID";
                        //select * from Performances where ID=1
                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, connection, transaction))
                        {
                            updateCmd.Parameters.AddWithValue("@PerformanceID", performanceId);
                            updateCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("❌ 트랜잭션 오류 발생: " + ex.Message);
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }


        public List<Performance> GetUserReservations(int userId, string keyword = "")
        {
            List<Performance> reservations = new List<Performance>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT P.ID, P.Date, P.Artist, P.Location, P.Details, P.Link, P.IsAvailableNum, P.ReservationNum
                    FROM User_Reservations UR
                    JOIN Performances P ON UR.PerformanceID = P.ID
                    WHERE UR.UserID = @UserID 
                    AND P.Artist LIKE @Keyword";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Debug.WriteLine(Convert.ToInt32(reader["IsAvailableNum"]));
                            reservations.Add(new Performance
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Date = reader["Date"].ToString(),
                                Artist = reader["Artist"].ToString(),
                                Location = reader["Location"].ToString(),
                                Details = reader["Details"].ToString(),
                                Link = reader["Link"]?.ToString(),
                                IsAvailableNum = Convert.ToInt32(reader["IsAvailableNum"]),
                                ReservationNum = Convert.ToInt32(reader["ReservationNum"]),
                            });
                        }
                    }
                }
            }

            Debug.WriteLine(reservations[0]);

            return reservations;
        }
    }
}
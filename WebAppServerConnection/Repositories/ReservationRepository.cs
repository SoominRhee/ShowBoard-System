using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using WebAppServerConnection.DTO;
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
                    SELECT P.ID, P.Date, P.Category, P.Artist, P.Location, P.Details, P.Link, P.IsAvailableNum, P.ReservationNum
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
                                Category = reader["Category"].ToString(),
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

            //Debug.WriteLine(reservations[0]);

            return reservations;
        }


        public List<UserReservationInfo> GetUserListByPerformanceId(int id)
        {
            List<UserReservationInfo> reservationInfo = new List<UserReservationInfo>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT 
                                    u.ID AS UserID,
                                    u.Username,
                                    ur.ReservationDate
                                FROM 
                                    User_Reservations ur
                                JOIN [Users] u ON ur.UserID = u.ID
                                WHERE 
                                    ur.PerformanceID = @PerformanceID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PerformanceID", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int userId = Convert.ToInt32(reader["UserID"]);
                            string username = reader["Username"].ToString();
                            DateTime reservationDate = Convert.ToDateTime(reader["ReservationDate"]);

                            // 출력
                            //Debug.WriteLine($"[예약자] ID: {userId}, 이름: {username}, 예약일: {reservationDate}");

                            reservationInfo.Add(new UserReservationInfo
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Username = reader["Username"].ToString(),
                                ReservationDate = reader["ReservationDate"].ToString()
                            });

                        }
                    }
                }
            }

            Debug.WriteLine("Repository return: " + reservationInfo.Count);

            return reservationInfo;
        }
    }
}
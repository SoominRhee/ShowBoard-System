using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Razor.Tokenizer.Symbols;
using WebAppServerConnection.Models;

namespace WebAppServerConnection.Repositories
{
    public class BoardRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString;


        public List<BoardPost> GetBoardList(string keyword = "")
        {
            List<BoardPost> posts = new List<BoardPost>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //string query = "SELECT ID, Date, Organizer, Summary, Details, DisplayPeriod FROM BoardPosts";
                string query = @"SELECT ID, Date, Organizer, Summary, Details, DisplayPeriod
                                 FROM BoardPosts
                                 Where Summary Like @Keyword";

                using (SqlCommand cmd = new SqlCommand(query, connection)) {

                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%"); // ✅ 부분 검색
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            posts.Add(new BoardPost
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Date = reader["Date"].ToString(),
                                Organizer = reader["Organizer"].ToString(),
                                Summary = reader["Summary"].ToString(),
                                Details = reader["Details"].ToString(),
                                DisplayPeriod = reader["DisplayPeriod"].ToString()
                            });
                        }
                    }
                }
            }
            return posts;
        }

        public bool CreateBoardPost(string summary, string details, string date, string organizer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO BoardPosts (Date, Organizer, Summary, Details, DisplayPeriod) VALUES (@Date, @Organizer, @Summary, @Details, @DisplayPeriod)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Organizer", organizer);
                    cmd.Parameters.AddWithValue("@Summary", summary);
                    cmd.Parameters.AddWithValue("@Details", details);
                    cmd.Parameters.AddWithValue("@DisplayPeriod", date);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ✅ 3️⃣ 게시글 삭제 (DELETE)
        public bool DeleteBoardPost(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM BoardPosts WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
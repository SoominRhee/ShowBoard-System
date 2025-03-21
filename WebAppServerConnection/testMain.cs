using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Server=DESKTOP-1APJ5P2;Database=TestDB;Integrated Security=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("✅ SQL Server 연결 성공!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ 연결 실패: " + ex.Message);
            }
        }
    }
}

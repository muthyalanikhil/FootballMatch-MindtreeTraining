using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FootballMatch
{
    public class Connection
    {
        public void SaveRecord(string query)
        {
            try
            {
                SqlConnection insertSqlConnection = new SqlConnection("Server=172.17.2.13;database=M1032434;integrated security=true;");
                insertSqlConnection.Open();    //Make connection
                SqlCommand sqlCommannd = new SqlCommand(query, insertSqlConnection);
                sqlCommannd.ExecuteNonQuery();
                insertSqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public SqlDataReader ReadData(string query)
        {
            SqlConnection readSqlConnection = new SqlConnection("Server=172.17.2.13;database=M1032434;integrated security=true;");
            readSqlConnection.Open();
            SqlCommand command = new SqlCommand(query, readSqlConnection);
            SqlDataReader data = command.ExecuteReader();
            return data;
        }
    }
}

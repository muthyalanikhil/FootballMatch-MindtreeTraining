using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace FootballMatch
{
    class Match
    {
        public string MatchId { get; set; }
        public string MatchDate { get; set; }
        public string FirstTeamName { get; set; }
        public string SecondTeamName { get; set; }
        public string FirstTeamGoal { get; set; }
        public string SecondTeamGoal { get; set; }

        Connection connection = new Connection();
        public void GetData()
        {
            SqlDataReader data = connection.ReadData("select * from Team");
            while (data.Read())
            {
                Console.WriteLine(data.GetString(0) + "\t\t\t\t\t" + data.GetString(1));

            }
        }

        public void SaveMatchDetail()
        {
            try
            {
                Console.WriteLine("Enter the number of Matches");
                int numberOfMatches = int.Parse(Console.ReadLine());
                while (numberOfMatches != 0)
                {
                    Console.WriteLine("--INSERT DATA IN MATCH TABLE--\n\n");
                    Console.WriteLine("Select First Team");
                    string FirstTeamName = Console.ReadLine();
                    Console.WriteLine("Select Second Team");
                    string SecondTeamName = Console.ReadLine();
                    Console.WriteLine("Enter Match Date and Time in YYYY/MM/DD and hh:mm:ss format");
                    DateTime date = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter Goals scored by First Team");
                    int FirstTeamGoals = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Goals scored by Second Team");
                    int SecondTeamGoals = int.Parse(Console.ReadLine());
                    connection.SaveRecord("insert into Match values('" + date + "','" + FirstTeamName + "','" + SecondTeamName + "'," + FirstTeamGoals + "," + SecondTeamGoals + ")");
                    numberOfMatches--;
                }
                Console.WriteLine("Inserted successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GetMatchDetail()
        {
            try
            {
                Console.WriteLine("Enter Team Name");

                string teamName = Console.ReadLine(); Console.WriteLine("\n\n");
                Console.WriteLine("DATE\t\t\t\tOPPONENTS\t\t\tGOAL\n\n");
                SqlDataReader data = connection.ReadData("select Match_Date as 'timetable' , second_Team_name as 'Opponent',First_Team_Goals as 'Goals' ,Second_Team_Goals as 'Goals' from Match where First_Team_Name='" + teamName + "' order by First_Team_Goals-Second_Team_Goals desc");

                while (data.Read())
                {
                    Console.WriteLine(data.GetDateTime(0) + "\t\t" + data.GetString(1) + "\t\t" + data.GetInt32(2) + "\t-\t" + data.GetInt32(3) + "\n\n");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

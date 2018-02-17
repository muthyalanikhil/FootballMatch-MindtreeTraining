using System;
using System.Collections.Generic;

namespace FootballMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AddTeamList addTeamList = new AddTeamList();
                Match match = new Match();
                Console.WriteLine("TOTAL TEAMS AND CITY\n\n");
                Console.WriteLine("Teams\t\t\t\t\t\tCity\n\n");
                match.GetData();
                Console.WriteLine("\n\n");
                string message = null;
                while (message == null)
                {
                    Console.WriteLine("Press 1 to add TEAMS and CITY OR \n\nPress 2 to add MATCH DETAILS");
                    int option = int.Parse(Console.ReadLine());
                    if (option == 1)
                    {
                        Console.WriteLine("\n\n\nenter 1 for insertion and 2 for updation\n\n");
                        int choice = int.Parse(Console.ReadLine());
                        if (choice == 1)
                        {
                            addTeamList.SaveTeamDetail();
                        }
                        else if (choice == 2)
                        {
                            addTeamList.updateTeamDetail();
                        }
                        else
                        {
                            Console.WriteLine("invalid input");
                        }
                    }
                    else if (option == 2)
                    {
                        string messageInner = null;
                        while (messageInner == null)
                        {
                            Console.WriteLine("\n\nEnter choice 1/2/3\n\n1 For adding match details\n2 For details of match for any team\n3 For exit");
                            int number = int.Parse(Console.ReadLine());
                            if (number == 1)
                            {
                                match.SaveMatchDetail();

                            }
                            if (number == 2)
                            {

                                match.GetMatchDetail();
                            }
                            else if (number == 3)
                            {
                                messageInner = "done";
                                Environment.Exit(0);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            };
            Console.ReadKey();
        }
    }
    public class AddTeamList
    {
        Connection connection = new Connection();
        List<Team> listTeam = new List<Team>();

        public void SaveTeamDetail()
        {
            try
            {
                string TeamName;
                string TeamCity;
                Console.WriteLine("--INSERT DATA IN TEAM TABLE--\n\n");
                Console.WriteLine("Enter the number of teams");
                int number = int.Parse(Console.ReadLine());
                for (int index = 0; index < number; index++)
                {
                    Console.WriteLine("Enter team name" + (index + 1));
                    TeamName = Console.ReadLine();
                    Console.WriteLine("Enter team City" + (index + 1));
                    TeamCity = Console.ReadLine();
                    listTeam.Add(new Team { TeamName = TeamName, TeamCity = TeamCity });
                }
                foreach (Team teamDetail in listTeam)
                {
                    connection.SaveRecord("insert into Team values ('" + teamDetail.TeamName + "','" + teamDetail.TeamCity + "')");
                }
                Console.WriteLine("\n\ninserted successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void updateTeamDetail()
        {
            try
            {
                Console.WriteLine("\n\n--UPDATE DATA IN TEAM TABLE--\n\n");
                Console.WriteLine("Enter Team Name");
                string teamName = Console.ReadLine();
                Console.WriteLine("Enter Team City");
                string teamCity = Console.ReadLine();
                connection.SaveRecord("update Team set Team_City='" + teamCity + "'" + "where Team_Name='" + teamName + "'");
                Console.WriteLine("\n\nupdated successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}






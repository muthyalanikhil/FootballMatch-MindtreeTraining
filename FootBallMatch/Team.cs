using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace FootballMatch
{
    public class Team
    {
        string teamName, teamCity;
        public string TeamName
        {
            get
            {
                return teamName;
            }
            set
            {
                teamName = value;
            }
        }
        public string TeamCity
        {
            get
            {
                return teamCity;
            }
            set
            {
                teamCity = value;
            }
        }
    }
}

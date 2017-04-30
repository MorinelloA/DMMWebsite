using DMMLib;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Configuration;

namespace DMMWCFLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public bool AuthenticateUser(string username, string password)
        {
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(userStore);
            //search user
            IdentityUser user = userManager.Find(username, password);

            //return user;
            if (user != null) //Username and Password is correct
                return true;
            else
                return false;
        }

        public bool CreateUser(string username, string password)
        {
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

            //Attempt to register new user
            IdentityUser user = new IdentityUser() { UserName = username };
            IdentityResult result = manager.Create(user, password);

            bool isCreated = false;
            if (result.Succeeded)
            {
                isCreated = true;
            }

            return isCreated;
        }

        public bool AddBoysTeam(Meet meet)
        {
            int meetID = FindMeetId(meet);
            bool didAdd = false;
            if (meet.schoolNames.boySchoolNames != null)
            {
                SqlConnection conn = null;
                try
                {
                    conn = GetConnection();
                    conn.Open();
                    foreach (KeyValuePair<string, string> entry in meet.schoolNames.boySchoolNames)
                    {
                        string SqlQuery = "insert into BoysTeams (BoysAbbr, BoysTeam, MeetKey) values ('" + entry.Key + "', '" + entry.Value + "', '" + meetID + "')";
                        SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                        int numberOfRows = cmd.ExecuteNonQuery();
                    }

                    didAdd = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
                finally
                {
                    conn.Close();
                }
            }

            return didAdd;
        }

        public bool AddGirlsTeam(Meet meet)
        {
            int meetID = FindMeetId(meet);
            bool didAdd = false;
            if (meet.schoolNames.girlSchoolNames != null)
            {
                SqlConnection conn = null;
                try
                {
                    conn = GetConnection();
                    conn.Open();
                    foreach (KeyValuePair<string, string> entry in meet.schoolNames.girlSchoolNames)
                    {
                        string SqlQuery = "insert into GirlsTeams (GirlsAbbr, GirlsTeam, MeetKey) values ('" + entry.Key + "', '" + entry.Value + "', '" + meetID + "')";
                        SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                        int numberOfRows = cmd.ExecuteNonQuery();
                    }

                    didAdd = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
                finally
                {
                    conn.Close();
                }
            }

            return didAdd;
        }

        public bool AddMeet(Meet meet, string user)
        {
            SqlConnection conn = null;
            bool didAdd = false;
            try
            {
                conn = GetConnection();
                conn.Open();
                //string SqlQuery = "insert into MeetMain (Date, Location, Weather) values ('" + meet.dateOfMeet + "', '" + meet.location + "', '" + meet.weatherConditions + "')";
                //SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                SqlCommand cmd = new SqlCommand("insert into MeetMain (Date, Location, Weather, Username) values ('" + meet.dateOfMeet + "', '" + meet.location + "', '" + meet.weatherConditions + "', '" + user + "')", conn);
                int numberOfRows = cmd.ExecuteNonQuery();

                //Add BoysTeams
                bool abt = AddBoysTeam(meet);
                //Add GirlsTeams
                bool agt = AddGirlsTeam(meet);
                //Add Performances
                bool ap = AddPerformances(meet);

                if (abt && agt && ap)
                    didAdd = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
            finally
            {
                conn.Close();
            }

            return didAdd;
        }

        public bool AddPerformance(Meet meet, string eventName)
        {
            int meetID = FindMeetId(meet);
            bool didAdd = false;
            SqlConnection conn = null;
            try
            {
                conn = GetConnection();
                conn.Open();
                foreach (Performance perf in meet.performances[eventName])
                {
                    string correctEvent = eventName.Replace("'", "");
                    string SqlQuery = "insert into Performances (AthleteName, SchoolName, EventName, HeatNum, Performance, MeetKey) values ('" + perf.athleteName + "', '" + perf.schoolName + "', '" + correctEvent + "', '" + perf.heatNum + "', '" + perf.performance + "', '" + meetID + "')";
                    SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                    int numberOfRows = cmd.ExecuteNonQuery();
                }

                didAdd = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
            finally
            {
                conn.Close();
            }

            return didAdd;
        }

        public bool AddPerformances(Meet meet)
        {
            int meetID = FindMeetId(meet);
            bool didAdd = false;
            if (meet.schoolNames.boySchoolNames != null)
            {
                SqlConnection conn = null;
                try
                {
                    conn = GetConnection();
                    conn.Open();
                    foreach (string eventName in meet.performances.Keys)
                    {
                        foreach (Performance perf in meet.performances[eventName])
                        {
                            string correctEvent = eventName.Replace("'", "");
                            string SqlQuery = "insert into Performances (AthleteName, SchoolName, EventName, HeatNum, Performance, MeetKey) values ('" + perf.athleteName + "', '" + perf.schoolName + "', '" + correctEvent + "', '" + perf.heatNum + "', '" + perf.performance + "', '" + meetID + "')";
                            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                            int numberOfRows = cmd.ExecuteNonQuery();
                        }
                    }

                    didAdd = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
                finally
                {
                    conn.Close();
                }
            }
            //performances MAY be null.
            {
                didAdd = true;
            }

            return didAdd;
        }

        public bool DeleteBoysTeam(int id)
        {
            bool didDelete = false;
            SqlConnection conn = null;
            try
            {
                conn = GetConnection();
                conn.Open();
                string SqlQuery = "delete from BoysTeams where MeetKey = '" + id + "'";
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                int numberOfRows = cmd.ExecuteNonQuery();

                didDelete = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
            finally
            {
                conn.Close();
            }

            return didDelete;
        }

        public bool DeleteGirlsTeam(int id)
        {
            bool didDelete = false;
            SqlConnection conn = null;
            try
            {
                conn = GetConnection();
                conn.Open();
                string SqlQuery = "delete from GirlsTeams where MeetKey = '" + id + "'";
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                int numberOfRows = cmd.ExecuteNonQuery();

                didDelete = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
            finally
            {
                conn.Close();
            }

            return didDelete;
        }

        public bool DeleteMeet(int id)
        {
            bool didDelete = false;
            SqlConnection conn = null;
            try
            {
                conn = GetConnection();
                conn.Open();

                DeleteBoysTeam(id);
                DeleteGirlsTeam(id);
                DeletePerformances(id);

                string SqlQuery = "delete from MeetMain where Id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                int numberOfRows = cmd.ExecuteNonQuery();

                didDelete = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
            finally
            {
                conn.Close();
            }

            return didDelete;
        }

        public bool DeletePerformances(int id)
        {
            bool didDelete = false;
            SqlConnection conn = null;
            try
            {
                conn = GetConnection();
                conn.Open();
                string SqlQuery = "delete from Performances where MeetKey = '" + id + "'";
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                int numberOfRows = cmd.ExecuteNonQuery();

                didDelete = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
            finally
            {
                conn.Close();
            }

            return didDelete;
        }

        public bool DeletePerformance(int id, string eventName)
        {
            bool didDelete = false;
            SqlConnection conn = null;
            try
            {
                conn = GetConnection();
                conn.Open();
                eventName = eventName.Replace("'", "");
                string SqlQuery = "delete from Performances where MeetKey = '" + id + "' and EventName = '" + eventName + "'";
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                int numberOfRows = cmd.ExecuteNonQuery();

                didDelete = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
            finally
            {
                conn.Close();
            }

            return didDelete;
        }

        public Dictionary<string, string> FindBoysTeam(int id)
        {
            SqlConnection conn = null;
            Dictionary<string, string> teams = new Dictionary<string, string>();
            try
            {
                conn = GetConnection();
                conn.Open();
                SqlDataReader reader = null;
                string SqlQuery = "select * from BoysTeams where MeetKey = '" + id + "'";
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string abbr = reader.GetString(reader.GetOrdinal("BoysAbbr"));
                    string team = reader.GetString(reader.GetOrdinal("BoysTeam"));
                    teams.Add(abbr, team);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
            finally
            {
                conn.Close();
            }

            return teams;
        }

        public Dictionary<string, string> FindGirlsTeam(int id)
        {
            SqlConnection conn = null;
            Dictionary<string, string> teams = new Dictionary<string, string>();
            try
            {
                conn = GetConnection();
                conn.Open();
                SqlDataReader reader = null;
                string SqlQuery = "select * from GirlsTeams where MeetKey = '" + id + "'";
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string abbr = reader.GetString(reader.GetOrdinal("GirlsAbbr"));
                    string team = reader.GetString(reader.GetOrdinal("GirlsTeam"));
                    teams.Add(abbr, team);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
            finally
            {
                conn.Close();
            }

            return teams;
        }

        public Meet FindMeet(int id)
        {
            SqlConnection conn = null;
            Meet myMeet = new Meet();
            try
            {
                conn = GetConnection();
                conn.Open();
                SqlDataReader reader = null;
                string SqlQuery = "select * from MeetMain where Id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    myMeet.dateOfMeet = reader.GetDateTime(reader.GetOrdinal("Date"));
                    myMeet.location = reader.GetString(reader.GetOrdinal("Location"));
                    myMeet.weatherConditions = reader.GetString(reader.GetOrdinal("Weather"));

                    Dictionary<string, string> boys = new Dictionary<string, string>();
                    Dictionary<string, string> girls = new Dictionary<string, string>();
                    boys = FindBoysTeam(id);
                    girls = FindGirlsTeam(id);
                    myMeet.schoolNames = new Teams(boys, girls);

                    myMeet.performances = FindPerformancesDictionary(id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
            finally
            {
                conn.Close();
            }

            return myMeet;
        }

        public int FindMeetId(Meet meet)
        {
            SqlConnection conn = null;
            int id = 0;
            try
            {
                conn = GetConnection();
                conn.Open();
                SqlDataReader reader = null;
                string SqlQuery = "select * from MeetMain where Date = '" + meet.dateOfMeet + "' and Location = '" + meet.location + "' and Weather = '" + meet.weatherConditions + "'";
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    id = reader.GetInt32(reader.GetOrdinal("Id"));

                    //FindBoysTeamsHere?
                    //FindGirlsTeamsHere?
                    //FindPerformancesHere?
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
            finally
            {
                conn.Close();
            }

            return id;
        }

        public Dictionary<string, List<Performance>> FindPerformancesDictionary(int id)
        {
            string[] events = { "100", "200", "400", "800", "1600", "3200", "HH", "300H", "4x100", "4x400", "4x800", "LJ", "TJ", "HJ", "PV", "Shotput", "Discus", "Javelin" };
            Dictionary<string, List<Performance>> dictOfPerfs = new Dictionary<string, List<Performance>>();

            foreach (string str in events)
            {
                List<Performance> boysPerfs = FindPerformancesList(id, "Boy's " + str);
                if (boysPerfs.Count > 0)
                {
                    dictOfPerfs.Add("Boy's " + str, boysPerfs);
                }
                List<Performance> girlsPerfs = FindPerformancesList(id, "Girl's " + str);
                if (girlsPerfs.Count > 0)
                {
                    dictOfPerfs.Add("Girl's " + str, girlsPerfs);
                }
            }

            return dictOfPerfs;
        }

        public List<Performance> FindPerformancesList(int id, string eventName)
        {
            SqlConnection conn = null;
            List<Performance> perfs = new List<Performance>();
            try
            {
                conn = GetConnection();
                conn.Open();
                SqlDataReader reader = null;
                eventName = eventName.Replace("'", "");
                string SqlQuery = "select * from Performances where MeetKey = '" + id + "' and EventName = '" + eventName + "'";
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string athleteName = reader.GetString(reader.GetOrdinal("AthleteName"));
                    string schoolName = reader.GetString(reader.GetOrdinal("SchoolName"));
                    int heatNum = reader.GetInt32(reader.GetOrdinal("HeatNum"));
                    decimal performance = reader.GetDecimal(reader.GetOrdinal("Performance"));
                    Performance perfToAdd = new Performance(athleteName, schoolName, heatNum, performance);
                    perfs.Add(perfToAdd);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
            finally
            {
                conn.Close();
            }

            return perfs;
        }

        public bool ResetPrimaryKeys()
        {
            SqlConnection conn = null;
            try
            {
                conn = GetConnection();
                conn.Open();
                SqlDataReader reader = null;
                string SqlQuery = "DBCC CHECKIDENT (BoysTeams, RESEED, 0)";
                //SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                //reader = cmd.ExecuteReader();

                SqlQuery += "\nDBCC CHECKIDENT (GirlsTeams, RESEED, 0)";
                //cmd = new SqlCommand(SqlQuery, conn);
                //reader = cmd.ExecuteReader();

                SqlQuery += "\nDBCC CHECKIDENT (Performances, RESEED, 0)";
                //cmd = new SqlCommand(SqlQuery, conn);
                //reader = cmd.ExecuteReader();

                SqlQuery += "\nDBCC CHECKIDENT (MeetMain, RESEED, 0)";
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
            finally
            {
                conn.Close();
            }

            return true;
        }

        public Dictionary<int, Meet> ListOfMeets(string user)
        {
            Dictionary<int, Meet> listOfMeets = new Dictionary<int, Meet>();

            SqlConnection conn = null;
            try
            {
                conn = GetConnection();
                conn.Open();
                SqlDataReader reader = null;
                //string SqlQuery = "select * from MeetMain";
                string SqlQuery = "select * from MeetMain where Username = '" + user + "'";
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime dt = reader.GetDateTime(reader.GetOrdinal("Date"));
                    string location = reader.GetString(reader.GetOrdinal("Location"));
                    string weather = reader.GetString(reader.GetOrdinal("Weather"));
                    Meet meetToAdd = new Meet(dt, location, weather, null);
                    int meetID = FindMeetId(meetToAdd);
                    listOfMeets.Add(meetID, meetToAdd);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
            finally
            {
                conn.Close();
            }

            return listOfMeets;
        }

        private SqlConnection GetConnection()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["MeetDB"].ConnectionString;
            return new SqlConnection(connectionString);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}

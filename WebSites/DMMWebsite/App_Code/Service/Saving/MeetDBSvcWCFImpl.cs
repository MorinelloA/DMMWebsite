using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DMMLib;

namespace DualMeetManager.Service.Saving
{
    /// <summary>
    /// Summary description for MeetDBSvcWCFImpl
    /// </summary>
    public class MeetDBSvcWCFImpl : IMeetDBSvc
    {
        public MeetDBSvcWCFImpl()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public bool AddBoysTeam(Meet meet)
        {
            ServiceReference3.Service1Client proxy = new ServiceReference3.Service1Client();
            bool result = proxy.AddBoysTeam(meet);
            return result;
        }

        public bool AddGirlsTeam(Meet meet)
        {
            ServiceReference3.Service1Client proxy = new ServiceReference3.Service1Client();
            bool result = proxy.AddGirlsTeam(meet);
            return result;
        }

        public bool AddMeet(Meet meet, string user)
        {
            ServiceReference3.Service1Client proxy = new ServiceReference3.Service1Client();
            bool result = proxy.AddMeet(meet, user);
            return result;
        }

        public bool AddPerformance(Meet meet, string eventName)
        {
            ServiceReference3.Service1Client proxy = new ServiceReference3.Service1Client();
            bool result = proxy.AddPerformance(meet, eventName);
            return result;
        }

        public bool AddPerformances(Meet meet)
        {
            ServiceReference3.Service1Client proxy = new ServiceReference3.Service1Client();
            bool result = proxy.AddPerformances(meet);
            return result;
        }

        public bool DeleteBoysTeam(int id)
        {
            ServiceReference3.Service1Client proxy = new ServiceReference3.Service1Client();
            bool result = proxy.DeleteBoysTeam(id);
            return result;
        }

        public bool DeleteGirlsTeam(int id)
        {
            ServiceReference3.Service1Client proxy = new ServiceReference3.Service1Client();
            bool result = proxy.DeleteGirlsTeam(id);
            return result;
        }

        public bool DeleteMeet(int id)
        {
            ServiceReference3.Service1Client proxy = new ServiceReference3.Service1Client();
            bool result = proxy.DeleteMeet(id);
            return result;
        }

        public bool DeletePerformance(int id, string eventName)
        {
            ServiceReference3.Service1Client proxy = new ServiceReference3.Service1Client();
            bool result = proxy.DeletePerformance(id, eventName);
            return result;
        }

        public bool DeletePerformances(int id)
        {
            ServiceReference3.Service1Client proxy = new ServiceReference3.Service1Client();
            bool result = proxy.DeletePerformances(id);
            return result;
        }

        public Dictionary<string, string> FindBoysTeam(int id)
        {
            ServiceReference3.Service1Client proxy = new ServiceReference3.Service1Client();
            Dictionary<string, string> result = proxy.FindBoysTeam(id);
            return result;
        }

        public Dictionary<string, string> FindGirlsTeam(int id)
        {
            ServiceReference3.Service1Client proxy = new ServiceReference3.Service1Client();
            Dictionary<string, string> result = proxy.FindGirlsTeam(id);
            return result;
        }

        public Meet FindMeet(int id)
        {
            ServiceReference3.Service1Client proxy = new ServiceReference3.Service1Client();
            Meet result = proxy.FindMeet(id);
            return result;
        }

        public int FindMeetId(Meet meet)
        {
            ServiceReference3.Service1Client proxy = new ServiceReference3.Service1Client();
            int result = proxy.FindMeetId(meet);
            return result;
        }

        public Dictionary<string, List<Performance>> FindPerformances(int id)
        {
            ServiceReference3.Service1Client proxy = new ServiceReference3.Service1Client();
            Dictionary<string, List<Performance>> result = proxy.FindPerformancesDictionary(id);
            return result;
        }

        public List<Performance> FindPerformances(int id, string eventName)
        {
            ServiceReference3.Service1Client proxy = new ServiceReference3.Service1Client();
            List<Performance> result = proxy.FindPerformancesList(id, eventName);
            return result;
        }

        public Dictionary<int, Meet> ListOfMeets(string user)
        {
            ServiceReference3.Service1Client proxy = new ServiceReference3.Service1Client();
            Dictionary<int, Meet> result = proxy.ListOfMeets(user);
            return result;
        }

        public bool ResetPrimaryKeys()
        {
            ServiceReference3.Service1Client proxy = new ServiceReference3.Service1Client();
            bool result = proxy.ResetPrimaryKeys();
            return result;
        }
    }
}
using DMMLib;
using DMMServer.Service.MeetSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMServer.Business.Managers
{
    public class MeetDBMgr : Manager
    {
        public bool AddMeet(Meet meet, string user)
        {
            IMeetDBSvc meetDBSvc = (IMeetDBSvc)GetService(typeof(IMeetDBSvc).Name);
            bool meetAdded = meetDBSvc.AddMeet(meet, user);
            return meetAdded;
        }

        public int FindMeetId(Meet meet)
        {
            IMeetDBSvc meetDBSvc = (IMeetDBSvc)GetService(typeof(IMeetDBSvc).Name);
            int meetID = meetDBSvc.FindMeetId(meet);
            return meetID;
        }

        public Meet FindMeet(int id)
        {
            IMeetDBSvc meetDBSvc = (IMeetDBSvc)GetService(typeof(IMeetDBSvc).Name);
            Meet meet = meetDBSvc.FindMeet(id);
            return meet;
        }

        public bool DeleteMeet(int id)
        {
            IMeetDBSvc meetDBSvc = (IMeetDBSvc)GetService(typeof(IMeetDBSvc).Name);
            bool meetDeleted = meetDBSvc.DeleteMeet(id);
            return meetDeleted;
        }

        public bool AddBoysTeam(Meet meet)
        {
            IMeetDBSvc meetDBSvc = (IMeetDBSvc)GetService(typeof(IMeetDBSvc).Name);
            bool boysTeamAdded = meetDBSvc.AddBoysTeam(meet);
            return boysTeamAdded;
        }

        public Dictionary<string, string> FindBoysTeam(int id)
        {
            IMeetDBSvc meetDBSvc = (IMeetDBSvc)GetService(typeof(IMeetDBSvc).Name);
            Dictionary<string, string> teams = meetDBSvc.FindBoysTeam(id);
            return teams;
        }

        public bool DeleteBoysTeam(int id)
        {
            IMeetDBSvc meetDBSvc = (IMeetDBSvc)GetService(typeof(IMeetDBSvc).Name);
            bool boysTeamDeleted = meetDBSvc.DeleteBoysTeam(id);
            return boysTeamDeleted;
        }

        public bool AddGirlsTeam(Meet meet)
        {
            IMeetDBSvc meetDBSvc = (IMeetDBSvc)GetService(typeof(IMeetDBSvc).Name);
            bool girlsTeamAdded = meetDBSvc.AddGirlsTeam(meet);
            return girlsTeamAdded;
        }

        public Dictionary<string, string> FindGirlsTeam(int id)
        {
            IMeetDBSvc meetDBSvc = (IMeetDBSvc)GetService(typeof(IMeetDBSvc).Name);
            Dictionary<string, string> teams = meetDBSvc.FindGirlsTeam(id);
            return teams;
        }

        public bool DeleteGirlsTeam(int id)
        {
            IMeetDBSvc meetDBSvc = (IMeetDBSvc)GetService(typeof(IMeetDBSvc).Name);
            bool girlsTeamDeleted = meetDBSvc.DeleteGirlsTeam(id);
            return girlsTeamDeleted;
        }

        public bool AddPerformances(Meet meet)
        {
            IMeetDBSvc meetDBSvc = (IMeetDBSvc)GetService(typeof(IMeetDBSvc).Name);
            bool performanceAdded = meetDBSvc.AddPerformances(meet);
            return performanceAdded;
        }

        public bool AddPerformance(Meet meet, string eventName)
        {
            IMeetDBSvc meetDBSvc = (IMeetDBSvc)GetService(typeof(IMeetDBSvc).Name);
            bool performanceAdded = meetDBSvc.AddPerformance(meet, eventName);
            return performanceAdded;
        }

        public Dictionary<string, List<Performance>> FindPerformances(int id)
        {
            IMeetDBSvc meetDBSvc = (IMeetDBSvc)GetService(typeof(IMeetDBSvc).Name);
            Dictionary<string, List<Performance>> perfs = meetDBSvc.FindPerformances(id);
            return perfs;
        }

        public List<Performance> FindPerformances(int id, string eventName)
        {
            IMeetDBSvc meetDBSvc = (IMeetDBSvc)GetService(typeof(IMeetDBSvc).Name);
            List<Performance> perfs = meetDBSvc.FindPerformances(id, eventName);
            return perfs;
        }

        public bool DeletePerformances(int id)
        {
            IMeetDBSvc meetDBSvc = (IMeetDBSvc)GetService(typeof(IMeetDBSvc).Name);
            bool perfsDeleted = meetDBSvc.DeletePerformances(id);
            return perfsDeleted;
        }

        public bool DeletePerformance(int id, string eventName)
        {
            IMeetDBSvc meetDBSvc = (IMeetDBSvc)GetService(typeof(IMeetDBSvc).Name);
            bool perfsDeleted = meetDBSvc.DeletePerformance(id, eventName);
            return perfsDeleted;
        }

        public Dictionary<int, Meet> ListOfMeets(string user)
        {
            IMeetDBSvc meetDBSvc = (IMeetDBSvc)GetService(typeof(IMeetDBSvc).Name);
            Dictionary<int, Meet> listOfMeets = meetDBSvc.ListOfMeets(user);
            return listOfMeets;
        }

        public bool ResetPrimaryKeys()
        {
            IMeetDBSvc meetDBSvc = (IMeetDBSvc)GetService(typeof(IMeetDBSvc).Name);
            bool resetKeys = meetDBSvc.ResetPrimaryKeys();
            return resetKeys;
        }
    }
}

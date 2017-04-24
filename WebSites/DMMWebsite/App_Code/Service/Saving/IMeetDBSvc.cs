using DMMLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IMeetDBSvc
/// </summary>
namespace DualMeetManager.Service.Saving
{
    public interface IMeetDBSvc : IService
    {
        bool AddMeet(Meet meet, string user);
        int FindMeetId(Meet meet);
        Meet FindMeet(int id);
        bool DeleteMeet(int id);

        bool AddBoysTeam(Meet meet);
        Dictionary<string, string> FindBoysTeam(int id);
        bool DeleteBoysTeam(int id);

        bool AddGirlsTeam(Meet meet);
        Dictionary<string, string> FindGirlsTeam(int id);
        bool DeleteGirlsTeam(int id);

        bool AddPerformances(Meet meet);
        bool AddPerformance(Meet meet, string eventName);
        Dictionary<string, List<Performance>> FindPerformances(int id);
        List<Performance> FindPerformances(int id, string eventName);
        bool DeletePerformances(int id);
        bool DeletePerformance(int id, string eventName);

        Dictionary<int, Meet> ListOfMeets(string user);
        bool ResetPrimaryKeys();
    }
}
using DMMLib;

using DualMeetManager.Service.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Business.Managers
{
    public class ScoringMgr : Manager
    {
        public IndEvent CalculateFieldEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
        {
            try
            {
                IScoringSvc scoringSvc = (IScoringSvc)GetService(typeof(IScoringSvc).Name);
                IndEvent ie = scoringSvc.CalculateFieldEvent(team1Abbr, team2Abbr, perf);
                return ie;
            }
            catch (Exception e) //Implement more specific Exceptions later
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
                return null;
            }
        }

        public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
        {
            try
            {
                IScoringSvc scoringSvc = (IScoringSvc)GetService(typeof(IScoringSvc).Name);
                IndEvent ie = scoringSvc.CalculateRunningEvent(team1Abbr, team2Abbr, perf);
                return ie;
            }
            catch (Exception e) //Implement more specific Exceptions later
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
                return null;
            }
        }

        public RelayEvent CalculateRelayEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
        {
            try
            {
                IScoringSvc scoringSvc = (IScoringSvc)GetService(typeof(IScoringSvc).Name);
                RelayEvent re = scoringSvc.CalculateRelayEvent(team1Abbr, team2Abbr, perf);
                return re;
            }
            catch (Exception e) //Implement more specific Exceptions later
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
                return null;
            }
        }

        public OverallScore CalculateTotal(OverallScore scores, string gender)
        {
            try
            {
                IScoringSvc scoringSvc = (IScoringSvc)GetService(typeof(IScoringSvc).Name);
                OverallScore os = scoringSvc.CalculateTotal(scores, gender);
                return os;
            }
            catch (Exception e) //Implement more specific Exceptions later
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
                return null;
            }
        }

        public OverallScore AddEvent(OverallScore scores, string eventName, IndEvent eventToAdd)
        {
            try
            {
                IScoringSvc scoringSvc = (IScoringSvc)GetService(typeof(IScoringSvc).Name);
                OverallScore os = scoringSvc.AddEvent(scores, eventName, eventToAdd);
                return os;
            }
            catch (Exception e) //Implement more specific Exceptions later
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
                return null;
            }
        }

        public OverallScore AddEvent(OverallScore scores, string eventName, RelayEvent eventToAdd)
        {
            try
            {
                IScoringSvc scoringSvc = (IScoringSvc)GetService(typeof(IScoringSvc).Name);
                OverallScore os = scoringSvc.AddEvent(scores, eventName, eventToAdd);
                return os;
            }
            catch (Exception e) //Implement more specific Exceptions later
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
                return null;
            }
        }
    }
}

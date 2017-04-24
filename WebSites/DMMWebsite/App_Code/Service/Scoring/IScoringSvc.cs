using DMMLib;

using System.Collections.Generic;

namespace DualMeetManager.Service.Scoring
{
    public interface IScoringSvc : IService
    {
        /// <summary>
        /// Interface for calculating points (1st, 2nd, and 3rd) for an individual running event
        /// </summary>
        /// <param name="team1Abbr">Abbr for team 1</param>
        /// <param name="team2Abbr">Abbr for team 2</param>
        /// <param name="perf">Complete list of performances for a particular running event</param>
        /// <returns>IndEvent, which holds all information ragarding this event's points</returns>
        IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf);

        /// <summary>
        /// Interface for calculating points (1st, 2nd, and 3rd) for an individual field event
        /// </summary>
        /// <param name="team1Abbr">Abbr for team 1</param>
        /// <param name="team2Abbr">Abbr for team 2</param>
        /// <param name="perf">Complete list of performances for a particular field event</param>
        /// <returns>IndEvent, which holds all information ragarding this event's points</returns>
        IndEvent CalculateFieldEvent(string team1Abbr, string team2Abbr, List<Performance> perf);

        /// <summary>
        /// Interface for calculating points (1st, and 2nd) for a relay event
        /// </summary>
        /// <param name="team1Abbr">Abbr for team 1</param>
        /// <param name="team2Abbr">Abbr for team 2</param>
        /// <param name="perf"></param>
        /// <returns>RelayEvent, which holds all information ragarding this event's points</returns>
        RelayEvent CalculateRelayEvent(string team1Abbr, string team2Abbr, List<Performance> perf);

        /// <summary>
        /// Interface for calculating The overall score of a meet
        /// </summary>
        /// <param name="scores">Overall scores</param>
        /// <param name="gender">string to hold what gender the meet is, boy's or girl's</param>
        /// <returns>OverallScore object that holds accurate overall score points</returns>
        OverallScore CalculateTotal(OverallScore scores, string gender);

        /// <summary>
        /// Interface for adding an indEvent to an OverallScore object
        /// </summary>
        /// <param name="scores">Overall scores</param>
        /// <param name="eventName">Name of the event being added</param>
        /// <param name="eventToAdd">Data for the event being added</param>
        /// <returns>OverallScore with the event added</returns>
        OverallScore AddEvent(OverallScore scores, string eventName, IndEvent eventToAdd);

        /// <summary>
        /// Interface for adding a relayEvent to an OverallScore object
        /// </summary>
        /// <param name="scores">Overall scores</param>
        /// <param name="eventName">Name of the event being added</param>
        /// <param name="eventToAdd">Data for the event being added</param>
        /// <returns>OverallScore with the event added</returns>
        OverallScore AddEvent(OverallScore scores, string eventName, RelayEvent eventToAdd);
    }
}

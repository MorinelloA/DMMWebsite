using DMMLib;

using System;
using System.Collections.Generic;

namespace DualMeetManager.Service.Printout
{
    public interface IPrintoutDocSvc : IService
    {
        /// <summary>
        /// Interface for creating a doc of individual event performances
        /// </summary>
        /// <param name="eventName">Name of the event for this printout</param>
        /// <param name="performances">List of performances for this printout</param>
        /// <returns>boolean that shows whether or not the doc was created successfully or not</returns>
        bool CreateIndEventDoc(string eventName, List<Performance> performances);

        /// <summary>
        /// Interface for creating a doc of all performances for one specific teams
        /// </summary>
        /// <param name="teamAbbr">Team to be printed</param>
        /// <param name="meetToPrint">Meet that the performances are being gathered from</param>
        /// <returns>boolean that shows whether or not the doc was created successfully or not</returns>
        bool CreateTeamPerfDoc(string teamAbbr, string gender, Meet meetToPrint);

        /// <summary>
        /// Interface for creating a doc for all scoring information for a Meet
        /// </summary>
        /// <param name="scoreToPrint">OverallScore information of the meet to be printed</param>
        /// <returns>boolean that shows whether or not the doc was created successfully or not</returns>
        bool CreateMeetResultsDoc(string gender, DateTime dt, string location, OverallScore scoreToPrint);
    }
}
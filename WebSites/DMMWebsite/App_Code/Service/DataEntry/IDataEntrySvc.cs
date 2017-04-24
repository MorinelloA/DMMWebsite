using DMMLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Service.DataEntry
{
    public interface IDataEntrySvc : IService
    {
        /// <summary>
        /// Interface for converting raw seconds into a formatted time
        /// </summary>
        /// <param name="perf">raw seconds</param>
        /// <returns>formatted time</returns>
        string ConvertToTimedData(decimal perf);

        /// <summary>
        /// Interface for converting a formatted time into raw seconds
        /// </summary>
        /// <param name="perf">formatted time</param>
        /// <returns>raw seconds</returns>
        decimal ConvertFromTimedData(string perf);

        /// <summary>
        /// Interface for converting raw inches into a formatted length
        /// </summary>
        /// <param name="perf">raw inches</param>
        /// <returns>formated length</returns>
        string ConvertToLengthData(decimal perf);

        /// <summary>
        /// Interface for converting a formatted length into raw inches
        /// </summary>
        /// <param name="perf">formatted length</param>
        /// <returns>raw inches</returns>
        decimal ConvertFromLengthData(string perf);

        //IDictionary<string, List<Performance>> is the same as Meet.performances
        //Ex: <MEET NAME>.performances = AddPerformanceToEvent(NEW DICTIONARY) 
        /// <summary>
        /// Interface for adding a single event performances to a Dictionary of events, performances
        /// </summary>
        /// <param name="perfList">Current dictionary</param>
        /// <param name="eventName">Event to add to the current dictionary</param>
        /// <param name="perfToAdd">Performance to add to the current dictionary</param>
        /// <returns>Updated Dictionary</returns>
        Dictionary<string, List<Performance>> AddPerformanceToEvent(Dictionary<string, List<Performance>> perfList, string eventName, Performance perfToAdd);

        /// <summary>
        /// Interface for adding a list of performances to a Dictionary of events, performances
        /// </summary>
        /// <param name="perfList">Current dictionary</param>
        /// <param name="eventName">Event to add to the current dictionary</param>
        /// <param name="perfsToAdd">Performances to add to the current dictionary</param>
        /// <returns>Updated Dictionary</returns>
        Dictionary<string, List<Performance>> AddPerformanceToEvent(Dictionary<string, List<Performance>> perfList, string eventName, List<Performance> perfsToAdd);
    }
}

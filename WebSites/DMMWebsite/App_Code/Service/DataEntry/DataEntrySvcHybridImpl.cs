using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DMMLib;

namespace DualMeetManager.Service.DataEntry
{
    public class DataEntrySvcHybridImpl : IDataEntrySvc
    {
        public Dictionary<string, List<Performance>> AddPerformanceToEvent(Dictionary<string, List<Performance>> perfList, string eventName, List<Performance> perfsToAdd)
        {
            return DataEntrySvcStaticImpl.AddPerformanceToEvent(perfList, eventName, perfsToAdd);
        }

        public Dictionary<string, List<Performance>> AddPerformanceToEvent(Dictionary<string, List<Performance>> perfList, string eventName, Performance perfToAdd)
        {
            return DataEntrySvcStaticImpl.AddPerformanceToEvent(perfList, eventName, perfToAdd);
        }

        public decimal ConvertFromLengthData(string perf)
        {
            return DataEntrySvcStaticImpl.ConvertFromLengthData(perf);
        }

        public decimal ConvertFromTimedData(string perf)
        {
            return DataEntrySvcStaticImpl.ConvertFromTimedData(perf);
        }

        public string ConvertToLengthData(decimal perf)
        {
            return DataEntrySvcStaticImpl.ConvertToLengthData(perf);
        }

        public string ConvertToTimedData(decimal perf)
        {
            return DataEntrySvcStaticImpl.ConvertToTimedData(perf);
        }
    }
}

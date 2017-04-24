using Newtonsoft.Json;
using System;

namespace DMMLib
{
    /// <summary>
    /// Class used to store one single performance for a particular event
    /// </summary>
    /// <remarks>You will typically see this used in a List or Dictionary</remarks>
    [Serializable]
    public class Performance
    {
        [JsonProperty(PropertyName = "athleteName")]
        public string athleteName { get; private set; }
        [JsonProperty(PropertyName = "schoolName")]
        public string schoolName { get; private set; }
        [JsonProperty(PropertyName = "heatNum")]
        public int heatNum { get; private set; }
        [JsonProperty(PropertyName = "performance")]
        public decimal performance { get; private set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Performance() { }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="athleteName">The athletes name</param>
        /// <param name="schoolName">The school the athlete is from (Abbr)</param>
        /// <param name="performance">The athlete's performance</param>
        /// <remarks>The performance will be raw data. This means that timed events will be in all seconds, as field events will be in all inches</remarks>
        public Performance(string athleteName, string schoolName, decimal performance)
        {
            this.athleteName = athleteName;
            this.schoolName = schoolName;
            this.performance = performance;
        }

        /// <summary>
        /// Parameterized constructor with heatNum. Used for running events
        /// </summary>
        /// <param name="athleteName">The athletes name</param>
        /// <param name="schoolName">The school the athlete is from (Abbr)</param>
        /// <param name="heatNum">Heat number the performance took place in</param>
        /// <param name="performance">The athlete's performance</param>
        /// <remarks>The performance will be raw data. This means that timed events will be in all seconds, as field events will be in all inches</remarks>
        public Performance(string athleteName, string schoolName, int heatNum, decimal performance)
        {
            this.athleteName = athleteName;
            this.schoolName = schoolName;
            this.heatNum = heatNum;
            this.performance = performance;
        }

        /// <summary>
        /// Method to make sure all data in the Performance class is valid
        /// </summary>
        /// <returns>true if it is a valid Performance object, false if not</returns>
        public bool validate()
        {
            if (string.IsNullOrWhiteSpace(athleteName)) return false; //Must have a name
            else if (string.IsNullOrWhiteSpace(schoolName)) return false; //Must have a school
            else if (performance <= 0) return false; //Valid time or distance is positive
            return true;
        }

        /// <summary>
        /// Prints out all the information regarding the Performance object
        /// </summary>
        /// <returns>A string with all Performance information</returns>
        public override string ToString()
        {
            //This performance will be returned as raw data (seconds and inches)

            if (heatNum == 0)
                return "Name: " + athleteName + ", " + schoolName + " - " + performance;
            else
                return "Name: " + athleteName + ", " + schoolName + " - Heat " + heatNum + " - " + performance;
        }

        /// <summary>
        /// Tests whether or not two Performance objects are equal to one another
        /// </summary>
        /// <param name="obj">obj being tested</param>
        /// <returns>true if the Performance objects are equal, false if they are not</returns>
        public override bool Equals(object obj)
        {
            Performance myPerf = obj as Performance;
            if (myPerf == null) return false;
            else if (myPerf.athleteName != athleteName) return false;
            else if (myPerf.schoolName != schoolName) return false;
            else if (myPerf.heatNum != heatNum) return false;
            else if (myPerf.performance != performance) return false;
            else return true;
        }

        /// <summary>
        /// Hashcode override
        /// </summary>
        /// <returns>The object's Hashcode</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + athleteName.GetHashCode();
                hash = hash * 23 + schoolName.GetHashCode();
                hash = hash * 23 + heatNum.GetHashCode();
                hash = hash * 23 + performance.GetHashCode();
                return hash;
            }
        }
    }
}
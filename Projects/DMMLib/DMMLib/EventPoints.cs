using System;
using System.Text;

namespace DMMLib
{
    /// <summary>
    /// Class used to store specfic place information for an event. 1st, 2nd, or 3rd
    /// </summary>
    public class EventPoints
    {
        //Team1 pts, Team2 pts, athlete name, school name, performance
        public decimal team1Pts { get; set; }
        public decimal team2Pts { get; set; }
        public string athleteName { get; set; }
        public string schoolName { get; set; }
        //Note: performance is a string because it could be in minutes and seconds (ex: 4:25)
        public string performance { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public EventPoints()
        {
            team1Pts = 0;
            team2Pts = 0;
            athleteName = "";
            schoolName = "";
            performance = "";
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="team1Pts">Amount of points team1 scored</param>
        /// <param name="team2Pts">Amount of points team2 scored</param>
        /// <param name="athleteName">The athlete's name</param>
        /// <param name="schoolName">The school name</param>
        /// <param name="performance">The performance, as a string. At this point, the raw data should have been converted</param>
        public EventPoints(decimal team1Pts, decimal team2Pts, string athleteName, string schoolName, string performance)
        {
            this.team1Pts = team1Pts;
            this.team2Pts = team2Pts;
            this.athleteName = athleteName;
            this.schoolName = schoolName;
            this.performance = performance;
        }

        /// <summary>
        /// Prints out all the information regarding the EventPoints object
        /// </summary>
        /// <returns>A string with all EventPoints information</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Athlete: " + athleteName + Environment.NewLine);
            sb.Append("School: " + schoolName + Environment.NewLine);
            sb.Append("Performance: " + performance + Environment.NewLine);
            sb.Append("Team 1 Points: " + string.Format("{0:0.##}", team1Pts) + Environment.NewLine);
            sb.Append("Team 2 Points: " + string.Format("{0:0.##}", team2Pts));
            return sb.ToString();
        }

        /// <summary>
        /// Tests whether or not two EventPoints objects are equal to one another
        /// </summary>
        /// <param name="obj">obj being tested</param>
        /// <returns>True if the EventPoints objects are equal, false if they are not</returns>
        public override bool Equals(object obj)
        {
            EventPoints myEventPoints = obj as EventPoints;
            if (myEventPoints == null && this == null) return true;
            else if (myEventPoints != null && this == null) return false;
            else if (myEventPoints == null && this != null) return false;
            else if (myEventPoints.team1Pts != team1Pts) return false;
            else if (myEventPoints.team2Pts != team2Pts) return false;
            else if (myEventPoints.athleteName != athleteName) return false;
            else if (myEventPoints.schoolName != schoolName) return false;
            else if (myEventPoints.performance != performance) return false;
            return true;
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
                hash = hash * 23 + team1Pts.GetHashCode();
                hash = hash * 23 + team2Pts.GetHashCode();
                hash = hash * 23 + athleteName.GetHashCode();
                hash = hash * 23 + schoolName.GetHashCode();
                hash = hash * 23 + performance.GetHashCode();
                return hash;
            }
        }

        //A validate method is not useful for this class
        //An object may very well be null
        //Also, because of ties, point values may be something other than the typical 5, 3, or 1
        /*public bool validate()
        {
            return true;
        }*/
    }
}
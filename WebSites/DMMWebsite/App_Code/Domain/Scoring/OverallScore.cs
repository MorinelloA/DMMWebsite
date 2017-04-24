using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DualMeetManager.Domain.Scoring
{
    /// <summary>
    /// Class used to store complete scoring information for each dual meet
    /// </summary>
    public class OverallScore
    {
        //Teams
        //Abbr, Full Name, OverallPts

        //Score cannot be changed here as Tuples are Read-Only
        //public Tuple<string, string, decimal> team1 { get; private set; }
        //public Tuple<string, string, decimal> team2 { get; private set; }

        public Tuple<string, string> team1 { get; private set; }
        public Tuple<string, string> team2 { get; private set; }

        public decimal team1Points { get; set; }
        public decimal team2Points { get; set; }

        //Event name, List of points
        public IDictionary<string, IndEvent> indEvents { get; set; }
        public IDictionary<string, RelayEvent> relayEvents { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public OverallScore(){}

        public OverallScore(Tuple<string, string> team1, Tuple<string, string> team2)
        {
            this.team1 = team1;
            this.team2 = team2;
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="team1">Team 1 Tuple (Abbr, Full Name)</param>
        /// <param name="team2">Team 2 Tuple (Abbr, Full Name)</param>
        /// <param name="indEvents">Dictionary with every individual event. Places 1st through 3rd</param>
        /// <param name="relayEvents">Dictionary with every relay event. Places 1st and 2nd</param>
        public OverallScore(Tuple<string, string> team1, Tuple<string, string> team2, IDictionary<string, IndEvent> indEvents, Dictionary<string, RelayEvent> relayEvents)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.indEvents = indEvents;
            this.relayEvents = relayEvents;
        }

        /// <summary>
        /// Parameterized Constructor with Points
        /// </summary>
        /// <param name="team1">Team 1 Tuple (Abbr, Full Name)</param>
        /// <param name="team2">Team 2 Tuple (Abbr, Full Name)</param>
        /// <param name="indEvents">Dictionary with every individual event. Places 1st through 3rd</param>
        /// <param name="relayEvents">Dictionary with every relay event. Places 1st and 2nd</param>
        /// <param name="team1Points">Total Points for Team1</param>
        /// <param name="team2Points">Total Points for Team2</param>
        public OverallScore(Tuple<string, string> team1, Tuple<string, string> team2, IDictionary<string, IndEvent> indEvents, Dictionary<string, RelayEvent> relayEvents, decimal team1Points, decimal team2Points)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.indEvents = indEvents;
            this.relayEvents = relayEvents;
            this.team1Points = team1Points;
            this.team2Points = team2Points;
        }

        /// <summary>
        /// Tests whether or not two OverallScore objects are equal to one another
        /// </summary>
        /// <param name="obj">obj being tested</param>
        /// <returns>True if the OverallScore objects are equal, false if they are not</returns>
        public override bool Equals(object obj)
        {
            //If there is a problem because of sorting Tuples, look here:
            //http://stackoverflow.com/questions/4668525/sort-listtupleint-int-in-place

            OverallScore myOverallScore = obj as OverallScore;
            if (!myOverallScore.team1.Equals(team1)) return false;
            else if (!myOverallScore.team2.Equals(team2)) return false;
            else if (!myOverallScore.indEvents.OrderBy(r => r.Key).SequenceEqual(indEvents.OrderBy(r => r.Key))) return false;
            else if (!myOverallScore.relayEvents.OrderBy(r => r.Key).SequenceEqual(relayEvents.OrderBy(r => r.Key))) return false;
            return true;
        }

        /// <summary>
        /// Prints out all the information regarding the OverallScore object
        /// </summary>
        /// <returns>A string with all OverallScore information</returns>
        public override string ToString()
        { 
            StringBuilder sb = new StringBuilder();
            sb.Append(team1.Item2 + " - " + team1.Item1 + ": " + team1Points + Environment.NewLine);
            sb.Append(team2.Item2 + " - " + team2.Item1 + ": " + team2Points + Environment.NewLine + Environment.NewLine);

            if (indEvents != null)
            {
                foreach (KeyValuePair<string, IndEvent> i in indEvents)
                {
                    sb.Append(i.Key.ToString() + Environment.NewLine);
                    sb.Append(i.Value.ToString() + Environment.NewLine);
                }
            }
            if (relayEvents != null)
            {
                foreach (KeyValuePair<string, RelayEvent> i in relayEvents)
                {
                    sb.Append(i.Key.ToString() + Environment.NewLine);
                    sb.Append(i.Value.ToString() + Environment.NewLine);
                }
            }
            return sb.ToString();
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
                hash = hash * 23 + team1.GetHashCode();
                hash = hash * 23 + team2.GetHashCode();
                hash = hash * 23 + team1Points.GetHashCode();
                hash = hash * 23 + team2Points.GetHashCode();
                hash = hash * 23 + indEvents.GetHashCode();
                hash = hash * 23 + relayEvents.GetHashCode();
                return hash;
            }
        }
    }
}
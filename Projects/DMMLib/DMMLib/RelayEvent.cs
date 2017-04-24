using System;
using System.Text;

namespace DMMLib
{
    /// <summary>
    /// Class used to determine points scored by two teams for a single relay event
    /// Stores names, schools, performances, and points for 1st, and 2nd
    /// Hold info for only relays
    /// </summary>
    public class RelayEvent
    {
        public string team1 { get; set; }
        public string team2 { get; set; }

        //Having points assigned for relays seems redundant since the winning relay gets 5pts, and the loser gets 0.
        //However, if rules were ever to change, the code would be much easier to update this way.
        //index 0 for 1st place, 1 for 2nd place
        public EventPoints[] points { get; set; }

        //Total
        //Team1 total, Team2 total
        public decimal team1Total { get; set; }
        public decimal team2Total { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RelayEvent()
        {
            points = new EventPoints[2];
            team1 = "";
            team2 = "";
            points[0] = new EventPoints(0.0m, 0.0m, "", "", "");
            points[1] = new EventPoints(0.0m, 0.0m, "", "", "");
            team1Total = 0;
            team2Total = 0;
        }

        /// <summary>
        /// Parametrerized Constructor
        /// </summary>
        /// <param name="team1">Abbr of Team 1</param>
        /// <param name="team2">Abbr of Team 2</param>
        /// <param name="firstPlacePts">Data for 1st place</param>
        /// <param name="secondPlacePts">Data for 2nd place</param>
        /// <param name="totalPts">Total points for this event by both teams</param>
        public RelayEvent(string team1, string team2, EventPoints firstPlacePts, EventPoints secondPlacePts, decimal team1Total, decimal team2Total)
        {
            points = new EventPoints[2];
            this.team1 = team1;
            this.team2 = team2;
            points[0] = firstPlacePts;
            points[1] = secondPlacePts;
            this.team1Total = team1Total;
            this.team2Total = team2Total;
        }

        /// <summary>
        /// Prints out all the information regarding the RelayEvent object
        /// </summary>
        /// <returns>A string with all RelayEvent information</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("First Place: " + points[0].athleteName + " - " + points[0].schoolName + ": " + points[0].performance + Environment.NewLine);
            sb.Append("First Place Pts: " + team1 + ": " + string.Format("{0:0.##}", points[0].team1Pts) + " " + team2 + ": " + string.Format("{0:0.##}", points[0].team2Pts) + Environment.NewLine);
            sb.Append("Second Place: " + points[1].athleteName + " - " + points[1].schoolName + ": " + points[1].performance + Environment.NewLine);
            sb.Append("Second Place Pts: " + team1 + ": " + string.Format("{0:0.##}", points[1].team1Pts) + " " + team2 + ": " + string.Format("{0:0.##}", points[1].team2Pts) + Environment.NewLine);
            sb.Append("Total: " + team1 + ": " + string.Format("{0:0.##}", team1Total) + " " + team2 + ": " + string.Format("{0:0.##}", team2Total));
            return sb.ToString();
        }

        /// <summary>
        /// Checks whether or not two RelayEvent objects are equal to one another
        /// </summary>
        /// <param name="obj">obj being tested</param>
        /// <returns>True if the RelayEvent objects are equal, false if they are not</returns>
        public override bool Equals(object obj)
        {
            RelayEvent myRelayEvent = obj as RelayEvent;
            if (!myRelayEvent.team1.Equals(team1)) return false;
            else if (!myRelayEvent.team2.Equals(team2)) return false;
            else if (!myRelayEvent.points[0].Equals(points[0])) return false;
            else if (!myRelayEvent.points[1].Equals(points[1])) return false;
            else if (myRelayEvent.team1Total != team1Total) return false;
            else if (myRelayEvent.team2Total != team2Total) return false;
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
                hash = hash * 23 + team1.GetHashCode();
                hash = hash * 23 + team2.GetHashCode();
                hash = hash * 23 + points[0].GetHashCode();
                hash = hash * 23 + points[1].GetHashCode();
                hash = hash * 23 + team1Total.GetHashCode();
                hash = hash * 23 + team2Total.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Method to make sure all data in the RelayEvent object is valid
        /// </summary>
        /// <returns>true if it is a valid RelayEvent, false if not</returns>
        public bool validate()
        {
            if (points[0].team1Pts + points[1].team1Pts != team1Total) return false; //Team1 points don't match
            else if (points[0].team2Pts + points[1].team2Pts != team2Total) return false; //Team2 points don't match
            else if (points[0].team1Pts + points[1].team1Pts + +points[0].team2Pts + points[1].team2Pts > 5) return false; //Check if an event is awarding more than 9 points
            else if (team1Total + team2Total > 5) return false; //Redundant if statement
            else if (string.IsNullOrWhiteSpace(team1)) return false; //team1 must have a name
            else if (string.IsNullOrWhiteSpace(team2)) return false; //team2 must have a name
            else if ((string.IsNullOrWhiteSpace(points[0].athleteName) && !string.IsNullOrWhiteSpace(points[0].schoolName)) || (!string.IsNullOrWhiteSpace(points[0].athleteName) && string.IsNullOrWhiteSpace(points[0].schoolName))) return false; //If name or school are null, the other must be null as well
            else if ((string.IsNullOrWhiteSpace(points[1].athleteName) && !string.IsNullOrWhiteSpace(points[1].schoolName)) || (!string.IsNullOrWhiteSpace(points[1].athleteName) && string.IsNullOrWhiteSpace(points[1].schoolName))) return false; //If name or school are null, the other must be null as well
            else if ((string.IsNullOrWhiteSpace(points[0].athleteName) || string.IsNullOrWhiteSpace(points[0].schoolName)) && (points[0].team1Pts + points[0].team2Pts != 0)) return false; //No name with points being distributed 
            else if ((string.IsNullOrWhiteSpace(points[1].athleteName) || string.IsNullOrWhiteSpace(points[1].schoolName)) && (points[1].team1Pts + points[1].team2Pts != 0)) return false; //No name with points being distributed
            else if (!string.IsNullOrWhiteSpace(points[0].athleteName) && (points[0].team1Pts + points[0].team2Pts == 0)) return false; //Name without distributing any points
            else if (points[1].team1Pts > 0 || points[1].team2Pts > 0) return false; //second place has points
            return true;
        }
    }
}
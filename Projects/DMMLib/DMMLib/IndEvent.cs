using System;
using System.Text;

namespace DMMLib
{
    /// <summary>
    /// Class used to determine points scored by two teams for a single individual event
    /// Stores names, schools, performances, and points for 1st, 2nd, and 3rd
    /// Hold info for both running and field events. Does not include relays
    /// </summary>
    public class IndEvent
    {
        //Team Abbr
        public string team1 { get; set; }
        public string team2 { get; set; }

        //index 0 for 1st place, 1 for 2nd place, 2 for 3rd place
        public EventPoints[] points { get; set; }

        //Total
        //Team1 total, Team2 total
        public decimal team1Total { get; set; }
        public decimal team2Total { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public IndEvent()
        {
            points = new EventPoints[3];
            team1 = "";
            team2 = "";
            points[0] = new EventPoints(0.0m, 0.0m, "", "", "");
            points[1] = new EventPoints(0.0m, 0.0m, "", "", "");
            points[2] = new EventPoints(0.0m, 0.0m, "", "", "");
            team1Total = 0.0m;
            team2Total = 0.0m;
        }

        /// <summary>
        /// Constructor without points
        /// </summary>
        /// <param name="team1">Abbr of Team1</param>
        /// <param name="team2">Abbr of Team2</param>
        public IndEvent(string team1, string team2)
        {
            points = new EventPoints[3];
            this.team1 = team1;
            this.team2 = team2;
            this.points[0] = new EventPoints(0.0m, 0.0m, "", "", "");
            this.points[1] = new EventPoints(0.0m, 0.0m, "", "", "");
            this.points[2] = new EventPoints(0.0m, 0.0m, "", "", "");
            this.team1Total = 0.0m;
            this.team2Total = 0.0m;

        }

        /// <summary>
        /// Constructor that includes points
        /// </summary>
        /// <param name="team1">Abbr of Team1</param>
        /// <param name="team2">Abbr of Team2</param>
        /// <param name="firstPlacePts">Data for first place</param>
        /// <param name="secondPlacePts">Data for second place</param>
        /// <param name="thirdPlacePts">Data for third place</param>
        /// <param name="team1Total">Total points for this event by team1</param>
        /// <param name="team2Total">Total points for this event by team2</param>
        public IndEvent(string team1, string team2, EventPoints firstPlacePts, EventPoints secondPlacePts, EventPoints thirdPlacePts, decimal team1Total, decimal team2Total)
        {
            points = new EventPoints[3];
            this.team1 = team1;
            this.team2 = team2;
            points[0] = firstPlacePts;
            points[1] = secondPlacePts;
            points[2] = thirdPlacePts;
            this.team1Total = team1Total;
            this.team2Total = team2Total;
        }

        /// <summary>
        /// Parameterized constructor with EventPoints array
        /// </summary>
        /// <param name="team1">Abbr of Team1</param>
        /// <param name="team2">Abbr of Team2</param>
        /// <param name="points">Array with points</param>
        /// <param name="totalPts">Total points for this event by both teams</param>
        public IndEvent(string team1, string team2, EventPoints[] points, decimal team1Total, decimal team2Total)
        {
            this.points = new EventPoints[3];
            this.team1 = team1;
            this.team2 = team2;
            this.points = points;
            this.team1Total = team1Total;
            this.team2Total = team2Total;
        }

        /// <summary>
        /// Prints out all the information regarding the IndEvent object
        /// </summary>
        /// <returns>A string with all IndEvent information</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("First Place: " + points[0].athleteName + " - " + points[0].schoolName + ": " + points[0].performance + Environment.NewLine);
            sb.Append("First Place Pts: " + team1 + ": " + string.Format("{0:0.##}", points[0].team1Pts) + " " + team2 + ": " + string.Format("{0:0.##}", points[0].team2Pts) + Environment.NewLine);
            sb.Append("Second Place: " + points[1].athleteName + " - " + points[1].schoolName + ": " + points[1].performance + Environment.NewLine);
            sb.Append("Second Place Pts: " + team1 + ": " + string.Format("{0:0.##}", points[1].team1Pts) + " " + team2 + ": " + string.Format("{0:0.##}", points[1].team2Pts) + Environment.NewLine);
            sb.Append("Third Place: " + points[2].athleteName + " - " + points[2].schoolName + ": " + points[2].performance + Environment.NewLine);
            sb.Append("Third Place Pts: " + team1 + ": " + string.Format("{0:0.##}", points[2].team1Pts) + " " + team2 + ": " + string.Format("{0:0.##}", points[2].team2Pts) + Environment.NewLine);
            sb.Append("Total: " + team1 + ": " + string.Format("{0:0.##}", team1Total) + " " + team2 + ": " + string.Format("{0:0.##}", team2Total));
            return sb.ToString();
        }

        /// <summary>
        /// Checkes whether or not two IndEvent objects are equal to one another
        /// </summary>
        /// <param name="obj">obj being tested</param>
        /// <returns>True if the IndEvent objects are equal, false if they are not</returns>
        public override bool Equals(object obj)
        {
            IndEvent myIndEvent = obj as IndEvent;
            if (myIndEvent == null && this == null) return true;
            else if (myIndEvent != null && this == null) return false;
            else if (myIndEvent == null && this != null) return false;
            else if (!myIndEvent.team1.Equals(team1)) return false;
            else if (!myIndEvent.team2.Equals(team2)) return false;
            else if (!myIndEvent.points[0].Equals(points[0])) return false;
            else if (!myIndEvent.points[1].Equals(points[1])) return false;
            else if (!myIndEvent.points[2].Equals(points[2])) return false;
            else if (myIndEvent.team1Total != team1Total) return false;
            else if (myIndEvent.team2Total != team2Total) return false;
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
                hash = hash * 23 + points[2].GetHashCode();
                hash = hash * 23 + team1Total.GetHashCode();
                hash = hash * 23 + team2Total.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Method to make sure all data in the IndEvent object is valid
        /// </summary>
        /// <returns>true if it is a valid IndEvent, false if not</returns>
        public bool validate()
        {
            //Following 2 lines could be true if total aren't calculated yet
            if (points[0].team1Pts + points[1].team1Pts + points[2].team1Pts != team1Total) return false; //Team1 points don't match
            else if (points[0].team2Pts + points[1].team2Pts + points[2].team2Pts != team2Total) return false; //Team2 points don't match
            else if (points[0].team1Pts + points[1].team1Pts + points[2].team1Pts + points[0].team2Pts + points[1].team2Pts + points[2].team2Pts > 9) return false; //Check if an event is awarding more than 9 points
            else if (team1Total + team2Total > 9) return false; //Redundant if statement
            else if (string.IsNullOrWhiteSpace(team1)) return false; //team1 must have a name
            else if (string.IsNullOrWhiteSpace(team2)) return false; //team2 must have a name
            else if ((string.IsNullOrWhiteSpace(points[0].athleteName) && !string.IsNullOrWhiteSpace(points[0].schoolName)) || (!string.IsNullOrWhiteSpace(points[0].athleteName) && string.IsNullOrWhiteSpace(points[0].schoolName))) return false; //If name or school are null, the other must be null as well
            else if ((string.IsNullOrWhiteSpace(points[1].athleteName) && !string.IsNullOrWhiteSpace(points[1].schoolName)) || (!string.IsNullOrWhiteSpace(points[1].athleteName) && string.IsNullOrWhiteSpace(points[1].schoolName))) return false; //If name or school are null, the other must be null as well
            else if ((string.IsNullOrWhiteSpace(points[2].athleteName) && !string.IsNullOrWhiteSpace(points[2].schoolName)) || (!string.IsNullOrWhiteSpace(points[2].athleteName) && string.IsNullOrWhiteSpace(points[2].schoolName))) return false; //If name or school are null, the other must be null as well
            else if ((string.IsNullOrWhiteSpace(points[0].athleteName) || string.IsNullOrWhiteSpace(points[0].schoolName)) && (points[0].team1Pts + points[0].team2Pts != 0)) return false; //No name with points being distributed 
            else if ((string.IsNullOrWhiteSpace(points[1].athleteName) || string.IsNullOrWhiteSpace(points[1].schoolName)) && (points[1].team1Pts + points[1].team2Pts != 0)) return false; //No name with points being distributed
            else if ((string.IsNullOrWhiteSpace(points[2].athleteName) || string.IsNullOrWhiteSpace(points[2].schoolName)) && (points[2].team1Pts + points[2].team2Pts != 0)) return false; //No name with points being distributed
            else if (!string.IsNullOrWhiteSpace(points[0].athleteName) && (points[0].team1Pts + points[0].team2Pts == 0)) return false; //Name without distributing any points
            else if (!string.IsNullOrWhiteSpace(points[1].athleteName) && (points[1].team1Pts + points[1].team2Pts == 0)) return false; //Name without distributing any points
            else if (!string.IsNullOrWhiteSpace(points[2].athleteName) && (points[2].team1Pts + points[2].team2Pts == 0)) return false; //Name without distributing any points
            return true;
        }
    }
}
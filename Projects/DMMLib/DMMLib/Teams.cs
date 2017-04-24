using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMMLib
{
    /// <summary>
    /// Contains information specific to Boy and Girl teams competing in the meet
    /// </summary>
    [Serializable]
    public class Teams
    {
        //Key is a three letter Abbr, Value is the full name
        //The Abbr is used for printout where full names could compromise the document
        [JsonProperty(PropertyName = "boySchoolNames")]
        public Dictionary<string, string> boySchoolNames { get; private set; }
        [JsonProperty(PropertyName = "girlSchoolNames")]
        public Dictionary<string, string> girlSchoolNames { get; private set; }

        /// <summary>
        /// Default Constructor for Teams
        /// </summary>
        public Teams() { }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="boySchoolNames">Dictionary of Boy's Team Abbr and Full names</param>
        /// <param name="girlSchoolNames">Dictionary of Girl's Team Abbr and Full names</param>
        public Teams(Dictionary<string, string> boySchoolNames, Dictionary<string, string> girlSchoolNames)
        {
            this.boySchoolNames = boySchoolNames;
            this.girlSchoolNames = girlSchoolNames;
        }

        /// <summary>
        /// Method to make sure all data in the Teams class is valid
        /// </summary>
        /// <returns>true if it is a valid Teams object, false if not</returns>
        public bool validate()
        {
            if (boySchoolNames == null && girlSchoolNames == null) return false; //Must have either a boy or girl team
            else if (boySchoolNames.Keys.Count() != boySchoolNames.Keys.Distinct().Count()) return false; //Duplicates Exist
            else if (boySchoolNames.Values.Count() != boySchoolNames.Values.Distinct().Count()) return false; //Duplicates Exist
            else if (girlSchoolNames.Keys.Count() != girlSchoolNames.Keys.Distinct().Count()) return false; //Duplicates Exist
            else if (girlSchoolNames.Values.Count() != girlSchoolNames.Values.Distinct().Count()) return false; //Duplicates Exist

            foreach (KeyValuePair<string, string> i in boySchoolNames)
            {
                if (string.IsNullOrWhiteSpace(i.Key)) return false;
                else if (string.IsNullOrWhiteSpace(i.Value)) return false;
                else if (i.Key.Length > 3) return false;
            }

            foreach (KeyValuePair<string, string> i in girlSchoolNames)
            {
                if (string.IsNullOrWhiteSpace(i.Key)) return false;
                else if (string.IsNullOrWhiteSpace(i.Value)) return false;
                else if (i.Key.Length > 3) return false;
            }

            return true;
        }

        /// <summary>
        /// Prints out all the information regarding the Teams object
        /// </summary>
        /// <returns>A string with all Teams information</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Teams:");
            sb.Append(Environment.NewLine + "Boys:");
            if (boySchoolNames != null)
            {
                foreach (KeyValuePair<string, string> i in boySchoolNames)
                {
                    sb.Append(Environment.NewLine + i.Value + " - " + i.Key);
                }
            }

            sb.Append(Environment.NewLine + "Girls:");
            if (girlSchoolNames != null)
            {
                foreach (KeyValuePair<string, string> i in girlSchoolNames)
                {
                    sb.Append(Environment.NewLine + i.Value + " - " + i.Key);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Tests whether or not two Teams objects are equal to one another
        /// </summary>
        /// <param name="obj">obj being tested</param>
        /// <returns>True if the Teams objects are equal, false if they are not</returns>
        public override bool Equals(object obj)
        {
            Teams myTeams = obj as Teams;
            if (myTeams == null) return false;
            else if (myTeams.boySchoolNames == null && boySchoolNames != null) return false;
            else if (myTeams.boySchoolNames != null && boySchoolNames == null) return false;
            else if (myTeams.girlSchoolNames == null && girlSchoolNames != null) return false;
            else if (myTeams.girlSchoolNames != null && girlSchoolNames == null) return false;
            else if (myTeams.boySchoolNames == null && boySchoolNames == null && myTeams.girlSchoolNames == null && girlSchoolNames == null) return true;
            else if (!myTeams.boySchoolNames.OrderBy(r => r.Key).SequenceEqual(boySchoolNames.OrderBy(r => r.Key))) return false;
            else if (!myTeams.girlSchoolNames.OrderBy(r => r.Key).SequenceEqual(girlSchoolNames.OrderBy(r => r.Key))) return false;
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
                hash = hash * 23 + boySchoolNames.GetHashCode();
                hash = hash * 23 + girlSchoolNames.GetHashCode();
                return hash;
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMMLib
{
    /// <summary>Holds all information relevant to a track meet's data</summary>
    /// <remarks>Does not hold information scoring information, that is done in seperate classes</remarks>
    [Serializable]
    public class Meet
    {
        [JsonProperty(PropertyName = "dateOfMeet")]
        public DateTime dateOfMeet { get; set; }
        [JsonProperty(PropertyName = "location")]
        public string location { get; set; }
        [JsonProperty(PropertyName = "weatherConditions")]
        public string weatherConditions { get; set; }
        [JsonProperty(PropertyName = "schoolNames")]
        public Teams schoolNames { get; set; }

        //The string in this dictionary is the event name
        [JsonProperty(PropertyName = "performances")]
        public Dictionary<string, List<Performance>> performances { get; set; }

        /// <summary>
        /// Default Constructor for Meet
        /// </summary>
        public Meet() { }

        /// <summary>
        /// Constructor used for a new meet
        /// </summary>
        /// <param name="dateOfMeet">Date for the meet</param>
        /// <param name="location">Where the meet took place</param>
        /// <param name="weatherConditions">What the weather conditions were like</param>
        /// <param name="schoolNames">Schools competing</param>
        /// <remarks>As this is for a new meet, performances will be added in later</remarks>
        public Meet(DateTime dateOfMeet, string location, string weatherConditions, Teams schoolNames)
        {
            this.dateOfMeet = dateOfMeet;
            this.location = location;
            this.weatherConditions = weatherConditions;
            this.schoolNames = schoolNames;
        }

        /// <summary>
        /// Constructor used for an existing meet
        /// </summary>
        /// <param name="dateOfMeet">Date for the meet</param>
        /// <param name="location">Where the meet took place</param>
        /// <param name="weatherConditions">What the weather conditions were like</param>
        /// <param name="schoolNames">Schools competing</param>
        /// <param name="performances">List of performances for every event and competitor</param>
        public Meet(DateTime dateOfMeet, string location, string weatherConditions, Teams schoolNames, Dictionary<string, List<Performance>> performances)
        {
            this.dateOfMeet = dateOfMeet;
            this.location = location;
            this.weatherConditions = weatherConditions;
            this.schoolNames = schoolNames;
            this.performances = performances;
        }

        /// <summary>
        /// Method to make sure all data in the Meet class is valid
        /// </summary>
        /// <returns>true if it is a valid Meet, false if not</returns>
        public bool validate()
        {
            if (dateOfMeet == DateTime.MinValue) return false; //Invalid Date
            else if (string.IsNullOrWhiteSpace(location)) return false; //No location given
            else if (string.IsNullOrWhiteSpace(weatherConditions)) return false; //No Weather conditions given
            else if (schoolNames == null) return false; //No school names
            else if (!schoolNames.validate()) return false; //Invalid school names

            if (performances != null) //This is allowed
            {
                //Check for incorrect event name
                //Array with valid event names
                string[] validEvents = {"Boy's 100", "Boy's 200", "Boy's 400",
                    "Boy's 800", "Boy's 1600", "Boy's 3200", "Boy's HH", "Boy's 300H", "Boy's 4x100",
                    "Boy's 4x400", "Boy's 4x800", "Boy's LJ", "Boy's TJ", "Boy's HJ",
                    "Boy's PV", "Boy's ShotPut", "Boy's Discus", "Boy's Javelin",
                    "Girl's 100", "Girl's 200", "Girl's 400",
                    "Girl's 800", "Girl's 1600", "Girl's 3200", "Girl's HH", "Girl's 300H", "Girl's 4x100",
                    "Girl's 4x400", "Girl's 4x800", "Girl's LJ", "Girl's TJ", "Girl's HJ",
                    "Girl's PV", "Girl's ShotPut", "Girl's Discus", "Girl's Javelin"};
                foreach (KeyValuePair<string, List<Performance>> i in performances)
                {
                    //If the key is not a valid event
                    if (!validEvents.Any(i.Key.Contains)) return false;
                }

                //foreach(Event i in events)
                foreach (KeyValuePair<string, List<Performance>> i in performances)
                {
                    foreach (Performance j in i.Value)
                        if (!j.validate()) return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Prints out all the information regarding the meet
        /// </summary>
        /// <returns>A string with all Meet information</returns>
        public override string ToString()
        {
            if (this == null)
            {
                return "Meet is empty";
            }
            else
            {
                StringBuilder str = new StringBuilder();
                str.Append("Date: " + String.Format("{0:MM/dd/yyyy}", dateOfMeet));
                str.Append(Environment.NewLine + "Location: " + location);
                str.Append(Environment.NewLine + "Weather Conditions: " + weatherConditions);

                if (schoolNames != null)
                    str.Append(Environment.NewLine + schoolNames.ToString());

                if (performances != null)
                {
                    foreach (KeyValuePair<string, List<Performance>> i in performances)
                    {
                        str.Append(Environment.NewLine + "Event: " + i.Key.ToString());
                        foreach (Performance j in i.Value)
                        {
                            str.Append(Environment.NewLine + j.ToString());
                        }
                    }
                }

                return str.ToString();
            }
        }

        /// <summary>
        /// Tests whether or not two Meet objects are equal to one another
        /// </summary>
        /// <param name="obj">obj being tested</param>
        /// <returns>True if the Meet objects are equal, false if they are not</returns>
        public override bool Equals(object obj)
        {
            Meet myMeet = obj as Meet;
            if (myMeet == null) return false;
            else if (!myMeet.dateOfMeet.Equals(dateOfMeet)) return false;
            else if (myMeet.location != location) return false;
            else if (myMeet.weatherConditions != weatherConditions) return false;
            else if (!myMeet.schoolNames.Equals(schoolNames)) return false;
            else if (myMeet.performances == null && performances == null) return true; //events could be null
            else if (myMeet.performances == null && performances != null) return false;
            else if (myMeet.performances != null && performances == null) return false;
            //else if (!myMeet.performances.OrderBy(r => r.Key).SequenceEqual(performances.OrderBy(r => r.Key))) return false;

            if (myMeet.performances.Count == performances.Count) // Require equal count.
            {
                foreach (var pair in myMeet.performances)
                {
                    List<Performance> value;
                    if (performances.TryGetValue(pair.Key, out value))
                    {
                        // Require value be equal.
                        if (!value.OrderBy(r => r.performance).SequenceEqual(pair.Value.OrderBy(r => r.performance)))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        // Require key be present.
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            //
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
                hash = hash * 23 + dateOfMeet.GetHashCode();
                hash = hash * 23 + location.GetHashCode();
                hash = hash * 23 + weatherConditions.GetHashCode();
                hash = hash * 23 + schoolNames.GetHashCode();
                hash = hash * 23 + performances.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Adds or Overrides a list of performances to a particular event
        /// </summary>
        /// <param name="eventName">Event that is being contested</param>
        /// <param name="pta">Performances to add</param>
        /// <remarks>THIS METHOD IS OUT OF PLACE. BELONGS IN SERVICE LAYER</remarks>
        public void AddPerformance(string eventName, List<Performance> pta)
        {
            if (performances.ContainsKey(eventName)) //contains event, override
                performances[eventName] = pta;
            else //does not already contain event
                performances.Add(eventName, pta);
        }
    }
}
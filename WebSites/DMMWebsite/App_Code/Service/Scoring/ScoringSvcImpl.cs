using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMMLib;

using DualMeetManager.Service.DataEntry;
using System.Reflection;
using DualMeetManager.Business.Exceptions;

namespace DualMeetManager.Service.Scoring
{
    /// <summary>
    /// Implementation for scoring all Meet data
    /// </summary>
    public class ScoringSvcImpl : IScoringSvc
    {
        /// <summary>
        /// Helper Method for Calculating Individual Event (Not Relay)
        /// </summary>
        /// <param name="team1Abbr">Abbreviation for Team #1</param>
        /// <param name="team2Abbr">Abbreviation for Team #2</param>
        /// <param name="teams1and2">Sorted List (Ascending or Descending, depending on event) of Performances for Teams 1 & 2</param>
        /// <returns>IndEvent, which holds all information ragarding this event's points</returns>
        /// <remarks>Does NOT include a way to determine Ties for Field Events. This must be implemented later by another Method</remarks>
        public static IndEvent CalculateIndEventInOrder(string team1Abbr, string team2Abbr, List<Performance> teams1and2)
        {
            //
            //gather info for 1st 2nd and 3rd
            //
            IndEvent eventToReturn = new IndEvent();
            eventToReturn.team1 = team1Abbr;
            eventToReturn.team2 = team2Abbr;

            List<int> firstPlaceHeats = new List<int>();
            List<int> secondPlaceHeats = new List<int>();
            List<int> thirdPlaceHeats = new List<int>();

            decimal firstPlacePerf = 0;
            decimal secondPlacePerf = 0;
            decimal thirdPlacePerf = 0;

            //First place performance
            if (teams1and2.Count > 0)
            {
                firstPlacePerf = teams1and2[0].performance;
                firstPlaceHeats.Add(teams1and2[0].heatNum);

                for (int i = 1; i < teams1and2.Count; i++)
                {
                    if (teams1and2[i].performance == firstPlacePerf)
                    {
                        //check heatnum
                        if (firstPlaceHeats.Contains(teams1and2[i].heatNum)) //check if it is already a 2nd item
                        {
                            if (secondPlaceHeats.Contains(teams1and2[i].heatNum)) //check if it is already a 3rd item
                            {
                                if (!thirdPlaceHeats.Contains(teams1and2[i].heatNum))
                                {
                                    thirdPlaceHeats.Add(teams1and2[i].heatNum);
                                    thirdPlacePerf = teams1and2[0].performance;
                                }
                            }
                            else
                            {
                                secondPlaceHeats.Add(teams1and2[i].heatNum);
                                secondPlacePerf = teams1and2[0].performance;
                            }
                        }
                        else
                        {
                            firstPlaceHeats.Add(teams1and2[i].heatNum);
                        }
                    }
                }

                //Check if 3 or more firsts
                //Should have no 2nds or 3rds
                if (firstPlaceHeats.Count >= 3)
                {
                    secondPlaceHeats.Clear();
                    thirdPlaceHeats.Clear();
                    secondPlacePerf = 0;
                    thirdPlacePerf = 0;
                }

                //Check if 2 firsts
                //Should have no 2nd, its should become third
                if (firstPlaceHeats.Count == 2)
                {
                    thirdPlaceHeats.Clear();
                    thirdPlaceHeats.AddRange(secondPlaceHeats);
                    secondPlaceHeats.Clear();
                    thirdPlacePerf = secondPlacePerf;
                    secondPlacePerf = 0;
                }

                //Check if 2 or more seconds
                //Should have no 3rds
                if (secondPlaceHeats.Count >= 2)
                {
                    thirdPlaceHeats.Clear();
                    thirdPlacePerf = 0;
                }

                //Check if second place was not already found, at least 2 performances, and not more than one firstPlace
                if (!(secondPlaceHeats.Count > 0 || teams1and2.Count <= 1 || firstPlaceHeats.Count > 1))
                {
                    secondPlacePerf = teams1and2[1].performance;
                    secondPlaceHeats.Add(teams1and2[1].heatNum);

                    for (int i = 2; i < teams1and2.Count; i++)
                    {
                        if (teams1and2[i].performance == secondPlacePerf)
                        {
                            //check heatnum
                            if (secondPlaceHeats.Contains(teams1and2[i].heatNum)) //check if it is already a 3rd item
                            {
                                if (!thirdPlaceHeats.Contains(teams1and2[i].heatNum))
                                {
                                    thirdPlaceHeats.Add(teams1and2[i].heatNum);
                                    thirdPlacePerf = teams1and2[i].performance;
                                }
                            }
                            else
                            {
                                secondPlaceHeats.Add(teams1and2[i].heatNum);
                                secondPlacePerf = teams1and2[i].performance;
                            }
                        }
                    }
                }
                else
                {
                    //This means that there were either 2 or more firsts, or second place was already found (same time + same heat)
                }

                //Check if third place was not already found and at least 3 performances
                if (!(thirdPlaceHeats.Count > 0 || teams1and2.Count <= 2 || secondPlaceHeats.Count + firstPlaceHeats.Count > 2))
                {
                    thirdPlacePerf = teams1and2[2].performance;
                    thirdPlaceHeats.Add(teams1and2[2].heatNum);

                    for (int i = 3; i < teams1and2.Count; i++)
                    {
                        if (teams1and2[i].performance == thirdPlacePerf)
                        {
                            //check heatnum
                            if (!thirdPlaceHeats.Contains(teams1and2[i].heatNum))
                            {
                                thirdPlaceHeats.Add(teams1and2[i].heatNum);
                                thirdPlacePerf = teams1and2[i].performance;
                            }
                        }
                    }
                }
                else
                {
                    //Third place should not be calculated because of ties with 1st and/or 2nd
                }


            }
            else //No performances for either team. Uncontested Event
            {
                //null object. needs created here
                Console.WriteLine("No performances for this event. Returning null IndEvent");
                eventToReturn = new IndEvent();
                //Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Console.WriteLine("Leaving " + MethodBase.GetCurrentMethod().DeclaringType + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return eventToReturn;
            }


            //Check for redundancy, or in wrong place.
            //This code is also above. MAY be needed again.
            //Check if 3 or more firsts
            //Should have no 2nds or 3rds
            /*if (firstPlaceHeats.Count >= 3)
            {
                secondPlaceHeats.Clear();
                thirdPlaceHeats.Clear();
                secondPlacePerf = 0;
                thirdPlacePerf = 0;
            }

            //Check if 2 firsts
            //Should have no 2nd, its should become third
            if (firstPlaceHeats.Count == 2)
            {
                thirdPlaceHeats.Clear();
                thirdPlaceHeats.AddRange(secondPlaceHeats);
                secondPlaceHeats.Clear();
                thirdPlacePerf = secondPlacePerf;
                secondPlacePerf = 0;
            }

            //Check if 2 or more seconds
            //Should have no 3rds
            if (secondPlaceHeats.Count >= 2)
            {
                thirdPlaceHeats.Clear();
                thirdPlacePerf = 0;
            }*/
            //End code check

            //
            //Populate IndEvent object
            //

            //Algorithm used to resort list if multiple same performances in same and different heats
            //Assumes list was originally organized by heats
            bool stopLoop = false;
            do
            {
                stopLoop = false;
                for (int i = 1; i < teams1and2.Count - 1; i++)
                {
                    if (teams1and2[i - 1].performance == teams1and2[i].performance && teams1and2[i - 1].heatNum == teams1and2[i].heatNum && teams1and2[i].performance == teams1and2[i + 1].performance && teams1and2[i].heatNum != teams1and2[i + 1].heatNum)
                    {
                        Performance temp = teams1and2[i];
                        teams1and2[i] = teams1and2[i + 1];
                        teams1and2[i + 1] = temp;
                        stopLoop = true;
                    }
                }
            } while (stopLoop);

            //ints used if dividing by them near the end of the method
            //Avoids Divide by zero errors because the ints in the Lists are about to be removed
            int numFirstPlaces = firstPlaceHeats.Count;
            int numSecondPlaces = secondPlaceHeats.Count;
            int numThirdPlaces = thirdPlaceHeats.Count;

            //Use this to convert into strings for EventPoints objects 
            DataEntrySvcImpl DESI = new DataEntrySvcImpl();

            EventPoints firstEventPoints = new EventPoints();
            EventPoints secondEventPoints = new EventPoints();
            EventPoints thirdEventPoints = new EventPoints();

            //first place EventPoints
            if (firstPlacePerf != 0)
            {
                firstEventPoints.performance = DESI.ConvertToTimedData(firstPlacePerf);
                if (firstPlaceHeats.Count > 1)
                {
                    Console.WriteLine(numFirstPlaces + "-Way Tie for 1st");
                    firstEventPoints.athleteName = "TIE";
                    firstEventPoints.schoolName = "TIE";
                    //Calculate Tie info

                    //Two-Way Tie
                    if (firstPlaceHeats.Count == 2)
                    {
                        foreach (Performance p in teams1and2)
                        {
                            if (p.performance == firstPlacePerf && firstPlaceHeats.Contains(p.heatNum))
                            {
                                //test taking out p.heatNum here
                                //Not sure if this is correct
                                firstPlaceHeats.Remove(p.heatNum);

                                if (p.schoolName == team1Abbr)
                                {
                                    firstEventPoints.team1Pts += 4;
                                }
                                else if (p.schoolName == team2Abbr)
                                {
                                    firstEventPoints.team2Pts += 4;
                                }
                                else
                                {
                                    Console.WriteLine("ERROR! This code should be unreachable!");
                                    throw new TeamNotFoundException(p.schoolName + " does not equal " + team1Abbr + " or " + team2Abbr);
                                }
                            }
                        }
                    }
                    //More than Two-Way Tie
                    else if (firstPlaceHeats.Count >= 2)
                    {
                        foreach (Performance p in teams1and2)
                        {
                            if (p.performance == firstPlacePerf && firstPlaceHeats.Contains(p.heatNum))
                            {
                                //test taking out p.heatNum here
                                //Not sure if this is correct
                                firstPlaceHeats.Remove(p.heatNum);

                                if (p.schoolName == team1Abbr)
                                {
                                    firstEventPoints.team1Pts += (9.0m / numFirstPlaces);
                                }
                                else if (p.schoolName == team2Abbr)
                                {
                                    firstEventPoints.team2Pts += (9.0m / numFirstPlaces);
                                }
                                else
                                {
                                    Console.WriteLine("ERROR! This code should be unreachable!");
                                    throw new TeamNotFoundException(p.schoolName + " does not equal " + team1Abbr + " or " + team2Abbr);
                                }
                            }
                        }
                    }
                }
                else
                {
                    //Populate regular non-tie info
                    firstEventPoints.athleteName = teams1and2[0].athleteName;
                    firstEventPoints.schoolName = teams1and2[0].schoolName;
                    if (firstEventPoints.schoolName == team1Abbr)
                    {
                        firstEventPoints.team1Pts = 5;
                        firstEventPoints.team2Pts = 0;
                    }
                    else if (firstEventPoints.schoolName == team2Abbr)
                    {
                        firstEventPoints.team1Pts = 0;
                        firstEventPoints.team2Pts = 5;
                    }
                    else
                    {
                        Console.WriteLine("ERROR! This code should be unreachable!");
                        throw new TeamNotFoundException(firstEventPoints.schoolName + " does not equal " + team1Abbr + " or " + team2Abbr);
                    }
                }
            }
            else
            {
                firstEventPoints.performance = "";
                firstEventPoints.athleteName = "";
                firstEventPoints.schoolName = "";
                firstEventPoints.team1Pts = 0;
                firstEventPoints.team2Pts = 0;
            }

            //secondplace EventPoints
            if (secondPlacePerf != 0)
            {
                secondEventPoints.performance = DESI.ConvertToTimedData(secondPlacePerf);
                if (secondPlaceHeats.Count > 1)
                {
                    Console.WriteLine(numSecondPlaces + "-Way Tie for 2nd");
                    secondEventPoints.athleteName = "TIE";
                    secondEventPoints.schoolName = "TIE";
                    //Calculate Tie info
                    foreach (Performance p in teams1and2)
                    {
                        if (p.performance == secondPlacePerf && secondPlaceHeats.Contains(p.heatNum))
                        {
                            //test taking out p.heatNum here
                            //Not sure if this is correct
                            secondPlaceHeats.Remove(p.heatNum);

                            if (p.schoolName == team1Abbr)
                            {
                                secondEventPoints.team1Pts += (4.0m / numSecondPlaces);
                            }
                            else if (p.schoolName == team2Abbr)
                            {
                                secondEventPoints.team2Pts += (4.0m / numSecondPlaces);
                            }
                            else
                            {
                                Console.WriteLine("ERROR! This code should be unreachable!");
                                throw new TeamNotFoundException(p.schoolName + " does not equal " + team1Abbr + " or " + team2Abbr);
                            }
                        }
                    }
                }
                else
                {
                    //Populate regular non-tie info
                    for (int i = 1; i < teams1and2.Count; i++)
                    {
                        if (teams1and2[i].performance == secondPlacePerf)
                        {
                            secondEventPoints.athleteName = teams1and2[i].athleteName;
                            secondEventPoints.schoolName = teams1and2[i].schoolName;
                            break; //break added, same perf same heat error without
                        }
                    }

                    if (secondEventPoints.schoolName == team1Abbr)
                    {
                        secondEventPoints.team1Pts = 3;
                        secondEventPoints.team2Pts = 0;
                    }
                    else if (secondEventPoints.schoolName == team2Abbr)
                    {
                        secondEventPoints.team1Pts = 0;
                        secondEventPoints.team2Pts = 3;
                    }
                    else
                    {
                        Console.WriteLine("ERROR! Second Place Points being assigned to an incorrect team name");
                        throw new TeamNotFoundException(secondEventPoints.schoolName + " does not equal " + team1Abbr + " or " + team2Abbr);
                    }
                }
            }
            else
            {
                secondEventPoints.performance = "";
                secondEventPoints.athleteName = "";
                secondEventPoints.schoolName = "";
                secondEventPoints.team1Pts = 0;
                secondEventPoints.team2Pts = 0;
            }

            //thirdplace EventPoints
            if (thirdPlacePerf != 0 && numFirstPlaces + numSecondPlaces < 3)
            {
                thirdEventPoints.performance = DESI.ConvertToTimedData(thirdPlacePerf);
                if (thirdPlaceHeats.Count > 1)
                {
                    Console.WriteLine(numThirdPlaces + "-Way Tie for 3rd");
                    thirdEventPoints.athleteName = "TIE";
                    thirdEventPoints.schoolName = "TIE";
                    //Calculate Tie info
                    foreach (Performance p in teams1and2)
                    {
                        if (p.performance == thirdPlacePerf && thirdPlaceHeats.Contains(p.heatNum))
                        {
                            //test taking out p.heatNum here
                            //Not sure if this is correct
                            thirdPlaceHeats.Remove(p.heatNum);

                            if (p.schoolName == team1Abbr)
                            {
                                thirdEventPoints.team1Pts += (1.0m / numThirdPlaces);
                            }
                            else if (p.schoolName == team2Abbr)
                            {
                                thirdEventPoints.team2Pts += (1.0m / numThirdPlaces);
                            }
                            else
                            {
                                Console.WriteLine("ERROR! This code should be unreachable!");
                                throw new TeamNotFoundException(p.schoolName + " does not equal " + team1Abbr + " or " + team2Abbr);
                            }
                        }
                    }
                }
                else
                {
                    //Populate regular non-tie info
                    for (int i = 2; i < teams1and2.Count; i++)
                    {
                        if (teams1and2[i].performance == thirdPlacePerf)
                        //if (teams1and2[i].performance == thirdPlacePerf && thirdPlaceHeats.Contains(teams1and2[i].heatNum)) //Changed
                        {
                            thirdEventPoints.athleteName = teams1and2[i].athleteName;
                            thirdEventPoints.schoolName = teams1and2[i].schoolName;
                            break; //break added, same perf same heat error without
                        }
                    }

                    if (thirdEventPoints.schoolName == team1Abbr)
                    {
                        thirdEventPoints.team1Pts = 1;
                        thirdEventPoints.team2Pts = 0;
                    }
                    else if (thirdEventPoints.schoolName == team2Abbr)
                    {
                        thirdEventPoints.team1Pts = 0;
                        thirdEventPoints.team2Pts = 1;
                    }
                    else
                    {
                        Console.WriteLine("ERROR! Third Place Points being assigned to an incorrect team name");
                        throw new TeamNotFoundException(thirdEventPoints.schoolName + " does not equal " + team1Abbr + " or " + team2Abbr);
                    }
                }
            }
            else
            {
                thirdEventPoints.performance = "";
                thirdEventPoints.athleteName = "";
                thirdEventPoints.schoolName = "";
                thirdEventPoints.team1Pts = 0;
                thirdEventPoints.team2Pts = 0;
            }

            //Populate points totals
            eventToReturn.points[0] = firstEventPoints;
            eventToReturn.points[1] = secondEventPoints;
            eventToReturn.points[2] = thirdEventPoints;
            eventToReturn.team1Total = firstEventPoints.team1Pts + secondEventPoints.team1Pts + thirdEventPoints.team1Pts;
            eventToReturn.team2Total = firstEventPoints.team2Pts + secondEventPoints.team2Pts + thirdEventPoints.team2Pts;

            //
            //return IndEvent Object
            //
            Console.WriteLine("Leaving " + MethodBase.GetCurrentMethod().DeclaringType + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return eventToReturn;
        }

        /// <summary>
        /// Implementation for adding an indEvent to an OverallScore object
        /// </summary>
        /// <param name="scores">Overall scores</param>
        /// <param name="eventName">Name of the event being added</param>
        /// <param name="eventToAdd">Data for the event being added</param>
        /// <returns>OverallScore with the event added</returns>
        public OverallScore AddEvent(OverallScore scores, string eventName, IndEvent eventToAdd)
        {
            if (scores == null)
                scores = new OverallScore();

            if (scores.indEvents == null)
                scores.indEvents = new Dictionary<string, IndEvent>();

            if (scores.indEvents != null && scores.indEvents.ContainsKey(eventName))
                scores.indEvents[eventName] = eventToAdd;
            else
                scores.indEvents.Add(eventName, eventToAdd);

            return scores;
        }

        /// <summary>
        /// Implementation for adding a relayEvent to an OverallScore object
        /// </summary>
        /// <param name="scores">Overall scores</param>
        /// <param name="eventName">Name of the event being added</param>
        /// <param name="eventToAdd">Data for the event being added</param>
        /// <returns>OverallScore with the event added</returns>
        public OverallScore AddEvent(OverallScore scores, string eventName, RelayEvent eventToAdd)
        {
            if (scores == null)
                scores = new OverallScore();

            if (scores.relayEvents == null)
                scores.relayEvents = new Dictionary<string, RelayEvent>();

            if (scores.relayEvents != null && scores.relayEvents.ContainsKey(eventName))
                scores.relayEvents[eventName] = eventToAdd;
            else
            {
                scores.relayEvents.Add(eventName, eventToAdd);
            }

            return scores;
        }

        /// <summary>
        /// Implementation for calculating points (1st, 2nd, and 3rd) for an individual field event
        /// </summary>
        /// <param name="team1Abbr">Abbr for team 1</param>
        /// <param name="team2Abbr">Abbr for team 2</param>
        /// <param name="perf">Complete list of performances for a particular field event</param>
        /// <returns>IndEvent, which holds all information ragarding this event's points</returns>
        public IndEvent CalculateFieldEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            //
            //gather performances from only teams 1 and 2
            //
            List<Performance> teams1and2 = new List<Performance>();
            foreach (Performance i in perf) //Iterate through entire list of performances
            {
                if (i.schoolName == team1Abbr || i.schoolName == team2Abbr) //check if the performance is for Team 1 or 2
                {
                    teams1and2.Add(i); //Add performance to working List
                }
            }
            //
            //sort performances from best to worst
            //
            teams1and2 = teams1and2.OrderByDescending(o => o.performance).ToList();

            //Do test here to determine if possible ties. Probably need to return null for this to work, although that could give some potential problems.
            if (teams1and2.Count >= 2 && teams1and2[0].performance == teams1and2[1].performance)
                return null;
            else if (teams1and2.Count >= 3 && teams1and2[1].performance == teams1and2[2].performance)
                return null;
            else if (teams1and2.Count >= 4 && teams1and2[2].performance == teams1and2[3].performance)
                return null;

            return CalculateIndEventInOrder(team1Abbr, team2Abbr, teams1and2);
        }

        /// <summary>
        /// Implementation for calculating points (1st, and 2nd) for a relay event
        /// </summary>
        /// <param name="team1Abbr">Abbr for team 1</param>
        /// <param name="team2Abbr">Abbr for team 2</param>
        /// <param name="perf"></param>
        /// <returns>RelayEvent, which holds all information ragarding this event's points</returns>
        public RelayEvent CalculateRelayEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            //
            //gather performances from only teams 1 and 2
            //
            List<Performance> teams1and2 = new List<Performance>();
            foreach (Performance i in perf) //Iterate through entire list of performances
            {
                //A name stands for A relays. Only A relays count towards points. B and above are scrimmage relays 
                if ((i.schoolName == team1Abbr && i.athleteName == "A Relay")|| (i.schoolName == team2Abbr && i.athleteName == "A Relay")) //check if the performance is for Team 1 or 2
                {
                    teams1and2.Add(i); //Add performance to working List
                }
            }
            //
            //sort performances from best to worst
            //
            teams1and2 = teams1and2.OrderBy(o => o.performance).ToList();

            RelayEvent eventToReturn = new RelayEvent();
            eventToReturn.team1 = team1Abbr;
            eventToReturn.team2 = team2Abbr;

            EventPoints[] points = new EventPoints[2];
            points[0] = new EventPoints();
            points[1] = new EventPoints();

            //Use this to convert into strings for EventPoints objects 
            DataEntrySvcImpl DESI = new DataEntrySvcImpl();

            //First Place
            if (teams1and2.Count > 0)
            {
                if (teams1and2[0].schoolName == team1Abbr)
                {
                    points[0] = new EventPoints(5.0m, 0.0m, teams1and2[0].athleteName, teams1and2[0].schoolName, DESI.ConvertToTimedData(teams1and2[0].performance));
                }
                else if (teams1and2[0].schoolName == team2Abbr)
                {
                    points[0] = new EventPoints(0.0m, 5.0m, teams1and2[0].athleteName, teams1and2[0].schoolName, DESI.ConvertToTimedData(teams1and2[0].performance));
                }
                else
                {
                    Console.WriteLine("ERROR! This code should be unreachable!");
                    throw new TeamNotFoundException(teams1and2[0].schoolName + " does not equal " + team1Abbr + " or " + team2Abbr);
                }
            }

            //Second Place
            if (teams1and2.Count > 1)
            {
                if (teams1and2[1].schoolName == team1Abbr)
                {
                    points[1] = new EventPoints(0.0m, 0.0m, teams1and2[1].athleteName, teams1and2[1].schoolName, DESI.ConvertToTimedData(teams1and2[1].performance));
                }
                else if (teams1and2[1].schoolName == team2Abbr)
                {
                    points[1] = new EventPoints(0.0m, 0.0m, teams1and2[1].athleteName, teams1and2[1].schoolName, DESI.ConvertToTimedData(teams1and2[1].performance));
                }
                else
                {
                    Console.WriteLine("ERROR! This code should be unreachable!");
                    throw new TeamNotFoundException(teams1and2[1].schoolName + " does not equal " + team1Abbr + " or " + team2Abbr);
                }
            }

            //Add Points data to returning object
            eventToReturn.points = points;
                

            //Calculate Totals
            eventToReturn.team1Total = points[0].team1Pts + points[1].team1Pts;
            eventToReturn.team2Total = points[0].team2Pts + points[1].team2Pts;
            
            //return object
            return eventToReturn;
        }

        /// <summary>
        /// Implementation for calculating points (1st, 2nd, and 3rd) for an individual running event
        /// </summary>
        /// <param name="team1Abbr">Abbr for team 1</param>
        /// <param name="team2Abbr">Abbr for team 2</param>
        /// <param name="perf">Complete list of performances for a particular running event</param>
        /// <returns>IndEvent, which holds all information ragarding this event's points</returns>
        public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            //
            //gather performances from only teams 1 and 2
            //
            List<Performance> teams1and2 = new List<Performance>();
            foreach(Performance i in perf) //Iterate through entire list of performances
            {
                if (i.schoolName == team1Abbr || i.schoolName == team2Abbr) //check if the performance is for Team 1 or 2
                {
                    teams1and2.Add(i); //Add performance to working List
                }
            }
            //
            //sort performances from best to worst
            //
            teams1and2 = teams1and2.OrderBy(o => o.performance).ToList();

            return CalculateIndEventInOrder(team1Abbr, team2Abbr, teams1and2);
        }

        /// <summary>
        /// Interface for calculating The overall score of a meet
        /// </summary>
        /// <param name="scores">Overall scores</param>
        /// <param name="gender">string to hold what gender the meet is, boy's or girl's</param>
        /// <returns>OverallScore object that holds accurate overall score points</returns>
        public OverallScore CalculateTotal(OverallScore scores, string gender)
        {
            decimal totalPointsTeam1 = 0;
            decimal totalPointsTeam2 = 0;
            IndEvent tempIndEvent = new IndEvent();
            RelayEvent tempRelayEvent = new RelayEvent();

            string[] validIndEvents = {"100", "200", "400", "800", "1600", "3200", "HH", "300H",
                "LJ", "TJ", "HJ", "PV", "ShotPut", "Discus", "Javelin"};

            for (int i = 0; i < validIndEvents.Length; i++)
            {
                if (scores != null && scores.indEvents != null)
                {
                    scores.indEvents.TryGetValue(gender + "'s " + validIndEvents[i], out tempIndEvent);
                    if (tempIndEvent != null)
                    {
                        totalPointsTeam1 += tempIndEvent.team1Total;
                        totalPointsTeam2 += tempIndEvent.team2Total;
                    }
                }
            }

            //DO THE SAME FOR RELAY EVENTS
            string[] validRelayEvents = {"4x100", "4x400", "4x800"};

            for (int i = 0; i < validRelayEvents.Length; i++)
            {
                if (scores != null && scores.relayEvents != null)
                {
                    scores.relayEvents.TryGetValue(gender + "'s " + validRelayEvents[i], out tempRelayEvent);
                    if (tempRelayEvent != null)
                    {
                        totalPointsTeam1 += tempRelayEvent.team1Total;
                        totalPointsTeam2 += tempRelayEvent.team2Total;
                    }
                }
            }

            scores.team1Points = totalPointsTeam1;
            scores.team2Points = totalPointsTeam2;

            return scores;
        }
    }
}

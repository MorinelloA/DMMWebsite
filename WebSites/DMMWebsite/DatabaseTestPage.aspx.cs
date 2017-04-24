using DualMeetManager.Business.Managers;
using DMMLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DatabaseTestPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Performance myPerformance1 = new Performance("A", "AA", 1.1m);
        Performance myPerformance2 = new Performance("B", "BB", 2.2m);
        Performance myPerformance3 = new Performance("C", "CC", 3.3m);
        Performance myPerformance4 = new Performance("D", "AA", 4.1m);
        Performance myPerformance5 = new Performance("E", "BB", 5.2m);
        Performance myPerformance6 = new Performance("F", "CC", 6.3m);

        List<Performance> myPerformancesA = new List<Performance>();
        myPerformancesA.Add(myPerformance1);
        myPerformancesA.Add(myPerformance2);
        myPerformancesA.Add(myPerformance3);

        List<Performance> myPerformancesB = new List<Performance>();
        myPerformancesB.Add(myPerformance4);
        myPerformancesB.Add(myPerformance5);
        myPerformancesB.Add(myPerformance6);

        Dictionary<string, List<Performance>> myPerformances = new Dictionary<string, List<Performance>>();
        myPerformances.Add("Boy's 100", myPerformancesA);
        myPerformances.Add("Boy's 200", myPerformancesB);

        Dictionary<string, string> boysNames = new Dictionary<string, string>();
        boysNames.Add("BLN", "Baldwin");
        boysNames.Add("TJ", "Thomas Jefferson");
        boysNames.Add("WHS", "Washington HS");

        Dictionary<string, string> girlsNames = new Dictionary<string, string>();
        girlsNames.Add("PLM", "Plum");
        girlsNames.Add("GWY", "Gateway");
        girlsNames.Add("KCH", "Knoch");

        Teams teams = new Teams(boysNames, girlsNames);

        Meet myMeetNoEvents = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams, myPerformances);


        TableRow meetRow = new TableRow();
        tblMeets.Rows.Add(meetRow);

        TableCell idCell = new TableCell();
        idCell.Text = "1";
        meetRow.Cells.Add(idCell);

        TableCell dateOfMeetCell = new TableCell();
        dateOfMeetCell.Text = myMeetNoEvents.dateOfMeet.ToString();
        meetRow.Cells.Add(dateOfMeetCell);

        TableCell locationCell = new TableCell();
        locationCell.Text = myMeetNoEvents.location;
        meetRow.Cells.Add(locationCell);

        TableCell weatherCell = new TableCell();
        weatherCell.Text = myMeetNoEvents.weatherConditions;
        meetRow.Cells.Add(weatherCell);

        for (int i = 0; i < myMeetNoEvents.schoolNames.boySchoolNames.Count; i++)
        {
            TableRow boysRow = new TableRow();
            tblBoysTeams.Rows.Add(boysRow);

            TableCell boysId = new TableCell();
            boysId.Text = (i+1).ToString();
            boysRow.Cells.Add(boysId);

            TableCell abbrCell = new TableCell();
            abbrCell.Text = myMeetNoEvents.schoolNames.boySchoolNames.ElementAt(i).Key;
            boysRow.Cells.Add(abbrCell);

            TableCell tNameCell = new TableCell();
            tNameCell.Text = myMeetNoEvents.schoolNames.boySchoolNames.ElementAt(i).Value;
            boysRow.Cells.Add(tNameCell);

            TableCell meetKeyBoys = new TableCell();
            meetKeyBoys.Text = idCell.Text;
            boysRow.Cells.Add(meetKeyBoys);
        }

        for (int i = 0; i < myMeetNoEvents.schoolNames.girlSchoolNames.Count; i++)
        {
            TableRow girlsRow = new TableRow();
            tblGirlsTeams.Rows.Add(girlsRow);

            TableCell girlsId = new TableCell();
            girlsId.Text = (i + 1).ToString();
            girlsRow.Cells.Add(girlsId);

            TableCell abbrCell = new TableCell();
            abbrCell.Text = myMeetNoEvents.schoolNames.girlSchoolNames.ElementAt(i).Key;
            girlsRow.Cells.Add(abbrCell);

            TableCell tNameCell = new TableCell();
            tNameCell.Text = myMeetNoEvents.schoolNames.girlSchoolNames.ElementAt(i).Value;
            girlsRow.Cells.Add(tNameCell);

            TableCell meetKeygirls = new TableCell();
            meetKeygirls.Text = idCell.Text;
            girlsRow.Cells.Add(meetKeygirls);
        }
        
        if(myMeetNoEvents != null && myMeetNoEvents.performances != null)
        {
            foreach (string eventName in myMeetNoEvents.performances.Keys)

            //for (int i = 0; i < myMeetNoEvents.performances.Keys; i++)
            {
                foreach (Performance perf in myMeetNoEvents.performances[eventName])
                {
                    TableRow perfRow = new TableRow();
                    tblPerformances.Rows.Add(perfRow);

                    TableCell perfId = new TableCell();
                    perfId.Text = (100).ToString();
                    perfRow.Cells.Add(perfId);

                    TableCell athleteCell = new TableCell();
                    athleteCell.Text = perf.athleteName;
                    perfRow.Cells.Add(athleteCell);

                    TableCell tNameCell = new TableCell();
                    tNameCell.Text = perf.schoolName;
                    perfRow.Cells.Add(tNameCell);

                    TableCell genderCell = new TableCell();
                    if (eventName.ToUpper().Contains("BOY"))
                    {
                        genderCell.Text = "Boy's";
                    }
                    else if (eventName.ToUpper().Contains("GIRL"))
                    {
                        genderCell.Text = "Girl's";
                    }
                    else
                    {
                        genderCell.Text = "";
                    }
                    perfRow.Cells.Add(genderCell);

                    TableCell eventCell = new TableCell();
                    eventCell.Text = eventName;
                    perfRow.Cells.Add(eventCell);

                    TableCell heatCell = new TableCell();
                    heatCell.Text = perf.heatNum.ToString();
                    perfRow.Cells.Add(heatCell);

                    TableCell perfCell = new TableCell();
                    perfCell.Text = perf.performance.ToString();
                    perfRow.Cells.Add(perfCell);

                    TableCell meetKeyPerf = new TableCell();
                    meetKeyPerf.Text = idCell.Text;
                    perfRow.Cells.Add(meetKeyPerf);

                }
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Performance myPerformance1 = new Performance("A", "AA", 1.1m);
        Performance myPerformance2 = new Performance("B", "BB", 2.2m);
        Performance myPerformance3 = new Performance("C", "CC", 3.3m);
        Performance myPerformance4 = new Performance("D", "AA", 4.1m);
        Performance myPerformance5 = new Performance("E", "BB", 5.2m);
        Performance myPerformance6 = new Performance("F", "CC", 6.3m);

        List<Performance> myPerformancesA = new List<Performance>();
        myPerformancesA.Add(myPerformance1);
        myPerformancesA.Add(myPerformance2);
        myPerformancesA.Add(myPerformance3);

        List<Performance> myPerformancesB = new List<Performance>();
        myPerformancesB.Add(myPerformance4);
        myPerformancesB.Add(myPerformance5);
        myPerformancesB.Add(myPerformance6);

        Dictionary<string, List<Performance>> myPerformances = new Dictionary<string, List<Performance>>();
        myPerformances.Add("Boy's 100", myPerformancesA);
        myPerformances.Add("Boy's 200", myPerformancesB);

        Dictionary<string, string> boysNames = new Dictionary<string, string>();
        boysNames.Add("BLN", "Baldwin");
        boysNames.Add("TJ", "Thomas Jefferson");
        boysNames.Add("WHS", "Washington HS");

        Dictionary<string, string> girlsNames = new Dictionary<string, string>();
        girlsNames.Add("PLM", "Plum");
        girlsNames.Add("GWY", "Gateway");
        girlsNames.Add("KCH", "Knoch");

        Teams teams = new Teams(boysNames, girlsNames);

        Meet myMeetNoEvents = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams, myPerformances);

        DatabaseMgr dbm = new DatabaseMgr();
        dbm.AddMeet(myMeetNoEvents, "NoUsername");

        /*TableRow meetRow = new TableRow();
        tblMeets.Rows.Add(meetRow);

        TableCell idCell = new TableCell();
        idCell.Text = "1";
        meetRow.Cells.Add(idCell);

        TableCell dateOfMeetCell = new TableCell();
        dateOfMeetCell.Text = myMeetNoEvents.dateOfMeet.ToString();
        meetRow.Cells.Add(dateOfMeetCell);

        TableCell locationCell = new TableCell();
        locationCell.Text = myMeetNoEvents.location;
        meetRow.Cells.Add(locationCell);

        TableCell weatherCell = new TableCell();
        weatherCell.Text = myMeetNoEvents.weatherConditions;
        meetRow.Cells.Add(weatherCell);

        for (int i = 0; i < myMeetNoEvents.schoolNames.boySchoolNames.Count; i++)
        {
            TableRow boysRow = new TableRow();
            tblBoysTeams.Rows.Add(boysRow);

            TableCell boysId = new TableCell();
            boysId.Text = (i + 1).ToString();
            boysRow.Cells.Add(boysId);

            TableCell abbrCell = new TableCell();
            abbrCell.Text = myMeetNoEvents.schoolNames.boySchoolNames.ElementAt(i).Key;
            boysRow.Cells.Add(abbrCell);

            TableCell tNameCell = new TableCell();
            tNameCell.Text = myMeetNoEvents.schoolNames.boySchoolNames.ElementAt(i).Value;
            boysRow.Cells.Add(tNameCell);

            TableCell meetKeyBoys = new TableCell();
            meetKeyBoys.Text = idCell.Text;
            boysRow.Cells.Add(meetKeyBoys);
        }

        for (int i = 0; i < myMeetNoEvents.schoolNames.girlSchoolNames.Count; i++)
        {
            TableRow girlsRow = new TableRow();
            tblGirlsTeams.Rows.Add(girlsRow);

            TableCell girlsId = new TableCell();
            girlsId.Text = (i + 1).ToString();
            girlsRow.Cells.Add(girlsId);

            TableCell abbrCell = new TableCell();
            abbrCell.Text = myMeetNoEvents.schoolNames.girlSchoolNames.ElementAt(i).Key;
            girlsRow.Cells.Add(abbrCell);

            TableCell tNameCell = new TableCell();
            tNameCell.Text = myMeetNoEvents.schoolNames.girlSchoolNames.ElementAt(i).Value;
            girlsRow.Cells.Add(tNameCell);

            TableCell meetKeygirls = new TableCell();
            meetKeygirls.Text = idCell.Text;
            girlsRow.Cells.Add(meetKeygirls);
        }

        if (myMeetNoEvents != null && myMeetNoEvents.performances != null)
        {
            foreach (string eventName in myMeetNoEvents.performances.Keys)

            //for (int i = 0; i < myMeetNoEvents.performances.Keys; i++)
            {
                foreach (Performance perf in myMeetNoEvents.performances[eventName])
                {
                    TableRow perfRow = new TableRow();
                    tblPerformances.Rows.Add(perfRow);

                    TableCell perfId = new TableCell();
                    perfId.Text = (100).ToString();
                    perfRow.Cells.Add(perfId);

                    TableCell athleteCell = new TableCell();
                    athleteCell.Text = perf.athleteName;
                    perfRow.Cells.Add(athleteCell);

                    TableCell tNameCell = new TableCell();
                    tNameCell.Text = perf.schoolName;
                    perfRow.Cells.Add(tNameCell);

                    TableCell genderCell = new TableCell();
                    if (eventName.ToUpper().Contains("BOY"))
                    {
                        genderCell.Text = "Boy's";
                    }
                    else if (eventName.ToUpper().Contains("GIRL"))
                    {
                        genderCell.Text = "Girl's";
                    }
                    else
                    {
                        genderCell.Text = "";
                    }
                    perfRow.Cells.Add(genderCell);

                    TableCell eventCell = new TableCell();
                    eventCell.Text = eventName;
                    perfRow.Cells.Add(eventCell);

                    TableCell heatCell = new TableCell();
                    heatCell.Text = perf.heatNum.ToString();
                    perfRow.Cells.Add(heatCell);

                    TableCell perfCell = new TableCell();
                    perfCell.Text = perf.performance.ToString();
                    perfRow.Cells.Add(perfCell);

                    TableCell meetKeyPerf = new TableCell();
                    meetKeyPerf.Text = idCell.Text;
                    perfRow.Cells.Add(meetKeyPerf);

                }
            }
        }*/
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        DatabaseMgr dbm = new DatabaseMgr();
        dbm.ResetPrimaryKeys();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Dictionary<string, string> boysNames = new Dictionary<string, string>();
        boysNames.Add("BLN", "Baldwin");
        boysNames.Add("TJ", "Thomas Jefferson");
        boysNames.Add("WHS", "Washington HS");

        Dictionary<string, string> girlsNames = new Dictionary<string, string>();
        girlsNames.Add("PLM", "Plum");
        girlsNames.Add("GWY", "Gateway");
        girlsNames.Add("KCH", "Knoch");

        Teams teams = new Teams(boysNames, girlsNames);
        Meet myMeetNoEvents = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams);

        DatabaseMgr dbm = new DatabaseMgr();
        int meetID = dbm.FindMeetId(myMeetNoEvents);
        dbm.DeleteMeet(meetID);
    }
}
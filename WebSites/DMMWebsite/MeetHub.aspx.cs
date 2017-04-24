using DualMeetManager.Business.Managers;
using DMMLib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MeetHub : System.Web.UI.Page
{
    Meet activeMeet;

    public IndEvent tieBreakerEvent = new IndEvent();

    //Overall Scores for every dual meet taking place
    Dictionary<string, OverallScore> boysActiveScores = new Dictionary<string, OverallScore>();
    Dictionary<string, OverallScore> girlsActiveScores = new Dictionary<string, OverallScore>();

    //File Path/Name for saving the Meet
    string file = "";

    //Generate List of Boy's team Abbrs from Dictionary
    List<string> boysAbbrs = new List<string>();

    //Generate List of Girl's team Abbrs from Dictionary
    List<string> girlsAbbrs = new List<string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        activeMeet = (Meet)Session["ActiveMeet"];

        //Session["ActiveMeet"] = newMeet;
        if (activeMeet != null)
            lblMeetTitle.Text = activeMeet.dateOfMeet.Month + "-" + activeMeet.dateOfMeet.Day + "-" + activeMeet.dateOfMeet.Year + " meet @ " + activeMeet.location.ToString();
        else
            lblMeetTitle.Text = "Invalid meet data";

        FormLoadHelper();

        if (activeMeet != null && activeMeet.performances != null)
        {
            if (activeMeet.performances.ContainsKey("Boy's 100"))
                AddRunningEventToScores("Boy", "Boy's 100", activeMeet.performances["Boy's 100"]);
            if (activeMeet.performances.ContainsKey("Boy's 200"))
                AddRunningEventToScores("Boy", "Boy's 200", activeMeet.performances["Boy's 200"]);
            if (activeMeet.performances.ContainsKey("Boy's 400"))
                AddRunningEventToScores("Boy", "Boy's 400", activeMeet.performances["Boy's 400"]);
            if (activeMeet.performances.ContainsKey("Boy's 800"))
                AddRunningEventToScores("Boy", "Boy's 800", activeMeet.performances["Boy's 800"]);
            if (activeMeet.performances.ContainsKey("Boy's 1600"))
                AddRunningEventToScores("Boy", "Boy's 1600", activeMeet.performances["Boy's 1600"]);
            if (activeMeet.performances.ContainsKey("Boy's 3200"))
                AddRunningEventToScores("Boy", "Boy's 3200", activeMeet.performances["Boy's 3200"]);
            if (activeMeet.performances.ContainsKey("Boy's HH"))
                AddRunningEventToScores("Boy", "Boy's HH", activeMeet.performances["Boy's HH"]);
            if (activeMeet.performances.ContainsKey("Boy's 300H"))
                AddRunningEventToScores("Boy", "Boy's 300H", activeMeet.performances["Boy's 300H"]);
            if (activeMeet.performances.ContainsKey("Boy's 4x100"))
                AddRelayEventToScores("Boy", "Boy's 4x100", activeMeet.performances["Boy's 4x100"]);
            if (activeMeet.performances.ContainsKey("Boy's 4x400"))
                AddRelayEventToScores("Boy", "Boy's 4x400", activeMeet.performances["Boy's 4x400"]);
            if (activeMeet.performances.ContainsKey("Boy's 4x800"))
                AddRelayEventToScores("Boy", "Boy's 4x800", activeMeet.performances["Boy's 4x800"]);
            if (activeMeet.performances.ContainsKey("Boy's LJ"))
                AddFieldEventToScores("Boy", "Boy's LJ", activeMeet.performances["Boy's LJ"]);
            if (activeMeet.performances.ContainsKey("Boy's TJ"))
                AddFieldEventToScores("Boy", "Boy's TJ", activeMeet.performances["Boy's TJ"]);
            if (activeMeet.performances.ContainsKey("Boy's HJ"))
                AddFieldEventToScores("Boy", "Boy's HJ", activeMeet.performances["Boy's HJ"]);
            if (activeMeet.performances.ContainsKey("Boy's PV"))
                AddFieldEventToScores("Boy", "Boy's PV", activeMeet.performances["Boy's PV"]);
            if (activeMeet.performances.ContainsKey("Boy's Shotput"))
                AddFieldEventToScores("Boy", "Boy's Shotput", activeMeet.performances["Boy's Shotput"]);
            if (activeMeet.performances.ContainsKey("Boy's Discus"))
                AddFieldEventToScores("Boy", "Boy's Discus", activeMeet.performances["Boy's Discus"]);
            if (activeMeet.performances.ContainsKey("Boy's Javelin"))
                AddFieldEventToScores("Boy", "Boy's Javelin", activeMeet.performances["Boy's Javelin"]);

            if (activeMeet.performances.ContainsKey("Girl's 100"))
                AddRunningEventToScores("Girl", "Girl's 100", activeMeet.performances["Girl's 100"]);
            if (activeMeet.performances.ContainsKey("Girl's 200"))
                AddRunningEventToScores("Girl", "Girl's 200", activeMeet.performances["Girl's 200"]);
            if (activeMeet.performances.ContainsKey("Girl's 400"))
                AddRunningEventToScores("Girl", "Girl's 400", activeMeet.performances["Girl's 400"]);
            if (activeMeet.performances.ContainsKey("Girl's 800"))
                AddRunningEventToScores("Girl", "Girl's 800", activeMeet.performances["Girl's 800"]);
            if (activeMeet.performances.ContainsKey("Girl's 1600"))
                AddRunningEventToScores("Girl", "Girl's 1600", activeMeet.performances["Girl's 1600"]);
            if (activeMeet.performances.ContainsKey("Girl's 3200"))
                AddRunningEventToScores("Girl", "Girl's 3200", activeMeet.performances["Girl's 3200"]);
            if (activeMeet.performances.ContainsKey("Girl's HH"))
                AddRunningEventToScores("Girl", "Girl's HH", activeMeet.performances["Girl's HH"]);
            if (activeMeet.performances.ContainsKey("Girl's 300H"))
                AddRunningEventToScores("Girl", "Girl's 300H", activeMeet.performances["Girl's 300H"]);
            if (activeMeet.performances.ContainsKey("Girl's 4x100"))
                AddRelayEventToScores("Girl", "Girl's 4x100", activeMeet.performances["Girl's 4x100"]);
            if (activeMeet.performances.ContainsKey("Girl's 4x400"))
                AddRelayEventToScores("Girl", "Girl's 4x400", activeMeet.performances["Girl's 4x400"]);
            if (activeMeet.performances.ContainsKey("Girl's 4x800"))
                AddRelayEventToScores("Girl", "Girl's 4x800", activeMeet.performances["Girl's 4x800"]);
            if (activeMeet.performances.ContainsKey("Girl's LJ"))
                AddFieldEventToScores("Girl", "Girl's LJ", activeMeet.performances["Girl's LJ"]);
            if (activeMeet.performances.ContainsKey("Girl's TJ"))
                AddFieldEventToScores("Girl", "Girl's TJ", activeMeet.performances["Girl's TJ"]);
            if (activeMeet.performances.ContainsKey("Girl's HJ"))
                AddFieldEventToScores("Girl", "Girl's HJ", activeMeet.performances["Girl's HJ"]);
            if (activeMeet.performances.ContainsKey("Girl's PV"))
                AddFieldEventToScores("Girl", "Girl's PV", activeMeet.performances["Girl's PV"]);
            if (activeMeet.performances.ContainsKey("Girl's Shotput"))
                AddFieldEventToScores("Girl", "Girl's Shotput", activeMeet.performances["Girl's Shotput"]);
            if (activeMeet.performances.ContainsKey("Girl's Discus"))
                AddFieldEventToScores("Girl", "Girl's Discus", activeMeet.performances["Girl's Discus"]);
            if (activeMeet.performances.ContainsKey("Girl's Javelin"))
                AddFieldEventToScores("Girl", "Girl's Javelin", activeMeet.performances["Girl's Javelin"]);
        }
    }
    
    private void FormLoadHelper()
    {
        //Create OverallScores

        foreach (string t1 in activeMeet.schoolNames.boySchoolNames.Keys)
        {
            foreach (string t2 in activeMeet.schoolNames.boySchoolNames.Keys)
            {
                if (t1 != t2 && !boysActiveScores.ContainsKey(t2 + "vs." + t1) && !boysActiveScores.ContainsKey(t1 + "vs." + t2))
                {
                    boysActiveScores.Add(t1 + "vs." + t2, new OverallScore(Tuple.Create(t1, activeMeet.schoolNames.boySchoolNames[t1]), Tuple.Create(t2, activeMeet.schoolNames.boySchoolNames[t2])));
                }
            }
        }
        foreach (string t1 in activeMeet.schoolNames.girlSchoolNames.Keys)
        {
            foreach (string t2 in activeMeet.schoolNames.girlSchoolNames.Keys)
            {
                if (t1 != t2 && !girlsActiveScores.ContainsKey(t2 + "vs." + t1) && !girlsActiveScores.ContainsKey(t1 + "vs." + t2))
                    girlsActiveScores.Add(t1 + "vs." + t2, new OverallScore(Tuple.Create(t1, activeMeet.schoolNames.girlSchoolNames[t1]), Tuple.Create(t2, activeMeet.schoolNames.girlSchoolNames[t2])));
            }
        }

        //Populate Boys List

        foreach (KeyValuePair<string, string> entry in activeMeet.schoolNames.boySchoolNames)
        {
            boysAbbrs.Add(entry.Key);
        }

        lbtnBoysTeam1Printout.Text = boysAbbrs[0];

        if (activeMeet.schoolNames.boySchoolNames.Count >= 2)
        {
            //Scores
            //mnuPrintoutsBoysScores.Visible = true;
            //boysTeamScores.Visible = true;
            lblBoysScores1vs2Printout.Visible = true;
            lblBoysScores1vs2Printout.Text = boysAbbrs[0] + " vs " + boysAbbrs[1];

            //Team Perf
            lbtnBoysPerfsAll.Visible = true;
            lbtnBoysTeam2Printout.Visible = true;
            lbtnBoysTeam2Printout.Text = boysAbbrs[1];

            if (activeMeet.schoolNames.boySchoolNames.Count >= 3)
            {
                //Scores
                boysTeamScoresAll.Visible = true;
                lblBoysScores1vs3Printout.Visible = true;
                lblBoysScores1vs3Printout.Text = boysAbbrs[0] + " vs " + boysAbbrs[2];
                lblBoysScores2vs3Printout.Visible = true;
                lblBoysScores2vs3Printout.Text = boysAbbrs[1] + " vs " + boysAbbrs[2];

                //Team Perf
                lbtnBoysTeam3Printout.Visible = true;
                lbtnBoysTeam3Printout.Text = boysAbbrs[2];

                if (activeMeet.schoolNames.boySchoolNames.Count >= 4)
                {
                    //Scores
                    lblBoysScores1vs4Printout.Visible = true;
                    lblBoysScores1vs4Printout.Text = boysAbbrs[0] + " vs " + boysAbbrs[3];
                    lblBoysScores2vs4Printout.Visible = true;
                    lblBoysScores2vs4Printout.Text = boysAbbrs[1] + " vs " + boysAbbrs[3];
                    lblBoysScores3vs4Printout.Visible = true;
                    lblBoysScores3vs4Printout.Text = boysAbbrs[2] + " vs " + boysAbbrs[3];

                    //Team Perf
                    lbtnBoysTeam4Printout.Visible = true;
                    lbtnBoysTeam4Printout.Text = boysAbbrs[3];

                    if (activeMeet.schoolNames.boySchoolNames.Count >= 5)
                    {
                        //Scores
                        lblBoysScores1vs5Printout.Visible = true;
                        lblBoysScores1vs5Printout.Text = boysAbbrs[0] + " vs " + boysAbbrs[4];
                        lblBoysScores2vs5Printout.Visible = true;
                        lblBoysScores2vs5Printout.Text = boysAbbrs[1] + " vs " + boysAbbrs[4];
                        lblBoysScores3vs5Printout.Visible = true;
                        lblBoysScores3vs5Printout.Text = boysAbbrs[2] + " vs " + boysAbbrs[4];
                        lblBoysScores4vs5Printout.Visible = true;
                        lblBoysScores4vs5Printout.Text = boysAbbrs[3] + " vs " + boysAbbrs[4];

                        //Team Perf
                        lbtnBoysTeam5Printout.Visible = true;
                        lbtnBoysTeam5Printout.Text = boysAbbrs[4];

                        if (activeMeet.schoolNames.boySchoolNames.Count >= 6)
                        {
                            //Scores
                            lblBoysScores1vs6Printout.Visible = true;
                            lblBoysScores1vs6Printout.Text = boysAbbrs[0] + " vs " + boysAbbrs[5];
                            lblBoysScores2vs6Printout.Visible = true;
                            lblBoysScores2vs6Printout.Text = boysAbbrs[1] + " vs " + boysAbbrs[5];
                            lblBoysScores3vs6Printout.Visible = true;
                            lblBoysScores3vs6Printout.Text = boysAbbrs[2] + " vs " + boysAbbrs[5];
                            lblBoysScores4vs6Printout.Visible = true;
                            lblBoysScores4vs6Printout.Text = boysAbbrs[3] + " vs " + boysAbbrs[5];
                            lblBoysScores5vs6Printout.Visible = true;
                            lblBoysScores5vs6Printout.Text = boysAbbrs[4] + " vs " + boysAbbrs[5];

                            //Team Perf
                            lbtnBoysTeam6Printout.Visible = true;
                            lbtnBoysTeam6Printout.Text = boysAbbrs[5];
                        }
                    }
                }
            }
        } // End Boy's data

        //Populate Girls List
        foreach (KeyValuePair<string, string> entry in activeMeet.schoolNames.girlSchoolNames)
        {
            girlsAbbrs.Add(entry.Key);
        }

        lbtnGirlsTeam1Printout.Text = girlsAbbrs[0];

        if (activeMeet.schoolNames.girlSchoolNames.Count >= 2)
        {
            //Scores
            //girlsTeamScores.Visible = true;
            lblGirlsScores1vs2Printout.Visible = true;
            lblGirlsScores1vs2Printout.Text = girlsAbbrs[0] + " vs " + girlsAbbrs[1];

            //Team Perf
            lbtnGirlsPerfsAll.Visible = true;
            lbtnGirlsTeam2Printout.Visible = true;
            lbtnGirlsTeam2Printout.Text = girlsAbbrs[1];

            if (activeMeet.schoolNames.girlSchoolNames.Count >= 3)
            {
                //Scores
                girlsTeamScoresAll.Visible = true;
                lblGirlsScores1vs3Printout.Visible = true;
                lblGirlsScores1vs3Printout.Text = girlsAbbrs[0] + " vs " + girlsAbbrs[2];
                lblGirlsScores2vs3Printout.Visible = true;
                lblGirlsScores2vs3Printout.Text = girlsAbbrs[1] + " vs " + girlsAbbrs[2];

                //Team Perf
                lbtnGirlsTeam3Printout.Visible = true;
                lbtnGirlsTeam3Printout.Text = girlsAbbrs[2];

                if (activeMeet.schoolNames.girlSchoolNames.Count >= 4)
                {
                    //Scores
                    lblGirlsScores1vs4Printout.Visible = true;
                    lblGirlsScores1vs4Printout.Text = girlsAbbrs[0] + " vs " + girlsAbbrs[3];
                    lblGirlsScores2vs4Printout.Visible = true;
                    lblGirlsScores2vs4Printout.Text = girlsAbbrs[1] + " vs " + girlsAbbrs[3];
                    lblGirlsScores3vs4Printout.Visible = true;
                    lblGirlsScores3vs4Printout.Text = girlsAbbrs[2] + " vs " + girlsAbbrs[3];

                    //Team Perf
                    lbtnGirlsTeam4Printout.Visible = true;
                    lbtnGirlsTeam4Printout.Text = girlsAbbrs[3];

                    if (activeMeet.schoolNames.girlSchoolNames.Count >= 5)
                    {
                        //Scores
                        lblGirlsScores1vs5Printout.Visible = true;
                        lblGirlsScores1vs5Printout.Text = girlsAbbrs[0] + " vs " + girlsAbbrs[4];
                        lblGirlsScores2vs5Printout.Visible = true;
                        lblGirlsScores2vs5Printout.Text = girlsAbbrs[1] + " vs " + girlsAbbrs[4];
                        lblGirlsScores3vs5Printout.Visible = true;
                        lblGirlsScores3vs5Printout.Text = girlsAbbrs[2] + " vs " + girlsAbbrs[4];
                        lblGirlsScores4vs5Printout.Visible = true;
                        lblGirlsScores4vs5Printout.Text = girlsAbbrs[3] + " vs " + girlsAbbrs[4];

                        //Team Perf
                        lbtnGirlsTeam5Printout.Visible = true;
                        lbtnGirlsTeam5Printout.Text = girlsAbbrs[4];

                        if (activeMeet.schoolNames.girlSchoolNames.Count >= 6)
                        {
                            //Scores
                            lblGirlsScores1vs6Printout.Visible = true;
                            lblGirlsScores1vs6Printout.Text = girlsAbbrs[0] + " vs " + girlsAbbrs[5];
                            lblGirlsScores2vs6Printout.Visible = true;
                            lblGirlsScores2vs6Printout.Text = girlsAbbrs[1] + " vs " + girlsAbbrs[5];
                            lblGirlsScores3vs6Printout.Visible = true;
                            lblGirlsScores3vs6Printout.Text = girlsAbbrs[2] + " vs " + girlsAbbrs[5];
                            lblGirlsScores4vs6Printout.Visible = true;
                            lblGirlsScores4vs6Printout.Text = girlsAbbrs[3] + " vs " + girlsAbbrs[5];
                            lblGirlsScores5vs6Printout.Visible = true;
                            lblGirlsScores5vs6Printout.Text = girlsAbbrs[4] + " vs " + girlsAbbrs[5];

                            //Team Perf
                            lbtnGirlsTeam6Printout.Visible = true;
                            lbtnGirlsTeam6Printout.Text = girlsAbbrs[5];
                        }
                    }
                }
            }
        } // End Girl's data
    }

    public void CalculateScoreTotals()
    {
        lstBoysScores.Items.Clear();
        lstGirlsScores.Items.Clear();

        ScoringMgr sm = new ScoringMgr();

        Dictionary<string, OverallScore> tempDictionary = new Dictionary<string, OverallScore>();

        foreach (string s in boysActiveScores.Keys)
        {
            tempDictionary.Add(s, sm.CalculateTotal(boysActiveScores[s], "Boy"));
            lstBoysScores.Items.Add(boysActiveScores[s].team1.Item2 + ": " + boysActiveScores[s].team1Points.ToString("0.###") + " - " + boysActiveScores[s].team2.Item2 + ": " + boysActiveScores[s].team2Points.ToString("0.###"));
        }
        boysActiveScores = tempDictionary;

        Dictionary<string, OverallScore> tempDictionaryg = new Dictionary<string, OverallScore>();
        foreach (string s in girlsActiveScores.Keys)
        {
            //girlsActiveScores[s] = sm.CalculateTotal(girlsActiveScores[s], "Girl");
            tempDictionaryg.Add(s, sm.CalculateTotal(girlsActiveScores[s], "Girl"));
            lstGirlsScores.Items.Add(girlsActiveScores[s].team1.Item2 + ": " + girlsActiveScores[s].team1Points.ToString("0.###") + " - " + girlsActiveScores[s].team2.Item2 + ": " + girlsActiveScores[s].team2Points.ToString("0.###"));
        }
        girlsActiveScores = tempDictionaryg;
    }

    public void AddRelayEventToScores(string gender, string eventName, List<Performance> perf)
    {
        ScoringMgr sm = new ScoringMgr();

        if (gender.StartsWith("Boy", StringComparison.OrdinalIgnoreCase))
        {
            foreach (string t1 in activeMeet.schoolNames.boySchoolNames.Keys)
            {
                foreach (string t2 in activeMeet.schoolNames.boySchoolNames.Keys)
                {
                    if (boysActiveScores.ContainsKey(t1 + "vs." + t2))
                    {
                        RelayEvent newEventToAdd = sm.CalculateRelayEvent(t1, t2, perf);
                        boysActiveScores[t1 + "vs." + t2] = sm.AddEvent(boysActiveScores[t1 + "vs." + t2], eventName, newEventToAdd);
                    }
                }
            }
        }
        else if (gender.StartsWith("Girl", StringComparison.OrdinalIgnoreCase))
        {
            foreach (string t1 in activeMeet.schoolNames.girlSchoolNames.Keys)
            {
                foreach (string t2 in activeMeet.schoolNames.girlSchoolNames.Keys)
                {
                    if (girlsActiveScores.ContainsKey(t1 + "vs." + t2))
                    {
                        RelayEvent newEventToAdd = sm.CalculateRelayEvent(t1, t2, perf);
                        girlsActiveScores[t1 + "vs." + t2] = sm.AddEvent(girlsActiveScores[t1 + "vs." + t2], eventName, newEventToAdd);
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("ERROR in AddRelayEventToScores - gender not Boy or Girl");
            Console.WriteLine("gender = " + gender);
            ScriptManager.RegisterClientScriptBlock(null, this.GetType(), "Error", "Error Adding relay event to scores", true);
        }

        CalculateScoreTotals();
    }

    public void AddFieldEventToScores(string gender, string eventName, List<Performance> perf)
    {
        ScoringMgr sm = new ScoringMgr();

        if (gender.StartsWith("Boy", StringComparison.OrdinalIgnoreCase))
        {
            foreach (string t1 in activeMeet.schoolNames.boySchoolNames.Keys)
            {
                foreach (string t2 in activeMeet.schoolNames.boySchoolNames.Keys)
                {
                    if (boysActiveScores.ContainsKey(t1 + "vs." + t2))
                    {
                        IndEvent newEventToAdd = sm.CalculateFieldEvent(t1, t2, perf);

                        if (newEventToAdd == null)
                        {
                            //Go to Tie Breaker Page HERE

                            //FieldEventTieBreaker fetb = new FieldEventTieBreaker(this, t1, t2, perf);
                            //fetb.ShowDialog();
                            //newEventToAdd = tieBreakerEvent;
                            //tieBreakerEvent = null;
                        }

                        boysActiveScores[t1 + "vs." + t2] = sm.AddEvent(boysActiveScores[t1 + "vs." + t2], eventName, newEventToAdd);
                    }
                }
            }
        }
        else if (gender.StartsWith("Girl", StringComparison.OrdinalIgnoreCase))
        {
            foreach (string t1 in activeMeet.schoolNames.girlSchoolNames.Keys)
            {
                foreach (string t2 in activeMeet.schoolNames.girlSchoolNames.Keys)
                {
                    if (girlsActiveScores.ContainsKey(t1 + "vs." + t2))
                    {
                        IndEvent newEventToAdd = sm.CalculateFieldEvent(t1, t2, perf);

                        if (newEventToAdd == null)
                        {
                            //Go To TieBreaker Page HERE

                            //FieldEventTieBreaker fetb = new FieldEventTieBreaker(this, t1, t2, perf);
                            //fetb.ShowDialog();
                            //newEventToAdd = tieBreakerEvent;
                            //tieBreakerEvent = null;
                        }

                        girlsActiveScores[t1 + "vs." + t2] = sm.AddEvent(girlsActiveScores[t1 + "vs." + t2], eventName, newEventToAdd);
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("ERROR in AddFieldEventToScores - gender not Boy or Girl");
            Console.WriteLine("gender = " + gender);
            ScriptManager.RegisterClientScriptBlock(null, this.GetType(), "Error", "Error Adding field event to scores", true);
        }

        CalculateScoreTotals();
    }

    public void AddRunningEventToScores(string gender, string eventName, List<Performance> perf)
    {
        ScoringMgr sm = new ScoringMgr();

        if (gender.StartsWith("Boy", StringComparison.OrdinalIgnoreCase))
        {
            foreach (string t1 in activeMeet.schoolNames.boySchoolNames.Keys)
            {
                foreach (string t2 in activeMeet.schoolNames.boySchoolNames.Keys)
                {
                    if (boysActiveScores.ContainsKey(t1 + "vs." + t2))
                    {
                        IndEvent newEventToAdd = sm.CalculateRunningEvent(t1, t2, perf);
                        boysActiveScores[t1 + "vs." + t2] = sm.AddEvent(boysActiveScores[t1 + "vs." + t2], eventName, newEventToAdd);
                    }
                }
            }
        }
        else if (gender.StartsWith("Girl", StringComparison.OrdinalIgnoreCase))
        {
            foreach (string t1 in activeMeet.schoolNames.girlSchoolNames.Keys)
            {
                foreach (string t2 in activeMeet.schoolNames.girlSchoolNames.Keys)
                {
                    if (girlsActiveScores.ContainsKey(t1 + "vs." + t2))
                    {
                        IndEvent newEventToAdd = sm.CalculateRunningEvent(t1, t2, perf);
                        girlsActiveScores[t1 + "vs." + t2] = sm.AddEvent(girlsActiveScores[t1 + "vs." + t2], eventName, newEventToAdd);
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("ERROR in AddRunningEventToScores - gender not Boy or Girl");
            Console.WriteLine("gender = " + gender);
            ScriptManager.RegisterClientScriptBlock(null, this.GetType(), "Error", "Error Adding running event to scores", true);
        }

        CalculateScoreTotals();
    }

    protected void lbtnBoys100_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Boy's 100";
        Response.Redirect("RunningEventEntry.aspx");
    }

    protected void lbtnBoys200_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Boy's 200";
        Response.Redirect("RunningEventEntry.aspx");
    }

    protected void lbtnBoys400_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Boy's 400";
        Response.Redirect("RunningEventEntry.aspx");
    }

    protected void lbtnBoys800_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Boy's 800";
        Response.Redirect("RunningEventEntry.aspx");
    }

    protected void lbtnBoys1600_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Boy's 1600";
        Response.Redirect("RunningEventEntry.aspx");
    }

    protected void lbtnBoys3200_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Boy's 3200";
        Response.Redirect("RunningEventEntry.aspx");
    }

    protected void lbtnBoysHH_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Boy's HH";
        Response.Redirect("RunningEventEntry.aspx");
    }

    protected void lbtnBoys300H_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Boy's 300H";
        Response.Redirect("RunningEventEntry.aspx");
    }

    protected void lbtnBoys4x1_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Boy's 4x100";
        Response.Redirect("RelayEventEntry.aspx");
    }

    protected void lbtnBoys4x4_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Boy's 4x400";
        Response.Redirect("RelayEventEntry.aspx");
    }

    protected void lbtnBoys4x8_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Boy's 4x800";
        Response.Redirect("RelayEventEntry.aspx");
    }

    protected void lbtnBoysLJ_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Boy's LJ";
        Response.Redirect("FieldEventEntry.aspx");
    }

    protected void lbtnBoysTJ_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Boy's TJ";
        Response.Redirect("FieldEventEntry.aspx");
    }

    protected void lbtnBoysHJ_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Boy's HJ";
        Response.Redirect("FieldEventEntry.aspx");
    }

    protected void lbtnBoysPV_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Boy's PV";
        Response.Redirect("FieldEventEntry.aspx");
    }

    protected void lbtnBoysShotput_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Boy's Shotput";
        Response.Redirect("FieldEventEntry.aspx");
    }

    protected void lbtnBoysDiscus_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Boy's Discus";
        Response.Redirect("FieldEventEntry.aspx");
    }

    protected void lbtnBoysJavelin_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Boy's Javelin";
        Response.Redirect("FieldEventEntry.aspx");
    }

    protected void lbtnGirls100_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Girl's 100";
        Response.Redirect("RunningEventEntry.aspx");
    }

    protected void lbtnGirls200_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Girl's 200";
        Response.Redirect("RunningEventEntry.aspx");
    }

    protected void lbtnGirls400_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Girl's 400";
        Response.Redirect("RunningEventEntry.aspx");
    }

    protected void lbtnGirls800_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Girl's 800";
        Response.Redirect("RunningEventEntry.aspx");
    }

    protected void lbtnGirls1600_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Girl's 1600";
        Response.Redirect("RunningEventEntry.aspx");
    }

    protected void lbtnGirls3200_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Girl's 3200";
        Response.Redirect("RunningEventEntry.aspx");
    }

    protected void lbtnGirlsHH_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Girl's HH";
        Response.Redirect("RunningEventEntry.aspx");
    }

    protected void lbtnGirls300H_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Girl's 300H";
        Response.Redirect("RunningEventEntry.aspx");
    }

    protected void lbtnGirls4x1_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Girl's 4x100";
        Response.Redirect("RelayEventEntry.aspx");
    }

    protected void lbtnGirls4x4_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Girl's 4x400";
        Response.Redirect("RelayEventEntry.aspx");
    }

    protected void lbtnGirls4x8_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Girl's 4x800";
        Response.Redirect("RelayEventEntry.aspx");
    }

    protected void lbtnGirlsLJ_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Girl's LJ";
        Response.Redirect("FieldEventEntry.aspx");
    }

    protected void lbtnGirlsTJ_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Girl's TJ";
        Response.Redirect("FieldEventEntry.aspx");
    }

    protected void lbtnGirlsHJ_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Girl's HJ";
        Response.Redirect("FieldEventEntry.aspx");
    }

    protected void lbtnGirlsPV_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Girl's PV";
        Response.Redirect("FieldEventEntry.aspx");
    }

    protected void lbtnGirlsShotput_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Girl's Shotput";
        Response.Redirect("FieldEventEntry.aspx");
    }

    protected void lbtnGirlsDiscus_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Girl's Discus";
        Response.Redirect("FieldEventEntry.aspx");
    }

    protected void lbtnGirlsJavelin_Click(object sender, EventArgs e)
    {
        Session["CurrentEvent"] = "Girl's Javelin";
        Response.Redirect("FieldEventEntry.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string test = activeMeet.ToString();
        //string script = "alert(\"" + test + "\");";

        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", script, true);

        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert(\"" + activeMeet.ToString() + "\");", true);
    }

    protected void lblBoysScores1vs2Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[0] + "vs." + boysAbbrs[1]]);
    }

    protected void lblBoysScores1vs3Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[0] + "vs." + boysAbbrs[2]]);
    }

    protected void lblBoysScores2vs3Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[1] + "vs." + boysAbbrs[2]]);
    }

    protected void lblBoysScores1vs4Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[0] + "vs." + boysAbbrs[3]]);
    }

    protected void lblBoysScores2vs4Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[1] + "vs." + boysAbbrs[3]]);
    }

    protected void lblBoysScores3vs4Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[2] + "vs." + boysAbbrs[3]]);
    }

    protected void lblBoysScores1vs5Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[0] + "vs." + boysAbbrs[4]]);
    }

    protected void lblBoysScores2vs5Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[1] + "vs." + boysAbbrs[4]]);
    }

    protected void lblBoysScores3vs5Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[2] + "vs." + boysAbbrs[4]]);
    }

    protected void lblBoysScores4vs5Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[3] + "vs." + boysAbbrs[4]]);
    }

    protected void lblBoysScores1vs6Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[0] + "vs." + boysAbbrs[5]]);
    }

    protected void lblBoysScores2vs6Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[1] + "vs." + boysAbbrs[5]]);
    }

    protected void lblBoysScores3vs6Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[2] + "vs." + boysAbbrs[5]]);
    }

    protected void lblBoysScores4vs6Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[3] + "vs." + boysAbbrs[5]]);
    }

    protected void lblBoysScores5vs6Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[4] + "vs." + boysAbbrs[5]]);
    }

    protected void lblGirlsScores1vs2Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[0] + "vs." + girlsAbbrs[1]]);
    }

    protected void lblGirlsScores1vs3Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[0] + "vs." + girlsAbbrs[2]]);
    }

    protected void lblGirlsScores2vs3Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[1] + "vs." + girlsAbbrs[2]]);
    }

    protected void lblGirlsScores1vs4Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[0] + "vs." + girlsAbbrs[3]]);
    }

    protected void lblGirlsScores2vs4Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[1] + "vs." + girlsAbbrs[3]]);
    }

    protected void lblGirlsScores3vs4Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[2] + "vs." + girlsAbbrs[3]]);
    }

    protected void lblGirlsScores1vs5Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[0] + "vs." + girlsAbbrs[4]]);
    }

    protected void lblGirlsScores2vs5Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[1] + "vs." + girlsAbbrs[4]]);
    }

    protected void lblGirlsScores3vs5Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[2] + "vs." + girlsAbbrs[4]]);
    }

    protected void lblGirlsScores4vs5Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[3] + "vs." + girlsAbbrs[4]]);
    }

    protected void lblGirlsScores1vs6Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[0] + "vs." + girlsAbbrs[5]]);
    }

    protected void lblGirlsScores2vs6Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[1] + "vs." + girlsAbbrs[5]]);
    }

    protected void lblGirlsScores3vs6Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[2] + "vs." + girlsAbbrs[5]]);
    }

    protected void lblGirlsScores4vs6Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[3] + "vs." + girlsAbbrs[5]]);
    }

    protected void lblGirlsScores5vs6Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[4] + "vs." + girlsAbbrs[5]]);
    }

    protected void lbtnBoysTeam1Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateTeamPerfDoc(lbtnBoysTeam1Printout.Text, "Boy's", activeMeet);
    }

    protected void lbtnBoysTeam2Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateTeamPerfDoc(lbtnBoysTeam2Printout.Text, "Boy's", activeMeet);
    }

    protected void lbtnBoysTeam3Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateTeamPerfDoc(lbtnBoysTeam3Printout.Text, "Boy's", activeMeet);
    }

    protected void lbtnBoysTeam4Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateTeamPerfDoc(lbtnBoysTeam4Printout.Text, "Boy's", activeMeet);
    }

    protected void lbtnBoysTeam5Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateTeamPerfDoc(lbtnBoysTeam5Printout.Text, "Boy's", activeMeet);
    }

    protected void lbtnBoysTeam6Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateTeamPerfDoc(lbtnBoysTeam6Printout.Text, "Boy's", activeMeet);
    }

    protected void lbtnGirlsTeam1Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateTeamPerfDoc(lbtnGirlsTeam1Printout.Text, "Girl's", activeMeet);
    }

    protected void lbtnGirlsTeam2Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateTeamPerfDoc(lbtnGirlsTeam2Printout.Text, "Girl's", activeMeet);
    }

    protected void lbtnGirlsTeam3Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateTeamPerfDoc(lbtnGirlsTeam3Printout.Text, "Girl's", activeMeet);
    }

    protected void lbtnGirlsTeam4Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateTeamPerfDoc(lbtnGirlsTeam4Printout.Text, "Girl's", activeMeet);
    }

    protected void lbtnGirlsTeam5Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateTeamPerfDoc(lbtnGirlsTeam5Printout.Text, "Girl's", activeMeet);
    }

    protected void lbtnGirlsTeam6Printout_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        pm.CreateTeamPerfDoc(lbtnGirlsTeam6Printout.Text, "Girl's", activeMeet);
    }

    protected void lbtnGirlsPerfsAll_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        if(activeMeet != null && activeMeet.schoolNames != null && activeMeet.schoolNames.girlSchoolNames != null)
        {
            foreach (string teamName in activeMeet.schoolNames.girlSchoolNames.Keys)
            {
                pm.CreateTeamPerfDoc(teamName, "Girl's", activeMeet);
            }
        }
    }

    protected void lbtnBoysPerfsAll_Click(object sender, EventArgs e)
    {
        PrintoutMgr pm = new PrintoutMgr();
        if (activeMeet != null && activeMeet.schoolNames != null && activeMeet.schoolNames.boySchoolNames != null)
        {
            foreach (string teamName in activeMeet.schoolNames.boySchoolNames.Keys)
            {
                pm.CreateTeamPerfDoc(teamName, "Boy's", activeMeet);
            }
        }
    }

    public void SortPerfs(string eventName)
    {
        if (activeMeet == null || activeMeet.performances == null || !activeMeet.performances.ContainsKey(eventName))
        {
            Console.WriteLine("Meet information for " + eventName + " not available");
        }
        else
        {
            if (eventName.Contains("LJ") || eventName.Contains("TJ") || eventName.Contains("HJ") || eventName.Contains("PV") || eventName.Contains("Shotput") || eventName.Contains("Discus") || eventName.Contains("Javelin"))
                activeMeet.performances[eventName] = activeMeet.performances[eventName].OrderByDescending(o => o.performance).ToList();
            else
                activeMeet.performances[eventName] = activeMeet.performances[eventName].OrderBy(o => o.performance).ToList();
        }
    }

    private void printEvent(string eventName)
    {
        PrintoutMgr pm = new PrintoutMgr();
        SortPerfs(eventName);
        if (activeMeet == null || activeMeet.performances == null || !activeMeet.performances.ContainsKey(eventName))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert(\"Meet information for " + eventName + " not available\");", true);
        }
        else
        {
            pm.CreateIndEventDoc(eventName, activeMeet.performances[eventName]);
        }
    }

    protected void lbtnBoys100Printout_Click(object sender, EventArgs e)
    {
        printEvent("Boy's 100");
    }

    protected void lbtnBoys200Printout_Click(object sender, EventArgs e)
    {
        printEvent("Boy's 200");
    }

    protected void lbtnBoys400Printout_Click(object sender, EventArgs e)
    {
        printEvent("Boy's 400");
    }

    protected void lbtnBoys800Printout_Click(object sender, EventArgs e)
    {
        printEvent("Boy's 800");
    }

    protected void lbtnBoys1600Printout_Click(object sender, EventArgs e)
    {
        printEvent("Boy's 1600");
    }

    protected void lbtnBoys3200Printout_Click(object sender, EventArgs e)
    {
        printEvent("Boy's 3200");
    }

    protected void lbtnBoysHHPrintout_Click(object sender, EventArgs e)
    {
        printEvent("Boy's HH");
    }

    protected void lbtnBoys300HPrintout_Click(object sender, EventArgs e)
    {
        printEvent("Boy's 300H");
    }

    protected void lbtnBoys4x1Printout_Click(object sender, EventArgs e)
    {
        printEvent("Boy's 4x100");
    }

    protected void lbtnBoys4x4Printout_Click(object sender, EventArgs e)
    {
        printEvent("Boy's 4x400");
    }

    protected void lbtnBoys4x8Printout_Click(object sender, EventArgs e)
    {
        printEvent("Boy's 4x800");
    }

    protected void lbtnBoysLJPrintout_Click(object sender, EventArgs e)
    {
        printEvent("Boy's LJ");
    }

    protected void lbtnBoysTJPrintout_Click(object sender, EventArgs e)
    {
        printEvent("Boy's TJ");
    }

    protected void lbtnBoysHJPrintout_Click(object sender, EventArgs e)
    {
        printEvent("Boy's HJ");
    }

    protected void lbtnBoysPVPrintout_Click(object sender, EventArgs e)
    {
        printEvent("Boy's PV");
    }

    protected void lbtnBoysShotputPrintout_Click(object sender, EventArgs e)
    {
        printEvent("Boy's Shotput");
    }

    protected void lbtnBoysDiscusPrintout_Click(object sender, EventArgs e)
    {
        printEvent("Boy's Discus");
    }

    protected void lbtnBoysJavelinPrintout_Click(object sender, EventArgs e)
    {
        printEvent("Boy's Javelin");
    }

    protected void lbtnGirls100Printout_Click(object sender, EventArgs e)
    {
        printEvent("Girl's 100");
    }

    protected void lbtnGirls200Printout_Click(object sender, EventArgs e)
    {
        printEvent("Girl's 200");
    }

    protected void lbtnGirls400Printout_Click(object sender, EventArgs e)
    {
        printEvent("Girl's 400");
    }

    protected void lbtnGirls800Printout_Click(object sender, EventArgs e)
    {
        printEvent("Girl's 800");
    }

    protected void lbtnGirls1600Printout_Click(object sender, EventArgs e)
    {
        printEvent("Girl's 1600");
    }

    protected void lbtnGirls3200Printout_Click(object sender, EventArgs e)
    {
        printEvent("Girl's 3200");
    }

    protected void lbtnGirlsHHPrintout_Click(object sender, EventArgs e)
    {
        printEvent("Girl's HH");
    }

    protected void lbtnGirls300HPrintout_Click(object sender, EventArgs e)
    {
        printEvent("Girl's 300H");
    }

    protected void lbtnGirls4x1Printout_Click(object sender, EventArgs e)
    {
        printEvent("Girl's 4x100");
    }

    protected void lbtnGirls4x4Printout_Click(object sender, EventArgs e)
    {
        printEvent("Girl's 4x400");
    }

    protected void lbtnGirls4x8Printout_Click(object sender, EventArgs e)
    {
        printEvent("Girl's 4x800");
    }

    protected void lbtnGirlsLJPrintout_Click(object sender, EventArgs e)
    {
        printEvent("Girl's LJ");
    }

    protected void lbtnGirlsTJPrintout_Click(object sender, EventArgs e)
    {
        printEvent("Girl's TJ");
    }

    protected void lbtnGirlsHJPrintout_Click(object sender, EventArgs e)
    {
        printEvent("Girl's HJ");
    }

    protected void lbtnGirlsPVPrintout_Click(object sender, EventArgs e)
    {
        printEvent("Girl's PV");
    }

    protected void lbtnGirlsShotputPrintout_Click(object sender, EventArgs e)
    {
        printEvent("Girl's Shotput");
    }

    protected void lbtnGirlsDiscusPrintout_Click(object sender, EventArgs e)
    {
        printEvent("Girl's Discus");
    }

    protected void lbtnGirlsJavelinPrintout_Click(object sender, EventArgs e)
    {
        printEvent("Girl's Javelin");
    }

    protected void lbtnBoysEvents_Click(object sender, EventArgs e)
    {
        if (panEnterBoysEvents.Visible)
            panEnterBoysEvents.Visible = false;
        else
            panEnterBoysEvents.Visible = true;
    }

    protected void lbtnGirlsEvents_Click(object sender, EventArgs e)
    {
        if (panEnterGirlsEvents.Visible)
            panEnterGirlsEvents.Visible = false;
        else
            panEnterGirlsEvents.Visible = true;
    }

    protected void lbtnEnterData_Click(object sender, EventArgs e)
    {
        if (lbtnBoysEvents.Visible)
            lbtnBoysEvents.Visible = false;
        else
            lbtnBoysEvents.Visible = true;

        if (lbtnGirlsEvents.Visible)
            lbtnGirlsEvents.Visible = false;
        else
            lbtnGirlsEvents.Visible = true;
    }

    protected void lbtnMain_Click(object sender, EventArgs e)
    {
        if (panMain.Visible)
            panMain.Visible = false;
        else
            panMain.Visible = true;
    }

    protected void lbtnPrintouts_Click(object sender, EventArgs e)
    {
        if (lbtnBoysTeamScorePrintouts.Visible)
            lbtnBoysTeamScorePrintouts.Visible = false;
        else
            lbtnBoysTeamScorePrintouts.Visible = true;

        if (lbtnGirlsTeamScorePrintouts.Visible)
            lbtnGirlsTeamScorePrintouts.Visible = false;
        else
            lbtnGirlsTeamScorePrintouts.Visible = true;

        if (lbtnBoysTeamPerfPrintouts.Visible)
            lbtnBoysTeamPerfPrintouts.Visible = false;
        else
            lbtnBoysTeamPerfPrintouts.Visible = true;

        if (lbtnGirlsTeamPerfPrintouts.Visible)
            lbtnGirlsTeamPerfPrintouts.Visible = false;
        else
            lbtnGirlsTeamPerfPrintouts.Visible = true;

        if (lbtnBoysEventPrintouts.Visible)
            lbtnBoysEventPrintouts.Visible = false;
        else
            lbtnBoysEventPrintouts.Visible = true;

        if (lbtnGirlsEventPrintouts.Visible)
            lbtnGirlsEventPrintouts.Visible = false;
        else
            lbtnGirlsEventPrintouts.Visible = true;
    }

    protected void lbtnBoysTeamScorePrintouts_Click(object sender, EventArgs e)
    {
        if (panBoysTeamScorePrintouts.Visible)
            panBoysTeamScorePrintouts.Visible = false;
        else
            panBoysTeamScorePrintouts.Visible = true;
    }

    protected void lbtnGirlsTeamScorePrintouts_Click(object sender, EventArgs e)
    {
        if (panGirlsTeamScorePrintouts.Visible)
            panGirlsTeamScorePrintouts.Visible = false;
        else
            panGirlsTeamScorePrintouts.Visible = true;
    }

    protected void lbtnBoysTeamPerfPrintouts_Click(object sender, EventArgs e)
    {
        if (panBoysTeamPerfPrintouts.Visible)
            panBoysTeamPerfPrintouts.Visible = false;
        else
            panBoysTeamPerfPrintouts.Visible = true;
    }

    protected void lbtnGirlsTeamPerfPrintouts_Click(object sender, EventArgs e)
    {
        if (panGirlsTeamPerfPrintouts.Visible)
            panGirlsTeamPerfPrintouts.Visible = false;
        else
            panGirlsTeamPerfPrintouts.Visible = true;
    }

    protected void lbtnBoysEventPrintouts_Click(object sender, EventArgs e)
    {
        if (panBoysEventPrintouts.Visible)
            panBoysEventPrintouts.Visible = false;
        else
            panBoysEventPrintouts.Visible = true;
    }

    protected void lbtnGirlsEventPrintouts_Click(object sender, EventArgs e)
    {
        if (panGirlsEventPrintouts.Visible)
            panGirlsEventPrintouts.Visible = false;
        else
            panGirlsEventPrintouts.Visible = true;
    }

    protected void lbtnOpenMeet_Click(object sender, EventArgs e)
    {
        Response.Redirect("OpenMeet.aspx");
    }

    protected void lbtnNewMeet_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateMeet.aspx");
    }

    protected void lbtnAccount_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}
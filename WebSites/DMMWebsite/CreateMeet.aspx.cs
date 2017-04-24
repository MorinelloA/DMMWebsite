using DualMeetManager.Business.Managers;
using DMMLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateMeet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblCounter.Text = Application["SiteCounter"].ToString();
    }

    int meetID = -1;
    Meet newMeet;

    protected void ddlBoys_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBoys.SelectedValue == "0")
        {
            panBoys1.Visible = false;
            panBoys2.Visible = false;
            panBoys3.Visible = false;
            panBoys4.Visible = false;
            panBoys5.Visible = false;
            panBoys6.Visible = false;
        }
        else if (ddlBoys.SelectedValue == "1")
        {
            panBoys1.Visible = true;
            panBoys2.Visible = false;
            panBoys3.Visible = false;
            panBoys4.Visible = false;
            panBoys5.Visible = false;
            panBoys6.Visible = false;
        }
        else if (ddlBoys.SelectedValue == "2")
        {
            panBoys1.Visible = true;
            panBoys2.Visible = true;
            panBoys3.Visible = false;
            panBoys4.Visible = false;
            panBoys5.Visible = false;
            panBoys6.Visible = false;
        }
        else if (ddlBoys.SelectedValue == "3")
        {
            panBoys1.Visible = true;
            panBoys2.Visible = true;
            panBoys3.Visible = true;
            panBoys4.Visible = false;
            panBoys5.Visible = false;
            panBoys6.Visible = false;
        }
        else if (ddlBoys.SelectedValue == "4")
        {
            panBoys1.Visible = true;
            panBoys2.Visible = true;
            panBoys3.Visible = true;
            panBoys4.Visible = true;
            panBoys5.Visible = false;
            panBoys6.Visible = false;
        }
        else if (ddlBoys.SelectedValue == "5")
        {
            panBoys1.Visible = true;
            panBoys2.Visible = true;
            panBoys3.Visible = true;
            panBoys4.Visible = true;
            panBoys5.Visible = true;
            panBoys6.Visible = false;
        }
        else if (ddlBoys.SelectedValue == "6")
        {
            panBoys1.Visible = true;
            panBoys2.Visible = true;
            panBoys3.Visible = true;
            panBoys4.Visible = true;
            panBoys5.Visible = true;
            panBoys6.Visible = true;
        }
    }

    protected void ddlGirls_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGirls.SelectedValue == "0")
        {
            panGirls1.Visible = false;
            panGirls2.Visible = false;
            panGirls3.Visible = false;
            panGirls4.Visible = false;
            panGirls5.Visible = false;
            panGirls6.Visible = false;
        }
        else if (ddlGirls.SelectedValue == "1")
        {
            panGirls1.Visible = true;
            panGirls2.Visible = false;
            panGirls3.Visible = false;
            panGirls4.Visible = false;
            panGirls5.Visible = false;
            panGirls6.Visible = false;
        }
        else if (ddlGirls.SelectedValue == "2")
        {
            panGirls1.Visible = true;
            panGirls2.Visible = true;
            panGirls3.Visible = false;
            panGirls4.Visible = false;
            panGirls5.Visible = false;
            panGirls6.Visible = false;
        }
        else if (ddlGirls.SelectedValue == "3")
        {
            panGirls1.Visible = true;
            panGirls2.Visible = true;
            panGirls3.Visible = true;
            panGirls4.Visible = false;
            panGirls5.Visible = false;
            panGirls6.Visible = false;
        }
        else if (ddlGirls.SelectedValue == "4")
        {
            panGirls1.Visible = true;
            panGirls2.Visible = true;
            panGirls3.Visible = true;
            panGirls4.Visible = true;
            panGirls5.Visible = false;
            panGirls6.Visible = false;
        }
        else if (ddlGirls.SelectedValue == "5")
        {
            panGirls1.Visible = true;
            panGirls2.Visible = true;
            panGirls3.Visible = true;
            panGirls4.Visible = true;
            panGirls5.Visible = true;
            panGirls6.Visible = false;
        }
        else if (ddlGirls.SelectedValue == "6")
        {
            panGirls1.Visible = true;
            panGirls2.Visible = true;
            panGirls3.Visible = true;
            panGirls4.Visible = true;
            panGirls5.Visible = true;
            panGirls6.Visible = true;
        }
    }

    protected void cmdCreate_Click(object sender, EventArgs e)
    {
        panAlert.Visible = true;
        if (txtLocation.Text == "")
        {
            lblAlert.Text = "Please enter a location";
        }
        else if (txtWeather.Text == "")
        {
            lblAlert.Text = "Please enter weather conditions";
        }
        else if (string.IsNullOrWhiteSpace(txtBoysTeam1.Text) || string.IsNullOrWhiteSpace(txtBoysAbbr1.Text))
        {
            lblAlert.Text = "Please enter team name information for boy's team #1";
        }
        else if ((string.IsNullOrWhiteSpace(txtBoysTeam2.Text) && !string.IsNullOrWhiteSpace(txtBoysAbbr2.Text)) || (!string.IsNullOrWhiteSpace(txtBoysTeam2.Text) && string.IsNullOrWhiteSpace(txtBoysAbbr2.Text)))
        {
            lblAlert.Text = "Invalid name information for boy's team #2";
        }
        else if ((string.IsNullOrWhiteSpace(txtBoysTeam3.Text) && !string.IsNullOrWhiteSpace(txtBoysAbbr3.Text)) || (!string.IsNullOrWhiteSpace(txtBoysTeam3.Text) && string.IsNullOrWhiteSpace(txtBoysAbbr3.Text)))
        {
            lblAlert.Text = "Invalid name information for boy's team #3";
        }
        else if ((string.IsNullOrWhiteSpace(txtBoysTeam4.Text) && !string.IsNullOrWhiteSpace(txtBoysAbbr4.Text)) || (!string.IsNullOrWhiteSpace(txtBoysTeam4.Text) && string.IsNullOrWhiteSpace(txtBoysAbbr4.Text)))
        {
            lblAlert.Text = "Invalid name information for boy's team #4";
        }
        else if ((string.IsNullOrWhiteSpace(txtBoysTeam5.Text) && !string.IsNullOrWhiteSpace(txtBoysAbbr5.Text)) || (!string.IsNullOrWhiteSpace(txtBoysTeam5.Text) && string.IsNullOrWhiteSpace(txtBoysAbbr5.Text)))
        {
            lblAlert.Text = "Invalid name information for boy's team #5";
        }
        else if ((string.IsNullOrWhiteSpace(txtBoysTeam6.Text) && !string.IsNullOrWhiteSpace(txtBoysAbbr6.Text)) || (!string.IsNullOrWhiteSpace(txtBoysTeam6.Text) && string.IsNullOrWhiteSpace(txtBoysAbbr6.Text)))
        {
            lblAlert.Text = "Invalid name information for boy's team #6";
        }
        else if (string.IsNullOrWhiteSpace(txtGirlsTeam1.Text) || string.IsNullOrWhiteSpace(txtGirlsAbbr1.Text))
        {
            lblAlert.Text = "Please enter team name information for girl's team #1";
        }
        else if ((string.IsNullOrWhiteSpace(txtGirlsTeam2.Text) && !string.IsNullOrWhiteSpace(txtGirlsAbbr2.Text)) || (!string.IsNullOrWhiteSpace(txtGirlsTeam2.Text) && string.IsNullOrWhiteSpace(txtGirlsAbbr2.Text)))
        {
            lblAlert.Text = "Invalid name information for girl's team #2";
        }
        else if ((string.IsNullOrWhiteSpace(txtGirlsTeam3.Text) && !string.IsNullOrWhiteSpace(txtGirlsAbbr3.Text)) || (!string.IsNullOrWhiteSpace(txtGirlsTeam3.Text) && string.IsNullOrWhiteSpace(txtGirlsAbbr3.Text)))
        {
            lblAlert.Text = "Invalid name information for girl's team #3";
        }
        else if ((string.IsNullOrWhiteSpace(txtGirlsTeam4.Text) && !string.IsNullOrWhiteSpace(txtGirlsAbbr4.Text)) || (!string.IsNullOrWhiteSpace(txtGirlsTeam4.Text) && string.IsNullOrWhiteSpace(txtGirlsAbbr4.Text)))
        {
            lblAlert.Text = "Invalid name information for girl's team #4";
        }
        else if ((string.IsNullOrWhiteSpace(txtGirlsTeam5.Text) && !string.IsNullOrWhiteSpace(txtGirlsAbbr5.Text)) || (!string.IsNullOrWhiteSpace(txtGirlsTeam5.Text) && string.IsNullOrWhiteSpace(txtGirlsAbbr5.Text)))
        {
            lblAlert.Text = "Invalid name information for girl's team #5";
        }
        else if ((string.IsNullOrWhiteSpace(txtGirlsTeam6.Text) && !string.IsNullOrWhiteSpace(txtGirlsAbbr6.Text)) || (!string.IsNullOrWhiteSpace(txtGirlsTeam6.Text) && string.IsNullOrWhiteSpace(txtGirlsAbbr6.Text)))
        {
            lblAlert.Text = "Invalid name information for girl's team #6";
        }
        else
        {
            

            string meetLocation = txtLocation.Text;

            int month = 1;
            if (ddlMonth.Text == "February")
                month = 2;
            else if (ddlMonth.Text == "March")
                month = 3;
            else if (ddlMonth.Text == "April")
                month = 4;
            else if (ddlMonth.Text == "May")
                month = 5;
            else if (ddlMonth.Text == "June")
                month = 6;
            else if (ddlMonth.Text == "July")
                month = 7;
            else if (ddlMonth.Text == "August")
                month = 8;
            else if (ddlMonth.Text == "September")
                month = 9;
            else if (ddlMonth.Text == "October")
                month = 10;
            else if (ddlMonth.Text == "November")
                month = 11;
            else if (ddlMonth.Text == "December")
                month = 12;

            DateTime meetDateTime = new DateTime(Convert.ToInt32(ddlYear.Text), month, Convert.ToInt32(ddlDay.Text));
            string meetWeather = txtWeather.Text;
            string boysTeam1Abbr = txtBoysAbbr1.Text.Trim();
            string boysTeam1Name = txtBoysTeam1.Text.Trim();
            string boysTeam2Abbr = txtBoysAbbr2.Text.Trim();
            string boysTeam2Name = txtBoysTeam2.Text.Trim();
            string boysTeam3Abbr = txtBoysAbbr3.Text.Trim();
            string boysTeam3Name = txtBoysTeam3.Text.Trim();
            string boysTeam4Abbr = txtBoysAbbr4.Text.Trim();
            string boysTeam4Name = txtBoysTeam4.Text.Trim();
            string boysTeam5Abbr = txtBoysAbbr5.Text.Trim();
            string boysTeam5Name = txtBoysTeam5.Text.Trim();
            string boysTeam6Abbr = txtBoysAbbr6.Text.Trim();
            string boysTeam6Name = txtBoysTeam6.Text.Trim();
            string girlsTeam1Abbr = txtGirlsAbbr1.Text.Trim();
            string girlsTeam1Name = txtGirlsTeam1.Text.Trim();
            string girlsTeam2Abbr = txtGirlsAbbr2.Text.Trim();
            string girlsTeam2Name = txtGirlsTeam2.Text.Trim();
            string girlsTeam3Abbr = txtGirlsAbbr3.Text.Trim();
            string girlsTeam3Name = txtGirlsTeam3.Text.Trim();
            string girlsTeam4Abbr = txtGirlsAbbr4.Text.Trim();
            string girlsTeam4Name = txtGirlsTeam4.Text.Trim();
            string girlsTeam5Abbr = txtGirlsAbbr5.Text.Trim();
            string girlsTeam5Name = txtGirlsTeam5.Text.Trim();
            string girlsTeam6Abbr = txtGirlsAbbr6.Text.Trim();
            string girlsTeam6Name = txtGirlsTeam6.Text.Trim();

            List<string> boysNames = new List<string>();
            if (!string.IsNullOrWhiteSpace(boysTeam1Name))
                boysNames.Add(boysTeam1Name);
            if (!string.IsNullOrWhiteSpace(boysTeam2Name))
                boysNames.Add(boysTeam2Name);
            if (!string.IsNullOrWhiteSpace(boysTeam3Name))
                boysNames.Add(boysTeam3Name);
            if (!string.IsNullOrWhiteSpace(boysTeam4Name))
                boysNames.Add(boysTeam4Name);
            if (!string.IsNullOrWhiteSpace(boysTeam5Name))
                boysNames.Add(boysTeam5Name);
            if (!string.IsNullOrWhiteSpace(boysTeam6Name))
                boysNames.Add(boysTeam6Name);

            List<string> boysAbbrs = new List<string>();
            if (!string.IsNullOrWhiteSpace(boysTeam1Abbr))
                boysAbbrs.Add(boysTeam1Abbr);
            if (!string.IsNullOrWhiteSpace(boysTeam2Abbr))
                boysAbbrs.Add(boysTeam2Abbr);
            if (!string.IsNullOrWhiteSpace(boysTeam3Abbr))
                boysAbbrs.Add(boysTeam3Abbr);
            if (!string.IsNullOrWhiteSpace(boysTeam4Abbr))
                boysAbbrs.Add(boysTeam4Abbr);
            if (!string.IsNullOrWhiteSpace(boysTeam5Abbr))
                boysAbbrs.Add(boysTeam5Abbr);
            if (!string.IsNullOrWhiteSpace(boysTeam6Abbr))
                boysAbbrs.Add(boysTeam6Abbr);

            List<string> girlsNames = new List<string>();
            if (!string.IsNullOrWhiteSpace(girlsTeam1Name))
                girlsNames.Add(girlsTeam1Name);
            if (!string.IsNullOrWhiteSpace(girlsTeam2Name))
                girlsNames.Add(girlsTeam2Name);
            if (!string.IsNullOrWhiteSpace(girlsTeam3Name))
                girlsNames.Add(girlsTeam3Name);
            if (!string.IsNullOrWhiteSpace(girlsTeam4Name))
                girlsNames.Add(girlsTeam4Name);
            if (!string.IsNullOrWhiteSpace(girlsTeam5Name))
                girlsNames.Add(girlsTeam5Name);
            if (!string.IsNullOrWhiteSpace(girlsTeam6Name))
                girlsNames.Add(girlsTeam6Name);

            List<string> girlsAbbrs = new List<string>();
            if (!string.IsNullOrWhiteSpace(girlsTeam1Abbr))
                girlsAbbrs.Add(girlsTeam1Abbr);
            if (!string.IsNullOrWhiteSpace(girlsTeam2Abbr))
                girlsAbbrs.Add(girlsTeam2Abbr);
            if (!string.IsNullOrWhiteSpace(girlsTeam3Abbr))
                girlsAbbrs.Add(girlsTeam3Abbr);
            if (!string.IsNullOrWhiteSpace(girlsTeam4Abbr))
                girlsAbbrs.Add(girlsTeam4Abbr);
            if (!string.IsNullOrWhiteSpace(girlsTeam5Abbr))
                girlsAbbrs.Add(girlsTeam5Abbr);
            if (!string.IsNullOrWhiteSpace(girlsTeam6Abbr))
                girlsAbbrs.Add(girlsTeam6Abbr);

            if (boysNames.Distinct().Count() != boysNames.Count())
                lblAlert.Text = "All Boy's names must be unique";
            else if (boysAbbrs.Distinct().Count() != boysAbbrs.Count())
                lblAlert.Text = "All Boy's abbrs must be unique";
            else if (girlsNames.Distinct().Count() != girlsNames.Count())
                lblAlert.Text = "All Girl's names must be unique";
            else if (girlsAbbrs.Distinct().Count() != girlsAbbrs.Count())
                lblAlert.Text = "All Girl's abbrs must be unique";
            else
            {
                Dictionary<string, string> boysTeams = new Dictionary<string, string>();
                boysTeams.Add(boysTeam1Abbr, boysTeam1Name);
                if (!string.IsNullOrWhiteSpace(boysTeam2Abbr))
                    boysTeams.Add(boysTeam2Abbr, boysTeam2Name);
                if (!string.IsNullOrWhiteSpace(boysTeam3Abbr))
                    boysTeams.Add(boysTeam3Abbr, boysTeam3Name);
                if (!string.IsNullOrWhiteSpace(boysTeam4Abbr))
                    boysTeams.Add(boysTeam4Abbr, boysTeam4Name);
                if (!string.IsNullOrWhiteSpace(boysTeam5Abbr))
                    boysTeams.Add(boysTeam5Abbr, boysTeam5Name);
                if (!string.IsNullOrWhiteSpace(boysTeam6Abbr))
                    boysTeams.Add(boysTeam6Abbr, boysTeam6Name);

                Dictionary<string, string> girlsTeams = new Dictionary<string, string>();
                girlsTeams.Add(girlsTeam1Abbr, girlsTeam1Name);
                if (!string.IsNullOrWhiteSpace(girlsTeam2Abbr))
                    girlsTeams.Add(girlsTeam2Abbr, girlsTeam2Name);
                if (!string.IsNullOrWhiteSpace(girlsTeam3Abbr))
                    girlsTeams.Add(girlsTeam3Abbr, girlsTeam3Name);
                if (!string.IsNullOrWhiteSpace(girlsTeam4Abbr))
                    girlsTeams.Add(girlsTeam4Abbr, girlsTeam4Name);
                if (!string.IsNullOrWhiteSpace(girlsTeam5Abbr))
                    girlsTeams.Add(girlsTeam5Abbr, girlsTeam5Name);
                if (!string.IsNullOrWhiteSpace(girlsTeam6Abbr))
                    girlsTeams.Add(girlsTeam6Abbr, girlsTeam6Name);

                Teams newTeams = new Teams(boysTeams, girlsTeams);

                newMeet = new Meet(meetDateTime, meetLocation, meetWeather, newTeams);

                if (newMeet.validate())
                {
                    DatabaseMgr dm = new DatabaseMgr();
                    meetID = dm.FindMeetId(newMeet);

                    if (meetID < 0)
                    {
                        panAlert.GroupingText = "Problem loading meet database. Please try again later";
                    }
                    else
                    {
                        
                        if (meetID == 0) //Meet does not exist in database
                        {
                            bool didAdd = dm.AddMeet(newMeet, Session["Username"].ToString());
                            if (didAdd)
                            {
                                Session["ActiveMeet"] = newMeet;

                                //Open MeetHub here
                                Response.Redirect("MeetHub.aspx");
                            }
                            else
                            {
                                lblAlert.Text = "Problem addign meet to database, please try again later";
                            }
                        }
                        else
                        {
                            panAlert.Visible = false;
                            panDatabaseAlert.Visible = true;

                            lblDatabaseAlert.Text = "Meet already exists, do you wish to overwrite existing meet, or open existing meet?";
                            cmdCreate.Visible = false;
                        }
                    }
                    
                }
                else
                {
                    lblAlert.Text = "Unknown problem creating this meet. Data was invalid.";
                }
            }
        }
    }

    protected void cmdOverwrite_Click(object sender, EventArgs e)
    {
        panAlert.Visible = true;
        panDatabaseAlert.Visible = false;

        DatabaseMgr dm = new DatabaseMgr();
        bool didDelete = dm.DeleteMeet(meetID);
        if(didDelete)
        {
            bool didAdd = dm.AddMeet(newMeet, Session["Username"].ToString());
            if(didAdd)
            {
                Session["ActiveMeet"] = newMeet;

                //Open MeetHub here
                Response.Redirect("MeetHub.aspx");
            }
            else
            {
                lblAlert.Text = "Meet deleted from database, but error adding new database entry";
            }
        }
        else
        {
            lblAlert.Text = "Error deleting existing meet from database";
        }
    }

    protected void cmdOpen_Click(object sender, EventArgs e)
    {
        panAlert.Visible = true;
        panDatabaseAlert.Visible = false;

        DatabaseMgr dm = new DatabaseMgr();
        Meet openedMeet = dm.FindMeet(meetID);
        if(openedMeet != null)
        {
            Session["ActiveMeet"] = openedMeet;

            //Open MeetHub here
            Response.Redirect("MeetHub.aspx");
        }
        else
        {
            lblAlert.Text = "Unknown error loading meet from database";
        }
    }

    protected void lbtnOpen_Click(object sender, EventArgs e)
    {
        Response.Redirect("OpenMeet.aspx");
    }
}
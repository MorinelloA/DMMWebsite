using DualMeetManager.Business.Managers;
using DMMLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FieldEventEntry : System.Web.UI.Page
{
    int currentHeatNum = 0;
    string eventName;
    List<Performance> allPerfs = new List<Performance>();
    EventMgr em = new EventMgr();

    protected void Page_Load(object sender, EventArgs e)
    {
        Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

        if (!IsPostBack) //If the page is loaded for the first time
        {
            if (Session["CurrentEvent"] != null) //This should never not be true
            {
                eventName = Session["CurrentEvent"].ToString();

                Meet myMeet = (Meet)Session["ActiveMeet"];
                if(myMeet.performances != null && myMeet.performances.ContainsKey(eventName))
                    allPerfs = myMeet.performances[eventName];
                
            }
            else //Error, consider a redirect
            {
                Console.WriteLine("ERROR. Invalid eventName");

                //Should prob exit and go to MeetHub page at this point
                //Code below exists for debug purposes
                eventName = "INVALID EVENT";
            }

            this.Title = eventName + " Entry";
            if (eventName.StartsWith("Boy"))
            {
                //Change background color to lightblue
                PageBody.Attributes.Add("style", "background-color: #ADD8E6");
            }
            else if (eventName.StartsWith("Girl"))
            {
                //Change background color to lightpink
                PageBody.Attributes.Add("style", "background-color: #ffb6c1");
            }
            PopulateTeams();
            SortListOfPerfs();
            currentHeatNum = 0;
            EnterDataIntoForm();
        }
        
        Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    protected void cmdClear_Click(object sender, EventArgs e)
    {
        panClear.Visible = true;
    }

    protected void cmdYes_Click(object sender, EventArgs e)
    {
        panClear.Visible = false;
        ClearAll();
    }

    protected void cmdNo_Click(object sender, EventArgs e)
    {
        panClear.Visible = false;
    }

    protected void cmdEnter_Click(object sender, EventArgs e)
    {
        Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        if (AddFlightToList())
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Success", "Data for " + eventName + " entered", true);

            //Add Event Here
            EventMgr em = new EventMgr();
            Meet myMeet = (Meet)Session["ActiveMeet"];
            eventName = (string)Session["CurrentEvent"];
            myMeet.performances = em.AddPerformanceToEvent(myMeet.performances, eventName, allPerfs);
            Session["ActiveMeet"] = myMeet;

            DatabaseMgr dm = new DatabaseMgr();
            int meetID = dm.FindMeetId(myMeet);
            dm.DeletePerformance(meetID, eventName);
            dm.AddPerformance(myMeet, eventName);

            //Go back to MeetHub Here
            Response.Redirect("MeetHub.aspx");

        }
        Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Check to make sure that the data entered into the form by the user is valid
    /// </summary>
    /// <returns>true if valid, false if invalid</returns>
    /// 
    private bool CheckData()
    {
        Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

        //Check that every athlete 1-32 has either no values or all values
        if ((string.IsNullOrWhiteSpace(txtName1.Text) && (!string.IsNullOrWhiteSpace(ddlSchool1.Text) || !string.IsNullOrWhiteSpace(txtPerf1.Text))) ||
            (string.IsNullOrWhiteSpace(ddlSchool1.Text) && (!string.IsNullOrWhiteSpace(txtName1.Text) || !string.IsNullOrWhiteSpace(txtPerf1.Text))) ||
            (string.IsNullOrWhiteSpace(txtPerf1.Text) && (!string.IsNullOrWhiteSpace(ddlSchool1.Text) || !string.IsNullOrWhiteSpace(txtName1.Text))))
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #1", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #1');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName2.Text) && string.IsNullOrWhiteSpace(ddlSchool2.Text) && string.IsNullOrWhiteSpace(txtPerf2.Text)) ||
            (string.IsNullOrWhiteSpace(txtName2.Text) && !string.IsNullOrWhiteSpace(ddlSchool2.Text) && string.IsNullOrWhiteSpace(txtPerf2.Text)) ||
            (string.IsNullOrWhiteSpace(txtName2.Text) && string.IsNullOrWhiteSpace(ddlSchool2.Text) && !string.IsNullOrWhiteSpace(txtPerf2.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #2", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName3.Text) && string.IsNullOrWhiteSpace(ddlSchool3.Text) && string.IsNullOrWhiteSpace(txtPerf3.Text)) ||
            (string.IsNullOrWhiteSpace(txtName3.Text) && !string.IsNullOrWhiteSpace(ddlSchool3.Text) && string.IsNullOrWhiteSpace(txtPerf3.Text)) ||
            (string.IsNullOrWhiteSpace(txtName3.Text) && string.IsNullOrWhiteSpace(ddlSchool3.Text) && !string.IsNullOrWhiteSpace(txtPerf3.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #3", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName4.Text) && string.IsNullOrWhiteSpace(ddlSchool4.Text) && string.IsNullOrWhiteSpace(txtPerf4.Text)) ||
            (string.IsNullOrWhiteSpace(txtName4.Text) && !string.IsNullOrWhiteSpace(ddlSchool4.Text) && string.IsNullOrWhiteSpace(txtPerf4.Text)) ||
            (string.IsNullOrWhiteSpace(txtName4.Text) && string.IsNullOrWhiteSpace(ddlSchool4.Text) && !string.IsNullOrWhiteSpace(txtPerf4.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #4", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName5.Text) && string.IsNullOrWhiteSpace(ddlSchool5.Text) && string.IsNullOrWhiteSpace(txtPerf5.Text)) ||
            (string.IsNullOrWhiteSpace(txtName5.Text) && !string.IsNullOrWhiteSpace(ddlSchool5.Text) && string.IsNullOrWhiteSpace(txtPerf5.Text)) ||
            (string.IsNullOrWhiteSpace(txtName5.Text) && string.IsNullOrWhiteSpace(ddlSchool5.Text) && !string.IsNullOrWhiteSpace(txtPerf5.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #5", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName6.Text) && string.IsNullOrWhiteSpace(ddlSchool6.Text) && string.IsNullOrWhiteSpace(txtPerf6.Text)) ||
            (string.IsNullOrWhiteSpace(txtName6.Text) && !string.IsNullOrWhiteSpace(ddlSchool6.Text) && string.IsNullOrWhiteSpace(txtPerf6.Text)) ||
            (string.IsNullOrWhiteSpace(txtName6.Text) && string.IsNullOrWhiteSpace(ddlSchool6.Text) && !string.IsNullOrWhiteSpace(txtPerf6.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #6", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName7.Text) && string.IsNullOrWhiteSpace(ddlSchool7.Text) && string.IsNullOrWhiteSpace(txtPerf7.Text)) ||
            (string.IsNullOrWhiteSpace(txtName7.Text) && !string.IsNullOrWhiteSpace(ddlSchool7.Text) && string.IsNullOrWhiteSpace(txtPerf7.Text)) ||
            (string.IsNullOrWhiteSpace(txtName7.Text) && string.IsNullOrWhiteSpace(ddlSchool7.Text) && !string.IsNullOrWhiteSpace(txtPerf7.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #7", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName8.Text) && string.IsNullOrWhiteSpace(ddlSchool8.Text) && string.IsNullOrWhiteSpace(txtPerf8.Text)) ||
            (string.IsNullOrWhiteSpace(txtName8.Text) && !string.IsNullOrWhiteSpace(ddlSchool8.Text) && string.IsNullOrWhiteSpace(txtPerf8.Text)) ||
            (string.IsNullOrWhiteSpace(txtName8.Text) && string.IsNullOrWhiteSpace(ddlSchool8.Text) && !string.IsNullOrWhiteSpace(txtPerf8.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #8", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName9.Text) && string.IsNullOrWhiteSpace(ddlSchool9.Text) && string.IsNullOrWhiteSpace(txtPerf9.Text)) ||
            (string.IsNullOrWhiteSpace(txtName9.Text) && !string.IsNullOrWhiteSpace(ddlSchool9.Text) && string.IsNullOrWhiteSpace(txtPerf9.Text)) ||
            (string.IsNullOrWhiteSpace(txtName9.Text) && string.IsNullOrWhiteSpace(ddlSchool9.Text) && !string.IsNullOrWhiteSpace(txtPerf9.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #9", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName10.Text) && string.IsNullOrWhiteSpace(ddlSchool10.Text) && string.IsNullOrWhiteSpace(txtPerf10.Text)) ||
            (string.IsNullOrWhiteSpace(txtName10.Text) && !string.IsNullOrWhiteSpace(ddlSchool10.Text) && string.IsNullOrWhiteSpace(txtPerf10.Text)) ||
            (string.IsNullOrWhiteSpace(txtName10.Text) && string.IsNullOrWhiteSpace(ddlSchool10.Text) && !string.IsNullOrWhiteSpace(txtPerf10.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #10", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName11.Text) && string.IsNullOrWhiteSpace(ddlSchool11.Text) && string.IsNullOrWhiteSpace(txtPerf11.Text)) ||
            (string.IsNullOrWhiteSpace(txtName11.Text) && !string.IsNullOrWhiteSpace(ddlSchool11.Text) && string.IsNullOrWhiteSpace(txtPerf11.Text)) ||
            (string.IsNullOrWhiteSpace(txtName11.Text) && string.IsNullOrWhiteSpace(ddlSchool11.Text) && !string.IsNullOrWhiteSpace(txtPerf11.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #11", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName12.Text) && string.IsNullOrWhiteSpace(ddlSchool12.Text) && string.IsNullOrWhiteSpace(txtPerf12.Text)) ||
            (string.IsNullOrWhiteSpace(txtName12.Text) && !string.IsNullOrWhiteSpace(ddlSchool12.Text) && string.IsNullOrWhiteSpace(txtPerf12.Text)) ||
            (string.IsNullOrWhiteSpace(txtName12.Text) && string.IsNullOrWhiteSpace(ddlSchool12.Text) && !string.IsNullOrWhiteSpace(txtPerf12.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #12", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName13.Text) && string.IsNullOrWhiteSpace(ddlSchool13.Text) && string.IsNullOrWhiteSpace(txtPerf13.Text)) ||
            (string.IsNullOrWhiteSpace(txtName13.Text) && !string.IsNullOrWhiteSpace(ddlSchool13.Text) && string.IsNullOrWhiteSpace(txtPerf13.Text)) ||
            (string.IsNullOrWhiteSpace(txtName13.Text) && string.IsNullOrWhiteSpace(ddlSchool13.Text) && !string.IsNullOrWhiteSpace(txtPerf13.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #13", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName14.Text) && string.IsNullOrWhiteSpace(ddlSchool14.Text) && string.IsNullOrWhiteSpace(txtPerf14.Text)) ||
            (string.IsNullOrWhiteSpace(txtName14.Text) && !string.IsNullOrWhiteSpace(ddlSchool14.Text) && string.IsNullOrWhiteSpace(txtPerf14.Text)) ||
            (string.IsNullOrWhiteSpace(txtName14.Text) && string.IsNullOrWhiteSpace(ddlSchool14.Text) && !string.IsNullOrWhiteSpace(txtPerf14.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #14", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName15.Text) && string.IsNullOrWhiteSpace(ddlSchool15.Text) && string.IsNullOrWhiteSpace(txtPerf15.Text)) ||
            (string.IsNullOrWhiteSpace(txtName15.Text) && !string.IsNullOrWhiteSpace(ddlSchool15.Text) && string.IsNullOrWhiteSpace(txtPerf15.Text)) ||
            (string.IsNullOrWhiteSpace(txtName15.Text) && string.IsNullOrWhiteSpace(ddlSchool15.Text) && !string.IsNullOrWhiteSpace(txtPerf15.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #15", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName16.Text) && string.IsNullOrWhiteSpace(ddlSchool16.Text) && string.IsNullOrWhiteSpace(txtPerf16.Text)) ||
            (string.IsNullOrWhiteSpace(txtName16.Text) && !string.IsNullOrWhiteSpace(ddlSchool16.Text) && string.IsNullOrWhiteSpace(txtPerf16.Text)) ||
            (string.IsNullOrWhiteSpace(txtName16.Text) && string.IsNullOrWhiteSpace(ddlSchool16.Text) && !string.IsNullOrWhiteSpace(txtPerf16.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #16", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName17.Text) && string.IsNullOrWhiteSpace(ddlSchool17.Text) && string.IsNullOrWhiteSpace(txtPerf17.Text)) ||
            (string.IsNullOrWhiteSpace(txtName17.Text) && !string.IsNullOrWhiteSpace(ddlSchool17.Text) && string.IsNullOrWhiteSpace(txtPerf17.Text)) ||
            (string.IsNullOrWhiteSpace(txtName17.Text) && string.IsNullOrWhiteSpace(ddlSchool17.Text) && !string.IsNullOrWhiteSpace(txtPerf17.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #17", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName18.Text) && string.IsNullOrWhiteSpace(ddlSchool18.Text) && string.IsNullOrWhiteSpace(txtPerf18.Text)) ||
            (string.IsNullOrWhiteSpace(txtName18.Text) && !string.IsNullOrWhiteSpace(ddlSchool18.Text) && string.IsNullOrWhiteSpace(txtPerf18.Text)) ||
            (string.IsNullOrWhiteSpace(txtName18.Text) && string.IsNullOrWhiteSpace(ddlSchool18.Text) && !string.IsNullOrWhiteSpace(txtPerf18.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #18", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName19.Text) && string.IsNullOrWhiteSpace(ddlSchool19.Text) && string.IsNullOrWhiteSpace(txtPerf19.Text)) ||
            (string.IsNullOrWhiteSpace(txtName19.Text) && !string.IsNullOrWhiteSpace(ddlSchool19.Text) && string.IsNullOrWhiteSpace(txtPerf19.Text)) ||
            (string.IsNullOrWhiteSpace(txtName19.Text) && string.IsNullOrWhiteSpace(ddlSchool19.Text) && !string.IsNullOrWhiteSpace(txtPerf19.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #19", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName20.Text) && string.IsNullOrWhiteSpace(ddlSchool20.Text) && string.IsNullOrWhiteSpace(txtPerf20.Text)) ||
            (string.IsNullOrWhiteSpace(txtName20.Text) && !string.IsNullOrWhiteSpace(ddlSchool20.Text) && string.IsNullOrWhiteSpace(txtPerf20.Text)) ||
            (string.IsNullOrWhiteSpace(txtName20.Text) && string.IsNullOrWhiteSpace(ddlSchool20.Text) && !string.IsNullOrWhiteSpace(txtPerf20.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #20", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName21.Text) && string.IsNullOrWhiteSpace(ddlSchool21.Text) && string.IsNullOrWhiteSpace(txtPerf21.Text)) ||
            (string.IsNullOrWhiteSpace(txtName21.Text) && !string.IsNullOrWhiteSpace(ddlSchool21.Text) && string.IsNullOrWhiteSpace(txtPerf21.Text)) ||
            (string.IsNullOrWhiteSpace(txtName21.Text) && string.IsNullOrWhiteSpace(ddlSchool21.Text) && !string.IsNullOrWhiteSpace(txtPerf21.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #21", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName22.Text) && string.IsNullOrWhiteSpace(ddlSchool22.Text) && string.IsNullOrWhiteSpace(txtPerf22.Text)) ||
            (string.IsNullOrWhiteSpace(txtName22.Text) && !string.IsNullOrWhiteSpace(ddlSchool22.Text) && string.IsNullOrWhiteSpace(txtPerf22.Text)) ||
            (string.IsNullOrWhiteSpace(txtName22.Text) && string.IsNullOrWhiteSpace(ddlSchool22.Text) && !string.IsNullOrWhiteSpace(txtPerf22.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #22", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName23.Text) && string.IsNullOrWhiteSpace(ddlSchool23.Text) && string.IsNullOrWhiteSpace(txtPerf23.Text)) ||
            (string.IsNullOrWhiteSpace(txtName23.Text) && !string.IsNullOrWhiteSpace(ddlSchool23.Text) && string.IsNullOrWhiteSpace(txtPerf23.Text)) ||
            (string.IsNullOrWhiteSpace(txtName23.Text) && string.IsNullOrWhiteSpace(ddlSchool23.Text) && !string.IsNullOrWhiteSpace(txtPerf23.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #23", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName24.Text) && string.IsNullOrWhiteSpace(ddlSchool24.Text) && string.IsNullOrWhiteSpace(txtPerf24.Text)) ||
            (string.IsNullOrWhiteSpace(txtName24.Text) && !string.IsNullOrWhiteSpace(ddlSchool24.Text) && string.IsNullOrWhiteSpace(txtPerf24.Text)) ||
            (string.IsNullOrWhiteSpace(txtName24.Text) && string.IsNullOrWhiteSpace(ddlSchool24.Text) && !string.IsNullOrWhiteSpace(txtPerf24.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #24", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName25.Text) && string.IsNullOrWhiteSpace(ddlSchool25.Text) && string.IsNullOrWhiteSpace(txtPerf25.Text)) ||
            (string.IsNullOrWhiteSpace(txtName25.Text) && !string.IsNullOrWhiteSpace(ddlSchool25.Text) && string.IsNullOrWhiteSpace(txtPerf25.Text)) ||
            (string.IsNullOrWhiteSpace(txtName25.Text) && string.IsNullOrWhiteSpace(ddlSchool25.Text) && !string.IsNullOrWhiteSpace(txtPerf25.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #25", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName26.Text) && string.IsNullOrWhiteSpace(ddlSchool26.Text) && string.IsNullOrWhiteSpace(txtPerf26.Text)) ||
            (string.IsNullOrWhiteSpace(txtName26.Text) && !string.IsNullOrWhiteSpace(ddlSchool26.Text) && string.IsNullOrWhiteSpace(txtPerf26.Text)) ||
            (string.IsNullOrWhiteSpace(txtName26.Text) && string.IsNullOrWhiteSpace(ddlSchool26.Text) && !string.IsNullOrWhiteSpace(txtPerf26.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #26", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName27.Text) && string.IsNullOrWhiteSpace(ddlSchool27.Text) && string.IsNullOrWhiteSpace(txtPerf27.Text)) ||
            (string.IsNullOrWhiteSpace(txtName27.Text) && !string.IsNullOrWhiteSpace(ddlSchool27.Text) && string.IsNullOrWhiteSpace(txtPerf27.Text)) ||
            (string.IsNullOrWhiteSpace(txtName27.Text) && string.IsNullOrWhiteSpace(ddlSchool27.Text) && !string.IsNullOrWhiteSpace(txtPerf27.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #27", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName28.Text) && string.IsNullOrWhiteSpace(ddlSchool28.Text) && string.IsNullOrWhiteSpace(txtPerf28.Text)) ||
            (string.IsNullOrWhiteSpace(txtName28.Text) && !string.IsNullOrWhiteSpace(ddlSchool28.Text) && string.IsNullOrWhiteSpace(txtPerf28.Text)) ||
            (string.IsNullOrWhiteSpace(txtName28.Text) && string.IsNullOrWhiteSpace(ddlSchool28.Text) && !string.IsNullOrWhiteSpace(txtPerf28.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #28", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName29.Text) && string.IsNullOrWhiteSpace(ddlSchool29.Text) && string.IsNullOrWhiteSpace(txtPerf29.Text)) ||
            (string.IsNullOrWhiteSpace(txtName29.Text) && !string.IsNullOrWhiteSpace(ddlSchool29.Text) && string.IsNullOrWhiteSpace(txtPerf29.Text)) ||
            (string.IsNullOrWhiteSpace(txtName29.Text) && string.IsNullOrWhiteSpace(ddlSchool29.Text) && !string.IsNullOrWhiteSpace(txtPerf29.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #29", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName30.Text) && string.IsNullOrWhiteSpace(ddlSchool30.Text) && string.IsNullOrWhiteSpace(txtPerf30.Text)) ||
            (string.IsNullOrWhiteSpace(txtName30.Text) && !string.IsNullOrWhiteSpace(ddlSchool30.Text) && string.IsNullOrWhiteSpace(txtPerf30.Text)) ||
            (string.IsNullOrWhiteSpace(txtName30.Text) && string.IsNullOrWhiteSpace(ddlSchool30.Text) && !string.IsNullOrWhiteSpace(txtPerf30.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #30", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName31.Text) && string.IsNullOrWhiteSpace(ddlSchool31.Text) && string.IsNullOrWhiteSpace(txtPerf31.Text)) ||
            (string.IsNullOrWhiteSpace(txtName31.Text) && !string.IsNullOrWhiteSpace(ddlSchool31.Text) && string.IsNullOrWhiteSpace(txtPerf31.Text)) ||
            (string.IsNullOrWhiteSpace(txtName31.Text) && string.IsNullOrWhiteSpace(ddlSchool31.Text) && !string.IsNullOrWhiteSpace(txtPerf31.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #31", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName32.Text) && string.IsNullOrWhiteSpace(ddlSchool32.Text) && string.IsNullOrWhiteSpace(txtPerf32.Text)) ||
            (string.IsNullOrWhiteSpace(txtName32.Text) && !string.IsNullOrWhiteSpace(ddlSchool32.Text) && string.IsNullOrWhiteSpace(txtPerf32.Text)) ||
            (string.IsNullOrWhiteSpace(txtName32.Text) && string.IsNullOrWhiteSpace(ddlSchool32.Text) && !string.IsNullOrWhiteSpace(txtPerf32.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #32", true);
            return false;
        }

        //Check for invalid performances
        if (!txtPerf1.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf1.Text.IndexOf('-') != txtPerf1.Text.LastIndexOf('-') || txtPerf1.Text.IndexOf('.') != txtPerf1.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #1 is invalid", true);
            return false;
        }
        if (!txtPerf2.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf2.Text.IndexOf('-') != txtPerf2.Text.LastIndexOf('-') || txtPerf2.Text.IndexOf('.') != txtPerf2.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #2 is invalid", true);
            return false;
        }
        if (!txtPerf3.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf3.Text.IndexOf('-') != txtPerf3.Text.LastIndexOf('-') || txtPerf3.Text.IndexOf('.') != txtPerf3.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #3 is invalid", true);
            return false;
        }
        if (!txtPerf4.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf4.Text.IndexOf('-') != txtPerf4.Text.LastIndexOf('-') || txtPerf4.Text.IndexOf('.') != txtPerf4.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #4 is invalid", true);
            return false;
        }
        if (!txtPerf5.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf5.Text.IndexOf('-') != txtPerf5.Text.LastIndexOf('-') || txtPerf5.Text.IndexOf('.') != txtPerf5.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #5 is invalid", true);
            return false;
        }
        if (!txtPerf6.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf6.Text.IndexOf('-') != txtPerf6.Text.LastIndexOf('-') || txtPerf6.Text.IndexOf('.') != txtPerf6.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #6 is invalid", true);
            return false;
        }
        if (!txtPerf7.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf7.Text.IndexOf('-') != txtPerf7.Text.LastIndexOf('-') || txtPerf7.Text.IndexOf('.') != txtPerf7.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #7 is invalid", true);
            return false;
        }
        if (!txtPerf8.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf8.Text.IndexOf('-') != txtPerf8.Text.LastIndexOf('-') || txtPerf8.Text.IndexOf('.') != txtPerf8.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #8 is invalid", true);
            return false;
        }
        if (!txtPerf9.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf9.Text.IndexOf('-') != txtPerf9.Text.LastIndexOf('-') || txtPerf9.Text.IndexOf('.') != txtPerf9.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #9 is invalid", true);
            return false;
        }
        if (!txtPerf10.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf10.Text.IndexOf('-') != txtPerf10.Text.LastIndexOf('-') || txtPerf10.Text.IndexOf('.') != txtPerf10.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #10 is invalid", true);
            return false;
        }
        if (!txtPerf11.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf11.Text.IndexOf('-') != txtPerf11.Text.LastIndexOf('-') || txtPerf11.Text.IndexOf('.') != txtPerf11.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #11 is invalid", true);
            return false;
        }
        if (!txtPerf12.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf12.Text.IndexOf('-') != txtPerf12.Text.LastIndexOf('-') || txtPerf12.Text.IndexOf('.') != txtPerf12.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #12 is invalid", true);
            return false;
        }
        if (!txtPerf13.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf13.Text.IndexOf('-') != txtPerf13.Text.LastIndexOf('-') || txtPerf13.Text.IndexOf('.') != txtPerf13.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #13 is invalid", true);
            return false;
        }
        if (!txtPerf14.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf14.Text.IndexOf('-') != txtPerf14.Text.LastIndexOf('-') || txtPerf14.Text.IndexOf('.') != txtPerf14.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #14 is invalid", true);
            return false;
        }
        if (!txtPerf15.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf15.Text.IndexOf('-') != txtPerf15.Text.LastIndexOf('-') || txtPerf15.Text.IndexOf('.') != txtPerf15.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #15 is invalid", true);
            return false;
        }
        if (!txtPerf16.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf16.Text.IndexOf('-') != txtPerf16.Text.LastIndexOf('-') || txtPerf16.Text.IndexOf('.') != txtPerf16.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #16 is invalid", true);
            return false;
        }
        if (!txtPerf17.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf17.Text.IndexOf('-') != txtPerf17.Text.LastIndexOf('-') || txtPerf17.Text.IndexOf('.') != txtPerf17.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #17 is invalid", true);
            return false;
        }
        if (!txtPerf18.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf18.Text.IndexOf('-') != txtPerf18.Text.LastIndexOf('-') || txtPerf18.Text.IndexOf('.') != txtPerf18.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #18 is invalid", true);
            return false;
        }
        if (!txtPerf19.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf19.Text.IndexOf('-') != txtPerf19.Text.LastIndexOf('-') || txtPerf19.Text.IndexOf('.') != txtPerf19.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #19 is invalid", true);
            return false;
        }
        if (!txtPerf20.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf20.Text.IndexOf('-') != txtPerf20.Text.LastIndexOf('-') || txtPerf20.Text.IndexOf('.') != txtPerf20.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #20 is invalid", true);
            return false;
        }
        if (!txtPerf21.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf21.Text.IndexOf('-') != txtPerf21.Text.LastIndexOf('-') || txtPerf21.Text.IndexOf('.') != txtPerf21.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #21 is invalid", true);
            return false;
        }
        if (!txtPerf22.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf22.Text.IndexOf('-') != txtPerf22.Text.LastIndexOf('-') || txtPerf22.Text.IndexOf('.') != txtPerf22.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #22 is invalid", true);
            return false;
        }
        if (!txtPerf23.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf23.Text.IndexOf('-') != txtPerf23.Text.LastIndexOf('-') || txtPerf23.Text.IndexOf('.') != txtPerf23.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #23 is invalid", true);
            return false;
        }
        if (!txtPerf24.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf24.Text.IndexOf('-') != txtPerf24.Text.LastIndexOf('-') || txtPerf24.Text.IndexOf('.') != txtPerf24.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #24 is invalid", true);
            return false;
        }
        if (!txtPerf25.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf25.Text.IndexOf('-') != txtPerf25.Text.LastIndexOf('-') || txtPerf25.Text.IndexOf('.') != txtPerf25.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #25 is invalid", true);
            return false;
        }
        if (!txtPerf26.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf26.Text.IndexOf('-') != txtPerf26.Text.LastIndexOf('-') || txtPerf26.Text.IndexOf('.') != txtPerf26.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #26 is invalid", true);
            return false;
        }
        if (!txtPerf27.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf27.Text.IndexOf('-') != txtPerf27.Text.LastIndexOf('-') || txtPerf27.Text.IndexOf('.') != txtPerf27.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #27 is invalid", true);
            return false;
        }
        if (!txtPerf28.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf28.Text.IndexOf('-') != txtPerf28.Text.LastIndexOf('-') || txtPerf28.Text.IndexOf('.') != txtPerf28.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #28 is invalid", true);
            return false;
        }
        if (!txtPerf29.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf29.Text.IndexOf('-') != txtPerf29.Text.LastIndexOf('-') || txtPerf29.Text.IndexOf('.') != txtPerf29.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #29 is invalid", true);
            return false;
        }
        if (!txtPerf30.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf30.Text.IndexOf('-') != txtPerf30.Text.LastIndexOf('-') || txtPerf30.Text.IndexOf('.') != txtPerf30.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #30 is invalid", true);
            return false;
        }
        if (!txtPerf31.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf31.Text.IndexOf('-') != txtPerf31.Text.LastIndexOf('-') || txtPerf31.Text.IndexOf('.') != txtPerf31.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #31 is invalid", true);
            return false;
        }
        if (!txtPerf32.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf32.Text.IndexOf('-') != txtPerf32.Text.LastIndexOf('-') || txtPerf32.Text.IndexOf('.') != txtPerf32.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #32 is invalid", true);
            return false;
        }

        //If all the above errors were ot found, return true
        Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        return true;
    }

    /// <summary>
    /// /// Clears all data from all objects on the form
    /// </summary>
    private void ClearAll()
    {
        txtName1.Text = "";
        ddlSchool1.Text = "";
        txtPerf1.Text = "";

        txtName2.Text = "";
        ddlSchool2.Text = "";
        txtPerf2.Text = "";

        txtName3.Text = "";
        ddlSchool3.Text = "";
        txtPerf3.Text = "";

        txtName4.Text = "";
        ddlSchool4.Text = "";
        txtPerf4.Text = "";

        txtName5.Text = "";
        ddlSchool5.Text = "";
        txtPerf5.Text = "";

        txtName6.Text = "";
        ddlSchool6.Text = "";
        txtPerf6.Text = "";

        txtName7.Text = "";
        ddlSchool7.Text = "";
        txtPerf7.Text = "";

        txtName8.Text = "";
        ddlSchool8.Text = "";
        txtPerf8.Text = "";

        txtName9.Text = "";
        ddlSchool9.Text = "";
        txtPerf9.Text = "";

        txtName10.Text = "";
        ddlSchool10.Text = "";
        txtPerf10.Text = "";

        txtName11.Text = "";
        ddlSchool11.Text = "";
        txtPerf11.Text = "";

        txtName12.Text = "";
        ddlSchool12.Text = "";
        txtPerf12.Text = "";

        txtName13.Text = "";
        ddlSchool13.Text = "";
        txtPerf13.Text = "";

        txtName14.Text = "";
        ddlSchool14.Text = "";
        txtPerf14.Text = "";

        txtName15.Text = "";
        ddlSchool15.Text = "";
        txtPerf15.Text = "";

        txtName16.Text = "";
        ddlSchool16.Text = "";
        txtPerf16.Text = "";

        txtName17.Text = "";
        ddlSchool17.Text = "";
        txtPerf17.Text = "";

        txtName18.Text = "";
        ddlSchool18.Text = "";
        txtPerf18.Text = "";

        txtName19.Text = "";
        ddlSchool19.Text = "";
        txtPerf19.Text = "";

        txtName20.Text = "";
        ddlSchool20.Text = "";
        txtPerf20.Text = "";

        txtName21.Text = "";
        ddlSchool21.Text = "";
        txtPerf21.Text = "";

        txtName22.Text = "";
        ddlSchool22.Text = "";
        txtPerf22.Text = "";

        txtName23.Text = "";
        ddlSchool23.Text = "";
        txtPerf23.Text = "";

        txtName24.Text = "";
        ddlSchool24.Text = "";
        txtPerf24.Text = "";

        txtName25.Text = "";
        ddlSchool25.Text = "";
        txtPerf25.Text = "";

        txtName26.Text = "";
        ddlSchool26.Text = "";
        txtPerf26.Text = "";

        txtName27.Text = "";
        ddlSchool27.Text = "";
        txtPerf27.Text = "";

        txtName28.Text = "";
        ddlSchool28.Text = "";
        txtPerf28.Text = "";

        txtName29.Text = "";
        ddlSchool29.Text = "";
        txtPerf29.Text = "";

        txtName30.Text = "";
        ddlSchool30.Text = "";
        txtPerf30.Text = "";

        txtName31.Text = "";
        ddlSchool31.Text = "";
        txtPerf31.Text = "";

        txtName32.Text = "";
        ddlSchool32.Text = "";
        txtPerf32.Text = "";
    }

    /// <summary>
    /// Enters data from specific heat (int currentHeatNum) for all objects on the form
    /// </summary>
    /// <remarks>Untested and does not look at other flights</remarks>
    private void EnterDataIntoForm()
    {
        Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

        ClearAll();
        if (allPerfs != null)
        {
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 0) != null)
            {
                txtName1.Text = allPerfs[(currentHeatNum * 32) + 0].athleteName;
                ddlSchool1.Text = allPerfs[(currentHeatNum * 32) + 0].schoolName;
                txtPerf1.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 0].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 1) != null)
            {
                txtName2.Text = allPerfs[(currentHeatNum * 32) + 1].athleteName;
                ddlSchool2.Text = allPerfs[(currentHeatNum * 32) + 1].schoolName;
                txtPerf2.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 1].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 2) != null)
            {
                txtName3.Text = allPerfs[(currentHeatNum * 32) + 2].athleteName;
                ddlSchool3.Text = allPerfs[(currentHeatNum * 32) + 2].schoolName;
                txtPerf3.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 2].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 3) != null)
            {
                txtName4.Text = allPerfs[(currentHeatNum * 32) + 3].athleteName;
                ddlSchool4.Text = allPerfs[(currentHeatNum * 32) + 3].schoolName;
                txtPerf4.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 3].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 4) != null)
            {
                txtName5.Text = allPerfs[(currentHeatNum * 32) + 4].athleteName;
                ddlSchool5.Text = allPerfs[(currentHeatNum * 32) + 4].schoolName;
                txtPerf5.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 4].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 5) != null)
            {
                txtName6.Text = allPerfs[(currentHeatNum * 32) + 5].athleteName;
                ddlSchool6.Text = allPerfs[(currentHeatNum * 32) + 5].schoolName;
                txtPerf6.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 5].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 6) != null)
            {
                txtName7.Text = allPerfs[(currentHeatNum * 32) + 6].athleteName;
                ddlSchool7.Text = allPerfs[(currentHeatNum * 32) + 6].schoolName;
                txtPerf7.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 6].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 7) != null)
            {
                txtName8.Text = allPerfs[(currentHeatNum * 32) + 7].athleteName;
                ddlSchool8.Text = allPerfs[(currentHeatNum * 32) + 7].schoolName;
                txtPerf8.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 7].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 8) != null)
            {
                txtName9.Text = allPerfs[(currentHeatNum * 32) + 8].athleteName;
                ddlSchool9.Text = allPerfs[(currentHeatNum * 32) + 8].schoolName;
                txtPerf9.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 8].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 9) != null)
            {
                txtName10.Text = allPerfs[(currentHeatNum * 32) + 9].athleteName;
                ddlSchool10.Text = allPerfs[(currentHeatNum * 32) + 9].schoolName;
                txtPerf10.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 9].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 10) != null)
            {
                txtName11.Text = allPerfs[(currentHeatNum * 32) + 10].athleteName;
                ddlSchool11.Text = allPerfs[(currentHeatNum * 32) + 10].schoolName;
                txtPerf11.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 10].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 11) != null)
            {
                txtName12.Text = allPerfs[(currentHeatNum * 32) + 11].athleteName;
                ddlSchool12.Text = allPerfs[(currentHeatNum * 32) + 11].schoolName;
                txtPerf12.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 11].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 12) != null)
            {
                txtName13.Text = allPerfs[(currentHeatNum * 32) + 12].athleteName;
                ddlSchool13.Text = allPerfs[(currentHeatNum * 32) + 12].schoolName;
                txtPerf13.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 12].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 13) != null)
            {
                txtName14.Text = allPerfs[(currentHeatNum * 32) + 13].athleteName;
                ddlSchool14.Text = allPerfs[(currentHeatNum * 32) + 13].schoolName;
                txtPerf14.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 13].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 14) != null)
            {
                txtName15.Text = allPerfs[(currentHeatNum * 32) + 14].athleteName;
                ddlSchool15.Text = allPerfs[(currentHeatNum * 32) + 14].schoolName;
                txtPerf15.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 14].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 15) != null)
            {
                txtName16.Text = allPerfs[(currentHeatNum * 32) + 15].athleteName;
                ddlSchool16.Text = allPerfs[(currentHeatNum * 32) + 15].schoolName;
                txtPerf16.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 15].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 16) != null)
            {
                txtName17.Text = allPerfs[(currentHeatNum * 32) + 16].athleteName;
                ddlSchool17.Text = allPerfs[(currentHeatNum * 32) + 16].schoolName;
                txtPerf17.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 16].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 17) != null)
            {
                txtName18.Text = allPerfs[(currentHeatNum * 32) + 17].athleteName;
                ddlSchool18.Text = allPerfs[(currentHeatNum * 32) + 17].schoolName;
                txtPerf18.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 17].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 18) != null)
            {
                txtName19.Text = allPerfs[(currentHeatNum * 32) + 18].athleteName;
                ddlSchool19.Text = allPerfs[(currentHeatNum * 32) + 18].schoolName;
                txtPerf19.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 18].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 19) != null)
            {
                txtName20.Text = allPerfs[(currentHeatNum * 32) + 19].athleteName;
                ddlSchool20.Text = allPerfs[(currentHeatNum * 32) + 19].schoolName;
                txtPerf20.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 19].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 20) != null)
            {
                txtName21.Text = allPerfs[(currentHeatNum * 32) + 20].athleteName;
                ddlSchool21.Text = allPerfs[(currentHeatNum * 32) + 20].schoolName;
                txtPerf21.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 20].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 21) != null)
            {
                txtName22.Text = allPerfs[(currentHeatNum * 32) + 21].athleteName;
                ddlSchool22.Text = allPerfs[(currentHeatNum * 32) + 21].schoolName;
                txtPerf22.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 21].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 22) != null)
            {
                txtName23.Text = allPerfs[(currentHeatNum * 32) + 22].athleteName;
                ddlSchool23.Text = allPerfs[(currentHeatNum * 32) + 22].schoolName;
                txtPerf23.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 22].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 23) != null)
            {
                txtName24.Text = allPerfs[(currentHeatNum * 32) + 23].athleteName;
                ddlSchool24.Text = allPerfs[(currentHeatNum * 32) + 23].schoolName;
                txtPerf24.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 23].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 24) != null)
            {
                txtName25.Text = allPerfs[(currentHeatNum * 32) + 24].athleteName;
                ddlSchool25.Text = allPerfs[(currentHeatNum * 32) + 24].schoolName;
                txtPerf25.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 24].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 25) != null)
            {
                txtName26.Text = allPerfs[(currentHeatNum * 32) + 25].athleteName;
                ddlSchool26.Text = allPerfs[(currentHeatNum * 32) + 25].schoolName;
                txtPerf26.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 25].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 26) != null)
            {
                txtName27.Text = allPerfs[(currentHeatNum * 32) + 26].athleteName;
                ddlSchool27.Text = allPerfs[(currentHeatNum * 32) + 26].schoolName;
                txtPerf27.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 26].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 27) != null)
            {
                txtName28.Text = allPerfs[(currentHeatNum * 32) + 27].athleteName;
                ddlSchool28.Text = allPerfs[(currentHeatNum * 32) + 27].schoolName;
                txtPerf28.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 27].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 28) != null)
            {
                txtName29.Text = allPerfs[(currentHeatNum * 32) + 28].athleteName;
                ddlSchool29.Text = allPerfs[(currentHeatNum * 32) + 28].schoolName;
                txtPerf29.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 28].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 29) != null)
            {
                txtName30.Text = allPerfs[(currentHeatNum * 32) + 29].athleteName;
                ddlSchool30.Text = allPerfs[(currentHeatNum * 32) + 29].schoolName;
                txtPerf30.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 29].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 30) != null)
            {
                txtName31.Text = allPerfs[(currentHeatNum * 32) + 30].athleteName;
                ddlSchool31.Text = allPerfs[(currentHeatNum * 32) + 30].schoolName;
                txtPerf31.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 30].performance);
            }
            if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 31) != null)
            {
                txtName32.Text = allPerfs[(currentHeatNum * 32) + 31].athleteName;
                ddlSchool32.Text = allPerfs[(currentHeatNum * 32) + 31].schoolName;
                txtPerf32.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 31].performance);
            }
        }
        Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Populate all combo boxes with the team names
    /// </summary>
    private void PopulateTeams()
    {
        ddlSchool1.Items.Add("");
        ddlSchool2.Items.Add("");
        ddlSchool3.Items.Add("");
        ddlSchool4.Items.Add("");
        ddlSchool5.Items.Add("");
        ddlSchool6.Items.Add("");
        ddlSchool7.Items.Add("");
        ddlSchool8.Items.Add("");
        ddlSchool9.Items.Add("");
        ddlSchool10.Items.Add("");
        ddlSchool11.Items.Add("");
        ddlSchool12.Items.Add("");
        ddlSchool13.Items.Add("");
        ddlSchool14.Items.Add("");
        ddlSchool15.Items.Add("");
        ddlSchool16.Items.Add("");
        ddlSchool17.Items.Add("");
        ddlSchool18.Items.Add("");
        ddlSchool19.Items.Add("");
        ddlSchool20.Items.Add("");
        ddlSchool21.Items.Add("");
        ddlSchool22.Items.Add("");
        ddlSchool23.Items.Add("");
        ddlSchool24.Items.Add("");
        ddlSchool25.Items.Add("");
        ddlSchool26.Items.Add("");
        ddlSchool27.Items.Add("");
        ddlSchool28.Items.Add("");
        ddlSchool29.Items.Add("");
        ddlSchool30.Items.Add("");
        ddlSchool31.Items.Add("");
        ddlSchool32.Items.Add("");

        Meet myMeet = (Meet)Session["ActiveMeet"];

        if(eventName.StartsWith("Boy") && myMeet != null && myMeet.schoolNames != null && myMeet.schoolNames.boySchoolNames != null)
        {
            foreach (string s in myMeet.schoolNames.boySchoolNames.Keys)
            {
                ddlSchool1.Items.Add(s);
                ddlSchool2.Items.Add(s);
                ddlSchool3.Items.Add(s);
                ddlSchool4.Items.Add(s);
                ddlSchool5.Items.Add(s);
                ddlSchool6.Items.Add(s);
                ddlSchool7.Items.Add(s);
                ddlSchool8.Items.Add(s);
                ddlSchool9.Items.Add(s);
                ddlSchool10.Items.Add(s);
                ddlSchool11.Items.Add(s);
                ddlSchool12.Items.Add(s);
                ddlSchool13.Items.Add(s);
                ddlSchool14.Items.Add(s);
                ddlSchool15.Items.Add(s);
                ddlSchool16.Items.Add(s);
                ddlSchool17.Items.Add(s);
                ddlSchool18.Items.Add(s);
                ddlSchool19.Items.Add(s);
                ddlSchool20.Items.Add(s);
                ddlSchool21.Items.Add(s);
                ddlSchool22.Items.Add(s);
                ddlSchool23.Items.Add(s);
                ddlSchool24.Items.Add(s);
                ddlSchool25.Items.Add(s);
                ddlSchool26.Items.Add(s);
                ddlSchool27.Items.Add(s);
                ddlSchool28.Items.Add(s);
                ddlSchool29.Items.Add(s);
                ddlSchool30.Items.Add(s);
                ddlSchool31.Items.Add(s);
                ddlSchool32.Items.Add(s);
            }
        }
        else if (eventName.StartsWith("Girl") && myMeet != null && myMeet.schoolNames != null && myMeet.schoolNames.girlSchoolNames != null)
        {
            foreach (string s in myMeet.schoolNames.girlSchoolNames.Keys)
            {
                ddlSchool1.Items.Add(s);
                ddlSchool2.Items.Add(s);
                ddlSchool3.Items.Add(s);
                ddlSchool4.Items.Add(s);
                ddlSchool5.Items.Add(s);
                ddlSchool6.Items.Add(s);
                ddlSchool7.Items.Add(s);
                ddlSchool8.Items.Add(s);
                ddlSchool9.Items.Add(s);
                ddlSchool10.Items.Add(s);
                ddlSchool11.Items.Add(s);
                ddlSchool12.Items.Add(s);
                ddlSchool13.Items.Add(s);
                ddlSchool14.Items.Add(s);
                ddlSchool15.Items.Add(s);
                ddlSchool16.Items.Add(s);
                ddlSchool17.Items.Add(s);
                ddlSchool18.Items.Add(s);
                ddlSchool19.Items.Add(s);
                ddlSchool20.Items.Add(s);
                ddlSchool21.Items.Add(s);
                ddlSchool22.Items.Add(s);
                ddlSchool23.Items.Add(s);
                ddlSchool24.Items.Add(s);
                ddlSchool25.Items.Add(s);
                ddlSchool26.Items.Add(s);
                ddlSchool27.Items.Add(s);
                ddlSchool28.Items.Add(s);
                ddlSchool29.Items.Add(s);
                ddlSchool30.Items.Add(s);
                ddlSchool31.Items.Add(s);
                ddlSchool32.Items.Add(s);
            }
        }

    }

    public void clearFlight(int flightNum)
    {
        for (int i = (flightNum * 32) + 32; i >= flightNum * 32; i--)
        {
            if (allPerfs != null && allPerfs.ElementAtOrDefault(i) != null)
            {
                allPerfs.RemoveAt(i);
            }
        }
    }

    public bool AddFlightToList()
    {
        Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        if (CheckData())
        {
            //Need to clear entire flight data
            clearFlight(currentHeatNum);

            if (allPerfs == null)
                allPerfs = new List<Performance>();
            //Need to delete performances from current "Flight"
            clearFlight(currentHeatNum);

            if (!string.IsNullOrWhiteSpace(txtName1.Text))
                allPerfs.Add(new Performance(txtName1.Text, ddlSchool1.Text, 0, em.ConvertFromLengthData(txtPerf1.Text)));
            if (!string.IsNullOrWhiteSpace(txtName2.Text))
                allPerfs.Add(new Performance(txtName2.Text, ddlSchool2.Text, 0, em.ConvertFromLengthData(txtPerf2.Text)));
            if (!string.IsNullOrWhiteSpace(txtName3.Text))
                allPerfs.Add(new Performance(txtName3.Text, ddlSchool3.Text, 0, em.ConvertFromLengthData(txtPerf3.Text)));
            if (!string.IsNullOrWhiteSpace(txtName4.Text))
                allPerfs.Add(new Performance(txtName4.Text, ddlSchool4.Text, 0, em.ConvertFromLengthData(txtPerf4.Text)));
            if (!string.IsNullOrWhiteSpace(txtName5.Text))
                allPerfs.Add(new Performance(txtName5.Text, ddlSchool5.Text, 0, em.ConvertFromLengthData(txtPerf5.Text)));
            if (!string.IsNullOrWhiteSpace(txtName6.Text))
                allPerfs.Add(new Performance(txtName6.Text, ddlSchool6.Text, 0, em.ConvertFromLengthData(txtPerf6.Text)));
            if (!string.IsNullOrWhiteSpace(txtName7.Text))
                allPerfs.Add(new Performance(txtName7.Text, ddlSchool7.Text, 0, em.ConvertFromLengthData(txtPerf7.Text)));
            if (!string.IsNullOrWhiteSpace(txtName8.Text))
                allPerfs.Add(new Performance(txtName8.Text, ddlSchool8.Text, 0, em.ConvertFromLengthData(txtPerf8.Text)));
            if (!string.IsNullOrWhiteSpace(txtName9.Text))
                allPerfs.Add(new Performance(txtName9.Text, ddlSchool9.Text, 0, em.ConvertFromLengthData(txtPerf9.Text)));
            if (!string.IsNullOrWhiteSpace(txtName10.Text))
                allPerfs.Add(new Performance(txtName10.Text, ddlSchool10.Text, 0, em.ConvertFromLengthData(txtPerf10.Text)));
            if (!string.IsNullOrWhiteSpace(txtName11.Text))
                allPerfs.Add(new Performance(txtName11.Text, ddlSchool11.Text, 0, em.ConvertFromLengthData(txtPerf11.Text)));
            if (!string.IsNullOrWhiteSpace(txtName12.Text))
                allPerfs.Add(new Performance(txtName12.Text, ddlSchool12.Text, 0, em.ConvertFromLengthData(txtPerf12.Text)));
            if (!string.IsNullOrWhiteSpace(txtName13.Text))
                allPerfs.Add(new Performance(txtName13.Text, ddlSchool13.Text, 0, em.ConvertFromLengthData(txtPerf13.Text)));
            if (!string.IsNullOrWhiteSpace(txtName14.Text))
                allPerfs.Add(new Performance(txtName14.Text, ddlSchool14.Text, 0, em.ConvertFromLengthData(txtPerf14.Text)));
            if (!string.IsNullOrWhiteSpace(txtName15.Text))
                allPerfs.Add(new Performance(txtName15.Text, ddlSchool15.Text, 0, em.ConvertFromLengthData(txtPerf15.Text)));
            if (!string.IsNullOrWhiteSpace(txtName16.Text))
                allPerfs.Add(new Performance(txtName16.Text, ddlSchool16.Text, 0, em.ConvertFromLengthData(txtPerf16.Text)));
            if (!string.IsNullOrWhiteSpace(txtName17.Text))
                allPerfs.Add(new Performance(txtName17.Text, ddlSchool17.Text, 0, em.ConvertFromLengthData(txtPerf17.Text)));
            if (!string.IsNullOrWhiteSpace(txtName18.Text))
                allPerfs.Add(new Performance(txtName18.Text, ddlSchool18.Text, 0, em.ConvertFromLengthData(txtPerf18.Text)));
            if (!string.IsNullOrWhiteSpace(txtName19.Text))
                allPerfs.Add(new Performance(txtName19.Text, ddlSchool19.Text, 0, em.ConvertFromLengthData(txtPerf19.Text)));
            if (!string.IsNullOrWhiteSpace(txtName20.Text))
                allPerfs.Add(new Performance(txtName20.Text, ddlSchool20.Text, 0, em.ConvertFromLengthData(txtPerf20.Text)));
            if (!string.IsNullOrWhiteSpace(txtName21.Text))
                allPerfs.Add(new Performance(txtName21.Text, ddlSchool21.Text, 0, em.ConvertFromLengthData(txtPerf21.Text)));
            if (!string.IsNullOrWhiteSpace(txtName22.Text))
                allPerfs.Add(new Performance(txtName22.Text, ddlSchool22.Text, 0, em.ConvertFromLengthData(txtPerf22.Text)));
            if (!string.IsNullOrWhiteSpace(txtName23.Text))
                allPerfs.Add(new Performance(txtName23.Text, ddlSchool23.Text, 0, em.ConvertFromLengthData(txtPerf23.Text)));
            if (!string.IsNullOrWhiteSpace(txtName24.Text))
                allPerfs.Add(new Performance(txtName24.Text, ddlSchool24.Text, 0, em.ConvertFromLengthData(txtPerf24.Text)));
            if (!string.IsNullOrWhiteSpace(txtName25.Text))
                allPerfs.Add(new Performance(txtName25.Text, ddlSchool25.Text, 0, em.ConvertFromLengthData(txtPerf25.Text)));
            if (!string.IsNullOrWhiteSpace(txtName26.Text))
                allPerfs.Add(new Performance(txtName26.Text, ddlSchool26.Text, 0, em.ConvertFromLengthData(txtPerf26.Text)));
            if (!string.IsNullOrWhiteSpace(txtName27.Text))
                allPerfs.Add(new Performance(txtName27.Text, ddlSchool27.Text, 0, em.ConvertFromLengthData(txtPerf27.Text)));
            if (!string.IsNullOrWhiteSpace(txtName28.Text))
                allPerfs.Add(new Performance(txtName28.Text, ddlSchool28.Text, 0, em.ConvertFromLengthData(txtPerf28.Text)));
            if (!string.IsNullOrWhiteSpace(txtName29.Text))
                allPerfs.Add(new Performance(txtName29.Text, ddlSchool29.Text, 0, em.ConvertFromLengthData(txtPerf29.Text)));
            if (!string.IsNullOrWhiteSpace(txtName30.Text))
                allPerfs.Add(new Performance(txtName30.Text, ddlSchool30.Text, 0, em.ConvertFromLengthData(txtPerf30.Text)));
            if (!string.IsNullOrWhiteSpace(txtName31.Text))
                allPerfs.Add(new Performance(txtName31.Text, ddlSchool31.Text, 0, em.ConvertFromLengthData(txtPerf31.Text)));
            if (!string.IsNullOrWhiteSpace(txtName32.Text))
                allPerfs.Add(new Performance(txtName32.Text, ddlSchool32.Text, 0, em.ConvertFromLengthData(txtPerf32.Text)));

            SortListOfPerfs();

            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return true;
        }
        else
        {
            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return false;
        }
    }

    /// <summary>
    /// Sorts the List of Performances in Descending Order (Best to Worst)
    /// </summary>
    private void SortListOfPerfs()
    {
        if (allPerfs != null && allPerfs.Count > 0)
        {
            allPerfs = allPerfs.OrderByDescending(o => o.performance).ToList();
        }
    }

    protected void cmdPrintout_Click(object sender, EventArgs e)
    {
        if (AddFlightToList())
        {
            PrintoutMgr pm = new PrintoutMgr();
            SortListOfPerfs();
            eventName = Session["CurrentEvent"].ToString();
            pm.CreateIndEventDoc(eventName, allPerfs);
        }
    }

    protected void cmdYesAll_Click(object sender, EventArgs e)
    {
        panClearAll.Visible = false;
        ClearAll();
        allPerfs.Clear();
    }

    protected void cmdNoAll_Click(object sender, EventArgs e)
    {
        panClearAll.Visible = false;
    }

    protected void cmdPrevious_Click(object sender, EventArgs e)
    {
        if (currentHeatNum <= 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid flight #", "Cannot go to a flight below 1", true);
            currentHeatNum = 0; // This should never be needed, but here just incase of an unknown error
        }
        else if (AddFlightToList())
        {
            currentHeatNum--;
            lblFlightNum.Text = "Flight #" + (currentHeatNum + 1);
            EnterDataIntoForm();
        }
    }

    protected void cmdNext_Click(object sender, EventArgs e)
    {
        if (currentHeatNum >= 10000)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid flight #", "Cannot go to a flight above 10,000", true);
            currentHeatNum = 10000; // This should never be needed, but here just incase of an unknown error
        }
        else if (AddFlightToList())
        {
            currentHeatNum++;
            lblFlightNum.Text = "Flight #" + (currentHeatNum + 1);
            EnterDataIntoForm();
        }
    }

    protected void cmdClearAll_Click(object sender, EventArgs e)
    {
        panClearAll.Visible = true;
    }
}

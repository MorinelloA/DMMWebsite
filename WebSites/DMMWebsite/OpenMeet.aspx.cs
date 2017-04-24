using DualMeetManager.Business.Managers;
using DMMLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OpenMeet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DatabaseMgr dm = new DatabaseMgr();
        Dictionary<int, Meet> listOfMeets = dm.ListOfMeets(Session["Username"].ToString());

        foreach (int key in listOfMeets.Keys)
        {
             lstMeets.Items.Add(new ListItem(listOfMeets[key].dateOfMeet.ToString() + " @ " + listOfMeets[key].location, key.ToString()));
        }
    }

    protected void cmdOpen_Click(object sender, EventArgs e)
    {
        DatabaseMgr dm = new DatabaseMgr();
        Meet meetToOpen = dm.FindMeet(Convert.ToInt32(lstMeets.SelectedValue));

        Session["ActiveMeet"] = meetToOpen;

        //Open MeetHub here
        Response.Redirect("MeetHub.aspx");
    }

    protected void lbtnCreate_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateMeet.aspx");
    }
}
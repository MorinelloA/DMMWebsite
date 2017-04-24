using DualMeetManager.Business.Managers;
using DMMLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RelayEventEntry : System.Web.UI.Page
{
    //MeetHub mh;
    Dictionary<string, string> teamNames = new Dictionary<string, string>();
    string eventName;

    List<Performance> allPerfs = new List<Performance>();
    EventMgr em = new EventMgr();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void GatherPerfs()
    {
        if (allPerfs != null)
            allPerfs.Clear();
        else
            allPerfs = new List<Performance>();

        if (!string.IsNullOrWhiteSpace(txtName1.Text))
            allPerfs.Add(new Performance(txtName1.Text, ddlSchool1.Text, 1, em.ConvertFromTimedData(txtPerf1.Text)));
        if (!string.IsNullOrWhiteSpace(txtName2.Text))
            allPerfs.Add(new Performance(txtName2.Text, ddlSchool2.Text, 1, em.ConvertFromTimedData(txtPerf2.Text)));
        if (!string.IsNullOrWhiteSpace(txtName3.Text))
            allPerfs.Add(new Performance(txtName3.Text, ddlSchool3.Text, 1, em.ConvertFromTimedData(txtPerf3.Text)));
        if (!string.IsNullOrWhiteSpace(txtName4.Text))
            allPerfs.Add(new Performance(txtName4.Text, ddlSchool4.Text, 1, em.ConvertFromTimedData(txtPerf4.Text)));
        if (!string.IsNullOrWhiteSpace(txtName5.Text))
            allPerfs.Add(new Performance(txtName5.Text, ddlSchool5.Text, 1, em.ConvertFromTimedData(txtPerf5.Text)));
        if (!string.IsNullOrWhiteSpace(txtName6.Text))
            allPerfs.Add(new Performance(txtName6.Text, ddlSchool6.Text, 1, em.ConvertFromTimedData(txtPerf6.Text)));

        if (!string.IsNullOrWhiteSpace(txtName17.Text))
            allPerfs.Add(new Performance(txtName17.Text, ddlSchool17.Text, 1, em.ConvertFromTimedData(txtPerf17.Text)));
        if (!string.IsNullOrWhiteSpace(txtName18.Text))
            allPerfs.Add(new Performance(txtName18.Text, ddlSchool18.Text, 1, em.ConvertFromTimedData(txtPerf18.Text)));
        if (!string.IsNullOrWhiteSpace(txtName19.Text))
            allPerfs.Add(new Performance(txtName19.Text, ddlSchool19.Text, 1, em.ConvertFromTimedData(txtPerf19.Text)));
        if (!string.IsNullOrWhiteSpace(txtName20.Text))
            allPerfs.Add(new Performance(txtName20.Text, ddlSchool20.Text, 1, em.ConvertFromTimedData(txtPerf20.Text)));
        if (!string.IsNullOrWhiteSpace(txtName21.Text))
            allPerfs.Add(new Performance(txtName21.Text, ddlSchool21.Text, 1, em.ConvertFromTimedData(txtPerf21.Text)));
        if (!string.IsNullOrWhiteSpace(txtName22.Text))
            allPerfs.Add(new Performance(txtName22.Text, ddlSchool22.Text, 1, em.ConvertFromTimedData(txtPerf22.Text)));
        if (!string.IsNullOrWhiteSpace(txtName23.Text))
            allPerfs.Add(new Performance(txtName23.Text, ddlSchool23.Text, 1, em.ConvertFromTimedData(txtPerf23.Text)));
        if (!string.IsNullOrWhiteSpace(txtName24.Text))
            allPerfs.Add(new Performance(txtName24.Text, ddlSchool24.Text, 1, em.ConvertFromTimedData(txtPerf24.Text)));
        if (!string.IsNullOrWhiteSpace(txtName25.Text))
            allPerfs.Add(new Performance(txtName25.Text, ddlSchool25.Text, 1, em.ConvertFromTimedData(txtPerf25.Text)));
        if (!string.IsNullOrWhiteSpace(txtName26.Text))
            allPerfs.Add(new Performance(txtName26.Text, ddlSchool26.Text, 1, em.ConvertFromTimedData(txtPerf26.Text)));
        if (!string.IsNullOrWhiteSpace(txtName27.Text))
            allPerfs.Add(new Performance(txtName27.Text, ddlSchool27.Text, 1, em.ConvertFromTimedData(txtPerf27.Text)));
        if (!string.IsNullOrWhiteSpace(txtName28.Text))
            allPerfs.Add(new Performance(txtName28.Text, ddlSchool28.Text, 1, em.ConvertFromTimedData(txtPerf28.Text)));
        if (!string.IsNullOrWhiteSpace(txtName29.Text))
            allPerfs.Add(new Performance(txtName29.Text, ddlSchool29.Text, 1, em.ConvertFromTimedData(txtPerf29.Text)));
        if (!string.IsNullOrWhiteSpace(txtName30.Text))
            allPerfs.Add(new Performance(txtName30.Text, ddlSchool30.Text, 1, em.ConvertFromTimedData(txtPerf30.Text)));
        if (!string.IsNullOrWhiteSpace(txtName31.Text))
            allPerfs.Add(new Performance(txtName31.Text, ddlSchool31.Text, 1, em.ConvertFromTimedData(txtPerf31.Text)));
        if (!string.IsNullOrWhiteSpace(txtName32.Text))
            allPerfs.Add(new Performance(txtName32.Text, ddlSchool32.Text, 1, em.ConvertFromTimedData(txtPerf32.Text)));

        SortListOfPerfs();
    }

    /// <summary>
    /// Sorts the List of Performances in Ascending Order
    /// </summary>
    private void SortListOfPerfs()
    {
        if (allPerfs != null && allPerfs.Count > 0)
        {
            allPerfs = allPerfs.OrderBy(o => o.performance).ToList();
        }
    }

    private void PopulateTeams()
    {
        ddlSchool1.Items.Add("");
        ddlSchool2.Items.Add("");
        ddlSchool3.Items.Add("");
        ddlSchool4.Items.Add("");
        ddlSchool5.Items.Add("");
        ddlSchool6.Items.Add("");
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
        foreach (string s in teamNames.Keys)
        {
            ddlSchool1.Items.Add(s);
            ddlSchool2.Items.Add(s);
            ddlSchool3.Items.Add(s);
            ddlSchool4.Items.Add(s);
            ddlSchool5.Items.Add(s);
            ddlSchool6.Items.Add(s);
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

    private bool CheckData()
    {
        Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

        //Check that every athlete 1-32 has either no values or all values
        if ((string.IsNullOrWhiteSpace(txtName1.Text) && (!string.IsNullOrWhiteSpace(ddlSchool1.Text) || !string.IsNullOrWhiteSpace(txtPerf1.Text))) ||
            (string.IsNullOrWhiteSpace(ddlSchool1.Text) && (!string.IsNullOrWhiteSpace(txtName1.Text) || !string.IsNullOrWhiteSpace(txtPerf1.Text))) ||
            (string.IsNullOrWhiteSpace(txtPerf1.Text) && (!string.IsNullOrWhiteSpace(ddlSchool1.Text) || !string.IsNullOrWhiteSpace(txtName1.Text))))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Incomplete data for Athlete #1", true);
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
        if (!txtPerf1.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf1.Text.IndexOf(':') != txtPerf1.Text.LastIndexOf(':') || txtPerf1.Text.IndexOf('.') != txtPerf1.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #1 is invalid", true);
            return false;
        }
        if (!txtPerf2.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf2.Text.IndexOf(':') != txtPerf2.Text.LastIndexOf(':') || txtPerf2.Text.IndexOf('.') != txtPerf2.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #2 is invalid", true);
            return false;
        }
        if (!txtPerf3.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf3.Text.IndexOf(':') != txtPerf3.Text.LastIndexOf(':') || txtPerf3.Text.IndexOf('.') != txtPerf3.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #3 is invalid", true);
            return false;
        }
        if (!txtPerf4.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf4.Text.IndexOf(':') != txtPerf4.Text.LastIndexOf(':') || txtPerf4.Text.IndexOf('.') != txtPerf4.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #4 is invalid", true);
            return false;
        }
        if (!txtPerf5.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf5.Text.IndexOf(':') != txtPerf5.Text.LastIndexOf(':') || txtPerf5.Text.IndexOf('.') != txtPerf5.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #5 is invalid", true);
            return false;
        }
        if (!txtPerf6.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf6.Text.IndexOf(':') != txtPerf6.Text.LastIndexOf(':') || txtPerf6.Text.IndexOf('.') != txtPerf6.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #6 is invalid", true);
            return false;
        }
        if (!txtPerf17.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf17.Text.IndexOf(':') != txtPerf17.Text.LastIndexOf(':') || txtPerf17.Text.IndexOf('.') != txtPerf17.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #17 is invalid", true);
            return false;
        }
        if (!txtPerf18.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf18.Text.IndexOf(':') != txtPerf18.Text.LastIndexOf(':') || txtPerf18.Text.IndexOf('.') != txtPerf18.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #18 is invalid", true);
            return false;
        }
        if (!txtPerf19.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf19.Text.IndexOf(':') != txtPerf19.Text.LastIndexOf(':') || txtPerf19.Text.IndexOf('.') != txtPerf19.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #19 is invalid", true);
            return false;
        }
        if (!txtPerf20.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf20.Text.IndexOf(':') != txtPerf20.Text.LastIndexOf(':') || txtPerf20.Text.IndexOf('.') != txtPerf20.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #20 is invalid", true);
            return false;
        }
        if (!txtPerf21.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf21.Text.IndexOf(':') != txtPerf21.Text.LastIndexOf(':') || txtPerf21.Text.IndexOf('.') != txtPerf21.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #21 is invalid", true);
            return false;
        }
        if (!txtPerf22.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf22.Text.IndexOf(':') != txtPerf22.Text.LastIndexOf(':') || txtPerf22.Text.IndexOf('.') != txtPerf22.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #22 is invalid", true);
            return false;
        }
        if (!txtPerf23.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf23.Text.IndexOf(':') != txtPerf23.Text.LastIndexOf(':') || txtPerf23.Text.IndexOf('.') != txtPerf23.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #23 is invalid", true);
            return false;
        }
        if (!txtPerf24.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf24.Text.IndexOf(':') != txtPerf24.Text.LastIndexOf(':') || txtPerf24.Text.IndexOf('.') != txtPerf24.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #24 is invalid", true);
            return false;
        }
        if (!txtPerf25.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf25.Text.IndexOf(':') != txtPerf25.Text.LastIndexOf(':') || txtPerf25.Text.IndexOf('.') != txtPerf25.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #25 is invalid", true);
            return false;
        }
        if (!txtPerf26.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf26.Text.IndexOf(':') != txtPerf26.Text.LastIndexOf(':') || txtPerf26.Text.IndexOf('.') != txtPerf26.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #26 is invalid", true);
            return false;
        }
        if (!txtPerf27.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf27.Text.IndexOf(':') != txtPerf27.Text.LastIndexOf(':') || txtPerf27.Text.IndexOf('.') != txtPerf27.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #27 is invalid", true);
            return false;
        }
        if (!txtPerf28.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf28.Text.IndexOf(':') != txtPerf28.Text.LastIndexOf(':') || txtPerf28.Text.IndexOf('.') != txtPerf28.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #28 is invalid", true);
            return false;
        }
        if (!txtPerf29.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf29.Text.IndexOf(':') != txtPerf29.Text.LastIndexOf(':') || txtPerf29.Text.IndexOf('.') != txtPerf29.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #29 is invalid", true);
            return false;
        }
        if (!txtPerf30.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf30.Text.IndexOf(':') != txtPerf30.Text.LastIndexOf(':') || txtPerf30.Text.IndexOf('.') != txtPerf30.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #30 is invalid", true);
            return false;
        }
        if (!txtPerf31.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf31.Text.IndexOf(':') != txtPerf31.Text.LastIndexOf(':') || txtPerf31.Text.IndexOf('.') != txtPerf31.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #31 is invalid", true);
            return false;
        }
        if (!txtPerf32.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf32.Text.IndexOf(':') != txtPerf32.Text.LastIndexOf(':') || txtPerf32.Text.IndexOf('.') != txtPerf32.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Performance entered for Athlete #32 is invalid", true);
            return false;
        }
        if (txtName17.Text == "A Relay" || txtName18.Text == "A Relay" || txtName19.Text == "A Relay" || txtName20.Text == "A Relay" || txtName21.Text == "A Relay" || txtName22.Text == "A Relay" || txtName23.Text == "A Relay" || txtName24.Text == "A Relay" ||
           txtName25.Text == "A Relay" || txtName26.Text == "A Relay" || txtName27.Text == "A Relay" || txtName28.Text == "A Relay" || txtName29.Text == "A Relay" || txtName30.Text == "A Relay" || txtName31.Text == "A Relay" || txtName32.Text == "A Relay")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "Invalid name for a non scoring team", true);
            return false;
        }
        //If all the above errors were ot found, return true
        Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        return true;
    }

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

    private void EnterDataIntoForm()
    {
        Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

        ClearAll();

        //Need to seperate scoring and non-scoring performances
        List<Performance> scoringPerfs = new List<Performance>();
        List<Performance> nonScoringPerfs = new List<Performance>();

        if (allPerfs != null)
        {
            foreach (Performance p in allPerfs)
            {
                if (p.athleteName == "A Relay")
                {
                    scoringPerfs.Add(p);
                }
                else
                {
                    nonScoringPerfs.Add(p);
                }
            }
        }

        if (scoringPerfs.ElementAtOrDefault(0) != null)
        {
            txtName1.Text = scoringPerfs[0].athleteName;
            ddlSchool1.Text = scoringPerfs[0].schoolName;
            txtPerf1.Text = em.ConvertToTimedData(scoringPerfs[0].performance);
        }
        if (scoringPerfs.ElementAtOrDefault(1) != null)
        {
            txtName2.Text = scoringPerfs[1].athleteName;
            ddlSchool2.Text = scoringPerfs[1].schoolName;
            txtPerf2.Text = em.ConvertToTimedData(scoringPerfs[1].performance);
        }
        if (scoringPerfs.ElementAtOrDefault(2) != null)
        {
            txtName3.Text = scoringPerfs[2].athleteName;
            ddlSchool3.Text = scoringPerfs[2].schoolName;
            txtPerf3.Text = em.ConvertToTimedData(scoringPerfs[2].performance);
        }
        if (scoringPerfs.ElementAtOrDefault(3) != null)
        {
            txtName4.Text = scoringPerfs[3].athleteName;
            ddlSchool4.Text = scoringPerfs[3].schoolName;
            txtPerf4.Text = em.ConvertToTimedData(scoringPerfs[3].performance);
        }
        if (scoringPerfs.ElementAtOrDefault(4) != null)
        {
            txtName5.Text = scoringPerfs[4].athleteName;
            ddlSchool5.Text = scoringPerfs[4].schoolName;
            txtPerf5.Text = em.ConvertToTimedData(scoringPerfs[4].performance);
        }
        if (scoringPerfs.ElementAtOrDefault(5) != null)
        {
            txtName6.Text = scoringPerfs[5].athleteName;
            ddlSchool6.Text = scoringPerfs[5].schoolName;
            txtPerf6.Text = em.ConvertToTimedData(scoringPerfs[5].performance);
        }

        //ADD NON SCORING PERFS HERE
        if (nonScoringPerfs.ElementAtOrDefault(0) != null)
        {
            txtName17.Text = nonScoringPerfs[0].athleteName;
            ddlSchool17.Text = nonScoringPerfs[0].schoolName;
            txtPerf17.Text = em.ConvertToTimedData(nonScoringPerfs[0].performance);
        }
        if (nonScoringPerfs.ElementAtOrDefault(1) != null)
        {
            txtName18.Text = nonScoringPerfs[1].athleteName;
            ddlSchool18.Text = nonScoringPerfs[1].schoolName;
            txtPerf18.Text = em.ConvertToTimedData(nonScoringPerfs[1].performance);
        }
        if (nonScoringPerfs.ElementAtOrDefault(2) != null)
        {
            txtName19.Text = nonScoringPerfs[2].athleteName;
            ddlSchool19.Text = nonScoringPerfs[2].schoolName;
            txtPerf19.Text = em.ConvertToTimedData(nonScoringPerfs[2].performance);
        }
        if (nonScoringPerfs.ElementAtOrDefault(3) != null)
        {
            txtName20.Text = nonScoringPerfs[3].athleteName;
            ddlSchool20.Text = nonScoringPerfs[3].schoolName;
            txtPerf20.Text = em.ConvertToTimedData(nonScoringPerfs[3].performance);
        }
        if (nonScoringPerfs.ElementAtOrDefault(4) != null)
        {
            txtName21.Text = nonScoringPerfs[4].athleteName;
            ddlSchool21.Text = nonScoringPerfs[4].schoolName;
            txtPerf21.Text = em.ConvertToTimedData(nonScoringPerfs[4].performance);
        }
        if (nonScoringPerfs.ElementAtOrDefault(5) != null)
        {
            txtName22.Text = nonScoringPerfs[5].athleteName;
            ddlSchool22.Text = nonScoringPerfs[5].schoolName;
            txtPerf22.Text = em.ConvertToTimedData(nonScoringPerfs[5].performance);
        }
        if (nonScoringPerfs.ElementAtOrDefault(6) != null)
        {
            txtName23.Text = nonScoringPerfs[6].athleteName;
            ddlSchool23.Text = nonScoringPerfs[6].schoolName;
            txtPerf23.Text = em.ConvertToTimedData(nonScoringPerfs[6].performance);
        }
        if (nonScoringPerfs.ElementAtOrDefault(7) != null)
        {
            txtName24.Text = nonScoringPerfs[7].athleteName;
            ddlSchool24.Text = nonScoringPerfs[7].schoolName;
            txtPerf24.Text = em.ConvertToTimedData(nonScoringPerfs[7].performance);
        }
        if (nonScoringPerfs.ElementAtOrDefault(8) != null)
        {
            txtName25.Text = nonScoringPerfs[8].athleteName;
            ddlSchool25.Text = nonScoringPerfs[8].schoolName;
            txtPerf25.Text = em.ConvertToTimedData(nonScoringPerfs[8].performance);
        }
        if (nonScoringPerfs.ElementAtOrDefault(9) != null)
        {
            txtName26.Text = nonScoringPerfs[9].athleteName;
            ddlSchool26.Text = nonScoringPerfs[9].schoolName;
            txtPerf26.Text = em.ConvertToTimedData(nonScoringPerfs[9].performance);
        }
        if (nonScoringPerfs.ElementAtOrDefault(10) != null)
        {
            txtName27.Text = nonScoringPerfs[10].athleteName;
            ddlSchool27.Text = nonScoringPerfs[10].schoolName;
            txtPerf27.Text = em.ConvertToTimedData(nonScoringPerfs[10].performance);
        }
        if (nonScoringPerfs.ElementAtOrDefault(11) != null)
        {
            txtName28.Text = nonScoringPerfs[11].athleteName;
            ddlSchool28.Text = nonScoringPerfs[11].schoolName;
            txtPerf28.Text = em.ConvertToTimedData(nonScoringPerfs[11].performance);
        }
        if (nonScoringPerfs.ElementAtOrDefault(12) != null)
        {
            txtName29.Text = nonScoringPerfs[12].athleteName;
            ddlSchool29.Text = nonScoringPerfs[12].schoolName;
            txtPerf29.Text = em.ConvertToTimedData(nonScoringPerfs[12].performance);
        }
        if (nonScoringPerfs.ElementAtOrDefault(13) != null)
        {
            txtName30.Text = nonScoringPerfs[13].athleteName;
            ddlSchool30.Text = nonScoringPerfs[13].schoolName;
            txtPerf30.Text = em.ConvertToTimedData(nonScoringPerfs[13].performance);
        }
        if (nonScoringPerfs.ElementAtOrDefault(14) != null)
        {
            txtName31.Text = nonScoringPerfs[14].athleteName;
            ddlSchool31.Text = nonScoringPerfs[14].schoolName;
            txtPerf31.Text = em.ConvertToTimedData(nonScoringPerfs[14].performance);
        }
        if (nonScoringPerfs.ElementAtOrDefault(15) != null)
        {
            txtName32.Text = nonScoringPerfs[15].athleteName;
            ddlSchool32.Text = nonScoringPerfs[15].schoolName;
            txtPerf32.Text = em.ConvertToTimedData(nonScoringPerfs[15].performance);
        }

        Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    protected void cmdEnter_Click(object sender, EventArgs e)
    {
        Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        if (CheckData())
        {
            GatherPerfs();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Success", "Data for " + eventName + " entered", true);

            /*mh.AddEvent(eventName, allPerfs);
            string gender = "Boy";
            if (eventName.StartsWith("Girl"))
            {
                gender = "Girl";
            }
            mh.AddRelayEventToScores(gender, eventName, allPerfs);
            mh.Show();
            this.Close();*/

        //Add Event to Meet
        //Go to MeetHub
        }
        Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    protected void cmdPrintout_Click(object sender, EventArgs e)
    {
        if (CheckData())
        {
            PrintoutMgr pm = new PrintoutMgr();
            GatherPerfs();
            SortListOfPerfs();
            pm.CreateIndEventDoc(eventName, allPerfs);
        }
    }

    protected void cmdClearAll_Click(object sender, EventArgs e)
    {
        panClearAll.Visible = true;
    }

    protected void cmdYesAll_Click(object sender, EventArgs e)
    {
        panClearAll.Visible = false;
        ClearAll();
    }

    protected void cmdNoAll_Click(object sender, EventArgs e)
    {
        panClearAll.Visible = false;
    }
}
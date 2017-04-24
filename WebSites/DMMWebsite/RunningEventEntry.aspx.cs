using DualMeetManager.Business.Managers;
using DMMLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RunningEventEntry : System.Web.UI.Page
{
    //int currentHeatNum;
    //string eventName;
    //List<Performance> allPerfs = new List<Performance>();
    //Dictionary<int, List<Performance>> perfs = new Dictionary<int, List<Performance>>();

    //Session["Perfs"] = new Dictionary<int, List<Performance>>();
    //Session["AllPerfs"] = new List<Performance>();
    EventMgr em = new EventMgr();

    protected void Page_Load(object sender, EventArgs e)
    {
        Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

        if (!IsPostBack) //If the page is loaded for the first time
        {
            Session["Perfs"] = new Dictionary<int, List<Performance>>();
            Session["AllPerfs"] = new List<Performance>();
            if (Session["CurrentEvent"] != null) //This should never not be true
            {

                Meet myMeet = (Meet)Session["ActiveMeet"];
                if (myMeet.performances != null && myMeet.performances.ContainsKey(Session["CurrentEvent"].ToString()))
                    //allPerfs = myMeet.performances[Session["CurrentEvent"].ToString()];
                    Session["AllPerfs"] = myMeet.performances[Session["CurrentEvent"].ToString()];
            }
            else //Error, consider a redirect
            {
                Console.WriteLine("ERROR. Invalid eventName");

                //Should prob exit and go to MeetHub page at this point
                //Code below exists for debug purposes
                Session["CurrentEvent"] = "INVALID EVENT";
            }

            this.Title = Session["CurrentEvent"] + " Entry";
            if (Session["CurrentEvent"].ToString().StartsWith("Boy"))
            {
                //Change background color to lightblue
                PageBody.Attributes.Add("style", "background-color: #ADD8E6");
            }
            else if (Session["CurrentEvent"].ToString().StartsWith("Girl"))
            {
                //Change background color to lightpink
                PageBody.Attributes.Add("style", "background-color: #ffb6c1");
            }
            PopulateTeams();
            SortListOfPerfs();
            PutPerfsIntoOrderedDictionary();
            Session["CurrentHeat"] = 0;
            EnterDataIntoForm();
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

        if (Session["CurrentEvent"].ToString().StartsWith("Boy") && myMeet != null && myMeet.schoolNames != null && myMeet.schoolNames.boySchoolNames != null)
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
        else if (Session["CurrentEvent"].ToString().StartsWith("Girl") && myMeet != null && myMeet.schoolNames != null && myMeet.schoolNames.girlSchoolNames != null)
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

    /// <summary>
    /// Sorts the List of Performances in Descending Order (Best to Worst)
    /// </summary>
    private void SortListOfPerfs()
    {
        if (Session["AllPerfs"] != null && ((List<Performance>)Session["AllPerfs"]).Count > 0)
        {
            Session["AllPerfs"] = ((List<Performance>)Session["AllPerfs"]).OrderBy(o => o.performance).ToList();
        }
    }

    /// <summary>
    /// Enters data from specific heat (int currentHeatNum) for all objects on the form
    /// </summary>
    /// <remarks>Untested and does not look at other flights</remarks>
    private void EnterDataIntoForm()
    {
        Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

        ClearAll();

        //Needs to check that this entry exists. Otherwise it will produce an error
        List<Performance> tempPerfs = new List<Performance>();

        Dictionary<int, List<Performance>> testDict = (Dictionary<int, List<Performance>>)Session["Perfs"];
        List<Performance> testPerfs = (List<Performance>)Session["AllPerfs"];
        int testHeat = (int)Session["CurrentHeat"];


        if (((Dictionary<int, List<Performance>>)Session["Perfs"]).ContainsKey((int)Session["CurrentHeat"]))
            tempPerfs = ((Dictionary<int, List<Performance>>)Session["Perfs"])[(int)Session["CurrentHeat"]] as List<Performance>;

        if (tempPerfs.ElementAtOrDefault(0) != null)
        {
            txtName1.Text = tempPerfs[0].athleteName;
            ddlSchool1.Text = tempPerfs[0].schoolName;
            txtPerf1.Text = em.ConvertToTimedData(tempPerfs[0].performance);
        }
        if (tempPerfs.ElementAtOrDefault(1) != null)
        {
            txtName2.Text = tempPerfs[1].athleteName;
            ddlSchool2.Text = tempPerfs[1].schoolName;
            txtPerf2.Text = em.ConvertToTimedData(tempPerfs[1].performance);
        }
        if (tempPerfs.ElementAtOrDefault(2) != null)
        {
            txtName3.Text = tempPerfs[2].athleteName;
            ddlSchool3.Text = tempPerfs[2].schoolName;
            txtPerf3.Text = em.ConvertToTimedData(tempPerfs[2].performance);
        }
        if (tempPerfs.ElementAtOrDefault(3) != null)
        {
            txtName4.Text = tempPerfs[3].athleteName;
            ddlSchool4.Text = tempPerfs[3].schoolName;
            txtPerf4.Text = em.ConvertToTimedData(tempPerfs[3].performance);
        }
        if (tempPerfs.ElementAtOrDefault(4) != null)
        {
            txtName5.Text = tempPerfs[4].athleteName;
            ddlSchool5.Text = tempPerfs[4].schoolName;
            txtPerf5.Text = em.ConvertToTimedData(tempPerfs[4].performance);
        }
        if (tempPerfs.ElementAtOrDefault(5) != null)
        {
            txtName6.Text = tempPerfs[5].athleteName;
            ddlSchool6.Text = tempPerfs[5].schoolName;
            txtPerf6.Text = em.ConvertToTimedData(tempPerfs[5].performance);
        }
        if (tempPerfs.ElementAtOrDefault(6) != null)
        {
            txtName7.Text = tempPerfs[6].athleteName;
            ddlSchool7.Text = tempPerfs[6].schoolName;
            txtPerf7.Text = em.ConvertToTimedData(tempPerfs[6].performance);
        }
        if (tempPerfs.ElementAtOrDefault(7) != null)
        {
            txtName8.Text = tempPerfs[7].athleteName;
            ddlSchool8.Text = tempPerfs[7].schoolName;
            txtPerf8.Text = em.ConvertToTimedData(tempPerfs[7].performance);
        }
        if (tempPerfs.ElementAtOrDefault(8) != null)
        {
            txtName9.Text = tempPerfs[8].athleteName;
            ddlSchool9.Text = tempPerfs[8].schoolName;
            txtPerf9.Text = em.ConvertToTimedData(tempPerfs[8].performance);
        }
        if (tempPerfs.ElementAtOrDefault(9) != null)
        {
            txtName10.Text = tempPerfs[9].athleteName;
            ddlSchool10.Text = tempPerfs[9].schoolName;
            txtPerf10.Text = em.ConvertToTimedData(tempPerfs[9].performance);
        }
        if (tempPerfs.ElementAtOrDefault(10) != null)
        {
            txtName11.Text = tempPerfs[10].athleteName;
            ddlSchool11.Text = tempPerfs[10].schoolName;
            txtPerf11.Text = em.ConvertToTimedData(tempPerfs[10].performance);
        }
        if (tempPerfs.ElementAtOrDefault(11) != null)
        {
            txtName12.Text = tempPerfs[11].athleteName;
            ddlSchool12.Text = tempPerfs[11].schoolName;
            txtPerf12.Text = em.ConvertToTimedData(tempPerfs[11].performance);
        }
        if (tempPerfs.ElementAtOrDefault(12) != null)
        {
            txtName13.Text = tempPerfs[12].athleteName;
            ddlSchool13.Text = tempPerfs[12].schoolName;
            txtPerf13.Text = em.ConvertToTimedData(tempPerfs[12].performance);
        }
        if (tempPerfs.ElementAtOrDefault(13) != null)
        {
            txtName14.Text = tempPerfs[13].athleteName;
            ddlSchool14.Text = tempPerfs[13].schoolName;
            txtPerf14.Text = em.ConvertToTimedData(tempPerfs[13].performance);
        }
        if (tempPerfs.ElementAtOrDefault(14) != null)
        {
            txtName15.Text = tempPerfs[14].athleteName;
            ddlSchool15.Text = tempPerfs[14].schoolName;
            txtPerf15.Text = em.ConvertToTimedData(tempPerfs[14].performance);
        }
        if (tempPerfs.ElementAtOrDefault(15) != null)
        {
            txtName16.Text = tempPerfs[15].athleteName;
            ddlSchool16.Text = tempPerfs[15].schoolName;
            txtPerf16.Text = em.ConvertToTimedData(tempPerfs[15].performance);
        }
        if (tempPerfs.ElementAtOrDefault(16) != null)
        {
            txtName17.Text = tempPerfs[16].athleteName;
            ddlSchool17.Text = tempPerfs[16].schoolName;
            txtPerf17.Text = em.ConvertToTimedData(tempPerfs[16].performance);
        }
        if (tempPerfs.ElementAtOrDefault(17) != null)
        {
            txtName18.Text = tempPerfs[17].athleteName;
            ddlSchool18.Text = tempPerfs[17].schoolName;
            txtPerf18.Text = em.ConvertToTimedData(tempPerfs[17].performance);
        }
        if (tempPerfs.ElementAtOrDefault(18) != null)
        {
            txtName19.Text = tempPerfs[18].athleteName;
            ddlSchool19.Text = tempPerfs[18].schoolName;
            txtPerf19.Text = em.ConvertToTimedData(tempPerfs[18].performance);
        }
        if (tempPerfs.ElementAtOrDefault(19) != null)
        {
            txtName20.Text = tempPerfs[19].athleteName;
            ddlSchool20.Text = tempPerfs[19].schoolName;
            txtPerf20.Text = em.ConvertToTimedData(tempPerfs[19].performance);
        }
        if (tempPerfs.ElementAtOrDefault(20) != null)
        {
            txtName21.Text = tempPerfs[20].athleteName;
            ddlSchool21.Text = tempPerfs[20].schoolName;
            txtPerf21.Text = em.ConvertToTimedData(tempPerfs[20].performance);
        }
        if (tempPerfs.ElementAtOrDefault(21) != null)
        {
            txtName22.Text = tempPerfs[21].athleteName;
            ddlSchool22.Text = tempPerfs[21].schoolName;
            txtPerf22.Text = em.ConvertToTimedData(tempPerfs[21].performance);
        }
        if (tempPerfs.ElementAtOrDefault(22) != null)
        {
            txtName23.Text = tempPerfs[22].athleteName;
            ddlSchool23.Text = tempPerfs[22].schoolName;
            txtPerf23.Text = em.ConvertToTimedData(tempPerfs[22].performance);
        }
        if (tempPerfs.ElementAtOrDefault(23) != null)
        {
            txtName24.Text = tempPerfs[23].athleteName;
            ddlSchool24.Text = tempPerfs[23].schoolName;
            txtPerf24.Text = em.ConvertToTimedData(tempPerfs[23].performance);
        }
        if (tempPerfs.ElementAtOrDefault(24) != null)
        {
            txtName25.Text = tempPerfs[24].athleteName;
            ddlSchool25.Text = tempPerfs[24].schoolName;
            txtPerf25.Text = em.ConvertToTimedData(tempPerfs[24].performance);
        }
        if (tempPerfs.ElementAtOrDefault(25) != null)
        {
            txtName26.Text = tempPerfs[25].athleteName;
            ddlSchool26.Text = tempPerfs[25].schoolName;
            txtPerf26.Text = em.ConvertToTimedData(tempPerfs[25].performance);
        }
        if (tempPerfs.ElementAtOrDefault(26) != null)
        {
            txtName27.Text = tempPerfs[26].athleteName;
            ddlSchool27.Text = tempPerfs[26].schoolName;
            txtPerf27.Text = em.ConvertToTimedData(tempPerfs[26].performance);
        }
        if (tempPerfs.ElementAtOrDefault(27) != null)
        {
            txtName28.Text = tempPerfs[27].athleteName;
            ddlSchool28.Text = tempPerfs[27].schoolName;
            txtPerf28.Text = em.ConvertToTimedData(tempPerfs[27].performance);
        }
        if (tempPerfs.ElementAtOrDefault(28) != null)
        {
            txtName29.Text = tempPerfs[28].athleteName;
            ddlSchool29.Text = tempPerfs[28].schoolName;
            txtPerf29.Text = em.ConvertToTimedData(tempPerfs[28].performance);
        }
        if (tempPerfs.ElementAtOrDefault(29) != null)
        {
            txtName30.Text = tempPerfs[29].athleteName;
            ddlSchool30.Text = tempPerfs[29].schoolName;
            txtPerf30.Text = em.ConvertToTimedData(tempPerfs[29].performance);
        }
        if (tempPerfs.ElementAtOrDefault(30) != null)
        {
            txtName31.Text = tempPerfs[30].athleteName;
            ddlSchool31.Text = tempPerfs[30].schoolName;
            txtPerf31.Text = em.ConvertToTimedData(tempPerfs[30].performance);
        }
        if (tempPerfs.ElementAtOrDefault(31) != null)
        {
            txtName32.Text = tempPerfs[31].athleteName;
            ddlSchool32.Text = tempPerfs[31].schoolName;
            txtPerf32.Text = em.ConvertToTimedData(tempPerfs[31].performance);
        }

        Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
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
    /// Adds an entire heat to the Dictionary of Performances
    /// </summary>
    /// <returns></returns>
    private bool AddHeatToDictionary()
    {
        Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        if (CheckData())
        {
            List<Performance> listToAdd = new List<Performance>();

            if (!string.IsNullOrWhiteSpace(txtName1.Text))
                listToAdd.Add(new Performance(txtName1.Text, ddlSchool1.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf1.Text)));
            if (!string.IsNullOrWhiteSpace(txtName2.Text))
                listToAdd.Add(new Performance(txtName2.Text, ddlSchool2.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf2.Text)));
            if (!string.IsNullOrWhiteSpace(txtName3.Text))
                listToAdd.Add(new Performance(txtName3.Text, ddlSchool3.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf3.Text)));
            if (!string.IsNullOrWhiteSpace(txtName4.Text))
                listToAdd.Add(new Performance(txtName4.Text, ddlSchool4.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf4.Text)));
            if (!string.IsNullOrWhiteSpace(txtName5.Text))
                listToAdd.Add(new Performance(txtName5.Text, ddlSchool5.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf5.Text)));
            if (!string.IsNullOrWhiteSpace(txtName6.Text))
                listToAdd.Add(new Performance(txtName6.Text, ddlSchool6.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf6.Text)));
            if (!string.IsNullOrWhiteSpace(txtName7.Text))
                listToAdd.Add(new Performance(txtName7.Text, ddlSchool7.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf7.Text)));
            if (!string.IsNullOrWhiteSpace(txtName8.Text))
                listToAdd.Add(new Performance(txtName8.Text, ddlSchool8.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf8.Text)));
            if (!string.IsNullOrWhiteSpace(txtName9.Text))
                listToAdd.Add(new Performance(txtName9.Text, ddlSchool9.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf9.Text)));
            if (!string.IsNullOrWhiteSpace(txtName10.Text))
                listToAdd.Add(new Performance(txtName10.Text, ddlSchool10.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf10.Text)));
            if (!string.IsNullOrWhiteSpace(txtName11.Text))
                listToAdd.Add(new Performance(txtName11.Text, ddlSchool11.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf11.Text)));
            if (!string.IsNullOrWhiteSpace(txtName12.Text))
                listToAdd.Add(new Performance(txtName12.Text, ddlSchool12.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf12.Text)));
            if (!string.IsNullOrWhiteSpace(txtName13.Text))
                listToAdd.Add(new Performance(txtName13.Text, ddlSchool13.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf13.Text)));
            if (!string.IsNullOrWhiteSpace(txtName14.Text))
                listToAdd.Add(new Performance(txtName14.Text, ddlSchool14.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf14.Text)));
            if (!string.IsNullOrWhiteSpace(txtName15.Text))
                listToAdd.Add(new Performance(txtName15.Text, ddlSchool15.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf15.Text)));
            if (!string.IsNullOrWhiteSpace(txtName16.Text))
                listToAdd.Add(new Performance(txtName16.Text, ddlSchool16.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf16.Text)));
            if (!string.IsNullOrWhiteSpace(txtName17.Text))
                listToAdd.Add(new Performance(txtName17.Text, ddlSchool17.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf17.Text)));
            if (!string.IsNullOrWhiteSpace(txtName18.Text))
                listToAdd.Add(new Performance(txtName18.Text, ddlSchool18.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf18.Text)));
            if (!string.IsNullOrWhiteSpace(txtName19.Text))
                listToAdd.Add(new Performance(txtName19.Text, ddlSchool19.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf19.Text)));
            if (!string.IsNullOrWhiteSpace(txtName20.Text))
                listToAdd.Add(new Performance(txtName20.Text, ddlSchool20.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf20.Text)));
            if (!string.IsNullOrWhiteSpace(txtName21.Text))
                listToAdd.Add(new Performance(txtName21.Text, ddlSchool21.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf21.Text)));
            if (!string.IsNullOrWhiteSpace(txtName22.Text))
                listToAdd.Add(new Performance(txtName22.Text, ddlSchool22.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf22.Text)));
            if (!string.IsNullOrWhiteSpace(txtName23.Text))
                listToAdd.Add(new Performance(txtName23.Text, ddlSchool23.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf23.Text)));
            if (!string.IsNullOrWhiteSpace(txtName24.Text))
                listToAdd.Add(new Performance(txtName24.Text, ddlSchool24.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf24.Text)));
            if (!string.IsNullOrWhiteSpace(txtName25.Text))
                listToAdd.Add(new Performance(txtName25.Text, ddlSchool25.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf25.Text)));
            if (!string.IsNullOrWhiteSpace(txtName26.Text))
                listToAdd.Add(new Performance(txtName26.Text, ddlSchool26.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf26.Text)));
            if (!string.IsNullOrWhiteSpace(txtName27.Text))
                listToAdd.Add(new Performance(txtName27.Text, ddlSchool27.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf27.Text)));
            if (!string.IsNullOrWhiteSpace(txtName28.Text))
                listToAdd.Add(new Performance(txtName28.Text, ddlSchool28.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf28.Text)));
            if (!string.IsNullOrWhiteSpace(txtName29.Text))
                listToAdd.Add(new Performance(txtName29.Text, ddlSchool29.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf29.Text)));
            if (!string.IsNullOrWhiteSpace(txtName30.Text))
                listToAdd.Add(new Performance(txtName30.Text, ddlSchool30.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf30.Text)));
            if (!string.IsNullOrWhiteSpace(txtName31.Text))
                listToAdd.Add(new Performance(txtName31.Text, ddlSchool31.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf31.Text)));
            if (!string.IsNullOrWhiteSpace(txtName32.Text))
                listToAdd.Add(new Performance(txtName32.Text, ddlSchool32.Text, (int)Session["CurrentHeat"] + 1, em.ConvertFromTimedData(txtPerf32.Text)));

            //if (Session["Perfs"].Contains((int)Session["CurrentHeat"]))

            if (((Dictionary<int, List<Performance>>)Session["Perfs"]).ContainsKey((int)Session["CurrentHeat"]))
                ((Dictionary<int, List<Performance>>)Session["Perfs"])[(int)Session["CurrentHeat"]] = listToAdd;
            else
                ((Dictionary<int, List<Performance>>)Session["Perfs"]).Add((int)Session["CurrentHeat"], listToAdd);

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
    /// Check to make sure that the data entered into the form by the user is valid
    /// </summary>
    /// <returns>true if valid, false if invalid</returns>
    private bool CheckData()
    {
        Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

        //Check that every athlete 1-32 has either no values or all values
        if ((string.IsNullOrWhiteSpace(txtName1.Text) && (!string.IsNullOrWhiteSpace(ddlSchool1.Text) || !string.IsNullOrWhiteSpace(txtPerf1.Text))) ||
            (string.IsNullOrWhiteSpace(ddlSchool1.Text) && (!string.IsNullOrWhiteSpace(txtName1.Text) || !string.IsNullOrWhiteSpace(txtPerf1.Text))) ||
            (string.IsNullOrWhiteSpace(txtPerf1.Text) && (!string.IsNullOrWhiteSpace(ddlSchool1.Text) || !string.IsNullOrWhiteSpace(txtName1.Text))))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #1');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName2.Text) && string.IsNullOrWhiteSpace(ddlSchool2.Text) && string.IsNullOrWhiteSpace(txtPerf2.Text)) ||
            (string.IsNullOrWhiteSpace(txtName2.Text) && !string.IsNullOrWhiteSpace(ddlSchool2.Text) && string.IsNullOrWhiteSpace(txtPerf2.Text)) ||
            (string.IsNullOrWhiteSpace(txtName2.Text) && string.IsNullOrWhiteSpace(ddlSchool2.Text) && !string.IsNullOrWhiteSpace(txtPerf2.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #2');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName3.Text) && string.IsNullOrWhiteSpace(ddlSchool3.Text) && string.IsNullOrWhiteSpace(txtPerf3.Text)) ||
            (string.IsNullOrWhiteSpace(txtName3.Text) && !string.IsNullOrWhiteSpace(ddlSchool3.Text) && string.IsNullOrWhiteSpace(txtPerf3.Text)) ||
            (string.IsNullOrWhiteSpace(txtName3.Text) && string.IsNullOrWhiteSpace(ddlSchool3.Text) && !string.IsNullOrWhiteSpace(txtPerf3.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #3');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName4.Text) && string.IsNullOrWhiteSpace(ddlSchool4.Text) && string.IsNullOrWhiteSpace(txtPerf4.Text)) ||
            (string.IsNullOrWhiteSpace(txtName4.Text) && !string.IsNullOrWhiteSpace(ddlSchool4.Text) && string.IsNullOrWhiteSpace(txtPerf4.Text)) ||
            (string.IsNullOrWhiteSpace(txtName4.Text) && string.IsNullOrWhiteSpace(ddlSchool4.Text) && !string.IsNullOrWhiteSpace(txtPerf4.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #4');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName5.Text) && string.IsNullOrWhiteSpace(ddlSchool5.Text) && string.IsNullOrWhiteSpace(txtPerf5.Text)) ||
            (string.IsNullOrWhiteSpace(txtName5.Text) && !string.IsNullOrWhiteSpace(ddlSchool5.Text) && string.IsNullOrWhiteSpace(txtPerf5.Text)) ||
            (string.IsNullOrWhiteSpace(txtName5.Text) && string.IsNullOrWhiteSpace(ddlSchool5.Text) && !string.IsNullOrWhiteSpace(txtPerf5.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #5');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName6.Text) && string.IsNullOrWhiteSpace(ddlSchool6.Text) && string.IsNullOrWhiteSpace(txtPerf6.Text)) ||
            (string.IsNullOrWhiteSpace(txtName6.Text) && !string.IsNullOrWhiteSpace(ddlSchool6.Text) && string.IsNullOrWhiteSpace(txtPerf6.Text)) ||
            (string.IsNullOrWhiteSpace(txtName6.Text) && string.IsNullOrWhiteSpace(ddlSchool6.Text) && !string.IsNullOrWhiteSpace(txtPerf6.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #6');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName7.Text) && string.IsNullOrWhiteSpace(ddlSchool7.Text) && string.IsNullOrWhiteSpace(txtPerf7.Text)) ||
            (string.IsNullOrWhiteSpace(txtName7.Text) && !string.IsNullOrWhiteSpace(ddlSchool7.Text) && string.IsNullOrWhiteSpace(txtPerf7.Text)) ||
            (string.IsNullOrWhiteSpace(txtName7.Text) && string.IsNullOrWhiteSpace(ddlSchool7.Text) && !string.IsNullOrWhiteSpace(txtPerf7.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #7');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName8.Text) && string.IsNullOrWhiteSpace(ddlSchool8.Text) && string.IsNullOrWhiteSpace(txtPerf8.Text)) ||
            (string.IsNullOrWhiteSpace(txtName8.Text) && !string.IsNullOrWhiteSpace(ddlSchool8.Text) && string.IsNullOrWhiteSpace(txtPerf8.Text)) ||
            (string.IsNullOrWhiteSpace(txtName8.Text) && string.IsNullOrWhiteSpace(ddlSchool8.Text) && !string.IsNullOrWhiteSpace(txtPerf8.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #8');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName9.Text) && string.IsNullOrWhiteSpace(ddlSchool9.Text) && string.IsNullOrWhiteSpace(txtPerf9.Text)) ||
            (string.IsNullOrWhiteSpace(txtName9.Text) && !string.IsNullOrWhiteSpace(ddlSchool9.Text) && string.IsNullOrWhiteSpace(txtPerf9.Text)) ||
            (string.IsNullOrWhiteSpace(txtName9.Text) && string.IsNullOrWhiteSpace(ddlSchool9.Text) && !string.IsNullOrWhiteSpace(txtPerf9.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #9');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName10.Text) && string.IsNullOrWhiteSpace(ddlSchool10.Text) && string.IsNullOrWhiteSpace(txtPerf10.Text)) ||
            (string.IsNullOrWhiteSpace(txtName10.Text) && !string.IsNullOrWhiteSpace(ddlSchool10.Text) && string.IsNullOrWhiteSpace(txtPerf10.Text)) ||
            (string.IsNullOrWhiteSpace(txtName10.Text) && string.IsNullOrWhiteSpace(ddlSchool10.Text) && !string.IsNullOrWhiteSpace(txtPerf10.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #10');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName11.Text) && string.IsNullOrWhiteSpace(ddlSchool11.Text) && string.IsNullOrWhiteSpace(txtPerf11.Text)) ||
            (string.IsNullOrWhiteSpace(txtName11.Text) && !string.IsNullOrWhiteSpace(ddlSchool11.Text) && string.IsNullOrWhiteSpace(txtPerf11.Text)) ||
            (string.IsNullOrWhiteSpace(txtName11.Text) && string.IsNullOrWhiteSpace(ddlSchool11.Text) && !string.IsNullOrWhiteSpace(txtPerf11.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #11');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName12.Text) && string.IsNullOrWhiteSpace(ddlSchool12.Text) && string.IsNullOrWhiteSpace(txtPerf12.Text)) ||
            (string.IsNullOrWhiteSpace(txtName12.Text) && !string.IsNullOrWhiteSpace(ddlSchool12.Text) && string.IsNullOrWhiteSpace(txtPerf12.Text)) ||
            (string.IsNullOrWhiteSpace(txtName12.Text) && string.IsNullOrWhiteSpace(ddlSchool12.Text) && !string.IsNullOrWhiteSpace(txtPerf12.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #12');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName13.Text) && string.IsNullOrWhiteSpace(ddlSchool13.Text) && string.IsNullOrWhiteSpace(txtPerf13.Text)) ||
            (string.IsNullOrWhiteSpace(txtName13.Text) && !string.IsNullOrWhiteSpace(ddlSchool13.Text) && string.IsNullOrWhiteSpace(txtPerf13.Text)) ||
            (string.IsNullOrWhiteSpace(txtName13.Text) && string.IsNullOrWhiteSpace(ddlSchool13.Text) && !string.IsNullOrWhiteSpace(txtPerf13.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #13');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName14.Text) && string.IsNullOrWhiteSpace(ddlSchool14.Text) && string.IsNullOrWhiteSpace(txtPerf14.Text)) ||
            (string.IsNullOrWhiteSpace(txtName14.Text) && !string.IsNullOrWhiteSpace(ddlSchool14.Text) && string.IsNullOrWhiteSpace(txtPerf14.Text)) ||
            (string.IsNullOrWhiteSpace(txtName14.Text) && string.IsNullOrWhiteSpace(ddlSchool14.Text) && !string.IsNullOrWhiteSpace(txtPerf14.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #14');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName15.Text) && string.IsNullOrWhiteSpace(ddlSchool15.Text) && string.IsNullOrWhiteSpace(txtPerf15.Text)) ||
            (string.IsNullOrWhiteSpace(txtName15.Text) && !string.IsNullOrWhiteSpace(ddlSchool15.Text) && string.IsNullOrWhiteSpace(txtPerf15.Text)) ||
            (string.IsNullOrWhiteSpace(txtName15.Text) && string.IsNullOrWhiteSpace(ddlSchool15.Text) && !string.IsNullOrWhiteSpace(txtPerf15.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #15');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName16.Text) && string.IsNullOrWhiteSpace(ddlSchool16.Text) && string.IsNullOrWhiteSpace(txtPerf16.Text)) ||
            (string.IsNullOrWhiteSpace(txtName16.Text) && !string.IsNullOrWhiteSpace(ddlSchool16.Text) && string.IsNullOrWhiteSpace(txtPerf16.Text)) ||
            (string.IsNullOrWhiteSpace(txtName16.Text) && string.IsNullOrWhiteSpace(ddlSchool16.Text) && !string.IsNullOrWhiteSpace(txtPerf16.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #16');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName17.Text) && string.IsNullOrWhiteSpace(ddlSchool17.Text) && string.IsNullOrWhiteSpace(txtPerf17.Text)) ||
            (string.IsNullOrWhiteSpace(txtName17.Text) && !string.IsNullOrWhiteSpace(ddlSchool17.Text) && string.IsNullOrWhiteSpace(txtPerf17.Text)) ||
            (string.IsNullOrWhiteSpace(txtName17.Text) && string.IsNullOrWhiteSpace(ddlSchool17.Text) && !string.IsNullOrWhiteSpace(txtPerf17.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #17');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName18.Text) && string.IsNullOrWhiteSpace(ddlSchool18.Text) && string.IsNullOrWhiteSpace(txtPerf18.Text)) ||
            (string.IsNullOrWhiteSpace(txtName18.Text) && !string.IsNullOrWhiteSpace(ddlSchool18.Text) && string.IsNullOrWhiteSpace(txtPerf18.Text)) ||
            (string.IsNullOrWhiteSpace(txtName18.Text) && string.IsNullOrWhiteSpace(ddlSchool18.Text) && !string.IsNullOrWhiteSpace(txtPerf18.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #18');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName19.Text) && string.IsNullOrWhiteSpace(ddlSchool19.Text) && string.IsNullOrWhiteSpace(txtPerf19.Text)) ||
            (string.IsNullOrWhiteSpace(txtName19.Text) && !string.IsNullOrWhiteSpace(ddlSchool19.Text) && string.IsNullOrWhiteSpace(txtPerf19.Text)) ||
            (string.IsNullOrWhiteSpace(txtName19.Text) && string.IsNullOrWhiteSpace(ddlSchool19.Text) && !string.IsNullOrWhiteSpace(txtPerf19.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #19');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName20.Text) && string.IsNullOrWhiteSpace(ddlSchool20.Text) && string.IsNullOrWhiteSpace(txtPerf20.Text)) ||
            (string.IsNullOrWhiteSpace(txtName20.Text) && !string.IsNullOrWhiteSpace(ddlSchool20.Text) && string.IsNullOrWhiteSpace(txtPerf20.Text)) ||
            (string.IsNullOrWhiteSpace(txtName20.Text) && string.IsNullOrWhiteSpace(ddlSchool20.Text) && !string.IsNullOrWhiteSpace(txtPerf20.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #20');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName21.Text) && string.IsNullOrWhiteSpace(ddlSchool21.Text) && string.IsNullOrWhiteSpace(txtPerf21.Text)) ||
            (string.IsNullOrWhiteSpace(txtName21.Text) && !string.IsNullOrWhiteSpace(ddlSchool21.Text) && string.IsNullOrWhiteSpace(txtPerf21.Text)) ||
            (string.IsNullOrWhiteSpace(txtName21.Text) && string.IsNullOrWhiteSpace(ddlSchool21.Text) && !string.IsNullOrWhiteSpace(txtPerf21.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #21');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName22.Text) && string.IsNullOrWhiteSpace(ddlSchool22.Text) && string.IsNullOrWhiteSpace(txtPerf22.Text)) ||
            (string.IsNullOrWhiteSpace(txtName22.Text) && !string.IsNullOrWhiteSpace(ddlSchool22.Text) && string.IsNullOrWhiteSpace(txtPerf22.Text)) ||
            (string.IsNullOrWhiteSpace(txtName22.Text) && string.IsNullOrWhiteSpace(ddlSchool22.Text) && !string.IsNullOrWhiteSpace(txtPerf22.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #22');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName23.Text) && string.IsNullOrWhiteSpace(ddlSchool23.Text) && string.IsNullOrWhiteSpace(txtPerf23.Text)) ||
            (string.IsNullOrWhiteSpace(txtName23.Text) && !string.IsNullOrWhiteSpace(ddlSchool23.Text) && string.IsNullOrWhiteSpace(txtPerf23.Text)) ||
            (string.IsNullOrWhiteSpace(txtName23.Text) && string.IsNullOrWhiteSpace(ddlSchool23.Text) && !string.IsNullOrWhiteSpace(txtPerf23.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #23');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName24.Text) && string.IsNullOrWhiteSpace(ddlSchool24.Text) && string.IsNullOrWhiteSpace(txtPerf24.Text)) ||
            (string.IsNullOrWhiteSpace(txtName24.Text) && !string.IsNullOrWhiteSpace(ddlSchool24.Text) && string.IsNullOrWhiteSpace(txtPerf24.Text)) ||
            (string.IsNullOrWhiteSpace(txtName24.Text) && string.IsNullOrWhiteSpace(ddlSchool24.Text) && !string.IsNullOrWhiteSpace(txtPerf24.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #24');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName25.Text) && string.IsNullOrWhiteSpace(ddlSchool25.Text) && string.IsNullOrWhiteSpace(txtPerf25.Text)) ||
            (string.IsNullOrWhiteSpace(txtName25.Text) && !string.IsNullOrWhiteSpace(ddlSchool25.Text) && string.IsNullOrWhiteSpace(txtPerf25.Text)) ||
            (string.IsNullOrWhiteSpace(txtName25.Text) && string.IsNullOrWhiteSpace(ddlSchool25.Text) && !string.IsNullOrWhiteSpace(txtPerf25.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #25');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName26.Text) && string.IsNullOrWhiteSpace(ddlSchool26.Text) && string.IsNullOrWhiteSpace(txtPerf26.Text)) ||
            (string.IsNullOrWhiteSpace(txtName26.Text) && !string.IsNullOrWhiteSpace(ddlSchool26.Text) && string.IsNullOrWhiteSpace(txtPerf26.Text)) ||
            (string.IsNullOrWhiteSpace(txtName26.Text) && string.IsNullOrWhiteSpace(ddlSchool26.Text) && !string.IsNullOrWhiteSpace(txtPerf26.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #26');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName27.Text) && string.IsNullOrWhiteSpace(ddlSchool27.Text) && string.IsNullOrWhiteSpace(txtPerf27.Text)) ||
            (string.IsNullOrWhiteSpace(txtName27.Text) && !string.IsNullOrWhiteSpace(ddlSchool27.Text) && string.IsNullOrWhiteSpace(txtPerf27.Text)) ||
            (string.IsNullOrWhiteSpace(txtName27.Text) && string.IsNullOrWhiteSpace(ddlSchool27.Text) && !string.IsNullOrWhiteSpace(txtPerf27.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #27');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName28.Text) && string.IsNullOrWhiteSpace(ddlSchool28.Text) && string.IsNullOrWhiteSpace(txtPerf28.Text)) ||
            (string.IsNullOrWhiteSpace(txtName28.Text) && !string.IsNullOrWhiteSpace(ddlSchool28.Text) && string.IsNullOrWhiteSpace(txtPerf28.Text)) ||
            (string.IsNullOrWhiteSpace(txtName28.Text) && string.IsNullOrWhiteSpace(ddlSchool28.Text) && !string.IsNullOrWhiteSpace(txtPerf28.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #28');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName29.Text) && string.IsNullOrWhiteSpace(ddlSchool29.Text) && string.IsNullOrWhiteSpace(txtPerf29.Text)) ||
            (string.IsNullOrWhiteSpace(txtName29.Text) && !string.IsNullOrWhiteSpace(ddlSchool29.Text) && string.IsNullOrWhiteSpace(txtPerf29.Text)) ||
            (string.IsNullOrWhiteSpace(txtName29.Text) && string.IsNullOrWhiteSpace(ddlSchool29.Text) && !string.IsNullOrWhiteSpace(txtPerf29.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #29');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName30.Text) && string.IsNullOrWhiteSpace(ddlSchool30.Text) && string.IsNullOrWhiteSpace(txtPerf30.Text)) ||
            (string.IsNullOrWhiteSpace(txtName30.Text) && !string.IsNullOrWhiteSpace(ddlSchool30.Text) && string.IsNullOrWhiteSpace(txtPerf30.Text)) ||
            (string.IsNullOrWhiteSpace(txtName30.Text) && string.IsNullOrWhiteSpace(ddlSchool30.Text) && !string.IsNullOrWhiteSpace(txtPerf30.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #30');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName31.Text) && string.IsNullOrWhiteSpace(ddlSchool31.Text) && string.IsNullOrWhiteSpace(txtPerf31.Text)) ||
            (string.IsNullOrWhiteSpace(txtName31.Text) && !string.IsNullOrWhiteSpace(ddlSchool31.Text) && string.IsNullOrWhiteSpace(txtPerf31.Text)) ||
            (string.IsNullOrWhiteSpace(txtName31.Text) && string.IsNullOrWhiteSpace(ddlSchool31.Text) && !string.IsNullOrWhiteSpace(txtPerf31.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #31');", true);
            return false;
        }
        if ((!string.IsNullOrWhiteSpace(txtName32.Text) && string.IsNullOrWhiteSpace(ddlSchool32.Text) && string.IsNullOrWhiteSpace(txtPerf32.Text)) ||
            (string.IsNullOrWhiteSpace(txtName32.Text) && !string.IsNullOrWhiteSpace(ddlSchool32.Text) && string.IsNullOrWhiteSpace(txtPerf32.Text)) ||
            (string.IsNullOrWhiteSpace(txtName32.Text) && string.IsNullOrWhiteSpace(ddlSchool32.Text) && !string.IsNullOrWhiteSpace(txtPerf32.Text)))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Incomplete data for Athlete #32');", true);
            return false;
        }

        //Check for invalid performances
        if (!txtPerf1.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf1.Text.IndexOf(':') != txtPerf1.Text.LastIndexOf(':') || txtPerf1.Text.IndexOf('.') != txtPerf1.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #1 is invalid');", true);
            return false;
        }
        if (!txtPerf2.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf2.Text.IndexOf(':') != txtPerf2.Text.LastIndexOf(':') || txtPerf2.Text.IndexOf('.') != txtPerf2.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #2 is invalid');", true);
            return false;
        }
        if (!txtPerf3.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf3.Text.IndexOf(':') != txtPerf3.Text.LastIndexOf(':') || txtPerf3.Text.IndexOf('.') != txtPerf3.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #3 is invalid');", true);
            return false;
        }
        if (!txtPerf4.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf4.Text.IndexOf(':') != txtPerf4.Text.LastIndexOf(':') || txtPerf4.Text.IndexOf('.') != txtPerf4.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #4 is invalid');", true);
            return false;
        }
        if (!txtPerf5.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf5.Text.IndexOf(':') != txtPerf5.Text.LastIndexOf(':') || txtPerf5.Text.IndexOf('.') != txtPerf5.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #5 is invalid');", true);
            return false;
        }
        if (!txtPerf6.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf6.Text.IndexOf(':') != txtPerf6.Text.LastIndexOf(':') || txtPerf6.Text.IndexOf('.') != txtPerf6.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #6 is invalid');", true);
            return false;
        }
        if (!txtPerf7.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf7.Text.IndexOf(':') != txtPerf7.Text.LastIndexOf(':') || txtPerf7.Text.IndexOf('.') != txtPerf7.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #7 is invalid');", true);
            return false;
        }
        if (!txtPerf8.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf8.Text.IndexOf(':') != txtPerf8.Text.LastIndexOf(':') || txtPerf8.Text.IndexOf('.') != txtPerf8.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #8 is invalid');", true);
            return false;
        }
        if (!txtPerf9.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf9.Text.IndexOf(':') != txtPerf9.Text.LastIndexOf(':') || txtPerf9.Text.IndexOf('.') != txtPerf9.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #9 is invalid');", true);
            return false;
        }
        if (!txtPerf10.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf10.Text.IndexOf(':') != txtPerf10.Text.LastIndexOf(':') || txtPerf10.Text.IndexOf('.') != txtPerf10.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #10 is invalid');", true);
            return false;
        }
        if (!txtPerf11.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf11.Text.IndexOf(':') != txtPerf11.Text.LastIndexOf(':') || txtPerf11.Text.IndexOf('.') != txtPerf11.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #11 is invalid');", true);
            return false;
        }
        if (!txtPerf12.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf12.Text.IndexOf(':') != txtPerf12.Text.LastIndexOf(':') || txtPerf12.Text.IndexOf('.') != txtPerf12.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #12 is invalid');", true);
            return false;
        }
        if (!txtPerf13.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf13.Text.IndexOf(':') != txtPerf13.Text.LastIndexOf(':') || txtPerf13.Text.IndexOf('.') != txtPerf13.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #13 is invalid');", true);
            return false;
        }
        if (!txtPerf14.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf14.Text.IndexOf(':') != txtPerf14.Text.LastIndexOf(':') || txtPerf14.Text.IndexOf('.') != txtPerf14.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #14 is invalid');", true);
            return false;
        }
        if (!txtPerf15.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf15.Text.IndexOf(':') != txtPerf15.Text.LastIndexOf(':') || txtPerf15.Text.IndexOf('.') != txtPerf15.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #15 is invalid');", true);
            return false;
        }
        if (!txtPerf16.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf16.Text.IndexOf(':') != txtPerf16.Text.LastIndexOf(':') || txtPerf16.Text.IndexOf('.') != txtPerf16.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #16 is invalid');", true);
            return false;
        }
        if (!txtPerf17.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf17.Text.IndexOf(':') != txtPerf17.Text.LastIndexOf(':') || txtPerf17.Text.IndexOf('.') != txtPerf17.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #17 is invalid');", true);
            return false;
        }
        if (!txtPerf18.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf18.Text.IndexOf(':') != txtPerf18.Text.LastIndexOf(':') || txtPerf18.Text.IndexOf('.') != txtPerf18.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #18 is invalid');", true);
            return false;
        }
        if (!txtPerf19.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf19.Text.IndexOf(':') != txtPerf19.Text.LastIndexOf(':') || txtPerf19.Text.IndexOf('.') != txtPerf19.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #19 is invalid');", true);
            return false;
        }
        if (!txtPerf20.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf20.Text.IndexOf(':') != txtPerf20.Text.LastIndexOf(':') || txtPerf20.Text.IndexOf('.') != txtPerf20.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #20 is invalid');", true);
            return false;
        }
        if (!txtPerf21.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf21.Text.IndexOf(':') != txtPerf21.Text.LastIndexOf(':') || txtPerf21.Text.IndexOf('.') != txtPerf21.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #21 is invalid');", true);
            return false;
        }
        if (!txtPerf22.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf22.Text.IndexOf(':') != txtPerf22.Text.LastIndexOf(':') || txtPerf22.Text.IndexOf('.') != txtPerf22.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #22 is invalid');", true);
            return false;
        }
        if (!txtPerf23.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf23.Text.IndexOf(':') != txtPerf23.Text.LastIndexOf(':') || txtPerf23.Text.IndexOf('.') != txtPerf23.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #23 is invalid');", true);
            return false;
        }
        if (!txtPerf24.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf24.Text.IndexOf(':') != txtPerf24.Text.LastIndexOf(':') || txtPerf24.Text.IndexOf('.') != txtPerf24.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #24 is invalid');", true);
            return false;
        }
        if (!txtPerf25.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf25.Text.IndexOf(':') != txtPerf25.Text.LastIndexOf(':') || txtPerf25.Text.IndexOf('.') != txtPerf25.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #25 is invalid');", true);
            return false;
        }
        if (!txtPerf26.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf26.Text.IndexOf(':') != txtPerf26.Text.LastIndexOf(':') || txtPerf26.Text.IndexOf('.') != txtPerf26.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #26 is invalid');", true);
            return false;
        }
        if (!txtPerf27.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf27.Text.IndexOf(':') != txtPerf27.Text.LastIndexOf(':') || txtPerf27.Text.IndexOf('.') != txtPerf27.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #27 is invalid');", true);
            return false;
        }
        if (!txtPerf28.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf28.Text.IndexOf(':') != txtPerf28.Text.LastIndexOf(':') || txtPerf28.Text.IndexOf('.') != txtPerf28.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #28 is invalid');", true);
            return false;
        }
        if (!txtPerf29.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf29.Text.IndexOf(':') != txtPerf29.Text.LastIndexOf(':') || txtPerf29.Text.IndexOf('.') != txtPerf29.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #29 is invalid');", true);
            return false;
        }
        if (!txtPerf30.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf30.Text.IndexOf(':') != txtPerf30.Text.LastIndexOf(':') || txtPerf30.Text.IndexOf('.') != txtPerf30.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #30 is invalid');", true);
            return false;
        }
        if (!txtPerf31.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf31.Text.IndexOf(':') != txtPerf31.Text.LastIndexOf(':') || txtPerf31.Text.IndexOf('.') != txtPerf31.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #31 is invalid');", true);
            return false;
        }
        if (!txtPerf32.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf32.Text.IndexOf(':') != txtPerf32.Text.LastIndexOf(':') || txtPerf32.Text.IndexOf('.') != txtPerf32.Text.LastIndexOf('.'))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Invalid Data", "alert('Performance entered for Athlete #32 is invalid');", true);
            return false;
        }

        //If all the above errors were ot found, return true
        Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        return true;
    }

    /// <summary>
    /// Puts all the Performances (Session["AllPerfs"]) into an Ordered Dictionary (Session["Perfs"])
    /// The key of this Dictionary is the heat Number. Value is a List of Performances for that heat
    /// This allows us to enter and gather performances from this form alot easier, quicker, and cleaner.
    /// </summary>
    private void PutPerfsIntoOrderedDictionary()
    {
        Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        //Clear perfs
        ((Dictionary<int, List<Performance>>)Session["Perfs"]).Clear();

        //Check that Session["AllPerfs"] is not null
        if (Session["AllPerfs"] != null)
        {
            //Get the highest heat number
            int highestHeat = 1;
            foreach (Performance p in (List<Performance>)Session["AllPerfs"])
            {
                if (p.heatNum > highestHeat)
                    highestHeat = p.heatNum;
            }

            //i is equal to the heat number
            for (int i = 1; i <= highestHeat; i++)
            {
                List<Performance> tempPerfs = new List<Performance>();
                foreach (Performance p in (List<Performance>)Session["AllPerfs"])
                {
                    if (p.heatNum == i)
                        tempPerfs.Add(p);
                }
                if (tempPerfs.Count > 0)
                    ((Dictionary<int, List<Performance>>)Session["Perfs"]).Add(i - 1, tempPerfs);
            }

        }
        Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Converts the Dictionary of Performances and puts it back into a List of Performances
    /// </summary>
    private void TakePerfsFromOrderedDictionary()
    {
        Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        if (Session["AllPerfs"] != null) ((List<Performance>)Session["AllPerfs"]).Clear();
        else Session["AllPerfs"] = new List<Performance>();
        foreach (int key in ((Dictionary<int, List<Performance>>)Session["Perfs"]).Keys)
        {
            //List<Performance> tempPerfs = new List<Performance>();
            //if (Session["Perfs"].Contains(currentHeatNum))
            //    tempPerfs = Session["Perfs"][currentHeatNum] as List<Performance>;
            List<Performance> tempPerfs = new List<Performance>();
            tempPerfs = ((Dictionary<int, List<Performance>>)Session["Perfs"])[key] as List<Performance>;
            foreach (Performance p in tempPerfs)
            {
                ((List<Performance>)Session["AllPerfs"]).Add(p);
            }
        }
        Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    protected void ddlNumRunners_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNumRunners.SelectedValue == "8")
        {
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
        }
        else if(ddlNumRunners.SelectedValue == "16")
        {
            Panel2.Visible = true;
            Panel3.Visible = false;
            Panel4.Visible = false;
        }
        else if(ddlNumRunners.SelectedValue == "32")
        {
            Panel2.Visible = true;
            Panel3.Visible = true;
            Panel4.Visible = true;
        }
    }

    protected void cmdEnter_Click(object sender, EventArgs e)
    {
        Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        if (AddHeatToDictionary())
        {
            TakePerfsFromOrderedDictionary();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Success", "Data for " + Session["CurrentEvent"] + " entered", true);

            //Add Event Here
            EventMgr em = new EventMgr();
            Meet myMeet = (Meet)Session["ActiveMeet"];
            myMeet.performances = em.AddPerformanceToEvent(myMeet.performances, Session["CurrentEvent"].ToString(), (List<Performance>)Session["AllPerfs"]);
            Session["ActiveMeet"] = myMeet;

            DatabaseMgr dm = new DatabaseMgr();
            int meetID = dm.FindMeetId(myMeet);
            dm.DeletePerformance(meetID, Session["CurrentEvent"].ToString());
            dm.AddPerformance(myMeet, Session["CurrentEvent"].ToString());

            //Go back to MeetHub Here
            Response.Redirect("MeetHub.aspx");
        }
    }

    protected void cmdPrintout_Click(object sender, EventArgs e)
    {
        if (AddHeatToDictionary())
        {
            PrintoutMgr pm = new PrintoutMgr();
            TakePerfsFromOrderedDictionary();
            SortListOfPerfs();
            pm.CreateIndEventDoc(Session["CurrentEvent"].ToString(), (List<Performance>)Session["AllPerfs"]);
        }
    }

    protected void cmdClear_Click(object sender, EventArgs e)
    {

    }

    protected void cmdPrevious_Click(object sender, EventArgs e)
    {
        if ((int)Session["CurrentHeat"] <= 0)
        {
            //MessageBox.Show("Cannot go to heat below 1", "Invalid heat #");
            Session["CurrentHeat"] = 0; // This should never be needed, but here just incase of an unknown error
        }
        else if (AddHeatToDictionary())
        {
            Session["CurrentHeat"] = (int)Session["CurrentHeat"] - 1;
            //grpHeats1.Text = "Heat #" + (currentHeatNum + 1);
            //grpHeats2.Text = "Heat #" + (currentHeatNum + 1);
            //SetCorrectNumRunners();
            //DisplayCorrectNumOfRunners();
            EnterDataIntoForm();
        }
    }

    protected void cmdNext_Click(object sender, EventArgs e)
    {
        if ((int)Session["CurrentHeat"] >= 10000)
        {
            //MessageBox.Show("Cannot go to heat above 10,000", "Invalid heat #");
            Session["CurrentHeat"] = 10000; // This should never be needed, but here just incase of an unknown error
        }
        else if (AddHeatToDictionary())
        {
            Session["CurrentHeat"] = (int)Session["CurrentHeat"]+1;
            //grpHeats1.Text = "Heat #" + (currentHeatNum + 1);
            //grpHeats2.Text = "Heat #" + (currentHeatNum + 1);
            //SetCorrectNumRunners();
            //DisplayCorrectNumOfRunners();
            EnterDataIntoForm();
        }
    }

    protected void cmdClear_Click1(object sender, EventArgs e)
    {
        panClear.Visible = true;
    }

    protected void cmdClearAll_Click(object sender, EventArgs e)
    {
        panClearAll.Visible = true;
    }

    protected void cmdYesAll_Click(object sender, EventArgs e)
    {
        ClearAll();
        ((Dictionary<int, List<Performance>>)Session["Perfs"]).Clear();
    }

    protected void cmdNoAll_Click(object sender, EventArgs e)
    {
        panClearAll.Visible = false;
    }

    protected void cmdYes_Click(object sender, EventArgs e)
    {
        ClearAll();
    }

    protected void cmdNo_Click(object sender, EventArgs e)
    {
        panClear.Visible = false;
    }
}
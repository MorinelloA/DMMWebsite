using DMMLib;
using DualMeetManager.Service.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace DualMeetManager.Business.Managers
{
    public class MeetMgr : Manager
    {
        public Meet openMeet(string filePath)
        {
            ISavingSvc saveSvc = (ISavingSvc)GetService(typeof(ISavingSvc).Name);
            Meet meetToOpen = saveSvc.openMeet(filePath);
            if (meetToOpen == null)
            {
                //null is probably inaccurate here
                ScriptManager.RegisterClientScriptBlock(null, this.GetType(), "Error", "Meet did NOT open correctly!", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(null, this.GetType(), "Success", "Meet opened correctly!", true);
            }
            return meetToOpen;
        }

        public bool saveMeet(string filePath, Meet meetToSave)
        {
            ISavingSvc saveSvc = (ISavingSvc)GetService(typeof(ISavingSvc).Name);
            bool didSave = saveSvc.saveMeet(filePath, meetToSave);
            if (!didSave)
            {
                ScriptManager.RegisterClientScriptBlock(null, this.GetType(), "Error", "Meet did NOT save!", true);
                return false;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(null, this.GetType(), "Success", "Meet saved correctly at: " + filePath, true);
                return true;
            }
        }
    }
}

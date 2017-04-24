using DMMLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Service.Saving
{
    /// <summary>
    /// Interface for saving objects
    /// </summary>
    public interface ISavingSvc : IService
    {
        /// <summary>
        /// Interface for saving a Meet object
        /// </summary>
        /// <param name="filePath">filename for the Meet</param>
        /// <param name="meetToSave">Meet object to save</param>
        /// <returns>boolean that tells the user whether or not the Meet was succcessfully saved or not</returns>
        bool saveMeet(string filePath, Meet meetToSave);

        /// <summary>
        /// Interface for opening a saved Meet object
        /// </summary>
        /// <param name="fileName">filename for the Meet to be open</param>
        /// <returns>Opened Meet</returns>
        Meet openMeet(string fileName);
    }
}

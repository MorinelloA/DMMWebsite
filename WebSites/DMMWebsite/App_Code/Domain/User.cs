using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DualMeetManager.Domain
{
    /// <summary>
    /// Summary description for User
    /// </summary>
    [Serializable]
    public class User
    {
        private string username;
        private string password;

        public User() { }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
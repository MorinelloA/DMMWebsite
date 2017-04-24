using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Business.Exceptions
{
    public class TeamNotFoundException : Exception
    {
        public TeamNotFoundException(string s) : base(s)
        {
        }
    }
}

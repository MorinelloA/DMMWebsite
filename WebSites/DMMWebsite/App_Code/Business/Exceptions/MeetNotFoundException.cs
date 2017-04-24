using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Business.Exceptions
{
    public class MeetNotFoundException : Exception
    {
        public MeetNotFoundException(string s) : base(s)
        {
        }
    }
}

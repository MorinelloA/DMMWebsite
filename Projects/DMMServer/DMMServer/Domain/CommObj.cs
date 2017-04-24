using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMServer.Domain
{
    [Serializable]
    public class CommObj
    {
        public string command { get; set; }
        public object myObject { get; set; }

        public CommObj() { }

        public CommObj(string command, object myObject)
        {
            this.command = command;
            this.myObject = myObject;
        }
    }
}

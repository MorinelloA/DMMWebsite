using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMLib
{
    [Serializable]
    public class CommObj
    {
        public string command { get; set; }
        public object myObject { get; set; }
        public object myObject2 { get; set; }

        public CommObj() { }

        public CommObj(string command, object myObject)
        {
            this.command = command;
            this.myObject = myObject;
        }

        public CommObj(string command, object myObject, object myObject2)
        {
            this.command = command;
            this.myObject = myObject;
            this.myObject2 = myObject2;
        }
    }
}

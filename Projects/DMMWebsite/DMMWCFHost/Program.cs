using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DMMWCFLib;
using System.ServiceModel;

namespace DMMWCFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Out.WriteLine("Starting Host");
                ServiceHost host = new ServiceHost(typeof(DMMWCFLib.Service1));
                host.Open();
                Console.Out.WriteLine("Service started; enter Return to exit application");
                Console.ReadLine();
                host.Close();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}

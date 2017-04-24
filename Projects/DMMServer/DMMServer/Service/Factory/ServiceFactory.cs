using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMServer.Service.Factory
{
    /// <summary>
    /// Service Factory
    /// It provides an interface to the Use Case Managers for implementation services. 
    /// </summary>
    public class ServiceFactory
    {

        private ServiceFactory() { }

        private static ServiceFactory factory = new ServiceFactory();
        public static ServiceFactory GetInstance() { return factory; }

        public IService GetService(string name)
        {
            Type type;
            Object obj = null;

            try
            {
                type = Type.GetType(GetImplName(name));
                obj = Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                Console.WriteLine(name + " not loaded");
                Console.WriteLine("Exception: " + e);
                //throw new ServiceLoadException(name + "not loaded", e);
            }
            return (IService)obj;
        }

        /// <param name="serviceName">
        /// @return </param>
        /// <exception cref="Exception"> </exception>
        private string GetImplName(string serviceName)
        {
            NameValueCollection settings = ConfigurationManager.AppSettings;
            return settings.Get(serviceName);
        }

    }
}

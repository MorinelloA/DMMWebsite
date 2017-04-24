using DMMServer.Service;
using DMMServer.Service.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMServer.Business.Managers
{
    public abstract class Manager
    {
        private ServiceFactory factory = ServiceFactory.GetInstance();

        protected IService GetService(string name)
        {
            return factory.GetService(name);
        }
    }
}

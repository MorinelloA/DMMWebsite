using DualMeetManager.Service;
using DualMeetManager.Service.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Business.Managers
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

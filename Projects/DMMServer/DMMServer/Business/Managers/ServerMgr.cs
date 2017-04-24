using DMMServer.Service.AccountSvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMServer.Business.Managers
{
    public class ServerMgr : Manager
    {
        /*
        public IdentityUser AuthenticateUser(string username, string password)
        {
            IAuthenticateUser AuthenticateSvc = (IAuthenticateUser)GetService(typeof(IAuthenticateUser).Name);
            IdentityUser iu = AuthenticateSvc.AuthenticateUser(username, password);
            return iu;
        }

        public IdentityResult CreateUser(string username, string password)
        {
            IAuthenticateUser CreateSvc = (IAuthenticateUser)GetService(typeof(IAuthenticateUser).Name);
            IdentityResult iu = CreateSvc.CreateUser(username, password);
            return iu;
        }
        */
        public bool AuthenticateUser(string username, string password)
        {
            IAuthenticateUser AuthenticateSvc = (IAuthenticateUser)GetService(typeof(IAuthenticateUser).Name);
            bool iu = AuthenticateSvc.AuthenticateUser(username, password);
            return iu;
        }

        public bool CreateUser(string username, string password)
        {
            IAuthenticateUser CreateSvc = (IAuthenticateUser)GetService(typeof(IAuthenticateUser).Name);
            bool iu = CreateSvc.CreateUser(username, password);
            return iu;
        }
    }
}

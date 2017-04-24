using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMServer.Service.AccountSvc
{
    public interface IAuthenticateUser : IService
    {
        /*
        IdentityUser AuthenticateUser(string username, string password);
        IdentityResult CreateUser(string username, string password);
        */

        bool AuthenticateUser(string username, string password);
        bool CreateUser(string username, string password);
    }
}

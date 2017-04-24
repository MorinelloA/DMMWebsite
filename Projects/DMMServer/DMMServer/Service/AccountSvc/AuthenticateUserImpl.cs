using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMServer.Service.AccountSvc
{
    public class AuthenticateUserImpl : IAuthenticateUser
    {
        /*
        public IdentityUser AuthenticateUser(string username, string password)
        {
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(userStore);
            //search user
            IdentityUser user = userManager.Find(username, password);

            return user;
        }

        public IdentityResult CreateUser(string username, string password)
        {
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

            //Attempt to register new user
            IdentityUser user = new IdentityUser() { UserName = username };
            IdentityResult result = manager.Create(user, password);

            return result;
        }
        */

        public bool AuthenticateUser(string username, string password)
        {
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(userStore);
            //search user
            IdentityUser user = userManager.Find(username, password);

            //return user;
            if (user != null) //Username and Password is correct
                return true;
            else
                return false;
        }

        public bool CreateUser(string username, string password)
        {
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

            //Attempt to register new user
            IdentityUser user = new IdentityUser() { UserName = username };
            IdentityResult result = manager.Create(user, password);

            bool isCreated = false;
            if(result.Succeeded)
            {
                isCreated = true;
            }

            return isCreated;
        }
    }
}

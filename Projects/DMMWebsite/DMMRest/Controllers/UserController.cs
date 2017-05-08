using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DMMRest.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/Auth
        private bool AuthenticateUser(string username, string password)
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

        private bool CreateUser(string username, string password)
        {
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

            //Attempt to register new user
            IdentityUser user = new IdentityUser() { UserName = username };
            IdentityResult result = manager.Create(user, password);

            bool isCreated = false;
            if (result.Succeeded)
            {
                isCreated = true;
            }

            return isCreated;
        }

        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public bool Get(string request, string username, string password)
        { 
            bool result = false;
            if(request == "Create")
            {
                result = CreateUser(username, password);
            }
            else if(request == "Authenticate")
            {
                result = AuthenticateUser(username, password);
            }
            return result;
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DMMWebAPI.Controllers
{
    public class AuthenticateController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

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
            if (result.Succeeded)
            {
                isCreated = true;
            }

            return isCreated;
        }
    }
}

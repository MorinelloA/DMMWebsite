using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using Microsoft.Owin.Security;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;
using DMMLib;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void cmdRegister_Click(object sender, EventArgs e)
    {
        
        UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
        UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

        //Attempt to register new user
        IdentityUser user = new IdentityUser() { UserName = txtUsername.Text };
        //IdentityResult result = manager.Create(user, txtPassword.Text);

        //Week 6 Server Implementation
        /*
        //Begin Server Code
        TcpClient tcpClient = new TcpClient();
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1313);
        tcpClient.Connect(endPoint);
        NetworkStream stream = tcpClient.GetStream();
        BinaryFormatter bf = new BinaryFormatter();
        bf.AssemblyFormat = FormatterAssemblyStyle.Simple;
        User userToCheck = new User(txtUsername.Text, txtPassword.Text);
        CommObj co = new CommObj("CreateUser", (object)userToCheck);
        bf.Serialize(stream, co);
        bool result = (bool)bf.Deserialize(stream);
        */

        //Week 7 WCF Implementation
        ServiceReference3.Service1Client proxy = new ServiceReference3.Service1Client();
        bool result = proxy.CreateUser(txtUsername.Text, txtPassword.Text);

        //If success
        if (result)
        {
            litStatus.Text = "User " + user.UserName + " has been successfully registered!";

            //login new user
            //var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            //var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            //authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);

            //Go to login page
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            litStatus.Text = "There was a problem registering this account";
        }
    }

    protected void lbtnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}
using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;
using DMMLib;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (User.Identity.IsAuthenticated) //If authenticated
            if (Session["Username"] == null || Session["Username"].ToString() == "") // NOT authenticated
            {
                //Show login form
                phLoginForm.Visible = true;
                phLoginStatus.Visible = false;
                phLogout.Visible = false;
                cmdSignOut.Visible = false;
            }
            else //Authenticated
            {
                //litStatus.Text = "Logged in as: " + User.Identity.GetUserName();
                litStatus.Text = "Logged in as: " + Session["Username"];
                //Session["Username"] = User.Identity.GetUserName();
                phLoginStatus.Visible = true;
                phLogout.Visible = true;
                cmdSignOut.Visible = true;
            }
        }
    }

    protected void cmdSignIn_Click(object sender, EventArgs e)
    {
        UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
        UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(userStore);
        //search user
        //IdentityUser user = userManager.Find(txtUsername.Text, txtPassword.Text);

        //Begin Server Code
        TcpClient tcpClient = new TcpClient();
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1313);
        tcpClient.Connect(endPoint);
        NetworkStream stream = tcpClient.GetStream();
        BinaryFormatter bf = new BinaryFormatter();
        bf.AssemblyFormat = FormatterAssemblyStyle.Simple;
        User userToCheck = new User(txtUsername.Text, txtPassword.Text);
        CommObj co = new CommObj("AuthenticateUser", (object)userToCheck);
        bf.Serialize(stream, co);
        bool result = (bool)bf.Deserialize(stream);

        //If the user exists
        //if (user != null)
        if (result)
        {
            //IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            //ClaimsIdentity userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            
            //Sign in
            //authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
            Session["Username"] = txtUsername.Text;
            Response.Redirect("~/Login.aspx");
        }
        else //if the user does not exist
        {
            litStatus.Text = "Invalid login or password";
            Session["Username"] = "";
            phLoginStatus.Visible = true;
        }
    }

    protected void cmdSignOut_Click(object sender, EventArgs e)
    {
        Session["Username"] = "";
        //var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        //authenticationManager.SignOut();
        Response.Redirect("~/Login.aspx");
    }

    protected void lbtnCreate_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateMeet.aspx");
    }

    protected void lbtnOpen_Click(object sender, EventArgs e)
    {
        Response.Redirect("OpenMeet.aspx");
    }

    protected void lbtnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }
}
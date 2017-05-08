using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var assemblyName = typeof(Test).AssemblyQualifiedName;
        var namespaceOfClass = typeof(Test).Namespace;

        Label1.Text = assemblyName;
        Label2.Text = namespaceOfClass;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        // (string request, string username, string password)

        WebClient webClient = new WebClient();
        webClient.QueryString.Add("request", "Create");
        webClient.QueryString.Add("username", "test20");
        webClient.QueryString.Add("password", "test20");
        //webClient.
        string result = webClient.DownloadString("http://localhost:53686/api/User/");
        Console.WriteLine(result);
    }
}
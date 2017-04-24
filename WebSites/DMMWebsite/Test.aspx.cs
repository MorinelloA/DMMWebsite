using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Login Page<br />
        <br />
        <asp:PlaceHolder ID="phLoginStatus" runat="server" Visible="False">
            <asp:Literal ID="litStatus" runat="server"></asp:Literal>
        </asp:PlaceHolder>
        <br />
        <asp:PlaceHolder ID="phLoginForm" runat="server" Visible="False">
            <br />
            <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" AssociatedControlID="txtPassword" Text="Password: "></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="cmdSignIn" runat="server" OnClick="cmdSignIn_Click" Text="Sign In"/>
        </asp:PlaceHolder>
        <br />
        <asp:PlaceHolder ID="phLogout" runat="server" Visible="False">
            <br />
            <br />
            <asp:LinkButton ID="lbtnCreate" runat="server" OnClick="lbtnCreate_Click">Create New Meet</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lbtnOpen" runat="server" OnClick="lbtnOpen_Click">Open Existing Meet</asp:LinkButton>
            <br />
            <br />
            <asp:Button ID="cmdSignOut" runat="server" OnClick="cmdSignOut_Click" Text="Sign Out" />
            <br />
        </asp:PlaceHolder>

    
        <br />
        Need an account?
        <asp:LinkButton ID="lbtnRegister" runat="server" OnClick="lbtnRegister_Click">Register Here</asp:LinkButton>

    
    </div>
    </form>
</body>
</html>

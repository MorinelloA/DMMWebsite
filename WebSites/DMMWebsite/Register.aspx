<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Register
    
        New User</div>
        <asp:Literal ID="litStatus" runat="server"></asp:Literal>
        <br />
        <br />
        <asp:Label ID="lblUserName" runat="server" Text="User Name: "></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="cmdRegister" runat="server" OnClick="cmdRegister_Click" Text="Register" Width="150px" />
        <br />
        <br />
        Already have an account?&nbsp; <asp:LinkButton ID="lbtnLogin" runat="server" OnClick="lbtnLogin_Click">Login Here</asp:LinkButton>
    </form>
</body>
</html>

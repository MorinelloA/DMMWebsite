<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OpenMeet.aspx.cs" Inherits="OpenMeet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ListBox ID="lstMeets" runat="server" Width="355px"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="cmdOpen" runat="server" OnClick="cmdOpen_Click" Text="Open Selected Meet" />
    
        <br />
        <br />
        <asp:LinkButton ID="lbtnCreate" runat="server" OnClick="lbtnCreate_Click">Create New Meet</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>

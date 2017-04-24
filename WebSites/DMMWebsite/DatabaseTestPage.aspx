<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DatabaseTestPage.aspx.cs" Inherits="DatabaseTestPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Test Database" />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Reset Primary Keys" />
        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Delete Meet" />
        <br />
        Meets <br />
        <asp:Table ID="tblMeets" runat="server" BorderStyle="Solid" BorderWidth="1px" GridLines="Both" Width="436px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Id</asp:TableCell>
                <asp:TableCell runat="server">Date</asp:TableCell>
                <asp:TableCell runat="server">Location</asp:TableCell>
                <asp:TableCell runat="server">Weather</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <br />
        BoyTeams<br />
        <asp:Table ID="tblBoysTeams" runat="server" BorderStyle="Solid" BorderWidth="1px" GridLines="Both" Width="431px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Id</asp:TableCell>
                <asp:TableCell runat="server">Abbr</asp:TableCell>
                <asp:TableCell runat="server">Name</asp:TableCell>
                <asp:TableCell runat="server">MeetKey</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <br />
        GirlTeams<br />
        <asp:Table ID="tblGirlsTeams" runat="server" BorderStyle="Solid" BorderWidth="1px" GridLines="Both" Width="431px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Id</asp:TableCell>
                <asp:TableCell runat="server">Abbr</asp:TableCell>
                <asp:TableCell runat="server">Name</asp:TableCell>
                <asp:TableCell runat="server">MeetKey</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <br />
        Performances<br />
        <asp:Table ID="tblPerformances" runat="server" BorderStyle="Solid" BorderWidth="1px" GridLines="Both" Width="721px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Id</asp:TableCell>
                <asp:TableCell runat="server">AthleteName</asp:TableCell>
                <asp:TableCell runat="server">SchoolName</asp:TableCell>
                <asp:TableCell runat="server">Gender</asp:TableCell>
                <asp:TableCell runat="server">EventName</asp:TableCell>
                <asp:TableCell runat="server">HeatNum</asp:TableCell>
                <asp:TableCell runat="server">Performance</asp:TableCell>
                <asp:TableCell runat="server">MeetKey</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FieldEventTieBreaker.aspx.cs" Inherits="FieldEventTieBreaker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel='stylesheet' type='text/css' href='DataEntryTies.css'/>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="cmdEnter" class="Button" runat="server" Text="Enter Data" />
            &nbsp;
            <asp:Button ID="cmdPrintout" class="Button" runat="server" Text="Printout" />
            &nbsp;
            <asp:Button ID="cmdClear" class="Button" runat="server" Text="Clear Data" />
            <br /><br />
            <asp:Button ID="cmdPrevious" class="Button" runat="server" Text="Previous Flight" />
            &nbsp;
            <asp:Button ID="cmdNext" class="Button" runat="server" Text="Next Flight" />
            <br />
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" CssClass="Panel">
                <table class="auto-style1">
                    <tr>
                        <td class='name'>Name</td>
                        <td class='school'>School</td>
                        <td class='performance'>Performance</td>
                        <td class='place'>Place</td>
                    </tr>
                    <tr>
                        <td class="name">
                            <asp:Label ID="lblName1" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSchool1" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPerf1" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPlace1" runat="server">
                                <asp:ListItem>- - -</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            <asp:Label ID="lblName2" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSchool2" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPerf2" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPlace2" runat="server">
                                <asp:ListItem>- - -</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            <asp:Label ID="lblName3" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSchool3" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPerf3" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPlace3" runat="server">
                                <asp:ListItem>- - -</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            <asp:Label ID="lblName4" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSchool4" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPerf4" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPlace4" runat="server">
                                <asp:ListItem>- - -</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            <asp:Label ID="lblName5" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSchool5" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPerf5" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPlace5" runat="server">
                                <asp:ListItem>- - -</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            <asp:Label ID="lblName6" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSchool6" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPerf6" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPlace6" runat="server">
                                <asp:ListItem>- - -</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            <asp:Label ID="lblName7" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSchool7" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPerf7" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPlace7" runat="server">
                                <asp:ListItem>- - -</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            <asp:Label ID="lblName8" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSchool8" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPerf8" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPlace8" runat="server">
                                <asp:ListItem>- - -</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            <asp:Label ID="lblName9" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSchool9" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPerf9" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPlace9" runat="server">
                                <asp:ListItem>- - -</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            <asp:Label ID="lblName10" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSchool10" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPerf10" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPlace10" runat="server">
                                <asp:ListItem>- - -</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            <asp:Label ID="lblName11" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSchool11" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPerf11" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPlace11" runat="server">
                                <asp:ListItem>- - -</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            <asp:Label ID="lblName12" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSchool12" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPerf12" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPlace12" runat="server">
                                <asp:ListItem>- - -</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            <asp:Label ID="lblName13" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSchool13" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPerf13" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPlace13" runat="server">
                                <asp:ListItem>- - -</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            <asp:Label ID="lblName14" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSchool14" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPerf14" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPlace14" runat="server">
                                <asp:ListItem>- - -</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            <asp:Label ID="lblName15" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSchool15" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPerf15" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPlace15" runat="server">
                                <asp:ListItem>- - -</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            <asp:Label ID="lblName16" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSchool16" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPerf16" runat="server" BorderStyle="None" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPlace16" runat="server">
                                <asp:ListItem>- - -</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>

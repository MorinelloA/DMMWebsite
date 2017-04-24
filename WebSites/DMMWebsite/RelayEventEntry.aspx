<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RelayEventEntry.aspx.cs" Inherits="RelayEventEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel='stylesheet' type='text/css' href='DataEntry.css'/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button class="Button" ID="cmdEnter" runat="server" Text="Enter Data" OnClick="cmdEnter_Click" />
        &nbsp;
        <asp:Button class="Button" ID="cmdPrintout" runat="server" Text="Printout" OnClick="cmdPrintout_Click" />
        <br />
        <asp:Button Class="Button" ID="cmdClearAll" runat="server" Text="Clear Event" OnClick="cmdClearAll_Click" />
        <br />
        <asp:Panel ID="panClearAll" CSSClass="Panel" runat="server" BorderColor="#CC0000" Visible="False">
            <br />
            Are you sure you want to clear all the data from this entire event?
            <asp:Button Class="Button" ID="cmdYesAll" runat="server" Text="Yes" OnClick="cmdYesAll_Click" />
            &nbsp;
            <asp:Button Class="Button" ID="cmdNoAll" runat="server" Text="No" OnClick="cmdNoAll_Click" />
            <br />
            <br />
        </asp:Panel>
        <br />
        <br />
        Scoring Teams
        &nbsp;  
        <asp:Panel ID="Panel1" CSSClass="Panel" runat="server">
            <table>
                <tr>
                    <td class="name">Name</td>
                    <td class="school">School</td>
                    <td class="performance">Time</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool1" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool2" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName3" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool3" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName4" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool4" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf4" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName5" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool5" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf5" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName6" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool6" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf6" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName7" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool7" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf7" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName8" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool8" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf8" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        Non-Scoring Teams
        <br />

        <asp:Panel ID="Panel3" runat="server" Visible="False">
            <table>
                <tr>
                    <td class="name">
                        <asp:TextBox ID="txtName17" runat="server"></asp:TextBox>
                    </td>
                    <td class="school">
                        <asp:DropDownList ID="ddlSchool17" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="performance">
                        <asp:TextBox ID="txtPerf17" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName18" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool18" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf18" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName19" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool19" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf19" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName20" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool20" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf20" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName21" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool21" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf21" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName22" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool22" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf22" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName23" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool23" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf23" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName24" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool24" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf24" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server" Visible="False">
            <table>
                <tr>
                    <td class="name">
                        <asp:TextBox ID="txtName25" runat="server"></asp:TextBox>
                    </td>
                    <td class="school">
                        <asp:DropDownList ID="ddlSchool25" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="performance">
                        <asp:TextBox ID="txtPerf25" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName26" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool26" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf26" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName27" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool27" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf27" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName28" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool28" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf28" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName29" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool29" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf29" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName30" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool30" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf30" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName31" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool31" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf31" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName32" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool32" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf32" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>

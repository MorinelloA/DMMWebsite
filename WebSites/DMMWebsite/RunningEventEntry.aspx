<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RunningEventEntry.aspx.cs" Inherits="RunningEventEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel='stylesheet' type='text/css' href='DataEntry.css'/>
</head>
<body id="PageBody" runat="server">
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="cmdEnter" class="Button" runat="server" Text="Enter Data" OnClick="cmdEnter_Click" />
&nbsp;
        <asp:Button ID="cmdPrintout" class="Button" runat="server" Text="Printout" OnClick="cmdPrintout_Click" />
&nbsp;
        <br />
        <asp:Button Class="Button" ID="cmdClear" runat="server" Text="Clear Heat" OnClick="cmdClear_Click1" />
        &nbsp;
        <asp:Button Class="Button" ID="cmdClearAll" runat="server" Text="Clear Event" OnClick="cmdClearAll_Click"/>
        <br />
        <asp:Panel ID="panClearAll" CSSClass="Panel" runat="server" BorderColor="#CC0000" Visible="False">
            <br />
            Are you sure you want to clear all the data from this entire event?
            <asp:Button Class="Button" ID="cmdYesAll" runat="server" Text="Yes" OnClick="cmdYesAll_Click"/>
            &nbsp;
            <asp:Button Class="Button" ID="cmdNoAll" runat="server" Text="No" OnClick="cmdNoAll_Click"/>
            <br />
            <br />
        </asp:Panel>
        <asp:Panel ID="panClear" CSSClass="Panel" runat="server" BorderColor="#CC0000" Visible="False">
            <br />
            Are you sure you want to clear all data from this heat?
            <asp:Button Class="Button" ID="cmdYes" runat="server" Text="Yes" OnClick="cmdYes_Click"/>
            &nbsp;
            <asp:Button Class="Button" ID="cmdNo" runat="server" Text="No" OnClick="cmdNo_Click"/>
            <br />
            <br />
        </asp:Panel>
        <br />
        <asp:Button ID="cmdPrevious" class="Button" runat="server" Text="Previous Heat" OnClick="cmdPrevious_Click" />
&nbsp;
        <asp:Button ID="cmdNext" class="Button" runat="server" Text="Next Heat" OnClick="cmdNext_Click" />
        <br />
        <br />
        Number of Runners: <asp:DropDownList ID="ddlNumRunners" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNumRunners_SelectedIndexChanged">
            <asp:ListItem Selected="True">8</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>32</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Panel ID="Panel1" CSSClass="Panel" runat="server">
            <table>
                <tr>
                    <td class="place">Place</td>
                    <td class="name">Name</td>
                    <td class="school">School</td>
                    <td class="performance">Time</td>
                </tr>
                <tr>
                    <td>1</td>
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
                    <td>2</td>
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
                    <td>3</td>
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
                    <td>4</td>
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
                    <td>5</td>
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
                    <td>6</td>
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
                    <td>7</td>
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
                    <td>8</td>
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
        <asp:Panel ID="Panel2" runat="server" Visible="False">
            <table>
                <tr>
                    <td class="place">9</td>
                    <td class="name">
                        <asp:TextBox ID="txtName9" runat="server"></asp:TextBox>
                    </td>
                    <td class="school">
                        <asp:DropDownList ID="ddlSchool9" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="performance">
                        <asp:TextBox ID="txtPerf9" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>10</td>
                    <td>
                        <asp:TextBox ID="txtName10" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool10" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf10" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>11</td>
                    <td>
                        <asp:TextBox ID="txtName11" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool11" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf11" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>12</td>
                    <td>
                        <asp:TextBox ID="txtName12" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool12" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf12" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>13</td>
                    <td>
                        <asp:TextBox ID="txtName13" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool13" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf13" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>14</td>
                    <td>
                        <asp:TextBox ID="txtName14" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool14" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf14" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>15</td>
                    <td>
                        <asp:TextBox ID="txtName15" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool15" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf15" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>16</td>
                    <td>
                        <asp:TextBox ID="txtName16" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool16" runat="server">
                            <asp:ListItem>- - -</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerf16" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Visible="False">
            <table>
                <tr>
                    <td class="place">17</td>
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
                    <td>18</td>
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
                    <td>19</td>
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
                    <td>20</td>
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
                    <td>21</td>
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
                    <td>22</td>
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
                    <td>23</td>
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
                    <td>24</td>
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
                    <td class="place">25</td>
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
                    <td>26</td>
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
                    <td>27</td>
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
                    <td>28</td>
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
                    <td>29</td>
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
                    <td>30</td>
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
                    <td>31</td>
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
                    <td>32</td>
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

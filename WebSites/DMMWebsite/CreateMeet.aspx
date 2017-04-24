<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateMeet.aspx.cs" Inherits="CreateMeet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Dual Meet Manager</title>
    <link rel='stylesheet' type='text/css' href='layout.css'/>
    <script src='https://code.jquery.com/jquery-3.1.0.min.js'></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:LinkButton ID="lbtnOpen" runat="server" OnClick="lbtnOpen_Click">Open Existing Meet</asp:LinkButton>
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Location: "></asp:Label>
        <asp:TextBox ID="txtLocation" runat="server" TabIndex="1"></asp:TextBox>
        <br />
        <p>
            <asp:Label ID="Label2" runat="server" Text="Date:"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="ddlMonth" runat="server" TabIndex="2">
                <asp:ListItem>January</asp:ListItem>
                <asp:ListItem>February</asp:ListItem>
                <asp:ListItem>March</asp:ListItem>
                <asp:ListItem>April</asp:ListItem>
                <asp:ListItem>May</asp:ListItem>
                <asp:ListItem>June</asp:ListItem>
                <asp:ListItem>July</asp:ListItem>
                <asp:ListItem>August</asp:ListItem>
                <asp:ListItem>September</asp:ListItem>
                <asp:ListItem>October</asp:ListItem>
                <asp:ListItem>November</asp:ListItem>
                <asp:ListItem>December</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlDay" runat="server" TabIndex="3">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
                <asp:ListItem>24</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>26</asp:ListItem>
                <asp:ListItem>27</asp:ListItem>
                <asp:ListItem>28</asp:ListItem>
                <asp:ListItem>29</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>31</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlYear" runat="server" TabIndex="4">
                <asp:ListItem>2015</asp:ListItem>
                <asp:ListItem>2016</asp:ListItem>
                <asp:ListItem>2017</asp:ListItem>
                <asp:ListItem>2018</asp:ListItem>
                <asp:ListItem>2019</asp:ListItem>
                <asp:ListItem>2020</asp:ListItem>
                <asp:ListItem>2021</asp:ListItem>
                <asp:ListItem>2022</asp:ListItem>
                <asp:ListItem>2023</asp:ListItem>
                <asp:ListItem>2024</asp:ListItem>
                <asp:ListItem>2025</asp:ListItem>
                <asp:ListItem>2026</asp:ListItem>
                <asp:ListItem>2027</asp:ListItem>
                <asp:ListItem>2028</asp:ListItem>
                <asp:ListItem>2029</asp:ListItem>
                <asp:ListItem>2030</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Weather: "></asp:Label>
            <asp:TextBox ID="txtWeather" runat="server" TabIndex="5"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label28" runat="server" Text="Number of Boy's Teams: "></asp:Label>
            <asp:DropDownList ID="ddlBoys" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBoys_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="0">-</asp:ListItem>
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
                <asp:ListItem Value="4">4</asp:ListItem>
                <asp:ListItem Value="5">5</asp:ListItem>
                <asp:ListItem Value="6">6</asp:ListItem>
            </asp:DropDownList>
        </p>
        <asp:Panel ID="panBoys1" runat="server" Visible="False">
            <asp:Label ID="Label4" runat="server" Text="Boy's Team #1 Name: "></asp:Label>
            <asp:TextBox ID="txtBoysTeam1" runat="server" TabIndex="6"></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label5" runat="server" Text="Boy's Team #1 Abbr: "></asp:Label>
            <asp:TextBox ID="txtBoysAbbr1" runat="server" MaxLength="3" TabIndex="7"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="panBoys2" runat="server" Visible="False">
            <asp:Label ID="Label6" runat="server" Text="Boy's Team #2 Name: "></asp:Label>
            <asp:TextBox ID="txtBoysTeam2" runat="server" TabIndex="8"></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label7" runat="server" Text="Boy's Team #2 Abbr: "></asp:Label>
            <asp:TextBox ID="txtBoysAbbr2" runat="server" MaxLength="3" TabIndex="9"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="panBoys3" runat="server" Visible="False">
            <asp:Label ID="Label8" runat="server" Text="Boy's Team #3 Name: "></asp:Label>
            <asp:TextBox ID="txtBoysTeam3" runat="server" TabIndex="10"></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label9" runat="server" Text="Boy's Team #3 Abbr: "></asp:Label>
            <asp:TextBox ID="txtBoysAbbr3" runat="server" MaxLength="3" TabIndex="11"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="panBoys4" runat="server" Visible="False">
            <asp:Label ID="Label10" runat="server" Text="Boy's Team #4 Name: "></asp:Label>
            <asp:TextBox ID="txtBoysTeam4" runat="server" TabIndex="12"></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label11" runat="server" Text="Boy's Team #4 Abbr: "></asp:Label>
            <asp:TextBox ID="txtBoysAbbr4" runat="server" MaxLength="3" TabIndex="13"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="panBoys5" runat="server" Visible="False">
            <asp:Label ID="Label12" runat="server" Text="Boy's Team #5 Name: "></asp:Label>
            <asp:TextBox ID="txtBoysTeam5" runat="server" TabIndex="14" ></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label13" runat="server" Text="Boy's Team #5 Abbr: "></asp:Label>
            <asp:TextBox ID="txtBoysAbbr5" runat="server" MaxLength="3" TabIndex="15"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="panBoys6" runat="server" Visible="False">
            <asp:Label ID="Label14" runat="server" Text="Boy's Team #6 Name: "></asp:Label>
            <asp:TextBox ID="txtBoysTeam6" runat="server" TabIndex="16"></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label15" runat="server" Text="Boy's Team #6 Abbr: "></asp:Label>
            <asp:TextBox ID="txtBoysAbbr6" runat="server" MaxLength="3" TabIndex="17"></asp:TextBox>
        </asp:Panel>
        
        <p>
            <asp:Label ID="Label29" runat="server" Text="Number of Girl's Teams: "></asp:Label>
            <asp:DropDownList ID="ddlGirls" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGirls_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="0">-</asp:ListItem>
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
                <asp:ListItem Value="4">4</asp:ListItem>
                <asp:ListItem Value="5">5</asp:ListItem>
                <asp:ListItem Value="6">6</asp:ListItem>
            </asp:DropDownList>
        </p>
        <asp:Panel ID="panGirls1" runat="server" Visible="False">
            <asp:Label ID="Label16" runat="server" Text="Girl's Team #1 Name: "></asp:Label>
            <asp:TextBox ID="txtGirlsTeam1" runat="server" TabIndex="18"></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label17" runat="server" Text="Girl's Team #1 Abbr: "></asp:Label>
            <asp:TextBox ID="txtGirlsAbbr1" runat="server" MaxLength="3" TabIndex="19"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="panGirls2" runat="server" Visible="False">
            <asp:Label ID="Label18" runat="server" Text="Girl's Team #2 Name: "></asp:Label>
            <asp:TextBox ID="txtGirlsTeam2" runat="server" TabIndex="20"></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label19" runat="server" Text="Girl's Team #2 Abbr: "></asp:Label>
            <asp:TextBox ID="txtGirlsAbbr2" runat="server" MaxLength="3" TabIndex="21"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="panGirls3" runat="server" Visible="False">
            <asp:Label ID="Label20" runat="server" Text="Girl's Team #3 Name: "></asp:Label>
            <asp:TextBox ID="txtGirlsTeam3" runat="server" TabIndex="22" ></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label21" runat="server" Text="Girl's Team #3 Abbr: "></asp:Label>
            <asp:TextBox ID="txtGirlsAbbr3" runat="server" MaxLength="3" TabIndex="23"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="panGirls4" runat="server" Visible="False">
            <asp:Label ID="Label22" runat="server" Text="Girl's Team #4 Name: "></asp:Label>
            <asp:TextBox ID="txtGirlsTeam4" runat="server" TabIndex="24"></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label23" runat="server" Text="Girl's Team #4 Abbr: "></asp:Label>
            <asp:TextBox ID="txtGirlsAbbr4" runat="server" MaxLength="3" TabIndex="25"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="panGirls5" runat="server" Visible="False">
            <asp:Label ID="Label24" runat="server" Text="Girl's Team #5 Name: "></asp:Label>
            <asp:TextBox ID="txtGirlsTeam5" runat="server" TabIndex="26"></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label25" runat="server" Text="Girl's Team #5 Abbr: "></asp:Label>
            <asp:TextBox ID="txtGirlsAbbr5" runat="server" MaxLength="3" TabIndex="27"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="panGirls6" runat="server" Visible="False">
            <asp:Label ID="Label26" runat="server" Text="Girl's Team #6 Name: "></asp:Label>
            <asp:TextBox ID="txtGirlsTeam6" runat="server" TabIndex="28"></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label27" runat="server" Text="Girl's Team #6 Abbr: "></asp:Label>
            <asp:TextBox ID="txtGirlsAbbr6" runat="server" MaxLength="3" TabIndex="29"></asp:TextBox>
        </asp:Panel>

        <asp:Panel ID="panAlert" runat="server" Visible="False">
            <br />
            <asp:label ID="lblAlert" runat="server" text="lblAlert"></asp:label>
        </asp:Panel>

        <asp:Panel ID="panDatabaseAlert" runat="server" Visible="False">
            <br />
            <asp:label ID="lblDatabaseAlert" runat="server" text="Meet already exists, do you wish to overwrite existing meet, or open existing meet?"></asp:label>
            <br />
            <br />
            <asp:Button ID="cmdOverwrite" runat="server" OnClick="cmdOverwrite_Click" Text="Overwrite Existing Meet" />
            <br />
            <br />
            <asp:Button ID="cmdOpen" runat="server" OnClick="cmdOpen_Click" Text="Open Existing Meet" />
        </asp:Panel>
        <br />

        <asp:Button ID="cmdCreate" runat="server" Text="Create Meet" Width="110px" OnClick="cmdCreate_Click" />
    </form>
</body>
</html>

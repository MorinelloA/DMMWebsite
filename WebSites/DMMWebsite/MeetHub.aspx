<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="MeetHub.aspx.cs" Inherits="MeetHub" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <link rel="stylesheet" href="https://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.css"/>
                <link rel='stylesheet' type='text/css' href='MeetHub.css'/>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <div id="header">
                <h1 style="text-align: center"><asp:Label ID="lblMeetTitle" runat="server" Text="Meet Title"></asp:Label>
                    </h1>
                </div>
                        <table>
                    <tr>
                        <td id="menuTD">
                            <div data-role="main" class="ui-content">
                                <div data-role="collapsible">
                                    <h1><asp:LinkButton ID="lbtnMain" runat="server" Text="Main" OnClick="lbtnMain_Click"></asp:LinkButton></h1>
                                    <asp:Panel ID="panMain" runat="server" Visible="false">
                                        <p><asp:LinkButton ID="lbtnAccount" runat="server" Text="Change Account" OnClick="lbtnAccount_Click"></asp:LinkButton></p>
                                        <p><asp:LinkButton ID="lbtnNewMeet" runat="server" Text="New Meet" OnClick="lbtnNewMeet_Click"></asp:LinkButton></p>
                                        <p><asp:LinkButton ID="lbtnOpenMeet" runat="server" Text="Open Meet" OnClick="lbtnOpenMeet_Click"></asp:LinkButton></p>
                                        <p><asp:LinkButton ID="lbtnSaveMeet" runat="server" Text="Save Meet"></asp:LinkButton></p>
                                    </asp:Panel>
                                </div>
                                <div data-role="collapsible">
                                    <h1><asp:LinkButton ID="lbtnEnterData" runat="server" Text="Enter Data" OnClick="lbtnEnterData_Click"></asp:LinkButton></h1>
                                    <div data-role="collapsible">
                                        <h2><asp:LinkButton ID="lbtnBoysEvents" runat="server" Text="Boy's" OnClick="lbtnBoysEvents_Click" Visible="False"></asp:LinkButton></h2>
                                        <asp:Panel ID="panEnterBoysEvents" runat="server" Visible="false">
                                            <p><asp:LinkButton ID="lbtnBoys100" runat="server" Text="100 Meters" OnClick="lbtnBoys100_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoys200" runat="server" Text="200 Meters" OnClick="lbtnBoys200_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoys400" runat="server" Text="400 Meters" OnClick="lbtnBoys400_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoys800" runat="server" Text="800 Meters" OnClick="lbtnBoys800_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoys1600" runat="server" Text="1600 Meters" OnClick="lbtnBoys1600_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoys3200" runat="server" Text="3200 Meters" OnClick="lbtnBoys3200_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysHH" runat="server" Text="110 Hurdles" OnClick="lbtnBoysHH_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoys300H" runat="server" Text="300 Hurdles" OnClick="lbtnBoys300H_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoys4x1" runat="server" Text="4x100 Relay" OnClick="lbtnBoys4x1_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoys4x4" runat="server" Text="4x400 Relay" OnClick="lbtnBoys4x4_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoys4x8" runat="server" Text="4x800 Relay" OnClick="lbtnBoys4x8_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysLJ" runat="server" Text="Long Jump" OnClick="lbtnBoysLJ_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysTJ" runat="server" Text="Triple Jump" OnClick="lbtnBoysTJ_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysHJ" runat="server" Text="High Jump" OnClick="lbtnBoysHJ_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysPV" runat="server" Text="Pole Vault" OnClick="lbtnBoysPV_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysShotput" runat="server" Text="Shotput" OnClick="lbtnBoysShotput_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysDiscus" runat="server" Text="Discus" OnClick="lbtnBoysDiscus_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysJavelin" runat="server" Text="Javelin" OnClick="lbtnBoysJavelin_Click"></asp:LinkButton></p>
                                        </asp:Panel>
                                    </div>
                                    <div data-role="collapsible">
                                        <h2><asp:LinkButton ID="lbtnGirlsEvents" runat="server" Text="Girl's" OnClick="lbtnGirlsEvents_Click" Visible="False"></asp:LinkButton></h2>
                                        <asp:Panel ID="panEnterGirlsEvents" runat="server" Visible="false">
                                            <p><asp:LinkButton ID="lbtnGirls100" runat="server" Text="100 Meters" OnClick="lbtnGirls100_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirls200" runat="server" Text="200 Meters" OnClick="lbtnGirls200_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirls400" runat="server" Text="400 Meters" OnClick="lbtnGirls400_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirls800" runat="server" Text="800 Meters" OnClick="lbtnGirls800_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirls1600" runat="server" Text="1600 Meters" OnClick="lbtnGirls1600_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirls3200" runat="server" Text="3200 Meters" OnClick="lbtnGirls3200_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsHH" runat="server" Text="100 Hurdles" OnClick="lbtnGirlsHH_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirls300H" runat="server" Text="300 Hurdles" OnClick="lbtnGirls300H_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirls4x1" runat="server" Text="4x100 Relay" OnClick="lbtnGirls4x1_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirls4x4" runat="server" Text="4x400 Relay" OnClick="lbtnGirls4x4_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirls4x8" runat="server" Text="4x800 Relay" OnClick="lbtnGirls4x8_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsLJ" runat="server" Text="Long Jump" OnClick="lbtnGirlsLJ_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsTJ" runat="server" Text="Triple Jump" OnClick="lbtnGirlsTJ_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsHJ" runat="server" Text="High Jump" OnClick="lbtnGirlsHJ_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsPV" runat="server" Text="Pole Vault" OnClick="lbtnGirlsPV_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsShotput" runat="server" Text="Shotput" OnClick="lbtnGirlsShotput_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsDiscus" runat="server" Text="Discus" OnClick="lbtnGirlsDiscus_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsJavelin" runat="server" Text="Javelin" OnClick="lbtnGirlsJavelin_Click"></asp:LinkButton></p>
                                        </asp:Panel>
                                    </div>
                                </div>
                                <div data-role="collapsible">
                                    <h1><asp:LinkButton ID="lbtnPrintouts" runat="server" Text="Printouts" OnClick="lbtnPrintouts_Click"></asp:LinkButton></h1>
                                    <div data-role="collapsible">
                                        <h2><asp:LinkButton ID="lbtnBoysTeamScorePrintouts" runat="server" Text="Boy's Team Scores" Visible="false" OnClick="lbtnBoysTeamScorePrintouts_Click"></asp:LinkButton></h2>
                                        <asp:Panel ID="panBoysTeamScorePrintouts" runat="server" Visible="false">
                                            <p><asp:LinkButton ID="boysTeamScoresAll" runat="server" Text="All" Visible="false"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblBoysScores1vs2Printout" runat="server" Text="Team1 vs. Team 2" Visible="false" OnClick="lblBoysScores1vs2Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblBoysScores1vs3Printout" runat="server" Text="Team1 vs. Team 3" Visible="false" OnClick="lblBoysScores1vs3Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblBoysScores2vs3Printout" runat="server" Text="Team2 vs. Team 3" Visible="false" OnClick="lblBoysScores2vs3Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblBoysScores1vs4Printout" runat="server" Text="Team1 vs. Team 4" Visible="false" OnClick="lblBoysScores1vs4Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblBoysScores2vs4Printout" runat="server" Text="Team2 vs. Team 4" Visible="false" OnClick="lblBoysScores2vs4Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblBoysScores3vs4Printout" runat="server" Text="Team3 vs. Team 4" Visible="false" OnClick="lblBoysScores3vs4Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblBoysScores1vs5Printout" runat="server" Text="Team1 vs. Team 5" Visible="false" OnClick="lblBoysScores1vs5Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblBoysScores2vs5Printout" runat="server" Text="Team2 vs. Team 5" Visible="false" OnClick="lblBoysScores2vs5Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblBoysScores3vs5Printout" runat="server" Text="Team3 vs. Team 5" Visible="false" OnClick="lblBoysScores3vs5Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblBoysScores4vs5Printout" runat="server" Text="Team4 vs. Team 5" Visible="false" OnClick="lblBoysScores4vs5Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblBoysScores1vs6Printout" runat="server" Text="Team1 vs. Team 6" Visible="false" OnClick="lblBoysScores1vs6Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblBoysScores2vs6Printout" runat="server" Text="Team2 vs. Team 6" Visible="false" OnClick="lblBoysScores2vs6Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblBoysScores3vs6Printout" runat="server" Text="Team3 vs. Team 6" Visible="false" OnClick="lblBoysScores3vs6Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblBoysScores4vs6Printout" runat="server" Text="Team4 vs. Team 6" Visible="false" OnClick="lblBoysScores4vs6Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblBoysScores5vs6Printout" runat="server" Text="Team5 vs. Team 6" Visible="false" OnClick="lblBoysScores5vs6Printout_Click"></asp:LinkButton></p>
                                        </asp:Panel>
                                    </div>
                                    <div data-role="collapsible">
                                        <h2><asp:LinkButton ID="lbtnGirlsTeamScorePrintouts" runat="server" Text="Girl's Team Scores" Visible="false" OnClick="lbtnGirlsTeamScorePrintouts_Click"></asp:LinkButton></h2>
                                        <asp:Panel ID="panGirlsTeamScorePrintouts" runat="server" Visible="false">
                                            <p><asp:LinkButton ID="girlsTeamScoresAll" runat="server" Text="All" Visible="false"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblGirlsScores1vs2Printout" runat="server" Text="Team1 vs. Team 2" Visible="false" OnClick="lblGirlsScores1vs2Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblGirlsScores1vs3Printout" runat="server" Text="Team1 vs. Team 3" Visible="false" OnClick="lblGirlsScores1vs3Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblGirlsScores2vs3Printout" runat="server" Text="Team2 vs. Team 3" Visible="false" OnClick="lblGirlsScores2vs3Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblGirlsScores1vs4Printout" runat="server" Text="Team1 vs. Team 4" Visible="false" OnClick="lblGirlsScores1vs4Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblGirlsScores2vs4Printout" runat="server" Text="Team2 vs. Team 4" Visible="false" OnClick="lblGirlsScores2vs4Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblGirlsScores3vs4Printout" runat="server" Text="Team3 vs. Team 4" Visible="false" OnClick="lblGirlsScores3vs4Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblGirlsScores1vs5Printout" runat="server" Text="Team1 vs. Team 5" Visible="false" OnClick="lblGirlsScores1vs5Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblGirlsScores2vs5Printout" runat="server" Text="Team2 vs. Team 5" Visible="false" OnClick="lblGirlsScores2vs5Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblGirlsScores3vs5Printout" runat="server" Text="Team3 vs. Team 5" Visible="false" OnClick="lblGirlsScores3vs5Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblGirlsScores4vs5Printout" runat="server" Text="Team4 vs. Team 5" Visible="false" OnClick="lblGirlsScores4vs5Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblGirlsScores1vs6Printout" runat="server" Text="Team1 vs. Team 6" Visible="false" OnClick="lblGirlsScores1vs6Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblGirlsScores2vs6Printout" runat="server" Text="Team2 vs. Team 6" Visible="false" OnClick="lblGirlsScores2vs6Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblGirlsScores3vs6Printout" runat="server" Text="Team3 vs. Team 6" Visible="false" OnClick="lblGirlsScores3vs6Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblGirlsScores4vs6Printout" runat="server" Text="Team4 vs. Team 6" Visible="false" OnClick="lblGirlsScores4vs6Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lblGirlsScores5vs6Printout" runat="server" Text="Team5 vs. Team 6" Visible="false" OnClick="lblGirlsScores5vs6Printout_Click"></asp:LinkButton></p>
                                        </asp:Panel>
                                    </div>
                                    <div data-role="collapsible">
                                        <h2><asp:LinkButton ID="lbtnBoysTeamPerfPrintouts" runat="server" Text="Boy's Team Performances" Visible="false" OnClick="lbtnBoysTeamPerfPrintouts_Click"></asp:LinkButton></h2>
                                        <asp:Panel ID="panBoysTeamPerfPrintouts" runat="server" Visible="false">
                                            <p><asp:LinkButton ID="lbtnBoysPerfsAll" runat="server" Text="All" OnClick="lbtnBoysPerfsAll_Click" Visible="False"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysTeam1Printout" runat="server" Text="Team 1" OnClick="lbtnBoysTeam1Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysTeam2Printout" runat="server" Text="Team 2" Visible="false" OnClick="lbtnBoysTeam2Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysTeam3Printout" runat="server" Text="Team 3" Visible="false" OnClick="lbtnBoysTeam3Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysTeam4Printout" runat="server" Text="Team 4" Visible="false" OnClick="lbtnBoysTeam4Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysTeam5Printout" runat="server" Text="Team 5" Visible="false" OnClick="lbtnBoysTeam5Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysTeam6Printout" runat="server" Text="Team 6" Visible="false" OnClick="lbtnBoysTeam6Printout_Click"></asp:LinkButton></p>
                                        </asp:Panel>
                                    </div>
                                    <div data-role="collapsible">
                                        <h2><asp:LinkButton ID="lbtnGirlsTeamPerfPrintouts" runat="server" Text="Girl's Team Performances" Visible="false" OnClick="lbtnGirlsTeamPerfPrintouts_Click"></asp:LinkButton></h2>
                                        <asp:Panel ID="panGirlsTeamPerfPrintouts" runat="server" Visible="false">
                                            <p><asp:LinkButton ID="lbtnGirlsPerfsAll" runat="server" Text="All" OnClick="lbtnGirlsPerfsAll_Click" Visible="False"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsTeam1Printout" runat="server" Text="Team 1" OnClick="lbtnGirlsTeam1Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsTeam2Printout" runat="server" Text="Team 2" Visible="false" OnClick="lbtnGirlsTeam2Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsTeam3Printout" runat="server" Text="Team 3" Visible="false" OnClick="lbtnGirlsTeam3Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsTeam4Printout" runat="server" Text="Team 4" Visible="false" OnClick="lbtnGirlsTeam4Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsTeam5Printout" runat="server" Text="Team 5" Visible="false" OnClick="lbtnGirlsTeam5Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsTeam6Printout" runat="server" Text="Team 6" Visible="false" OnClick="lbtnGirlsTeam6Printout_Click"></asp:LinkButton></p>
                                        </asp:Panel>
                                    </div>
                                    <div data-role="collapsible">
                                        <h2><asp:LinkButton ID="lbtnBoysEventPrintouts" runat="server" Text="Boy's Event Performances" Visible="false" OnClick="lbtnBoysEventPrintouts_Click"></asp:LinkButton></h2>
                                        <asp:Panel ID="panBoysEventPrintouts" runat="server" Visible="false">
                                            <p><asp:LinkButton ID="lbtnBoys100Printout" runat="server" Text="100 Meters" OnClick="lbtnBoys100Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoys200Printout" runat="server" Text="200 Meters" OnClick="lbtnBoys200Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoys400Printout" runat="server" Text="400 Meters" OnClick="lbtnBoys400Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoys800Printout" runat="server" Text="800 Meters" OnClick="lbtnBoys800Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoys1600Printout" runat="server" Text="1600 Meters" OnClick="lbtnBoys1600Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoys3200Printout" runat="server" Text="3200 Meters" OnClick="lbtnBoys3200Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysHHPrintout" runat="server" Text="100 Hurdles" OnClick="lbtnBoysHHPrintout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoys300HPrintout" runat="server" Text="300 Hurdles" OnClick="lbtnBoys300HPrintout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoys4x1Printout" runat="server" Text="4x100 Relay" OnClick="lbtnBoys4x1Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoys4x4Printout" runat="server" Text="4x400 Relay" OnClick="lbtnBoys4x4Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoys4x8Printout" runat="server" Text="4x800 Relay" OnClick="lbtnBoys4x8Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysLJPrintout" runat="server" Text="Long Jump" OnClick="lbtnBoysLJPrintout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysTJPrintout" runat="server" Text="Triple Jump" OnClick="lbtnBoysTJPrintout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysHJPrintout" runat="server" Text="High Jump" OnClick="lbtnBoysHJPrintout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysPVPrintout" runat="server" Text="Pole Vault" OnClick="lbtnBoysPVPrintout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysShotputPrintout" runat="server" Text="Shotput" OnClick="lbtnBoysShotputPrintout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysDiscusPrintout" runat="server" Text="Discus" OnClick="lbtnBoysDiscusPrintout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnBoysJavelinPrintout" runat="server" Text="Javelin" OnClick="lbtnBoysJavelinPrintout_Click"></asp:LinkButton></p>
                                        </asp:Panel>
                                    </div>
                                    <div data-role="collapsible">
                                        <h2><asp:LinkButton ID="lbtnGirlsEventPrintouts" runat="server" Text="Girl's Event Performances" Visible="false" OnClick="lbtnGirlsEventPrintouts_Click"></asp:LinkButton></h2>
                                        <asp:Panel ID="panGirlsEventPrintouts" runat="server" Visible="false">
                                            <p><asp:LinkButton ID="lbtnGirls100Printout" runat="server" Text="100 Meters" OnClick="lbtnGirls100Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirls200Printout" runat="server" Text="200 Meters" OnClick="lbtnGirls200Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirls400Printout" runat="server" Text="400 Meters" OnClick="lbtnGirls400Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirls800Printout" runat="server" Text="800 Meters" OnClick="lbtnGirls800Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirls1600Printout" runat="server" Text="1600 Meters" OnClick="lbtnGirls1600Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirls3200Printout" runat="server" Text="3200 Meters" OnClick="lbtnGirls3200Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsHHPrintout" runat="server" Text="100 Hurdles" OnClick="lbtnGirlsHHPrintout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirls300HPrintout" runat="server" Text="300 Hurdles" OnClick="lbtnGirls300HPrintout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirls4x1Printout" runat="server" Text="4x100 Relay" OnClick="lbtnGirls4x1Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirls4x4Printout" runat="server" Text="4x400 Relay" OnClick="lbtnGirls4x4Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirls4x8Printout" runat="server" Text="4x800 Relay" OnClick="lbtnGirls4x8Printout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsLJPrintout" runat="server" Text="Long Jump" OnClick="lbtnGirlsLJPrintout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsTJPrintout" runat="server" Text="Triple Jump" OnClick="lbtnGirlsTJPrintout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsHJPrintout" runat="server" Text="High Jump" OnClick="lbtnGirlsHJPrintout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsPVPrintout" runat="server" Text="Pole Vault" OnClick="lbtnGirlsPVPrintout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsShotputPrintout" runat="server" Text="Shotput" OnClick="lbtnGirlsShotputPrintout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsDiscusPrintout" runat="server" Text="Discus" OnClick="lbtnGirlsDiscusPrintout_Click"></asp:LinkButton></p>
                                            <p><asp:LinkButton ID="lbtnGirlsJavelinPrintout" runat="server" Text="Javelin" OnClick="lbtnGirlsJavelinPrintout_Click"></asp:LinkButton></p>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </td>
                        <td id="scoresTD">
                            <b>
                            Boy&#39;s Scores</b>:<br />
                            <asp:ListBox ID="lstBoysScores" runat="server" Height="200px" Width="300px"></asp:ListBox>
                            <br />
                            <br />
                            <b>Girl&#39;s Scores</b>:<br />
                            <asp:ListBox ID="lstGirlsScores" runat="server" Height="200px" Width="300px"></asp:ListBox>
                        </td>
                    </tr>
                </table>
                <div data-role="footer">
                    <h1 style="text-align: center">Meet Info Goes Here</h1>
                </div>
            </div>
        </form>
    </body>
</html>

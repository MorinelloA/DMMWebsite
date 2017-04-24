using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMMLib;

using Novacode;
using System.Drawing;
using DualMeetManager.Business.Managers;
using System.Text.RegularExpressions;
using System.IO;

namespace DualMeetManager.Service.Printout
{
    /// <summary>
    /// Implementation that uses the DocX library to generate Microsoft Word documents for Meet information
    /// </summary>
    public class PrintoutDocXSvcImpl : IPrintoutDocSvc
    {
        /// <summary>
        /// Implementation for creating a doc of individual event performances
        /// </summary>
        /// <param name="eventName">Name of the event for this printout</param>
        /// <param name="performances">List of performances for this printout</param>
        /// <returns>boolean that shows whether or not the doc was created successfully or not</returns>
        public bool CreateIndEventDoc(string eventName, List<Performance> performances)
        {
            //Make sure we get a valid filename
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < eventName.Length; i++)
            {
                //if (!perf.All(c => char.IsDigit(c) || c == ':' || c == '.'))
                if (char.IsLetterOrDigit(eventName[i]))
                {
                    sb.Append(eventName[i]);
                }
            }
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\printouts\\events");
            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\printouts\\events\\" + sb.ToString() + ".docx";
            try
            {
                using (DocX document = DocX.Create(fileName))
                {
                    document.MarginLeft = 36; //.5 Margin
                    document.MarginRight = 36;
                    document.MarginTop = 36;
                    document.MarginBottom = 36;
                    // Add a new Paragraph to the document.
                    Paragraph p = document.InsertParagraph();

                    // Append some text.
                    p.Append(eventName + "\n\n").Font(new FontFamily("Arial Black"));

                    if (performances != null)
                    {
                        EventMgr eMgr = new EventMgr();
                        if (performances[0].heatNum != 0) //Running Event
                        {
                            // Add a Table to this document. (Rows, Columns)
                            Table t = document.AddTable(performances.Count + 1, 5);
                            // Specify some properties for this Table.
                            t.Alignment = Alignment.center;
                            t.Design = TableDesign.TableNormal;

                            //t.Rows[0].Cells[0].FillColor = Color.Azure;
                            //t.Rows[0].Cells[0].Paragraphs.First().Append("#").Font(new FontFamily("Arial Black"));
                            t.Rows[0].Cells[0].Paragraphs.First().Append("#").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                            t.Rows[0].Cells[1].Paragraphs.First().Append("Athlete").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                            t.Rows[0].Cells[2].Paragraphs.First().Append("School").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                            t.Rows[0].Cells[3].Paragraphs.First().Append("Performance").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                            t.Rows[0].Cells[4].Paragraphs.First().Append("Heat").Bold().UnderlineStyle(UnderlineStyle.singleLine);

                            for (int i = 0; i < performances.Count; i++)
                            {
                                t.Rows[i + 1].Cells[0].Paragraphs.First().Append((i + 1).ToString());
                                t.Rows[i + 1].Cells[1].Paragraphs.First().Append(performances[i].athleteName);
                                t.Rows[i + 1].Cells[2].Paragraphs.First().Append(performances[i].schoolName);
                                t.Rows[i + 1].Cells[3].Paragraphs.First().Append(eMgr.ConvertToTimedData(performances[i].performance));
                                t.Rows[i + 1].Cells[4].Paragraphs.First().Append(performances[i].heatNum.ToString());
                            }

                            document.InsertTable(t);
                        }
                        else //Field Event
                        {
                            // Add a Table to this document. (Rows, Columns)
                            Table t = document.AddTable(performances.Count + 1, 4);
                            // Specify some properties for this Table.
                            t.Alignment = Alignment.center;
                            t.Design = TableDesign.TableNormal;

                            t.Rows[0].Cells[0].Paragraphs.First().Append("#").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                            t.Rows[0].Cells[1].Paragraphs.First().Append("Athlete").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                            t.Rows[0].Cells[2].Paragraphs.First().Append("School").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                            t.Rows[0].Cells[3].Paragraphs.First().Append("Performance").Bold().UnderlineStyle(UnderlineStyle.singleLine);

                            for (int i = 0; i < performances.Count; i++)
                            {
                                t.Rows[i + 1].Cells[0].Paragraphs.First().Append((i + 1).ToString());
                                t.Rows[i + 1].Cells[1].Paragraphs.First().Append(performances[i].athleteName);
                                t.Rows[i + 1].Cells[2].Paragraphs.First().Append(performances[i].schoolName);
                                t.Rows[i + 1].Cells[3].Paragraphs.First().Append(eMgr.ConvertToLengthData(performances[i].performance));
                            }

                            document.InsertTable(t);
                        }
                        Paragraph pp = document.InsertParagraph();
                        pp.Append("\n\n\nNOTE: Ties are not calculated on this sheet. #'s are only for reference").Font(new FontFamily("Arial"));
                    }
                    else //No performances
                    {
                        p.Append("No performances for this event").Font(new FontFamily("Arial"));
                    }

                    // Save the document.
                    document.Save();
                    System.Diagnostics.Process.Start(fileName);
                }
            }
            catch(IOException ioe)
            {
                Console.WriteLine("Error creating individual points printout");
                Console.WriteLine(ioe);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Implementation for creating a doc for all scoring information for a Meet
        /// </summary>
        /// <param name="scoreToPrint">OverallScore information of the meet to be printed</param>
        /// <returns>boolean that shows whether or not the doc was created successfully or not</returns>
        public bool CreateMeetResultsDoc(string gender, DateTime dt, string location, OverallScore scoreToPrint)
        {
            //if(scoreToPrint == null || scoreToPrint.)
            EventMgr eMgr = new EventMgr();
            Directory.CreateDirectory("printouts\\scores");
            string fileName = "printouts\\scores\\" + gender[0] + "-" + scoreToPrint.team1.Item1 + "vs" + scoreToPrint.team2.Item1 + ".docx";
            try
            {
                using (DocX document = DocX.Create(fileName))
                {
                    document.MarginLeft = 36; //.5 Margin
                    document.MarginRight = 36;
                    document.MarginTop = 36;
                    document.MarginBottom = 36;

                    //Meet Info at top
                    Paragraph pp = document.InsertParagraph();

                    // Append some text.
                    pp.Append(gender + " Track & Field\n").FontSize(12).Bold();
                    pp.Append(scoreToPrint.team1.Item2 + " vs. " + scoreToPrint.team2.Item2 + "\n").FontSize(12).Bold();
                    pp.Append(dt.ToShortDateString() + " @ " + location + "\n").FontSize(12).Bold();
                    pp.Alignment = Alignment.center;

                    Table t = document.AddTable(53, 12);
                    // Specify some properties for this Table.
                    t.Alignment = Alignment.center;
                    t.Design = TableDesign.TableNormal;
                    Border b = new Border(BorderStyle.Tcbs_single, BorderSize.one, 0, Color.Black);
                    t.SetBorder(TableBorderType.Bottom, b);
                    t.SetBorder(TableBorderType.Top, b);
                    t.SetBorder(TableBorderType.Left, b);
                    t.SetBorder(TableBorderType.Right, b);
                    t.SetBorder(TableBorderType.InsideH, b);
                    t.SetBorder(TableBorderType.InsideV, b);

                    //Align all cells to center
                    for (int aa = 0; aa < 53; aa++)
                    {
                        for (int bb = 0; bb < 12; bb++)
                        {
                            t.Rows[aa].Cells[bb].Paragraphs.First().Alignment = Alignment.center;
                        }
                    }

                    //Shade appropriate cell grey
                    for (int bb = 0; bb <= 5; bb++)
                    {
                        for (int aa = 1; aa <= 5; aa++)
                        {
                            t.Rows[aa].Cells[bb].Shading = Color.LightGray;
                        }
                        for (int aa = 13; aa <= 17; aa++)
                        {
                            t.Rows[aa].Cells[bb].Shading = Color.LightGray;
                        }
                        for (int aa = 25; aa <= 28; aa++)
                        {
                            t.Rows[aa].Cells[bb].Shading = Color.LightGray;
                        }
                        for (int aa = 36; aa <= 40; aa++)
                        {
                            t.Rows[aa].Cells[bb].Shading = Color.LightGray;
                        }
                        for (int aa = 48; aa <= 52; aa++)
                        {
                            t.Rows[aa].Cells[bb].Shading = Color.LightGray;
                        }
                    }
                    for (int bb = 6; bb <= 11; bb++)
                    {
                        for (int aa = 7; aa <= 11; aa++)
                        {
                            t.Rows[aa].Cells[bb].Shading = Color.LightGray;
                        }
                        for (int aa = 19; aa <= 23; aa++)
                        {
                            t.Rows[aa].Cells[bb].Shading = Color.LightGray;
                        }
                        for (int aa = 30; aa <= 34; aa++)
                        {
                            t.Rows[aa].Cells[bb].Shading = Color.LightGray;
                        }
                        for (int aa = 42; aa <= 46; aa++)
                        {
                            t.Rows[aa].Cells[bb].Shading = Color.LightGray;
                        }
                    }

                    //100 & 200
                    t.Rows[0].MergeCells(0, 5);
                    t.Rows[0].MergeCells(1, 6);
                    t.Rows[0].Cells[0].RemoveParagraphAt(0);
                    t.Rows[0].Cells[0].RemoveParagraphAt(0);
                    t.Rows[0].Cells[0].RemoveParagraphAt(0);
                    t.Rows[0].Cells[0].RemoveParagraphAt(0);
                    t.Rows[0].Cells[0].RemoveParagraphAt(0);
                    t.Rows[0].Cells[1].RemoveParagraphAt(0);
                    t.Rows[0].Cells[1].RemoveParagraphAt(0);
                    t.Rows[0].Cells[1].RemoveParagraphAt(0);
                    t.Rows[0].Cells[1].RemoveParagraphAt(0);
                    t.Rows[0].Cells[1].RemoveParagraphAt(0);
                    t.Rows[0].Cells[0].Paragraphs.First().Append("100 Meter Dash");
                    t.Rows[0].Cells[1].Paragraphs.First().Append("200 Meter Dash");
                    t.Rows[0].Cells[0].Shading = Color.Black;
                    t.Rows[0].Cells[1].Shading = Color.Black;
                    t.Rows[1].Cells[0].Paragraphs.First().Append("#");
                    t.Rows[1].Cells[1].Paragraphs.First().Append("Athlete");
                    t.Rows[1].Cells[2].Paragraphs.First().Append("School");
                    t.Rows[1].Cells[3].Paragraphs.First().Append("Time");
                    t.Rows[1].Cells[4].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                    t.Rows[1].Cells[5].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                    t.Rows[1].Cells[6].Paragraphs.First().Append("#");
                    t.Rows[1].Cells[7].Paragraphs.First().Append("Athlete");
                    t.Rows[1].Cells[8].Paragraphs.First().Append("School");
                    t.Rows[1].Cells[9].Paragraphs.First().Append("Time");
                    t.Rows[1].Cells[10].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                    t.Rows[1].Cells[11].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                    //100
                    t.Rows[2].Cells[0].Paragraphs.First().Append("1");
                    t.Rows[3].Cells[0].Paragraphs.First().Append("2");
                    t.Rows[4].Cells[0].Paragraphs.First().Append("3");
                    t.Rows[5].MergeCells(0, 3);
                    t.Rows[5].Cells[0].RemoveParagraphAt(0);
                    t.Rows[5].Cells[0].RemoveParagraphAt(0);
                    t.Rows[5].Cells[0].RemoveParagraphAt(0);
                    t.Rows[5].Cells[0].Paragraphs.First().Append("Total");
                    t.Rows[5].Cells[0].Paragraphs.First().Alignment = Alignment.left;
                    if (scoreToPrint.indEvents != null && scoreToPrint.indEvents.ContainsKey(gender + " 100"))
                    {
                        t.Rows[2].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 100"].points[0].athleteName).FontSize(8);
                        t.Rows[2].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 100"].points[0].schoolName).FontSize(8);
                        t.Rows[2].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 100"].points[0].performance).FontSize(8);
                        t.Rows[2].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 100"].points[0].team1Pts)).FontSize(8);
                        t.Rows[2].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 100"].points[0].team2Pts)).FontSize(8);
                        t.Rows[3].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 100"].points[1].athleteName).FontSize(8);
                        t.Rows[3].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 100"].points[1].schoolName).FontSize(8);
                        t.Rows[3].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 100"].points[1].performance).FontSize(8);
                        t.Rows[3].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 100"].points[1].team1Pts)).FontSize(8);
                        t.Rows[3].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 100"].points[1].team2Pts)).FontSize(8);
                        t.Rows[4].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 100"].points[2].athleteName).FontSize(8);
                        t.Rows[4].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 100"].points[2].schoolName).FontSize(8);
                        t.Rows[4].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 100"].points[2].performance).FontSize(8);
                        t.Rows[4].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 100"].points[2].team1Pts)).FontSize(8);
                        t.Rows[4].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 100"].points[2].team2Pts)).FontSize(8);
                        t.Rows[5].Cells[1].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 100"].team1Total)).FontSize(8);
                        t.Rows[5].Cells[2].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 100"].team2Total)).FontSize(8);
                    }
                    else
                    {
                        t.Rows[2].Cells[4].Paragraphs.First().Append("0").FontSize(8);
                        t.Rows[2].Cells[5].Paragraphs.First().Append("0").FontSize(8);
                        t.Rows[3].Cells[4].Paragraphs.First().Append("0").FontSize(8);
                        t.Rows[3].Cells[5].Paragraphs.First().Append("0").FontSize(8);
                        t.Rows[4].Cells[4].Paragraphs.First().Append("0").FontSize(8);
                        t.Rows[4].Cells[5].Paragraphs.First().Append("0").FontSize(8);
                        t.Rows[5].Cells[1].Paragraphs.First().Append("0").FontSize(8);
                        t.Rows[5].Cells[2].Paragraphs.First().Append("0").FontSize(8);
                    }
                    //200
                    t.Rows[2].Cells[6].Paragraphs.First().Append("1");
                    t.Rows[3].Cells[6].Paragraphs.First().Append("2");
                    t.Rows[4].Cells[6].Paragraphs.First().Append("3");
                    t.Rows[5].MergeCells(3, 6);
                    t.Rows[5].Cells[3].RemoveParagraphAt(0);
                    t.Rows[5].Cells[3].RemoveParagraphAt(0);
                    t.Rows[5].Cells[3].RemoveParagraphAt(0);
                    t.Rows[5].Cells[3].Paragraphs.First().Append("Total");
                    t.Rows[5].Cells[3].Paragraphs.First().Alignment = Alignment.left;
                    if (scoreToPrint.indEvents != null && scoreToPrint.indEvents.ContainsKey(gender + " 200"))
                    {
                        t.Rows[2].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 200"].points[0].athleteName);
                        t.Rows[2].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 200"].points[0].schoolName);
                        t.Rows[2].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 200"].points[0].performance);
                        t.Rows[2].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 200"].points[0].team1Pts));
                        t.Rows[2].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 200"].points[0].team2Pts));
                        t.Rows[3].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 200"].points[1].athleteName);
                        t.Rows[3].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 200"].points[1].schoolName);
                        t.Rows[3].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 200"].points[1].performance);
                        t.Rows[3].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 200"].points[1].team1Pts));
                        t.Rows[3].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 200"].points[1].team2Pts));
                        t.Rows[4].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 200"].points[2].athleteName);
                        t.Rows[4].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 200"].points[2].schoolName);
                        t.Rows[4].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 200"].points[2].performance);
                        t.Rows[4].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 200"].points[2].team1Pts));
                        t.Rows[4].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 200"].points[2].team2Pts));
                        t.Rows[5].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 200"].team1Total));
                        t.Rows[5].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 200"].team2Total));
                    }
                    else
                    {
                        t.Rows[2].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[2].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[3].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[3].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[4].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[4].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[5].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[5].Cells[5].Paragraphs.First().Append("0");
                    }

                    // Merge the cells 400 & 800 Title Cells into one new cell.
                    t.Rows[6].MergeCells(0, 5);
                    t.Rows[6].MergeCells(1, 6);
                    t.Rows[6].Cells[0].RemoveParagraphAt(0);
                    t.Rows[6].Cells[0].RemoveParagraphAt(0);
                    t.Rows[6].Cells[0].RemoveParagraphAt(0);
                    t.Rows[6].Cells[0].RemoveParagraphAt(0);
                    t.Rows[6].Cells[0].RemoveParagraphAt(0);
                    t.Rows[6].Cells[1].RemoveParagraphAt(0);
                    t.Rows[6].Cells[1].RemoveParagraphAt(0);
                    t.Rows[6].Cells[1].RemoveParagraphAt(0);
                    t.Rows[6].Cells[1].RemoveParagraphAt(0);
                    t.Rows[6].Cells[1].RemoveParagraphAt(0);
                    t.Rows[6].Cells[0].Paragraphs.First().Append("400 Meter Dash");
                    t.Rows[6].Cells[1].Paragraphs.First().Append("800 Meter Dash");
                    t.Rows[6].Cells[0].Shading = Color.Black;
                    t.Rows[6].Cells[1].Shading = Color.Black;
                    t.Rows[7].Cells[0].Paragraphs.First().Append("#");
                    t.Rows[7].Cells[1].Paragraphs.First().Append("Athlete");
                    t.Rows[7].Cells[2].Paragraphs.First().Append("School");
                    t.Rows[7].Cells[3].Paragraphs.First().Append("Time");
                    t.Rows[7].Cells[4].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                    t.Rows[7].Cells[5].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                    t.Rows[7].Cells[6].Paragraphs.First().Append("#");
                    t.Rows[7].Cells[7].Paragraphs.First().Append("Athlete");
                    t.Rows[7].Cells[8].Paragraphs.First().Append("School");
                    t.Rows[7].Cells[9].Paragraphs.First().Append("Time");
                    t.Rows[7].Cells[10].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                    t.Rows[7].Cells[11].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                    //400
                    t.Rows[8].Cells[0].Paragraphs.First().Append("1");
                    t.Rows[9].Cells[0].Paragraphs.First().Append("2");
                    t.Rows[10].Cells[0].Paragraphs.First().Append("3");
                    t.Rows[11].MergeCells(0, 3);
                    t.Rows[11].Cells[0].RemoveParagraphAt(0);
                    t.Rows[11].Cells[0].RemoveParagraphAt(0);
                    t.Rows[11].Cells[0].RemoveParagraphAt(0);
                    t.Rows[11].Cells[0].Paragraphs.First().Append("Total");
                    t.Rows[11].Cells[0].Paragraphs.First().Alignment = Alignment.left;
                    if (scoreToPrint.indEvents != null && scoreToPrint.indEvents.ContainsKey(gender + " 400"))
                    {
                        t.Rows[8].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 400"].points[0].athleteName);
                        t.Rows[8].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 400"].points[0].schoolName);
                        t.Rows[8].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 400"].points[0].performance);
                        t.Rows[8].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 400"].points[0].team1Pts));
                        t.Rows[8].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 400"].points[0].team2Pts));
                        t.Rows[9].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 400"].points[1].athleteName);
                        t.Rows[9].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 400"].points[1].schoolName);
                        t.Rows[9].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 400"].points[1].performance);
                        t.Rows[9].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 400"].points[1].team1Pts));
                        t.Rows[9].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 400"].points[1].team2Pts));
                        t.Rows[10].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 400"].points[2].athleteName);
                        t.Rows[10].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 400"].points[2].schoolName);
                        t.Rows[10].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 400"].points[2].performance);
                        t.Rows[10].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 400"].points[2].team1Pts));
                        t.Rows[10].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 400"].points[2].team2Pts));
                        t.Rows[11].Cells[1].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 400"].team1Total));
                        t.Rows[11].Cells[2].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 400"].team2Total));
                    }
                    else
                    {
                        t.Rows[8].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[8].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[9].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[9].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[10].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[10].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[11].Cells[1].Paragraphs.First().Append("0");
                        t.Rows[11].Cells[2].Paragraphs.First().Append("0");
                    }
                    //800
                    t.Rows[8].Cells[6].Paragraphs.First().Append("1");
                    t.Rows[9].Cells[6].Paragraphs.First().Append("2");
                    t.Rows[10].Cells[6].Paragraphs.First().Append("3");
                    t.Rows[11].MergeCells(3, 6);
                    t.Rows[11].Cells[3].RemoveParagraphAt(0);
                    t.Rows[11].Cells[3].RemoveParagraphAt(0);
                    t.Rows[11].Cells[3].RemoveParagraphAt(0);
                    t.Rows[11].Cells[3].Paragraphs.First().Append("Total");
                    t.Rows[11].Cells[3].Paragraphs.First().Alignment = Alignment.left;
                    if (scoreToPrint.indEvents != null && scoreToPrint.indEvents.ContainsKey(gender + " 800"))
                    {
                        t.Rows[8].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 800"].points[0].athleteName);
                        t.Rows[8].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 800"].points[0].schoolName);
                        t.Rows[8].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 800"].points[0].performance);
                        t.Rows[8].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 800"].points[0].team1Pts));
                        t.Rows[8].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 800"].points[0].team2Pts));
                        t.Rows[9].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 800"].points[1].athleteName);
                        t.Rows[9].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 800"].points[1].schoolName);
                        t.Rows[9].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 800"].points[1].performance);
                        t.Rows[9].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 800"].points[1].team1Pts));
                        t.Rows[9].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 800"].points[1].team2Pts));
                        t.Rows[10].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 800"].points[2].athleteName);
                        t.Rows[10].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 800"].points[2].schoolName);
                        t.Rows[10].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 800"].points[2].performance);
                        t.Rows[10].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 800"].points[2].team1Pts));
                        t.Rows[10].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 800"].points[2].team2Pts));
                        t.Rows[11].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 800"].team1Total));
                        t.Rows[11].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 800"].team2Total));
                    }
                    else
                    {
                        t.Rows[8].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[8].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[9].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[9].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[10].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[10].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[11].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[11].Cells[5].Paragraphs.First().Append("0");
                    }

                    // Merge the cells 1600 & 3200 Title Cells into one new cell.
                    t.Rows[12].MergeCells(0, 5);
                    t.Rows[12].MergeCells(1, 6);
                    t.Rows[12].Cells[0].RemoveParagraphAt(0);
                    t.Rows[12].Cells[0].RemoveParagraphAt(0);
                    t.Rows[12].Cells[0].RemoveParagraphAt(0);
                    t.Rows[12].Cells[0].RemoveParagraphAt(0);
                    t.Rows[12].Cells[0].RemoveParagraphAt(0);
                    t.Rows[12].Cells[1].RemoveParagraphAt(0);
                    t.Rows[12].Cells[1].RemoveParagraphAt(0);
                    t.Rows[12].Cells[1].RemoveParagraphAt(0);
                    t.Rows[12].Cells[1].RemoveParagraphAt(0);
                    t.Rows[12].Cells[1].RemoveParagraphAt(0);
                    t.Rows[12].Cells[0].Paragraphs.First().Append("1600 Meter Dash");
                    t.Rows[12].Cells[1].Paragraphs.First().Append("3200 Meter Dash");
                    t.Rows[12].Cells[0].Shading = Color.Black;
                    t.Rows[12].Cells[1].Shading = Color.Black;
                    t.Rows[13].Cells[0].Paragraphs.First().Append("#");
                    t.Rows[13].Cells[1].Paragraphs.First().Append("Athlete");
                    t.Rows[13].Cells[2].Paragraphs.First().Append("School");
                    t.Rows[13].Cells[3].Paragraphs.First().Append("Time");
                    t.Rows[13].Cells[4].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                    t.Rows[13].Cells[5].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                    t.Rows[13].Cells[6].Paragraphs.First().Append("#");
                    t.Rows[13].Cells[7].Paragraphs.First().Append("Athlete");
                    t.Rows[13].Cells[8].Paragraphs.First().Append("School");
                    t.Rows[13].Cells[9].Paragraphs.First().Append("Time");
                    t.Rows[13].Cells[10].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                    t.Rows[13].Cells[11].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                    //1600
                    t.Rows[14].Cells[0].Paragraphs.First().Append("1");
                    t.Rows[15].Cells[0].Paragraphs.First().Append("2");
                    t.Rows[16].Cells[0].Paragraphs.First().Append("3");
                    t.Rows[17].MergeCells(0, 3);
                    t.Rows[17].Cells[0].RemoveParagraphAt(0);
                    t.Rows[17].Cells[0].RemoveParagraphAt(0);
                    t.Rows[17].Cells[0].RemoveParagraphAt(0);
                    t.Rows[17].Cells[0].Paragraphs.First().Append("Total");
                    t.Rows[17].Cells[0].Paragraphs.First().Alignment = Alignment.left;
                    if (scoreToPrint.indEvents != null && scoreToPrint.indEvents.ContainsKey(gender + " 1600"))
                    {
                        t.Rows[14].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 1600"].points[0].athleteName);
                        t.Rows[14].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 1600"].points[0].schoolName);
                        t.Rows[14].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 1600"].points[0].performance);
                        t.Rows[14].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 1600"].points[0].team1Pts));
                        t.Rows[14].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 1600"].points[0].team2Pts));
                        t.Rows[15].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 1600"].points[1].athleteName);
                        t.Rows[15].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 1600"].points[1].schoolName);
                        t.Rows[15].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 1600"].points[1].performance);
                        t.Rows[15].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 1600"].points[1].team1Pts));
                        t.Rows[15].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 1600"].points[1].team2Pts));
                        t.Rows[16].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 1600"].points[2].athleteName);
                        t.Rows[16].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 1600"].points[2].schoolName);
                        t.Rows[16].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 1600"].points[2].performance);
                        t.Rows[16].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 1600"].points[2].team1Pts));
                        t.Rows[16].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 1600"].points[2].team2Pts));
                        t.Rows[17].Cells[1].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 1600"].team1Total));
                        t.Rows[17].Cells[2].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 1600"].team2Total));
                    }
                    else
                    {
                        t.Rows[14].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[14].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[15].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[15].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[16].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[16].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[17].Cells[1].Paragraphs.First().Append("0");
                        t.Rows[17].Cells[2].Paragraphs.First().Append("0");
                    }
                    //3200
                    t.Rows[14].Cells[6].Paragraphs.First().Append("1");
                    t.Rows[15].Cells[6].Paragraphs.First().Append("2");
                    t.Rows[16].Cells[6].Paragraphs.First().Append("3");
                    t.Rows[17].MergeCells(3, 6);
                    t.Rows[17].Cells[3].RemoveParagraphAt(0);
                    t.Rows[17].Cells[3].RemoveParagraphAt(0);
                    t.Rows[17].Cells[3].RemoveParagraphAt(0);
                    t.Rows[17].Cells[3].Paragraphs.First().Append("Total");
                    t.Rows[17].Cells[3].Paragraphs.First().Alignment = Alignment.left;
                    if (scoreToPrint.indEvents != null && scoreToPrint.indEvents.ContainsKey(gender + " 3200"))
                    {
                        t.Rows[14].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 3200"].points[0].athleteName);
                        t.Rows[14].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 3200"].points[0].schoolName);
                        t.Rows[14].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 3200"].points[0].performance);
                        t.Rows[14].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 3200"].points[0].team1Pts));
                        t.Rows[14].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 3200"].points[0].team2Pts));
                        t.Rows[15].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 3200"].points[1].athleteName);
                        t.Rows[15].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 3200"].points[1].schoolName);
                        t.Rows[15].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 3200"].points[1].performance);
                        t.Rows[15].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 3200"].points[1].team1Pts));
                        t.Rows[15].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 3200"].points[1].team2Pts));
                        t.Rows[16].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 3200"].points[2].athleteName);
                        t.Rows[16].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 3200"].points[2].schoolName);
                        t.Rows[16].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 3200"].points[2].performance);
                        t.Rows[16].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 3200"].points[2].team1Pts));
                        t.Rows[16].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 3200"].points[2].team2Pts));
                        t.Rows[17].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 3200"].team1Total));
                        t.Rows[17].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 3200"].team2Total));
                    }
                    else
                    {
                        t.Rows[14].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[14].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[15].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[15].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[16].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[16].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[17].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[17].Cells[5].Paragraphs.First().Append("0");
                    }

                    // Merge the cells High Hurdle & 300H Title Cells into one new cell.
                    t.Rows[18].MergeCells(0, 5);
                    t.Rows[18].MergeCells(1, 6);
                    t.Rows[18].Cells[0].RemoveParagraphAt(0);
                    t.Rows[18].Cells[0].RemoveParagraphAt(0);
                    t.Rows[18].Cells[0].RemoveParagraphAt(0);
                    t.Rows[18].Cells[0].RemoveParagraphAt(0);
                    t.Rows[18].Cells[0].RemoveParagraphAt(0);
                    t.Rows[18].Cells[1].RemoveParagraphAt(0);
                    t.Rows[18].Cells[1].RemoveParagraphAt(0);
                    t.Rows[18].Cells[1].RemoveParagraphAt(0);
                    t.Rows[18].Cells[1].RemoveParagraphAt(0);
                    t.Rows[18].Cells[1].RemoveParagraphAt(0);
                    t.Rows[18].Cells[0].Paragraphs.First().Append("High Hurdles");
                    t.Rows[18].Cells[1].Paragraphs.First().Append("300 Meter Hurdles");
                    t.Rows[18].Cells[0].Shading = Color.Black;
                    t.Rows[18].Cells[1].Shading = Color.Black;
                    t.Rows[19].Cells[0].Paragraphs.First().Append("#");
                    t.Rows[19].Cells[1].Paragraphs.First().Append("Athlete");
                    t.Rows[19].Cells[2].Paragraphs.First().Append("School");
                    t.Rows[19].Cells[3].Paragraphs.First().Append("Time");
                    t.Rows[19].Cells[4].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                    t.Rows[19].Cells[5].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                    t.Rows[19].Cells[6].Paragraphs.First().Append("#");
                    t.Rows[19].Cells[7].Paragraphs.First().Append("Athlete");
                    t.Rows[19].Cells[8].Paragraphs.First().Append("School");
                    t.Rows[19].Cells[9].Paragraphs.First().Append("Time");
                    t.Rows[19].Cells[10].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                    t.Rows[19].Cells[11].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                    //HH
                    t.Rows[20].Cells[0].Paragraphs.First().Append("1");
                    t.Rows[21].Cells[0].Paragraphs.First().Append("2");
                    t.Rows[22].Cells[0].Paragraphs.First().Append("3");
                    t.Rows[23].MergeCells(0, 3);
                    t.Rows[23].Cells[0].RemoveParagraphAt(0);
                    t.Rows[23].Cells[0].RemoveParagraphAt(0);
                    t.Rows[23].Cells[0].RemoveParagraphAt(0);
                    t.Rows[23].Cells[0].Paragraphs.First().Append("Total");
                    t.Rows[23].Cells[0].Paragraphs.First().Alignment = Alignment.left;
                    if (scoreToPrint.indEvents != null && scoreToPrint.indEvents.ContainsKey(gender + " HH"))
                    {
                        t.Rows[20].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " HH"].points[0].athleteName);
                        t.Rows[20].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " HH"].points[0].schoolName);
                        t.Rows[20].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " HH"].points[0].performance);
                        t.Rows[20].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " HH"].points[0].team1Pts));
                        t.Rows[20].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " HH"].points[0].team2Pts));
                        t.Rows[21].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " HH"].points[1].athleteName);
                        t.Rows[21].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " HH"].points[1].schoolName);
                        t.Rows[21].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " HH"].points[1].performance);
                        t.Rows[21].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " HH"].points[1].team1Pts));
                        t.Rows[21].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " HH"].points[1].team2Pts));
                        t.Rows[22].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " HH"].points[2].athleteName);
                        t.Rows[22].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " HH"].points[2].schoolName);
                        t.Rows[22].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " HH"].points[2].performance);
                        t.Rows[22].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " HH"].points[2].team1Pts));
                        t.Rows[22].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " HH"].points[2].team2Pts));
                        t.Rows[23].Cells[1].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " HH"].team1Total));
                        t.Rows[23].Cells[2].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " HH"].team2Total));
                    }
                    else
                    {
                        t.Rows[20].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[20].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[21].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[21].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[22].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[22].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[23].Cells[1].Paragraphs.First().Append("0");
                        t.Rows[23].Cells[2].Paragraphs.First().Append("0");
                    }
                    //300H
                    t.Rows[20].Cells[6].Paragraphs.First().Append("1");
                    t.Rows[21].Cells[6].Paragraphs.First().Append("2");
                    t.Rows[22].Cells[6].Paragraphs.First().Append("3");
                    t.Rows[23].MergeCells(3, 6);
                    t.Rows[23].Cells[3].RemoveParagraphAt(0);
                    t.Rows[23].Cells[3].RemoveParagraphAt(0);
                    t.Rows[23].Cells[3].RemoveParagraphAt(0);
                    t.Rows[23].Cells[3].Paragraphs.First().Append("Total");
                    t.Rows[23].Cells[3].Paragraphs.First().Alignment = Alignment.left;
                    if (scoreToPrint.indEvents != null && scoreToPrint.indEvents.ContainsKey(gender + " 300H"))
                    {
                        t.Rows[20].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 300H"].points[0].athleteName);
                        t.Rows[20].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 300H"].points[0].schoolName);
                        t.Rows[20].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 300H"].points[0].performance);
                        t.Rows[20].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 300H"].points[0].team1Pts));
                        t.Rows[20].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 300H"].points[0].team2Pts));
                        t.Rows[21].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 300H"].points[1].athleteName);
                        t.Rows[21].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 300H"].points[1].schoolName);
                        t.Rows[21].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 300H"].points[1].performance);
                        t.Rows[21].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 300H"].points[1].team1Pts));
                        t.Rows[21].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 300H"].points[1].team2Pts));
                        t.Rows[22].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 300H"].points[2].athleteName);
                        t.Rows[22].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 300H"].points[2].schoolName);
                        t.Rows[22].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " 300H"].points[2].performance);
                        t.Rows[22].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 300H"].points[2].team1Pts));
                        t.Rows[22].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 300H"].points[2].team2Pts));
                        t.Rows[23].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 300H"].team1Total));
                        t.Rows[23].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " 300H"].team2Total));
                    }
                    else
                    {
                        t.Rows[20].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[20].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[21].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[21].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[22].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[22].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[23].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[23].Cells[5].Paragraphs.First().Append("0");
                    }

                    // Merge the cells 4x100 & 4x400 Title Cells into one new cell.
                    t.Rows[24].MergeCells(0, 5);
                    t.Rows[24].MergeCells(1, 6);
                    t.Rows[24].Cells[0].RemoveParagraphAt(0);
                    t.Rows[24].Cells[0].RemoveParagraphAt(0);
                    t.Rows[24].Cells[0].RemoveParagraphAt(0);
                    t.Rows[24].Cells[0].RemoveParagraphAt(0);
                    t.Rows[24].Cells[0].RemoveParagraphAt(0);
                    t.Rows[24].Cells[1].RemoveParagraphAt(0);
                    t.Rows[24].Cells[1].RemoveParagraphAt(0);
                    t.Rows[24].Cells[1].RemoveParagraphAt(0);
                    t.Rows[24].Cells[1].RemoveParagraphAt(0);
                    t.Rows[24].Cells[1].RemoveParagraphAt(0);
                    t.Rows[24].Cells[0].Paragraphs.First().Append("4x100 Meter Relay");
                    t.Rows[24].Cells[1].Paragraphs.First().Append("4x400 Meter Relay");
                    t.Rows[24].Cells[0].Shading = Color.Black;
                    t.Rows[24].Cells[1].Shading = Color.Black;
                    t.Rows[25].Cells[0].Paragraphs.First().Append("#");
                    t.Rows[25].Cells[1].Paragraphs.First().Append("Athlete");
                    t.Rows[25].Cells[2].Paragraphs.First().Append("School");
                    t.Rows[25].Cells[3].Paragraphs.First().Append("Time");
                    t.Rows[25].Cells[4].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                    t.Rows[25].Cells[5].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                    t.Rows[25].Cells[6].Paragraphs.First().Append("#");
                    t.Rows[25].Cells[7].Paragraphs.First().Append("Athlete");
                    t.Rows[25].Cells[8].Paragraphs.First().Append("School");
                    t.Rows[25].Cells[9].Paragraphs.First().Append("Time");
                    t.Rows[25].Cells[10].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                    t.Rows[25].Cells[11].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                    //4x100
                    t.Rows[26].Cells[0].Paragraphs.First().Append("1");
                    t.Rows[27].Cells[0].Paragraphs.First().Append("2");
                    t.Rows[28].MergeCells(0, 3);
                    t.Rows[28].Cells[0].RemoveParagraphAt(0);
                    t.Rows[28].Cells[0].RemoveParagraphAt(0);
                    t.Rows[28].Cells[0].RemoveParagraphAt(0);
                    t.Rows[28].Cells[0].Paragraphs.First().Append("Total");
                    t.Rows[28].Cells[0].Paragraphs.First().Alignment = Alignment.left;
                    if (scoreToPrint.relayEvents != null && scoreToPrint.relayEvents.ContainsKey(gender + " 4x100"))
                    {
                        t.Rows[26].Cells[1].Paragraphs.First().Append(scoreToPrint.relayEvents[gender + " 4x100"].points[0].athleteName);
                        t.Rows[26].Cells[2].Paragraphs.First().Append(scoreToPrint.relayEvents[gender + " 4x100"].points[0].schoolName);
                        t.Rows[26].Cells[3].Paragraphs.First().Append(scoreToPrint.relayEvents[gender + " 4x100"].points[0].performance);
                        t.Rows[26].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.relayEvents[gender + " 4x100"].points[0].team1Pts));
                        t.Rows[26].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.relayEvents[gender + " 4x100"].points[0].team2Pts));
                        t.Rows[27].Cells[1].Paragraphs.First().Append(scoreToPrint.relayEvents[gender + " 4x100"].points[1].athleteName);
                        t.Rows[27].Cells[2].Paragraphs.First().Append(scoreToPrint.relayEvents[gender + " 4x100"].points[1].schoolName);
                        t.Rows[27].Cells[3].Paragraphs.First().Append(scoreToPrint.relayEvents[gender + " 4x100"].points[1].performance);
                        t.Rows[27].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.relayEvents[gender + " 4x100"].points[1].team1Pts));
                        t.Rows[27].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.relayEvents[gender + " 4x100"].points[1].team2Pts));
                        t.Rows[28].Cells[1].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.relayEvents[gender + " 4x100"].team1Total));
                        t.Rows[28].Cells[2].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.relayEvents[gender + " 4x100"].team2Total));
                    }
                    else
                    {
                        t.Rows[26].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[26].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[27].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[27].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[28].Cells[1].Paragraphs.First().Append("0");
                        t.Rows[28].Cells[2].Paragraphs.First().Append("0");
                    }
                    //4x400
                    t.Rows[26].Cells[6].Paragraphs.First().Append("1");
                    t.Rows[27].Cells[6].Paragraphs.First().Append("2");
                    t.Rows[28].MergeCells(3, 6);
                    t.Rows[28].Cells[3].RemoveParagraphAt(0);
                    t.Rows[28].Cells[3].RemoveParagraphAt(0);
                    t.Rows[28].Cells[3].RemoveParagraphAt(0);
                    t.Rows[28].Cells[3].Paragraphs.First().Append("Total");
                    t.Rows[28].Cells[3].Paragraphs.First().Alignment = Alignment.left;
                    if (scoreToPrint.relayEvents != null && scoreToPrint.relayEvents.ContainsKey(gender + " 4x400"))
                    {
                        t.Rows[26].Cells[7].Paragraphs.First().Append(scoreToPrint.relayEvents[gender + " 4x400"].points[0].athleteName);
                        t.Rows[26].Cells[8].Paragraphs.First().Append(scoreToPrint.relayEvents[gender + " 4x400"].points[0].schoolName);
                        t.Rows[26].Cells[9].Paragraphs.First().Append(scoreToPrint.relayEvents[gender + " 4x400"].points[0].performance);
                        t.Rows[26].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.relayEvents[gender + " 4x400"].points[0].team1Pts));
                        t.Rows[26].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.relayEvents[gender + " 4x400"].points[0].team2Pts));
                        t.Rows[27].Cells[7].Paragraphs.First().Append(scoreToPrint.relayEvents[gender + " 4x400"].points[1].athleteName);
                        t.Rows[27].Cells[8].Paragraphs.First().Append(scoreToPrint.relayEvents[gender + " 4x400"].points[1].schoolName);
                        t.Rows[27].Cells[9].Paragraphs.First().Append(scoreToPrint.relayEvents[gender + " 4x400"].points[1].performance);
                        t.Rows[27].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.relayEvents[gender + " 4x400"].points[1].team1Pts));
                        t.Rows[27].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.relayEvents[gender + " 4x400"].points[1].team2Pts));
                        t.Rows[27].Cells[7].Paragraphs.First().Append(scoreToPrint.relayEvents[gender + " 4x400"].points[2].athleteName);
                        t.Rows[28].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.relayEvents[gender + " 4x400"].team1Total));
                        t.Rows[28].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.relayEvents[gender + " 4x400"].team2Total));
                    }
                    else
                    {
                        t.Rows[26].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[26].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[27].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[27].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[28].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[28].Cells[5].Paragraphs.First().Append("0");
                    }

                    // Merge the cells 4x800 & Shotput Title Cells into one new cell.
                    t.Rows[29].MergeCells(0, 5);
                    t.Rows[29].MergeCells(1, 6);
                    t.Rows[29].Cells[0].RemoveParagraphAt(0);
                    t.Rows[29].Cells[0].RemoveParagraphAt(0);
                    t.Rows[29].Cells[0].RemoveParagraphAt(0);
                    t.Rows[29].Cells[0].RemoveParagraphAt(0);
                    t.Rows[29].Cells[0].RemoveParagraphAt(0);
                    t.Rows[29].Cells[1].RemoveParagraphAt(0);
                    t.Rows[29].Cells[1].RemoveParagraphAt(0);
                    t.Rows[29].Cells[1].RemoveParagraphAt(0);
                    t.Rows[29].Cells[1].RemoveParagraphAt(0);
                    t.Rows[29].Cells[1].RemoveParagraphAt(0);
                    t.Rows[29].Cells[0].Paragraphs.First().Append("4x800 Meter Relay");
                    t.Rows[29].Cells[1].Paragraphs.First().Append("Shotput");
                    t.Rows[29].Cells[0].Shading = Color.Black;
                    t.Rows[29].Cells[1].Shading = Color.Black;
                    t.Rows[30].Cells[0].Paragraphs.First().Append("#");
                    t.Rows[30].Cells[1].Paragraphs.First().Append("Athlete");
                    t.Rows[30].Cells[2].Paragraphs.First().Append("School");
                    t.Rows[30].Cells[3].Paragraphs.First().Append("Time");
                    t.Rows[30].Cells[4].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                    t.Rows[30].Cells[5].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                    t.Rows[30].Cells[6].Paragraphs.First().Append("#");
                    t.Rows[30].Cells[7].Paragraphs.First().Append("Athlete");
                    t.Rows[30].Cells[8].Paragraphs.First().Append("School");
                    t.Rows[30].Cells[9].Paragraphs.First().Append("Time");
                    t.Rows[30].Cells[10].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                    t.Rows[30].Cells[11].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                    //4x800
                    t.Rows[31].Cells[0].Paragraphs.First().Append("1");
                    t.Rows[32].Cells[0].Paragraphs.First().Append("2");
                    //t.Rows[33].Cells[0].Paragraphs.First().Append("3");
                    t.Rows[33].MergeCells(0, 3);
                    t.Rows[33].Cells[0].RemoveParagraphAt(0);
                    t.Rows[33].Cells[0].RemoveParagraphAt(0);
                    t.Rows[33].Cells[0].RemoveParagraphAt(0);
                    t.Rows[33].Cells[0].Paragraphs.First().Append("Total");
                    t.Rows[33].Cells[0].Paragraphs.First().Alignment = Alignment.left;
                    t.Rows[34].MergeCells(0, 5);
                    t.Rows[34].Cells[0].Shading = Color.Black;
                    t.Rows[34].Cells[0].RemoveParagraphAt(0);
                    t.Rows[34].Cells[0].RemoveParagraphAt(0);
                    t.Rows[34].Cells[0].RemoveParagraphAt(0);
                    t.Rows[34].Cells[0].RemoveParagraphAt(0);
                    t.Rows[34].Cells[0].RemoveParagraphAt(0);

                    if (scoreToPrint.relayEvents != null && scoreToPrint.relayEvents.ContainsKey(gender + " 4x800"))
                    {
                        t.Rows[31].Cells[1].Paragraphs.First().Append(scoreToPrint.relayEvents[gender + " 4x800"].points[0].athleteName);
                        t.Rows[31].Cells[2].Paragraphs.First().Append(scoreToPrint.relayEvents[gender + " 4x800"].points[0].schoolName);
                        t.Rows[31].Cells[3].Paragraphs.First().Append(scoreToPrint.relayEvents[gender + " 4x800"].points[0].performance);
                        t.Rows[31].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.relayEvents[gender + " 4x800"].points[0].team1Pts));
                        t.Rows[31].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.relayEvents[gender + " 4x800"].points[0].team2Pts));
                        t.Rows[32].Cells[1].Paragraphs.First().Append(scoreToPrint.relayEvents[gender + " 4x800"].points[1].athleteName);
                        t.Rows[32].Cells[2].Paragraphs.First().Append(scoreToPrint.relayEvents[gender + " 4x800"].points[1].schoolName);
                        t.Rows[32].Cells[3].Paragraphs.First().Append(scoreToPrint.relayEvents[gender + " 4x800"].points[1].performance);
                        t.Rows[32].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.relayEvents[gender + " 4x800"].points[1].team1Pts));
                        t.Rows[32].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.relayEvents[gender + " 4x800"].points[1].team2Pts));
                        t.Rows[33].Cells[1].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.relayEvents[gender + " 4x800"].team1Total));
                        t.Rows[33].Cells[2].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.relayEvents[gender + " 4x800"].team2Total));
                    }
                    else
                    {
                        t.Rows[31].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[31].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[32].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[32].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[33].Cells[1].Paragraphs.First().Append("0");
                        t.Rows[33].Cells[2].Paragraphs.First().Append("0");
                    }
                    //ShotPut
                    t.Rows[31].Cells[6].Paragraphs.First().Append("1");
                    t.Rows[32].Cells[6].Paragraphs.First().Append("2");
                    t.Rows[33].Cells[3].Paragraphs.First().Append("3");
                    t.Rows[34].MergeCells(1, 4);
                    t.Rows[34].Cells[1].RemoveParagraphAt(0);
                    t.Rows[34].Cells[1].RemoveParagraphAt(0);
                    t.Rows[34].Cells[1].RemoveParagraphAt(0);
                    t.Rows[34].Cells[1].Paragraphs.First().Append("Total");
                    t.Rows[34].Cells[1].Paragraphs.First().Alignment = Alignment.left;
                    if (scoreToPrint.indEvents != null && scoreToPrint.indEvents.ContainsKey(gender + " ShotPut"))
                    {
                        t.Rows[31].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " ShotPut"].points[0].athleteName);
                        t.Rows[31].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " ShotPut"].points[0].schoolName);
                        t.Rows[31].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " ShotPut"].points[0].performance);
                        t.Rows[31].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " ShotPut"].points[0].team1Pts));
                        t.Rows[31].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " ShotPut"].points[0].team2Pts));
                        t.Rows[32].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " ShotPut"].points[1].athleteName);
                        t.Rows[32].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " ShotPut"].points[1].schoolName);
                        t.Rows[32].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " ShotPut"].points[1].performance);
                        t.Rows[32].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " ShotPut"].points[1].team1Pts));
                        t.Rows[32].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " ShotPut"].points[1].team2Pts));
                        t.Rows[33].Cells[4].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " ShotPut"].points[2].athleteName);
                        t.Rows[33].Cells[5].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " ShotPut"].points[2].schoolName);
                        t.Rows[33].Cells[6].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " ShotPut"].points[2].performance);
                        t.Rows[33].Cells[7].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " ShotPut"].points[2].team1Pts));
                        t.Rows[33].Cells[8].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " ShotPut"].points[2].team2Pts));
                        t.Rows[34].Cells[2].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " ShotPut"].team1Total));
                        t.Rows[34].Cells[3].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " ShotPut"].team2Total));
                    }
                    else
                    {
                        t.Rows[31].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[31].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[32].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[32].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[33].Cells[7].Paragraphs.First().Append("0");
                        t.Rows[33].Cells[8].Paragraphs.First().Append("0");
                        t.Rows[34].Cells[2].Paragraphs.First().Append("0");
                        t.Rows[34].Cells[3].Paragraphs.First().Append("0");
                    }

                    // Merge the cells Discus & Javelin Title Cells into one new cell.
                    t.Rows[35].MergeCells(0, 5);
                    t.Rows[35].MergeCells(1, 6);
                    t.Rows[35].Cells[0].RemoveParagraphAt(0);
                    t.Rows[35].Cells[0].RemoveParagraphAt(0);
                    t.Rows[35].Cells[0].RemoveParagraphAt(0);
                    t.Rows[35].Cells[0].RemoveParagraphAt(0);
                    t.Rows[35].Cells[0].RemoveParagraphAt(0);
                    t.Rows[35].Cells[1].RemoveParagraphAt(0);
                    t.Rows[35].Cells[1].RemoveParagraphAt(0);
                    t.Rows[35].Cells[1].RemoveParagraphAt(0);
                    t.Rows[35].Cells[1].RemoveParagraphAt(0);
                    t.Rows[35].Cells[1].RemoveParagraphAt(0);
                    t.Rows[35].Cells[0].Paragraphs.First().Append("Discus");
                    t.Rows[35].Cells[1].Paragraphs.First().Append("Javelin");
                    t.Rows[35].Cells[0].Shading = Color.Black;
                    t.Rows[35].Cells[1].Shading = Color.Black;
                    t.Rows[36].Cells[0].Paragraphs.First().Append("#");
                    t.Rows[36].Cells[1].Paragraphs.First().Append("Athlete");
                    t.Rows[36].Cells[2].Paragraphs.First().Append("School");
                    t.Rows[36].Cells[3].Paragraphs.First().Append("Time");
                    t.Rows[36].Cells[4].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                    t.Rows[36].Cells[5].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                    t.Rows[36].Cells[6].Paragraphs.First().Append("#");
                    t.Rows[36].Cells[7].Paragraphs.First().Append("Athlete");
                    t.Rows[36].Cells[8].Paragraphs.First().Append("School");
                    t.Rows[36].Cells[9].Paragraphs.First().Append("Time");
                    t.Rows[36].Cells[10].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                    t.Rows[36].Cells[11].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                    //Discus
                    t.Rows[37].Cells[0].Paragraphs.First().Append("1");
                    t.Rows[38].Cells[0].Paragraphs.First().Append("2");
                    t.Rows[39].Cells[0].Paragraphs.First().Append("3");
                    t.Rows[40].MergeCells(0, 3);
                    t.Rows[40].Cells[0].RemoveParagraphAt(0);
                    t.Rows[40].Cells[0].RemoveParagraphAt(0);
                    t.Rows[40].Cells[0].RemoveParagraphAt(0);
                    t.Rows[40].Cells[0].Paragraphs.First().Append("Total");
                    t.Rows[40].Cells[0].Paragraphs.First().Alignment = Alignment.left;
                    if (scoreToPrint.indEvents != null && scoreToPrint.indEvents.ContainsKey(gender + " Discus"))
                    {
                        t.Rows[37].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " Discus"].points[0].athleteName);
                        t.Rows[37].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " Discus"].points[0].schoolName);
                        t.Rows[37].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " Discus"].points[0].performance);
                        t.Rows[37].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " Discus"].points[0].team1Pts));
                        t.Rows[37].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " Discus"].points[0].team2Pts));
                        t.Rows[38].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " Discus"].points[1].athleteName);
                        t.Rows[38].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " Discus"].points[1].schoolName);
                        t.Rows[38].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " Discus"].points[1].performance);
                        t.Rows[38].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " Discus"].points[1].team1Pts));
                        t.Rows[38].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " Discus"].points[1].team2Pts));
                        t.Rows[39].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " Discus"].points[2].athleteName);
                        t.Rows[39].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " Discus"].points[2].schoolName);
                        t.Rows[39].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " Discus"].points[2].performance);
                        t.Rows[39].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " Discus"].points[2].team1Pts));
                        t.Rows[39].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " Discus"].points[2].team2Pts));
                        t.Rows[40].Cells[1].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " Discus"].team1Total));
                        t.Rows[40].Cells[2].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " Discus"].team2Total));
                    }
                    else
                    {
                        t.Rows[37].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[37].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[38].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[38].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[39].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[39].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[40].Cells[1].Paragraphs.First().Append("0");
                        t.Rows[40].Cells[2].Paragraphs.First().Append("0");
                    }
                    //Javelin
                    t.Rows[37].Cells[6].Paragraphs.First().Append("1");
                    t.Rows[38].Cells[6].Paragraphs.First().Append("2");
                    t.Rows[39].Cells[6].Paragraphs.First().Append("3");
                    t.Rows[40].MergeCells(3, 6);
                    t.Rows[40].Cells[3].RemoveParagraphAt(0);
                    t.Rows[40].Cells[3].RemoveParagraphAt(0);
                    t.Rows[40].Cells[3].RemoveParagraphAt(0);
                    t.Rows[40].Cells[3].Paragraphs.First().Append("Total");
                    t.Rows[40].Cells[3].Paragraphs.First().Alignment = Alignment.left;
                    if (scoreToPrint.indEvents != null && scoreToPrint.indEvents.ContainsKey(gender + " Javelin"))
                    {
                        t.Rows[37].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " Javelin"].points[0].athleteName);
                        t.Rows[37].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " Javelin"].points[0].schoolName);
                        t.Rows[37].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " Javelin"].points[0].performance);
                        t.Rows[37].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " Javelin"].points[0].team1Pts));
                        t.Rows[37].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " Javelin"].points[0].team2Pts));
                        t.Rows[38].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " Javelin"].points[1].athleteName);
                        t.Rows[38].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " Javelin"].points[1].schoolName);
                        t.Rows[38].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " Javelin"].points[1].performance);
                        t.Rows[38].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " Javelin"].points[1].team1Pts));
                        t.Rows[38].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " Javelin"].points[1].team2Pts));
                        t.Rows[39].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " Javelin"].points[2].athleteName);
                        t.Rows[39].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " Javelin"].points[2].schoolName);
                        t.Rows[39].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " Javelin"].points[2].performance);
                        t.Rows[39].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " Javelin"].points[2].team1Pts));
                        t.Rows[39].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " Javelin"].points[2].team2Pts));
                        t.Rows[40].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " Javelin"].team1Total));
                        t.Rows[40].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " Javelin"].team2Total));
                    }
                    else
                    {
                        t.Rows[37].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[37].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[38].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[38].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[39].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[39].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[40].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[40].Cells[5].Paragraphs.First().Append("0");
                    }

                    // Merge the cells LJ & TJ Title Cells into one new cell.
                    t.Rows[41].MergeCells(0, 5);
                    t.Rows[41].MergeCells(1, 6);
                    t.Rows[41].Cells[0].RemoveParagraphAt(0);
                    t.Rows[41].Cells[0].RemoveParagraphAt(0);
                    t.Rows[41].Cells[0].RemoveParagraphAt(0);
                    t.Rows[41].Cells[0].RemoveParagraphAt(0);
                    t.Rows[41].Cells[0].RemoveParagraphAt(0);
                    t.Rows[41].Cells[1].RemoveParagraphAt(0);
                    t.Rows[41].Cells[1].RemoveParagraphAt(0);
                    t.Rows[41].Cells[1].RemoveParagraphAt(0);
                    t.Rows[41].Cells[1].RemoveParagraphAt(0);
                    t.Rows[41].Cells[1].RemoveParagraphAt(0);
                    t.Rows[41].Cells[0].Paragraphs.First().Append("Long Jump");
                    t.Rows[41].Cells[1].Paragraphs.First().Append("Triple Jump");
                    t.Rows[41].Cells[0].Shading = Color.Black;
                    t.Rows[41].Cells[1].Shading = Color.Black;
                    t.Rows[42].Cells[0].Paragraphs.First().Append("#");
                    t.Rows[42].Cells[1].Paragraphs.First().Append("Athlete");
                    t.Rows[42].Cells[2].Paragraphs.First().Append("School");
                    t.Rows[42].Cells[3].Paragraphs.First().Append("Time");
                    t.Rows[42].Cells[4].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                    t.Rows[42].Cells[5].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                    t.Rows[42].Cells[6].Paragraphs.First().Append("#");
                    t.Rows[42].Cells[7].Paragraphs.First().Append("Athlete");
                    t.Rows[42].Cells[8].Paragraphs.First().Append("School");
                    t.Rows[42].Cells[9].Paragraphs.First().Append("Time");
                    t.Rows[42].Cells[10].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                    t.Rows[42].Cells[11].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                    //LJ
                    t.Rows[43].Cells[0].Paragraphs.First().Append("1");
                    t.Rows[44].Cells[0].Paragraphs.First().Append("2");
                    t.Rows[45].Cells[0].Paragraphs.First().Append("3");
                    t.Rows[46].MergeCells(0, 3);
                    t.Rows[46].Cells[0].RemoveParagraphAt(0);
                    t.Rows[46].Cells[0].RemoveParagraphAt(0);
                    t.Rows[46].Cells[0].RemoveParagraphAt(0);
                    t.Rows[46].Cells[0].Paragraphs.First().Append("Total");
                    t.Rows[46].Cells[0].Paragraphs.First().Alignment = Alignment.left;
                    if (scoreToPrint.indEvents != null && scoreToPrint.indEvents.ContainsKey(gender + " LJ"))
                    {
                        t.Rows[43].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " LJ"].points[0].athleteName);
                        t.Rows[43].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " LJ"].points[0].schoolName);
                        t.Rows[43].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " LJ"].points[0].performance);
                        t.Rows[43].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " LJ"].points[0].team1Pts));
                        t.Rows[43].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " LJ"].points[0].team2Pts));
                        t.Rows[44].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " LJ"].points[1].athleteName);
                        t.Rows[44].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " LJ"].points[1].schoolName);
                        t.Rows[44].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " LJ"].points[1].performance);
                        t.Rows[44].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " LJ"].points[1].team1Pts));
                        t.Rows[44].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " LJ"].points[1].team2Pts));
                        t.Rows[45].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " LJ"].points[2].athleteName);
                        t.Rows[45].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " LJ"].points[2].schoolName);
                        t.Rows[45].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " LJ"].points[2].performance);
                        t.Rows[45].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " LJ"].points[2].team1Pts));
                        t.Rows[45].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " LJ"].points[2].team2Pts));
                        t.Rows[46].Cells[1].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " LJ"].team1Total));
                        t.Rows[46].Cells[2].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " LJ"].team2Total));
                    }
                    else
                    {
                        t.Rows[43].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[43].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[44].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[44].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[45].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[45].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[46].Cells[1].Paragraphs.First().Append("0");
                        t.Rows[46].Cells[2].Paragraphs.First().Append("0");
                    }
                    //TJ
                    t.Rows[43].Cells[6].Paragraphs.First().Append("1");
                    t.Rows[44].Cells[6].Paragraphs.First().Append("2");
                    t.Rows[45].Cells[6].Paragraphs.First().Append("3");
                    t.Rows[46].MergeCells(3, 6);
                    t.Rows[46].Cells[3].RemoveParagraphAt(0);
                    t.Rows[46].Cells[3].RemoveParagraphAt(0);
                    t.Rows[46].Cells[3].RemoveParagraphAt(0);
                    t.Rows[46].Cells[3].Paragraphs.First().Append("Total");
                    t.Rows[46].Cells[3].Paragraphs.First().Alignment = Alignment.left;
                    if (scoreToPrint.indEvents != null && scoreToPrint.indEvents.ContainsKey(gender + " TJ"))
                    {
                        t.Rows[43].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " TJ"].points[0].athleteName);
                        t.Rows[43].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " TJ"].points[0].schoolName);
                        t.Rows[43].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " TJ"].points[0].performance);
                        t.Rows[43].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " TJ"].points[0].team1Pts));
                        t.Rows[43].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " TJ"].points[0].team2Pts));
                        t.Rows[44].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " TJ"].points[1].athleteName);
                        t.Rows[44].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " TJ"].points[1].schoolName);
                        t.Rows[44].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " TJ"].points[1].performance);
                        t.Rows[44].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " TJ"].points[1].team1Pts));
                        t.Rows[44].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " TJ"].points[1].team2Pts));
                        t.Rows[45].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " TJ"].points[2].athleteName);
                        t.Rows[45].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " TJ"].points[2].schoolName);
                        t.Rows[45].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " TJ"].points[2].performance);
                        t.Rows[45].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " TJ"].points[2].team1Pts));
                        t.Rows[45].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " TJ"].points[2].team2Pts));
                        t.Rows[46].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " TJ"].team1Total));
                        t.Rows[46].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " TJ"].team2Total));
                    }
                    else
                    {
                        t.Rows[43].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[43].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[44].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[44].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[45].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[45].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[46].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[46].Cells[5].Paragraphs.First().Append("0");
                    }

                    // Merge the cells High Jump & Pole Vault Title Cells into one new cell.
                    t.Rows[47].MergeCells(0, 5);
                    t.Rows[47].MergeCells(1, 6);
                    t.Rows[47].Cells[0].RemoveParagraphAt(0);
                    t.Rows[47].Cells[0].RemoveParagraphAt(0);
                    t.Rows[47].Cells[0].RemoveParagraphAt(0);
                    t.Rows[47].Cells[0].RemoveParagraphAt(0);
                    t.Rows[47].Cells[0].RemoveParagraphAt(0);
                    t.Rows[47].Cells[1].RemoveParagraphAt(0);
                    t.Rows[47].Cells[1].RemoveParagraphAt(0);
                    t.Rows[47].Cells[1].RemoveParagraphAt(0);
                    t.Rows[47].Cells[1].RemoveParagraphAt(0);
                    t.Rows[47].Cells[1].RemoveParagraphAt(0);
                    t.Rows[47].Cells[0].Paragraphs.First().Append("High Jump");
                    t.Rows[47].Cells[1].Paragraphs.First().Append("Pole Vault");
                    t.Rows[47].Cells[0].Shading = Color.Black;
                    t.Rows[47].Cells[1].Shading = Color.Black;
                    t.Rows[48].Cells[0].Paragraphs.First().Append("#");
                    t.Rows[48].Cells[1].Paragraphs.First().Append("Athlete");
                    t.Rows[48].Cells[2].Paragraphs.First().Append("School");
                    t.Rows[48].Cells[3].Paragraphs.First().Append("Time");
                    t.Rows[48].Cells[4].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                    t.Rows[48].Cells[5].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                    t.Rows[48].Cells[6].Paragraphs.First().Append("#");
                    t.Rows[48].Cells[7].Paragraphs.First().Append("Athlete");
                    t.Rows[48].Cells[8].Paragraphs.First().Append("School");
                    t.Rows[48].Cells[9].Paragraphs.First().Append("Time");
                    t.Rows[48].Cells[10].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                    t.Rows[48].Cells[11].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                    //HJ
                    t.Rows[49].Cells[0].Paragraphs.First().Append("1");
                    t.Rows[50].Cells[0].Paragraphs.First().Append("2");
                    t.Rows[51].Cells[0].Paragraphs.First().Append("3");
                    t.Rows[52].MergeCells(0, 3);
                    t.Rows[52].Cells[0].RemoveParagraphAt(0);
                    t.Rows[52].Cells[0].RemoveParagraphAt(0);
                    t.Rows[52].Cells[0].RemoveParagraphAt(0);
                    t.Rows[52].Cells[0].Paragraphs.First().Append("Total");
                    t.Rows[52].Cells[0].Paragraphs.First().Alignment = Alignment.left;
                    if (scoreToPrint.indEvents != null && scoreToPrint.indEvents.ContainsKey(gender + " HJ"))
                    {
                        t.Rows[49].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " HJ"].points[0].athleteName);
                        t.Rows[49].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " HJ"].points[0].schoolName);
                        t.Rows[49].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " HJ"].points[0].performance);
                        t.Rows[49].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " HJ"].points[0].team1Pts));
                        t.Rows[49].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " HJ"].points[0].team2Pts));
                        t.Rows[50].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " HJ"].points[1].athleteName);
                        t.Rows[50].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " HJ"].points[1].schoolName);
                        t.Rows[50].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " HJ"].points[1].performance);
                        t.Rows[50].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " HJ"].points[1].team1Pts));
                        t.Rows[50].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " HJ"].points[1].team2Pts));
                        t.Rows[51].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " HJ"].points[2].athleteName);
                        t.Rows[51].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " HJ"].points[2].schoolName);
                        t.Rows[51].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " HJ"].points[2].performance);
                        t.Rows[51].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " HJ"].points[2].team1Pts));
                        t.Rows[51].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " HJ"].points[2].team2Pts));
                        t.Rows[52].Cells[1].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " HJ"].team1Total));
                        t.Rows[52].Cells[2].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " HJ"].team2Total));
                    }
                    else
                    {
                        t.Rows[49].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[49].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[50].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[50].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[51].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[51].Cells[5].Paragraphs.First().Append("0");
                        t.Rows[52].Cells[1].Paragraphs.First().Append("0");
                        t.Rows[52].Cells[2].Paragraphs.First().Append("0");
                    }
                    //PV
                    t.Rows[49].Cells[6].Paragraphs.First().Append("1");
                    t.Rows[50].Cells[6].Paragraphs.First().Append("2");
                    t.Rows[51].Cells[6].Paragraphs.First().Append("3");
                    t.Rows[52].MergeCells(3, 6);
                    t.Rows[52].Cells[3].RemoveParagraphAt(0);
                    t.Rows[52].Cells[3].RemoveParagraphAt(0);
                    t.Rows[52].Cells[3].RemoveParagraphAt(0);
                    t.Rows[52].Cells[3].Paragraphs.First().Append("Total");
                    t.Rows[52].Cells[3].Paragraphs.First().Alignment = Alignment.left;
                    if (scoreToPrint.indEvents != null && scoreToPrint.indEvents.ContainsKey(gender + " PV"))
                    {
                        t.Rows[49].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " PV"].points[0].athleteName);
                        t.Rows[49].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " PV"].points[0].schoolName);
                        t.Rows[49].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " PV"].points[0].performance);
                        t.Rows[49].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " PV"].points[0].team1Pts));
                        t.Rows[49].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " PV"].points[0].team2Pts));
                        t.Rows[50].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " PV"].points[1].athleteName);
                        t.Rows[50].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " PV"].points[1].schoolName);
                        t.Rows[50].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " PV"].points[1].performance);
                        t.Rows[50].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " PV"].points[1].team1Pts));
                        t.Rows[50].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " PV"].points[1].team2Pts));
                        t.Rows[51].Cells[7].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " PV"].points[2].athleteName);
                        t.Rows[51].Cells[8].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " PV"].points[2].schoolName);
                        t.Rows[51].Cells[9].Paragraphs.First().Append(scoreToPrint.indEvents[gender + " PV"].points[2].performance);
                        t.Rows[51].Cells[10].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " PV"].points[2].team1Pts));
                        t.Rows[51].Cells[11].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " PV"].points[2].team2Pts));
                        t.Rows[52].Cells[4].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " PV"].team1Total));
                        t.Rows[52].Cells[5].Paragraphs.First().Append(string.Format("{0:0.##}", scoreToPrint.indEvents[gender + " PV"].team2Total));
                    }
                    else
                    {
                        t.Rows[49].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[49].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[50].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[50].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[51].Cells[10].Paragraphs.First().Append("0");
                        t.Rows[51].Cells[11].Paragraphs.First().Append("0");
                        t.Rows[52].Cells[4].Paragraphs.First().Append("0");
                        t.Rows[52].Cells[5].Paragraphs.First().Append("0");
                    }

                    //Cell Fonts
                    int eventNames = 11;
                    int titleRows = 10;
                    int dataRows = 8;
                    int scoreRows = 10;

                    t.Rows[0].Cells[0].Paragraphs.First().FontSize(eventNames);
                    t.Rows[0].Cells[1].Paragraphs.First().FontSize(eventNames);
                    for(int i = 0; i <= 11; i++) t.Rows[1].Cells[i].Paragraphs.First().FontSize(titleRows);
                    for (int i = 0; i <= 11; i++) t.Rows[2].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 11; i++) t.Rows[3].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 11; i++) t.Rows[4].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 5; i++) t.Rows[5].Cells[i].Paragraphs.First().FontSize(scoreRows);
                    t.Rows[6].Cells[0].Paragraphs.First().FontSize(eventNames);
                    t.Rows[6].Cells[1].Paragraphs.First().FontSize(eventNames);
                    for(int i = 0; i <= 11; i++) t.Rows[7].Cells[i].Paragraphs.First().FontSize(titleRows);
                    for (int i = 0; i <= 11; i++) t.Rows[8].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 11; i++) t.Rows[9].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 11; i++) t.Rows[10].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 5; i++) t.Rows[11].Cells[i].Paragraphs.First().FontSize(scoreRows);
                    t.Rows[12].Cells[0].Paragraphs.First().FontSize(eventNames);
                    t.Rows[12].Cells[1].Paragraphs.First().FontSize(eventNames);
                    for(int i = 0; i <= 11; i++) t.Rows[13].Cells[i].Paragraphs.First().FontSize(titleRows);
                    for (int i = 0; i <= 11; i++) t.Rows[14].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 11; i++) t.Rows[15].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 11; i++) t.Rows[16].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 5; i++) t.Rows[17].Cells[i].Paragraphs.First().FontSize(scoreRows);
                    t.Rows[18].Cells[0].Paragraphs.First().FontSize(eventNames);
                    t.Rows[18].Cells[1].Paragraphs.First().FontSize(eventNames);
                    for(int i = 0; i <= 11; i++) t.Rows[19].Cells[i].Paragraphs.First().FontSize(titleRows);
                    for (int i = 0; i <= 11; i++) t.Rows[20].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 11; i++) t.Rows[21].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 11; i++) t.Rows[22].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 5; i++) t.Rows[23].Cells[i].Paragraphs.First().FontSize(scoreRows);
                    t.Rows[24].Cells[0].Paragraphs.First().FontSize(eventNames);
                    t.Rows[24].Cells[1].Paragraphs.First().FontSize(eventNames);
                    for(int i = 0; i <= 11; i++) t.Rows[25].Cells[i].Paragraphs.First().FontSize(titleRows);
                    for (int i = 0; i <= 11; i++) t.Rows[26].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 11; i++) t.Rows[27].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 5; i++) t.Rows[28].Cells[i].Paragraphs.First().FontSize(scoreRows);
                    t.Rows[29].Cells[0].Paragraphs.First().FontSize(eventNames);
                    t.Rows[29].Cells[1].Paragraphs.First().FontSize(eventNames);
                    for(int i = 0; i <= 11; i++) t.Rows[30].Cells[i].Paragraphs.First().FontSize(titleRows);
                    for (int i = 0; i <= 11; i++) t.Rows[31].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 11; i++) t.Rows[32].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 2; i++) t.Rows[33].Cells[i].Paragraphs.First().FontSize(scoreRows);
                    for (int i = 3; i <= 8; i++) t.Rows[33].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 3; i++) t.Rows[34].Cells[i].Paragraphs.First().FontSize(scoreRows);
                    t.Rows[35].Cells[0].Paragraphs.First().FontSize(eventNames);
                    t.Rows[35].Cells[1].Paragraphs.First().FontSize(eventNames);
                    for(int i = 0; i <= 11; i++) t.Rows[36].Cells[i].Paragraphs.First().FontSize(titleRows);
                    for (int i = 0; i <= 11; i++) t.Rows[37].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 11; i++) t.Rows[38].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 11; i++) t.Rows[39].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 5; i++) t.Rows[40].Cells[i].Paragraphs.First().FontSize(scoreRows);
                    t.Rows[41].Cells[0].Paragraphs.First().FontSize(eventNames);
                    t.Rows[41].Cells[1].Paragraphs.First().FontSize(eventNames);
                    for(int i = 0; i <= 11; i++) t.Rows[42].Cells[i].Paragraphs.First().FontSize(titleRows);
                    for (int i = 0; i <= 11; i++) t.Rows[43].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 11; i++) t.Rows[44].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 11; i++) t.Rows[45].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 5; i++) t.Rows[46].Cells[i].Paragraphs.First().FontSize(scoreRows);
                    t.Rows[47].Cells[0].Paragraphs.First().FontSize(eventNames);
                    t.Rows[47].Cells[1].Paragraphs.First().FontSize(eventNames);
                    for(int i = 0; i <= 11; i++) t.Rows[48].Cells[i].Paragraphs.First().FontSize(titleRows);
                    for (int i = 0; i <= 11; i++) t.Rows[49].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 11; i++) t.Rows[50].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 11; i++) t.Rows[51].Cells[i].Paragraphs.First().FontSize(dataRows);
                    for (int i = 0; i <= 5; i++) t.Rows[52].Cells[i].Paragraphs.First().FontSize(scoreRows);

                    document.InsertTable(t);

                    Paragraph ppp = document.InsertParagraph();
                    ppp.Append("\nFinal Score:\n").FontSize(12).Bold();
                    ppp.Append(scoreToPrint.team1.Item2 + ": " + string.Format("{0:0.##}", scoreToPrint.team1Points) + "\n").FontSize(12).Bold();
                    ppp.Append(scoreToPrint.team2.Item2 + ": " + string.Format("{0:0.##}", scoreToPrint.team2Points) + "\n").FontSize(12).Bold();

                    document.Save();
                    System.Diagnostics.Process.Start(fileName);
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error creating team points printout");
                Console.WriteLine(ioe);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Implementation for creating a doc of all performances for one specific team
        /// </summary>
        /// <param name="teamAbbr">Team to be printed</param>
        /// <param name="meetToPrint">Meet that the performances are being gathered from</param>
        /// <returns>boolean that shows whether or not the doc was created successfully or not</returns>
        public bool CreateTeamPerfDoc(string teamAbbr, string gender, Meet meetToPrint)
        {
            Dictionary<string, List<Performance>> performances = new Dictionary<string, List<Performance>>();
            //go thru each event in meetToPrint
            foreach(string evt in meetToPrint.performances.Keys)
            {
                //go thru and add performances with the teamAbbr to the temp list
                List<Performance> tempPerfs = new List<Performance>();
                foreach(Performance p in meetToPrint.performances[evt])
                {
                    if(p.schoolName == teamAbbr)
                    {
                        tempPerfs.Add(p);
                    }
                }

                //Add tempList to performances
                if(tempPerfs != null && tempPerfs.Count > 0) //Cannot add a null value to a dictionary key
                    performances.Add(evt, tempPerfs);
            } //The above SHOULD be complete. Still untested

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < gender.Length; i++)
            {
                if (char.IsLetterOrDigit(gender[i]))
                {
                    sb.Append(gender[i]);
                }
            }

            Directory.CreateDirectory("printouts\\teamperfs");
            string fileName = "printouts\\teamperfs\\" + teamAbbr + "-" + sb.ToString() + "-" + meetToPrint.dateOfMeet.Month + "-" + meetToPrint.dateOfMeet.Day + "Performances.docx";
            try
            {
                using (DocX document = DocX.Create(fileName))
                {
                    document.MarginLeft = 36; //.5 Margin
                    document.MarginRight = 36;
                    document.MarginTop = 36;
                    document.MarginBottom = 36;

                    Paragraph pp = document.InsertParagraph();

                    // Append some text.
                    pp.Append(teamAbbr + " Performances\n\n").Font(new FontFamily("Arial Black"));

                    Paragraph[] p = new Paragraph[18];
                    Paragraph[] noPerf = new Paragraph[18];
                    Table[] perfs = new Table[18];


                    if (performances != null)
                    {
                        EventMgr eMgr = new EventMgr();

                        string[] validEvents = {gender + " 100", gender + " 200", gender + " 400",
                    gender + " 800", gender + " 1600", gender + " 3200", gender + " HH", gender + " 300H", gender + " 4x100",
                    gender + " 4x400", gender + " 4x800", gender + " LJ", gender + " TJ", gender + " HJ",
                    gender + " PV", gender + " ShotPut", gender + " Discus", gender + " Javelin"};

                        //foreach (string evt in validEvents)
                        for (int i = 0; i < validEvents.Length; i++)
                        {
                            //Print event name
                            p[i] = document.InsertParagraph();
                            p[i].Append("\n\n" + validEvents[i] + ":\n").Bold();

                            //Print table of performances
                            if (!performances.ContainsKey(validEvents[i])) //If key does not exist, the team did not compete in this event
                            {
                                noPerf[i] = document.InsertParagraph();
                                noPerf[i].Append("Event not competed in by this team");
                            }
                            //Check if running or field event
                            else
                            {
                                List<Performance> tempEventList = performances[validEvents[i]]; //new List<Performance>();
                                if (tempEventList[0].heatNum != 0) //running event
                                {
                                    tempEventList = tempEventList.OrderBy(o => o.performance).ToList(); //Order list by best-worst performance
                                    perfs[i] = document.AddTable(tempEventList.Count + 1, 4);
                                    // Specify some properties for this Table.
                                    perfs[i].Alignment = Alignment.center;
                                    perfs[i].Design = TableDesign.TableNormal;

                                    //t.Rows[0].Cells[0].FillColor = Color.Azure;
                                    //t.Rows[0].Cells[0].Paragraphs.First().Append("#").Font(new FontFamily("Arial Black"));
                                    perfs[i].Rows[0].Cells[0].Paragraphs.First().Append("#").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                                    perfs[i].Rows[0].Cells[1].Paragraphs.First().Append("Athlete").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                                    perfs[i].Rows[0].Cells[2].Paragraphs.First().Append("Performance").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                                    perfs[i].Rows[0].Cells[3].Paragraphs.First().Append("Heat").Bold().UnderlineStyle(UnderlineStyle.singleLine);

                                    for (int j = 0; j < tempEventList.Count; j++)
                                    {
                                        perfs[i].Rows[j + 1].Cells[0].Paragraphs.First().Append((j + 1).ToString());
                                        perfs[i].Rows[j + 1].Cells[1].Paragraphs.First().Append(tempEventList[j].athleteName);
                                        perfs[i].Rows[j + 1].Cells[2].Paragraphs.First().Append(eMgr.ConvertToTimedData(tempEventList[j].performance));
                                        perfs[i].Rows[j + 1].Cells[3].Paragraphs.First().Append(tempEventList[j].heatNum.ToString());
                                    }

                                    document.InsertTable(perfs[i]);
                                }
                                else // field event
                                {
                                    tempEventList = tempEventList.OrderByDescending(o => o.performance).ToList(); //Order list by best-worst performance
                                    perfs[i] = document.AddTable(tempEventList.Count + 1, 3);
                                    // Specify some properties for this Table.
                                    perfs[i].Alignment = Alignment.center;
                                    perfs[i].Design = TableDesign.TableNormal;

                                    //t.Rows[0].Cells[0].FillColor = Color.Azure;
                                    //t.Rows[0].Cells[0].Paragraphs.First().Append("#").Font(new FontFamily("Arial Black"));
                                    perfs[i].Rows[0].Cells[0].Paragraphs.First().Append("#").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                                    perfs[i].Rows[0].Cells[1].Paragraphs.First().Append("Athlete").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                                    perfs[i].Rows[0].Cells[2].Paragraphs.First().Append("Performance").Bold().UnderlineStyle(UnderlineStyle.singleLine);

                                    for (int j = 0; j < tempEventList.Count; j++)
                                    {
                                        perfs[i].Rows[j + 1].Cells[0].Paragraphs.First().Append((j + 1).ToString());
                                        perfs[i].Rows[j + 1].Cells[1].Paragraphs.First().Append(tempEventList[j].athleteName);
                                        perfs[i].Rows[j + 1].Cells[2].Paragraphs.First().Append(eMgr.ConvertToLengthData(tempEventList[j].performance));
                                    }

                                    document.InsertTable(perfs[i]);
                                }
                            }
                            //Enter some blank Space for next event
                            //Might not be needed

                        }
                        // Save the document.
                        document.Save();
                        System.Diagnostics.Process.Start(fileName);
                    }
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error creating team performance printout");
                Console.WriteLine(ioe);
                return false;
            }
            return true;
        }
    }
}

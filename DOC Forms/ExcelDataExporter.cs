using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Windows;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using Application = System.Windows.Application;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;
using Style = System.Windows.Style;

namespace DOC_Forms
{
    public static class ExcelDataExporter
    {
        private static ExcelApplication _application;
        private static Workbook _workbook;
        private static Worksheet _worksheet;
        private static int _curRow = 0;
        private static int _minCol = 0;
        private static int _maxCol = 9;
        private static int Heading1FontSize = 20;
        private static int Heading2FontSize = 16;
        private static int Heading3FontSize = 14;
        private static int SubHeadingFontSize = 12;
        private static int TextFontSize = 12;
        private static int _columnWidth = 16;
        private static int _lastCol = _maxCol - _minCol + 1;

        public const XlRgbColor BarColor = XlRgbColor.rgbCornflowerBlue;

        public static void ExportData(IEpicForm form)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save excel export";
            saveFileDialog.DefaultExt = ".xlsx";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.AddExtension = true;

            if ((saveFileDialog.ShowDialog() != true)) return;

            _application = new ExcelApplication();
            _application.DisplayAlerts = false;
            _application.Visible = false;
            _application.Workbooks.Add();

            _workbook = _application.ActiveWorkbook;
            _worksheet = (Worksheet) _application.ActiveSheet;
            _worksheet.PageSetup.FitToPagesWide = 1;
            Range rng = GetRange(_minCol, 1, _maxCol, 1);
            rng.ColumnWidth = _columnWidth;

            _curRow = 1;

            foreach (IPageViewModel page in form.GetPages())
            {
                ExportPage((dynamic) page);
            }

            _workbook.SaveAs(saveFileDialog.FileName);
            _application.Quit();
            MessageBox.Show("Export Complete!");
        }

        private static void ExportPage(IPageViewModel page)
        {
            //TODO: Finish all pages
            Console.WriteLine("No export function for page....");
        }

        /// <summary>
        /// Page 1
        /// </summary>
        /// <param name="page"></param>
        private static void ExportPage(Page1ViewModel page)
        {
            Range rng = GetRange(_minCol, _curRow, _maxCol, _curRow);
            rng.Cells.Font.Size = 18;
            rng.Cells.Font.Bold = true;
            rng.Merge();
            rng.Value = "EPICS CODING FORM";
            rng.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            ++_curRow;

            // Session Info
            OutputBlackWhiteHeading("Session Information");

            OutputNormalText("Session date: " + page.SessionDate.ToString("d"),0,2);
            OutputNormalText("Staff name: " + page.StaffName,2,3);
            ++_curRow;
            OutputNormalText("Review date: " + page.ReviewDate.ToString("d"), 0, 2);
            OutputNormalText("Reviewer's name: " + page.ReviewName, 2, 3);
            ++_curRow;
            OutputNormalText("Caseload number: " + page.CaseloadNumber, 0, 2);
            OutputNormalText("Client's name: " + page.ClientName, 2, 3);
            ++_curRow;
            OutputNormalText("Session Length: " + page.SessionLength, 0, 2);
            OutputNormalText("Client SID#: " + page.ClientSID, 2, 3);
            ++_curRow;

            // Additional info
            OutputNormalText("Client DOB: " + page.ClientDOB.ToString("d"), 0, 2);
            string temp = page.GenderMale ? "Male" : page.GenderFemale ? "Female" : page.GenderOtherText;
            OutputNormalText("Client gender: " + temp, 2, 3);
            ++_curRow;
            OutputNormalText("Client race: " + page.Race);
            ++_curRow;
            temp = page.FirstMeetingYes ? "Yes" : page.FirstMeetingNo ? "No" : "N/A";
            OutputNormalText("Was the client's first meeting with this staff person? " + temp);
            ++_curRow;
            temp = page.ClientHomelessYes ? "Yes" : page.ClientHomelessNo ? "No" : "N/A";
            OutputNormalText("Was the client homeless at the time of the session? " + temp);
            ++_curRow;
            temp = page.ClientAgressiveYes ? "Yes" : page.ClientAgressiveNo ? "No" : "N/A";
            OutputNormalText("Did the client seem to be in a state of agitation, crisis, or acute need? " + temp);
            ++_curRow;
            // Rating summary
            OutputBlackWhiteHeading("RATING QUICK SUMMARY");
            OutputHeading3Text("Section", 0, 2);
            OutputHeading3Text("Score", 2, 1);
            OutputHeading3Text("Summary", 3, 3);
            OutputHeading3Text("Score", 6, 2);
            ++_curRow;
            OutputHeading3Text("CHECK IN (C)",0,2);
            OutputNormalText(page.CheckInScore,2,1);
            OutputHeading3Text("OVERALL SESSION SCORE (Sum of all section scores)", 3, 3);
            OutputNormalText(page.OverallScore, 6, 1);
            ++_curRow;
            OutputHeading3Text("REVIEW (R)", 0, 2);
            OutputNormalText(page.ReviewScore, 2, 1);
            ++_curRow;
            OutputHeading3Text("INTERVENTION (I)", 0, 2);
            OutputNormalText(page.InterventionScore, 2, 1);
            OutputHeading3Text("SUM OF SCORES >= 2", 3, 3);
            OutputNormalText(page.PercentHighEPICS, 6, 1);
            ++_curRow;
            OutputHeading3Text("HOMEWORK (H)", 0, 2);
            OutputNormalText(page.HomeworkScore, 2, 1);
            ++_curRow;
            OutputHeading3Text("BEHAVIORAL PRACTICES", 0, 2);
            OutputNormalText(page.BehavioralScore, 2, 1);
            OutputHeading3Text("SUM OF SCORES < 2", 3, 3);
            OutputNormalText(page.PercentLowEPICS, 6, 1);
            ++_curRow;
            OutputHeading3Text("GLOBAL PRACTICES", 0, 2);
            OutputNormalText(page.GlobalScore, 2, 1);
            ++_curRow;
            OutputHeading3Text("Top staff strengths: ", 0, 3);
            OutputNormalText(page.TopStaffStrengths, 3, _maxCol+1);
            ++_curRow;
            OutputHeading3Text("Top staff strength improvements: ", 0, 3);
            OutputNormalText(page.TopStaffImprovements, 3, _maxCol+1);
            ++_curRow;
            OutputBlueSubHeading($"Completed {page.CompletedEpics} EPICS sessions out of {page.PercentEpicsCompleted} office visits in last 6 months = {page.PercentEpicsCompleted}");
            OutputHeading3Text("Next tape is due: ", 0, 3);
            OutputNormalText(page.NextTapeDueDate.ToString("d"), 3, 1);
            ++_curRow;
            OutputBlueSubHeading("Additional comments:");
            OutputNormalText(page.AdditionalCommentsText);
            ++_curRow;
            
            ++_curRow;
        }

        /// <summary>
        /// Page 2 export
        /// </summary>
        /// <param name="page"></param>
        static void ExportPage(Page2ViewModel page)
        {
            OutputBlackWhiteHeading(page.SectionText[0]);
            OutputBlueHeading3(page.SectionText[1],0,6);
            OutputBlueHeading3(page.SectionText[2],6,2);
            OutputBlueHeading3(page.SectionText[3],8,2);
            SetHeight(40);
            ++_curRow;

            for (int i = 4; i <= 12; ++i)
            {
                OutputNormalText(page.SectionText[i],0,6); // needs

                if (page.Section1Bools[i - 4][0])
                {
                    OutputNormalText("First Plan", 6, 1);
                }
                if (page.Section1Bools[i - 4][1])
                {
                    OutputNormalText("Second Plan", 7, 1);
                }
                if (page.Section1Bools[i - 4][2])
                {
                    OutputNormalText("First Plan", 8, 1);
                }
                if (page.Section1Bools[i - 4][3])
                {
                    OutputNormalText("Second Plan", 9, 1);
                }
                ++_curRow;
            }
            ++_curRow;
            OutputBlackBlueHeading("");
            --_curRow;
            OutputBlueHeading3("Yes",7,1);
            OutputBlueHeading3("No",8,1);
            OutputBlueHeading3("N/A",9,1);
            ++_curRow;

            for (int i = 13; i <= 21; ++i)
            {
                OutputNormalText(page.SectionText[i], 0, 6); // needs

                if (page.Section2Bools[i - 13][0])
                {
                    OutputNormalText("Yes", 6, 1);
                }
                else if (page.Section2Bools[i - 13][1])
                {
                    OutputNormalText("No", 6, 1);
                }
                else if (page.Section2Bools[i - 13][2])
                {
                    OutputNormalText("N/A", 6, 1);
                }
                ++_curRow;
            }
            OutputNormalText(page.SectionText[22],0,4);
            if (page.Section2Bools[10][0])
            {
                OutputNormalText(page.SectionText[23],4,2);
            }
            if (page.Section2Bools[9][0])
            {
                OutputNormalText("Yes", 6, 1);
            }
            else if (page.Section2Bools[9][1])
            {
                OutputNormalText("No", 6, 1);
            }
            else if (page.Section2Bools[9][2])
            {
                OutputNormalText("N/A", 6, 1);
            }
            ++_curRow;
            ++_curRow;
            OutputColoredHeading3(XlRgbColor.rgbLimeGreen, page.SectionText[24],0,_maxCol-_minCol+1);
            ++_curRow;
            OutputNormalText(page.Section1Comments);
            ++_curRow;
            ++_curRow;
            // Section2

            OutputBlackWhiteHeading(page.SectionText[25]);
            OutputNormalText(page.Quarterlies);
            ++_curRow;
            ++_curRow;

            OutputBlackWhiteHeading(page.SectionText[26]);
            OutputNormalText(page.SectionText[27] + " " + page.LastGoals);
            ++_curRow;
            OutputNormalText(page.SectionText[28] + " " + page.CurrentGoals);
            ++_curRow;
            ++_curRow;
        }

        /// <summary>
        /// Page 3
        /// </summary>
        /// <param name="page"></param>
        private static void ExportPage(Page3ViewModel page)
        {
            OutputBlackWhiteHeading(page.TextArray[0]);
            OutputHeading3Text(page.TextArray[1], 0, 2);
            OutputNormalText(page.CheckInTextInput[0],2,4);
            

            // row data
            var choices = new []{"N/A","0", "1", "2", "3", "4"};
            for (int i = 7; i <= 9; i++)
            {
                OutputNormalText(page.TextArray[i],0,5);

                for (int choice = 0; choice < choices.Length-1; choice++)
                {
                    if (page.Section1Bools[i - 7][choice])
                    {
                        OutputNormalText(choices[choice+1], 5, 1);
                        break;
                    }
                }
                ++_curRow;
            }

            //total
            OutputHeading3Text(page.TextArray[10],0,5);
            OutputColoredHeading3(XlRgbColor.rgbLimeGreen, page.TotalScores[0].Val.ToString(),5,1);
            ++_curRow;

            //comments
            OutputBlueHeading3("Comments",0,_maxCol+1);
            ++_curRow;
            OutputNormalText(page.Comments[0]);
            ++_curRow;
            ++_curRow;

            // Section 2

            OutputBlackWhiteHeading(page.TextArray[11]);
            OutputHeading3Text(page.TextArray[12], 0, 1);
            OutputNormalText(page.ReviewTextInput[0], 1, 2);
            OutputHeading3Text(page.TextArray[13], 3, 1);
            OutputNormalText(page.ReviewTextInput[1], 4, 2);
            

            //rows
            for (int i = 19; i <= 22; i++)
            {
                OutputNormalText(page.TextArray[i], 0, 5);

                for (int choice = 0; choice < choices.Length; choice++)
                {
                    if (page.Section2Bools[i - 19][choice])
                    {
                        OutputNormalText(choices[choice], 5, 1);
                        break;
                    }
                }
                ++_curRow;
            }

            //total
            OutputHeading3Text(page.TextArray[23], 0, 5);
            OutputColoredHeading3(XlRgbColor.rgbLimeGreen, page.TotalScores[1].Val.ToString(), 5, 1);
            ++_curRow;

            //comments
            OutputBlueHeading3("Comments", 0, _maxCol + 1);
            ++_curRow;
            OutputNormalText(page.Comments[1]);
            ++_curRow;
            ++_curRow;

            // section 3

            OutputBlackWhiteHeading(page.TextArray[24]);
            OutputHeading3Text(page.TextArray[26], 0, 2);
            OutputNormalText(page.InterventionTextInput[0], 2, 3);
            OutputHeading3Text(page.TextArray[27], 5, 2);
            OutputNormalText(page.InterventionTextInput[1], 7, 3);
            ++_curRow;
            OutputHeading3Text(page.TextArray[28], 0, 2);
            OutputNormalText(page.InterventionTextInput[2], 2, 3);
            OutputHeading3Text(page.TextArray[29], 5, 2);
            OutputNormalText(page.InterventionTextInput[3], 7, 3);
            ++_curRow;
            OutputHeading3Text(page.TextArray[30], 0, 2);
            OutputNormalText(page.InterventionTextInput[4], 2, 3);

            //rows
            for (int i = 31; i <= 33; i++)
            {
                OutputNormalText(page.TextArray[i], 0, 5);

                for (int choice = 1; choice < choices.Length; choice++)
                {
                    if (page.Section3Bools[i - 31][choice-1])
                    {
                        OutputNormalText(choices[choice], 5, 1);
                        break;
                    }
                }
                ++_curRow;
            }

            //total
            OutputHeading3Text(page.TextArray[34], 0, 5);
            OutputColoredHeading3(XlRgbColor.rgbLimeGreen, page.TotalScores[2].Val.ToString(), 5, 1);
            ++_curRow;

            //comments
            OutputBlueHeading3("Comments", 0, _maxCol + 1);
            ++_curRow;
            OutputNormalText(page.Comments[2]);
            ++_curRow;


            ++_curRow;
        }

        /// <summary>
        /// Page 4
        /// </summary>
        /// <param name="page"></param>
        private static void ExportPage(Page4ViewModel page)
        {
            OutputBlackBlueHeading(page.TextArray[0]);

            if (page.SectionBools[0][0])
            {
                OutputNormalText(page.TextArray[1], 0, _maxCol+1);
                ++_curRow;
            }
            if (page.SectionBools[0][1])
            {
                OutputNormalText(page.TextArray[2], 0, _maxCol+1);
                ++_curRow;
            }
            if (page.SectionBools[0][2])
            {
                OutputNormalText(page.TextArray[3], 0, _maxCol+1);
                // extra stuff here
                int col = 5;
                for (int i = 0; i < 5; ++i)
                {
                    if(page.SectionBools[0][3+i])
                        OutputNormalText(page.OptionText[i],col++,1);
                }
                ++_curRow;
            }
            if (page.SectionBools[0][8])
            {
                OutputNormalText(page.TextArray[4], 0, _maxCol+1);
                ++_curRow;
            }
            if (page.SectionBools[0][9])
            {
                OutputNormalText(page.TextArray[5], 0, _maxCol+1);
                ++_curRow;
            }
            if (page.SectionBools[0][10])
            {
                int col = 5;
                OutputNormalText(page.TextArray[6], 0, col);
                ++_curRow;
                // extra stuff here
                for (int i = 0; i < 5; ++i)
                {
                    if (page.SectionBools[0][11 + i])
                        OutputNormalText(page.OptionText[i], col++, 1);
                }
                ++_curRow;
            }
            ++_curRow;

            // Section 2
            OutputBlackBlueHeading(page.TextArray[12]);

            if (page.SectionBools[1][0])
            {
                OutputNormalText(page.TextArray[13], 0, _maxCol+1);
                ++_curRow;
            }
            if (page.SectionBools[1][1])
            {
                OutputNormalText(page.TextArray[14], 0, _maxCol+1);
                ++_curRow;
            }
            if (page.SectionBools[1][2])
            {
                OutputNormalText(page.TextArray[15], 0, _maxCol+1);
                ++_curRow;
            }
            if (page.SectionBools[0][3])
            {
                int col = 5;
                OutputNormalText(page.TextArray[16], 0, col);
                ++_curRow;
                // extra stuff here
                for (int i = 0; i < 5; ++i)
                {
                    if (page.SectionBools[0][4 + i])
                        OutputNormalText(page.OptionText[i], col++, 1);
                }
                ++_curRow;
            }
            if (page.SectionBools[1][9])
            {
                OutputNormalText(page.TextArray[17], 0, _maxCol+1);
                ++_curRow;
            }
            ++_curRow;

            //Section 3
            OutputBlackBlueHeading(page.TextArray[18],3,page.TextArray[19]);

            for (int i = 0; i < page.SectionBools[2].Length; ++i)
            {
                var obsBool = page.SectionBools[2][i];
                if (obsBool)
                {
                    OutputNormalText(page.TextArray[20+i], 0, _maxCol+1);
                    ++_curRow;
                }
            }
            ++_curRow;

            //Section 4

            OutputBlackBlueHeading(page.TextArray[28]);


            for (int i = 0; i < 2; ++i)
            {
                var obsBool = page.SectionBools[3][i];
                if (obsBool)
                {
                    OutputNormalText(page.TextArray[29 + i], 0, _maxCol+1);
                    ++_curRow;
                }
            }

            if (page.SectionBools[3][2])
            {
                int col = 5;
                OutputNormalText(page.TextArray[31],_minCol,col);
                for (int i = 0; i < 4; ++i)
                {
                    if (page.SectionBools[3][3 + i])
                        OutputNormalText(page.OptionText[5+i], col++, 1);
                }
                ++_curRow;
            }

            for (int i = 7; i < 11; ++i)
            {
                var obsBool = page.SectionBools[3][i];
                if (obsBool)
                {
                    OutputNormalText(page.TextArray[25 + i], 0, _maxCol+1);
                    ++_curRow;
                }
            }
            ++_curRow;
            ++_curRow;
        }


        /// <summary>
        /// Page 5
        /// </summary>
        /// <param name="page"></param>
        private static void ExportPage(Page5ViewModel page)
        {
            try
            {
                // ## Section 1 ##

                // Output the title of the section
                OutputBlackBlueHeading("Skill Building or Problem Solving");

                // Output selected skill
                OutputHeading3Text(page.SkillBuildingSkill);

                // List all checked items
                if (page.OptionS1O1)
                {
                    OutputNormalText(page.OptionS1O1Text);
                    ++_curRow;
                }
                if (page.OptionS1O2)
                {
                    OutputNormalText(page.OptionS1O2Text);
                    ++_curRow;
                }
                if (page.OptionS1O3)
                {
                    OutputNormalText(page.OptionS1O3Text);
                    ++_curRow;
                }
                if (page.OptionS1O4)
                {
                    OutputNormalText(page.OptionS1O4Text);
                    ++_curRow;
                }
                if (page.OptionS1O5)
                {
                    OutputNormalText(page.OptionS1O5Text);
                    ++_curRow;
                }
                if (page.OptionS1O6)
                {
                    OutputNormalText( page.OptionS1O6Text);
                    ++_curRow;
                }
                if (page.OptionS1O7)
                {
                    OutputNormalText( page.OptionS1O7Text);
                    ++_curRow;
                }
                if (page.OptionS1O8)
                {
                    OutputNormalText( page.OptionS1O8Text);
                    ++_curRow;
                }
                ++_curRow;


                // ## Section 2 ##

                // Output the title of the section
                OutputBlackBlueHeading("Carey Guide/Carey BIT");

                // Output selected skill
                OutputHeading3Text(page.CareyText);

                // List all checked items
                if (page.OptionS2O1)
                {
                    OutputNormalText( page.OptionS2O1Text);
                    ++_curRow;
                }
                if (page.OptionS2O2)
                {
                    OutputNormalText( page.OptionS2O2Text);
                    ++_curRow;
                }
                if (page.OptionS2O3)
                {
                    OutputNormalText( page.OptionS2O3Text);
                    ++_curRow;
                }
                if (page.OptionS2O4)
                {
                    OutputNormalText( page.OptionS2O4Text);
                    ++_curRow;
                }
                if (page.OptionS2O5)
                {
                    OutputNormalText( page.OptionS2O5Text);
                    ++_curRow;
                }
                if (page.OptionS2O6)
                {
                    OutputNormalText( page.OptionS2O6Text);
                    ++_curRow;
                }
                ++_curRow;


                // ## Section 3 ##

                // Output the title of the section
                OutputBlackBlueHeading( "Other Intervention");

                // Output selected skill
                OutputHeading3Text(page.OtherInterventionText);

                // List all checked items
                if (page.OptionS3O1)
                {
                    OutputNormalText( page.OptionS3O1Text);
                    ++_curRow;
                }
                if (page.OptionS3O2)
                {
                    OutputNormalText( page.OptionS3O2Text);
                    ++_curRow;
                }
                if (page.OptionS3O3)
                {
                    OutputNormalText( page.OptionS3O3Text);
                    ++_curRow;
                }
                if (page.OptionS3O4)
                {
                    OutputNormalText( page.OptionS3O4Text);
                    ++_curRow;
                }
                if (page.OptionS3O5)
                {
                    OutputNormalText( page.OptionS3O5Text);
                    ++_curRow;
                }
                if (page.OptionS3O6)
                {
                    OutputNormalText( page.OptionS3O6Text);
                    ++_curRow;
                }
                if (page.OptionS3O7)
                {
                    OutputNormalText( page.OptionS3O7Text);
                    ++_curRow;
                }
                ++_curRow;


                // ## Section 4 ##

                // Output the title of the section
                OutputBlackBlueHeading( "Graduated Rehearsal");

                // Output selected skill
                OutputHeading3Text(page.GraduatedText);

                // List all checked items
                if (page.OptionS4O1)
                {
                    OutputNormalText( page.OptionS4O1Text);
                    ++_curRow;
                }
                ++_curRow;
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }

        }

        /// <summary>
        /// Page 6 export
        /// </summary>
        /// <param name="page"></param>
        private static void ExportPage(Page6ViewModel page)
        {
            OutputBlackWhiteHeading(page.TextArray[0][0]);
            OutputHeading3Text(page.TextArray[0][1], 0, 2);
            OutputNormalText(page.TextInput[0], 2, 2);
            ++_curRow;
            OutputHeading3Text(page.TextArray[0][2], 0, 2);
            OutputNormalText(page.TextInput[1], 2, 2);
            ++_curRow;
            OutputHeading3Text(page.TextArray[0][3],0,2);
            OutputNormalText(page.TextInput[2],2,4);
            ++_curRow;

            //rows
            for (int row = 0; row < 2; row++)
            {
                OutputHeading3Text(page.TextArray[0][4+row],0,5);
                for (int i = 0; i < 5; i++)
                {
                    if (page.BoolArray[0][0+row][i])
                    {
                        OutputNormalText(i.ToString(),5,1);
                   }
                }
                ++_curRow;
            }

            //total
            OutputHeading3Text(page.TextArray[0][6],0,5);
            OutputColoredHeading3(XlRgbColor.rgbLimeGreen, page.TotalScores[0].Val.ToString(),5,1);
            ++_curRow;

            OutputBlueHeading3("Comments",0,_maxCol+1);
            ++_curRow;
            OutputNormalText(page.Comments[0]);
            ++_curRow;
            ++_curRow;

            //Section 2

            OutputBlackWhiteHeading(page.TextArray[1][0]);

            OutputHeading3Text(page.TextArray[1][2], 0, 2);
            OutputNormalText(page.TextInput[3], 2, 2);
            ++_curRow;
            OutputHeading3Text(page.TextArray[1][3], 0, 2);
            OutputNormalText(page.TextInput[4], 2, 2);
            ++_curRow;

            //rows
            for (int row = 0; row < 3; row++)
            {
                OutputHeading3Text(page.TextArray[1][4 + row], 0, 5);
                for (int i = 0; i < 5; i++)
                {
                    if (page.BoolArray[1][0 + row][i])
                    {
                        OutputNormalText(i.ToString(), 5, 1);
                    }
                }
                ++_curRow;
            }

            //total
            OutputHeading3Text(page.TextArray[1][7], 0, 5);
            OutputColoredHeading3(XlRgbColor.rgbLimeGreen, page.TotalScores[1].Val.ToString(), 5, 1);
            ++_curRow;

            OutputBlueHeading3("Comments", 0, _maxCol + 1);
            ++_curRow;
            OutputNormalText(page.Comments[1]);
            ++_curRow;
            ++_curRow;

            //Section 3
            OutputBlackBlueHeading(page.TextArray[2][0]);
            if (page.BoolArray[2][0][0])
            {
                OutputBlueHeading3("Missed opportunity", 0, _maxCol - _minCol + 1);
            }
            else
            {
                //rows
                for (int i = 0; i < 3; i++)
                {
                    if (page.BoolArray[2][1][i])
                    {
                        OutputNormalText(page.TextArray[2][2 + i]);
                        ++_curRow;
                    }
                }
            }

            OutputHeading3Text(page.TextArray[2][5], 0, 3);
            OutputNormalText(page.TextInput[5], 3, _lastCol);
            ++_curRow;

            OutputColoredHeading3(XlRgbColor.rgbLimeGreen, "Comments", 0, _lastCol);
            ++_curRow;
            OutputNormalText(page.Comments[2]);
            ++_curRow;
            ++_curRow;


            //Section 4
            OutputBlackBlueHeading(page.TextArray[3][0]);
            if (page.BoolArray[3][0][0])
            {
                OutputBlueHeading3("Missed opportunity", 0, _maxCol - _minCol + 1);
            }
            else
            {
                //rows
                for (int i = 0; i < 4; i++)
                {
                    if (page.BoolArray[3][1][i])
                    {
                        OutputNormalText(page.TextArray[3][2 + i]);
                        ++_curRow;
                    }
                }
            }

            OutputHeading3Text(page.TextArray[3][6], 0, 3);
            OutputNormalText(page.TextInput[6], 3, _lastCol);
            ++_curRow;

            OutputColoredHeading3(XlRgbColor.rgbLimeGreen, "Comments", 0, _lastCol);
            ++_curRow;
            OutputNormalText(page.Comments[3]);
            ++_curRow;
            ++_curRow;

            //Section 5
            OutputBlackBlueHeading(page.TextArray[4][0]);
            if (page.BoolArray[4][0][0])
            {
                OutputBlueHeading3("Missed opportunity", 0, _maxCol - _minCol + 1);
            }
            else
            {
                //rows
                for (int i = 0; i < 4; i++)
                {
                    if (page.BoolArray[4][1][i])
                    {
                        OutputNormalText(page.TextArray[4][2 + i]);
                        ++_curRow;
                    }
                }
            }

            OutputHeading3Text(page.TextArray[4][6], 0, 3);
            OutputNormalText(page.TextInput[7], 3, _lastCol);
            ++_curRow;

            OutputColoredHeading3(XlRgbColor.rgbLimeGreen, "Comments", 0, _lastCol);
            ++_curRow;
            OutputNormalText(page.Comments[4]);
            ++_curRow;

            ++_curRow;
        }

        /// <summary>
        /// Page 7 export
        /// </summary>
        /// <param name="page"></param>
        private static void ExportPage(Page7ViewModel page)
        {
            OutputBlackWhiteHeading(page.TextArray[0][0]);
            OutputBlueHeading3(page.TextArray[0][1],0,_lastCol);
            ++_curRow;
            bool outputAnItem = false;
            for (int row = 0; row < 3; row++)
            {
                outputAnItem = false;
                for (int col = 0; col < 3; col++)
                {
                    if (page.BoolArray[0][row][col])
                    {
                        OutputNormalText(page.TextArray[0][2+row*3+col],col*3,3);
                        outputAnItem = true;
                    }
                }
                if(outputAnItem)
                    ++_curRow;
            }

            OutputBlackBar();

            //rows...
            for (int row = 16; row <= 25; row++)
            {
                if (page.BoolArray[0][row - 13][0]) continue; // Item is N/A

                OutputNormalText(page.TextArray[0][row],0,5);
                for (int rating = 1; rating < 6; rating++)
                {
                    if(page.BoolArray[0][row-13][rating])
                        OutputHeading3Text((rating-1).ToString(),5,1);
                }
                ++_curRow;
            }

            OutputHeading3Text("Total intervention score: ", 0, 3);
            OutputColoredHeading3(XlRgbColor.rgbLimeGreen, page.TotalScores[0].Val.ToString(),5,1);
            ++_curRow;

            OutputBlueHeading3("Additional comments",0,_lastCol);
            ++_curRow;
            OutputNormalText(page.Comments[0]);
            ++_curRow;
            ++_curRow;

            //Section 2
            OutputBlackWhiteHeading(page.TextArray[1][0]);
            OutputBlueHeading3(page.TextArray[1][1],0,_lastCol);
            ++_curRow;

            // row1
            string temp;
            temp = page.TextArray[1][2];
            if (page.BoolArray[1][0][0])
                temp += page.TextArray[1][3];
            if (page.BoolArray[1][0][1])
                temp += page.TextArray[1][4];
            OutputNormalText(temp);
            ++_curRow;

            // row2
            OutputHeading3Text(page.TextArray[1][5], 0, 2);
            OutputNormalText(page.InputText[0], 2, 1);
            OutputHeading3Text(page.TextArray[1][6], 3, 1);
            OutputNormalText(page.InputText[1], 4, 1);
            OutputHeading3Text(page.TextArray[1][7], 5, 2);
            OutputNormalText(page.InputText[2], 7, 1);
            OutputHeading3Text(page.TextArray[1][8], 8, 1);
            OutputNormalText(page.InputText[3], 9, 1);
            ++_curRow;

            // row3
            temp = page.TextArray[1][9];
            if (page.BoolArray[1][1][0])
                temp += page.TextArray[1][10];
            if (page.BoolArray[1][1][1])
                temp += page.TextArray[1][11];
            OutputNormalText(temp);
            ++_curRow;

            // row4
            OutputHeading3Text(page.TextArray[1][12], 0, 1);
            OutputNormalText(page.InputText[4], 1, 2);
            OutputHeading3Text(page.TextArray[1][13], 3, 1);
            OutputNormalText(page.InputText[5], 4, 2);
            OutputHeading3Text(page.TextArray[1][14], 6, 1);
            OutputNormalText(page.InputText[6], 7, 2);
            ++_curRow;

            // row5
            temp = page.TextArray[1][15];
            if (page.BoolArray[1][2][0])
                temp += page.TextArray[1][16];
            if (page.BoolArray[1][2][1])
                temp += page.TextArray[1][17];
            OutputNormalText(temp);
            ++_curRow;

            // row6
            OutputHeading3Text(page.TextArray[1][18], 0, 1);
            OutputNormalText(page.InputText[7], 1, 2);
            OutputHeading3Text(page.TextArray[1][19], 3, 1);
            OutputNormalText(page.InputText[8], 4, 2);
            OutputHeading3Text(page.TextArray[1][20], 6, 1);
            OutputNormalText(page.InputText[9], 7, 2);
            ++_curRow;

            // row7
            if (page.BoolArray[1][3][0])
                temp = page.TextArray[1][21];
            OutputNormalText(temp);
            ++_curRow;

            // row8
            OutputHeading3Text(page.TextArray[1][22], 0, 2);
            OutputNormalText(page.InputText[10], 2, 2);
            ++_curRow;

            OutputBlueHeading3(page.TextArray[1][23],0,_lastCol);
            ++_curRow;
            OutputHeading3Text(page.TextArray[1][24], 0, 3);
            temp = page.BoolArray[1][4][0] ? "Yes" : "No";
            OutputNormalText(temp, 3, 1);
            OutputHeading3Text(page.TextArray[1][25], 5, 3);
            temp = page.BoolArray[1][4][2] ? "Yes" : "No";
            OutputNormalText(temp, 8, 1);
            ++_curRow;
            OutputHeading3Text(page.TextArray[1][26], 0, 3);
            temp = page.BoolArray[1][6][2] ? "Yes" : "No";
            OutputNormalText(temp, 3, 1);
            OutputHeading3Text(page.TextArray[1][27], 5, 3);
            temp = page.BoolArray[1][8][2] ? "Yes" : "No";
            OutputNormalText(temp, 8, 1);
            ++_curRow;

            OutputBlueHeading3(page.TextArray[1][28],0,_lastCol);
            ++_curRow;

            OutputHeading3Text(page.TextArray[1][29], 0, 2);
            ++_curRow;
            OutputNormalText(page.TextArray[1][35], 1, 2);
            for (int i = 0; i < 5; i++)
            {
                if (page.BoolArray[1][5][i])
                    OutputNormalText(i.ToString(), 3, 1);
            }
            ++_curRow;

            OutputNormalText(page.TextArray[1][36], 1, 2);
            for (int i = 0; i < 5; i++)
            {
                if (page.BoolArray[1][6][i])
                    OutputNormalText(i.ToString(), 3, 1);
            }
            ++_curRow;

            OutputHeading3Text(page.TextArray[1][37], 0, 2);
            ++_curRow;
            OutputNormalText(page.TextArray[1][43], 1, 2);
            for (int i = 0; i < 5; i++)
            {
                if (page.BoolArray[1][5][i])
                    OutputNormalText(i.ToString(), 3, 1);
            }
            ++_curRow;

            OutputNormalText(page.TextArray[1][44], 1, 2);
            for (int i = 0; i < 5; i++)
            {
                if (page.BoolArray[1][6][i])
                    OutputNormalText(i.ToString(), 3, 1);
            }
            ++_curRow;

            OutputColoredHeading3(XlRgbColor.rgbLimeGreen, page.TextArray[1][45],0,_lastCol);
            ++_curRow;
            OutputNormalText(page.Comments[1]);
        }

        //TODO: Clean up these helper functions. There is a lot of duplicated code...

        /// <summary>
        /// Writes the text into the given range. Does not add a row.
        /// </summary>
        /// <param name="text">Text to be written out</param>
        private static void OutputNormalText(string text)
        {
            OutputNormalText(text,_minCol, _lastCol);
        }

        /// <summary>
        /// Writes the text into the given range. Does not add a row.
        /// </summary>
        /// <param name="text">Text to be written out</param>
        /// <param name="startColumn">Zero indexed column</param>
        /// <param name="columns">Total number of columns the text takes</param>
        private static void OutputNormalText(string text, int startColumn, int columns)
        {
            columns--;
            Range rng = GetRange(_minCol + startColumn, _curRow, _minCol + startColumn + columns, _curRow);
            rng.UnMerge();
            rng.Cells.Font.Size = TextFontSize;
            rng.Merge();
            rng.WrapText = true;
            rng.Value = text;

        }

        /// <summary>
        /// Writes the text into the given range. Does not add a row.
        /// </summary>
        /// <param name="text">Text to be written out</param>
        /// <param name="startColumn">Zero indexed column</param>
        /// <param name="columns">Total number of columns the text takes</param>
        private static void OutputHeading3Text(string text, int startColumn, int columns)
        {
            columns--;
            Range rng = GetRange(_minCol + startColumn, _curRow, _minCol + startColumn + columns, _curRow);
            rng.UnMerge();
            rng.Cells.Font.Size = Heading3FontSize;
            rng.Merge();
            rng.WrapText = true;
            rng.Rows.AutoFit();
            rng.Value = text;
            rng.Cells.Font.Bold = true;
        }

        /// <summary>
        /// Writes the text into the given range. Does not add a row.
        /// </summary>
        /// <param name="text">Text to be written out</param>
        private static void OutputHeading3Text(string text)
        {
            Range rng = GetRange(_minCol, _curRow, _maxCol, _curRow);
            rng.UnMerge();
            rng.Cells.Font.Size = Heading3FontSize;
            rng.Merge();
            rng.Value = text;
        }

        /// <summary>
        /// Writes the heading out to the current row. Adds a row.
        /// </summary>
        /// <param name="text">Main heading</param>
        static void OutputBlackWhiteHeading(String text)
        {
            Range rng = GetRange(_minCol, _curRow, _maxCol, _curRow);
            rng.UnMerge();
            rng.Cells.Font.Size = Heading2FontSize;
            rng.Cells.Font.Bold = true;
            rng.Interior.Color = XlRgbColor.rgbBlack; //bg
            rng.Font.Color = XlRgbColor.rgbWhite; // text
            rng.Merge();
            rng.Value = text;
            ++_curRow;
        }

        /// <summary>
        /// Outputs a black bar. Adds a row
        /// </summary>
        static void OutputBlackBar()
        {
            Range rng = GetRange(_minCol, _curRow, _maxCol, _curRow);
            rng.Interior.Color = XlRgbColor.rgbBlack; //bg
            rng.RowHeight = 10;
            rng.Merge();
            ++_curRow;
        }

        /// <summary>
        /// Writes the heading out to the current row. Adds two rows. A black one, and a blue one with headings.
        /// </summary>
        /// <param name="text">Main heading</param>
        /// <param name="subCol">Starting column for subtext</param>
        /// <param name="subtext">Sub heading</param>
        static void OutputBlackBlueHeading(String text, int subCol, String subtext)
        {
            // black bar above
            OutputBlackBar();

            // main text
            Range rng = GetRange(_minCol, _curRow, _minCol + subCol - 1, _curRow);
            rng.Cells.Font.Size = Heading2FontSize;
            rng.Cells.Font.Bold = true;
            rng.Interior.Color = XlRgbColor.rgbCornflowerBlue; //bg
            rng.Font.Color = XlRgbColor.rgbBlack; // text
            rng.Merge();
            rng.Value = text;

            //sub text
            rng = GetRange(_minCol + subCol, _curRow, _maxCol, _curRow);
            rng.Cells.Font.Size = Heading2FontSize;
            rng.Cells.Font.Bold = false;
            rng.Interior.Color = XlRgbColor.rgbCornflowerBlue; //bg
            rng.Font.Color = XlRgbColor.rgbBlack; // text
            rng.Merge();
            rng.Value = subtext;
            ++_curRow;
        }


        /// <summary>
        /// Writes the heading out to the current row. Adds two rows. A black one, and a blue one with headings.
        /// </summary>
        private static void OutputBlackBlueHeading(string text)
        {
            // black bar above
            Range rng = GetRange(_minCol, _curRow, _maxCol, _curRow);
            rng.Interior.Color = XlRgbColor.rgbBlack; //bg
            rng.RowHeight = 10;
            rng.Merge();
            ++_curRow;

            // main text
            rng = GetRange(_minCol, _curRow, _maxCol, _curRow);
            rng.Cells.Font.Size = Heading2FontSize;
            rng.Cells.Font.Bold = true;
            rng.Interior.Color = XlRgbColor.rgbCornflowerBlue; //bg
            rng.Font.Color = XlRgbColor.rgbBlack; // text
            rng.Merge();
            rng.Value = text;
            ++_curRow;
        }


        /// <summary>
        /// Writes out black text with blue BG. Does not add a row.
        /// </summary>
        /// <param name="text">Text to write</param>
        /// <param name="startColumn">Zero indexed starting column</param>
        /// <param name="numColumns">Number of columns the text occupies</param>
        private static void OutputBlueHeading3(string text, int startColumn, int numColumns)
        {
            OutputColoredHeading3(XlRgbColor.rgbCornflowerBlue,text,startColumn,numColumns);
        }

        /// <summary>
        /// Writes out black text with blue BG. Does not add a row.
        /// </summary>
        /// <param name="bgColor">Background color</param>
        /// <param name="text">Text to write</param>
        /// <param name="startColumn">Zero indexed starting column</param>
        /// <param name="numColumns">Number of columns the text occupies</param>
        /// <param name="fontColor">Text color. Default is black</param>
        private static void OutputColoredHeading3(XlRgbColor bgColor,string text, int startColumn, int numColumns, XlRgbColor fontColor = XlRgbColor.rgbBlack)
        {
            Range rng = GetRange(_minCol + startColumn, _curRow, _minCol + startColumn + numColumns - 1, _curRow);
            rng.UnMerge();
            rng.Cells.Font.Size = Heading3FontSize;
            rng.Cells.Font.Bold = true;
            rng.Interior.Color = bgColor; //bg
            rng.Font.Color = fontColor; // text
            rng.Merge();
            rng.WrapText = true;
            rng.Value = text;
            rng.HorizontalAlignment = XlHAlign.xlHAlignCenter;
        }


        /// <summary>
        /// Writes the heading out to the current row. Adds a row.
        /// </summary>
        private static void OutputBlueSubHeading(string text)
        {
            Range rng = GetRange(_minCol, _curRow, _maxCol, _curRow);
            rng.Cells.Font.Size = SubHeadingFontSize;
            rng.Cells.Font.Bold = true;
            rng.Interior.Color = XlRgbColor.rgbCornflowerBlue; //bg
            rng.Font.Color = XlRgbColor.rgbBlack; // text
            rng.Merge();
            rng.Value = text;
            rng.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            ++_curRow;
        }



        /// <summary>
        /// Returns a Range for the given area
        /// </summary>
        /// <param name="startCol">Zero indexed starting column</param>
        /// <param name="startRow">starting row</param>
        /// <param name="endCol">Zero indexed ending column</param>
        /// <param name="endRow">ending row</param>
        /// <returns></returns>
        public static Range GetRange(int startCol, int startRow, int endCol, int endRow)
        {
            string first = $"{(char) ('A' + startCol)}{startRow}";
            string second = $"{(char)('A' + endCol)}{endRow}";
            Range rng = _worksheet.Range[first, second];
            rng.Merge();
            return rng;
        }

        /// <summary>
        /// Sets the height of the current row. 
        /// </summary>
        /// <param name="height">Not in pixels. Dependent on height of font. </param>
        private static void SetHeight(int height)
        {
            Range rng;

                rng = GetRange(_minCol, _curRow, _minCol, _curRow);
                rng.RowHeight = height;
            //for (int col = _minCol; col < _maxCol; col++)
            //{
            //    rng = GetRange(col, _curRow, col, _curRow);
            //    rng.RowHeight = height;
            //}
        }

    }
}

﻿using System;
using System.Linq.Expressions;
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

        public const XlRgbColor BarColor = XlRgbColor.rgbCornflowerBlue;

        public static void ExportData(IEpicForm form)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save excel export";
            saveFileDialog.DefaultExt = ".xlsx";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.AddExtension = false;

            if ((saveFileDialog.ShowDialog() != true)) return;

            _application = new ExcelApplication();
            _application.DisplayAlerts = false;
            _application.Visible = true;
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
            _curRow++;

            OutputBlackWhiteHeading("Session Information");

            OutputNormalText("Session date: " + page.SessionDate.ToString("d"),0,2);
            _curRow++;

            ++_curRow;
        }

        /// <summary>
        /// Page 3
        /// </summary>
        /// <param name="page"></param>
        private static void ExportPage(Page3ViewModel page)
        {
            OutputBlackWhiteHeading(page.TextArray[0]);
            _curRow++;
            OutputNormalText(page.TextArray[1] + page.CheckInTextInput[0], 0, 2);
            _curRow++;
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
                OutputNormalText(page.TextArray[1], 0, _maxCol);
                ++_curRow;
            }
            if (page.SectionBools[0][1])
            {
                OutputNormalText(page.TextArray[2], 0, _maxCol);
                ++_curRow;
            }
            if (page.SectionBools[0][2])
            {
                OutputNormalText(page.TextArray[3], 0, _maxCol);
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
                OutputNormalText(page.TextArray[4], 0, _maxCol);
                ++_curRow;
            }
            if (page.SectionBools[0][9])
            {
                OutputNormalText(page.TextArray[5], 0, _maxCol);
                ++_curRow;
            }
            if (page.SectionBools[0][10])
            {
                OutputNormalText(page.TextArray[6], 0, _maxCol);
                _curRow++;
                // extra stuff here
                int col = 5;
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
                OutputNormalText(page.TextArray[13], 0, _maxCol);
                ++_curRow;
            }
            if (page.SectionBools[1][1])
            {
                OutputNormalText(page.TextArray[14], 0, _maxCol);
                ++_curRow;
            }
            if (page.SectionBools[1][2])
            {
                OutputNormalText(page.TextArray[15], 0, _maxCol);
                ++_curRow;
            }
            if (page.SectionBools[0][3])
            {
                OutputNormalText(page.TextArray[16], 0, _maxCol);
                _curRow++;
                // extra stuff here
                int col = 5;
                for (int i = 0; i < 5; ++i)
                {
                    if (page.SectionBools[0][4 + i])
                        OutputNormalText(page.OptionText[i], col++, 1);
                }
                ++_curRow;
            }
            if (page.SectionBools[1][9])
            {
                OutputNormalText(page.TextArray[17], 0, _maxCol);
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
                    OutputNormalText(page.TextArray[20+i], 0, _maxCol);
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
                    OutputNormalText(page.TextArray[29 + i], 0, _maxCol);
                    ++_curRow;
                }
            }

            if (page.SectionBools[3][2])
            {
                OutputNormalText(page.TextArray[31]);
                int col = 5;
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
                    OutputNormalText(page.TextArray[25 + i], 0, _maxCol);
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
                    _curRow++;
                }
                if (page.OptionS1O2)
                {
                    OutputNormalText(page.OptionS1O2Text);
                    _curRow++;
                }
                if (page.OptionS1O3)
                {
                    OutputNormalText(page.OptionS1O3Text);
                    _curRow++;
                }
                if (page.OptionS1O4)
                {
                    OutputNormalText(page.OptionS1O4Text);
                    _curRow++;
                }
                if (page.OptionS1O5)
                {
                    OutputNormalText(page.OptionS1O5Text);
                    _curRow++;
                }
                if (page.OptionS1O6)
                {
                    OutputNormalText( page.OptionS1O6Text);
                    _curRow++;
                }
                if (page.OptionS1O7)
                {
                    OutputNormalText( page.OptionS1O7Text);
                    _curRow++;
                }
                if (page.OptionS1O8)
                {
                    OutputNormalText( page.OptionS1O8Text);
                    _curRow++;
                }
                _curRow++;


                // ## Section 2 ##

                // Output the title of the section
                OutputBlackBlueHeading("Carey Guide/Carey BIT");

                // Output selected skill
                OutputHeading3Text(page.CareyText);

                // List all checked items
                if (page.OptionS2O1)
                {
                    OutputNormalText( page.OptionS2O1Text);
                    _curRow++;
                }
                if (page.OptionS2O2)
                {
                    OutputNormalText( page.OptionS2O2Text);
                    _curRow++;
                }
                if (page.OptionS2O3)
                {
                    OutputNormalText( page.OptionS2O3Text);
                    _curRow++;
                }
                if (page.OptionS2O4)
                {
                    OutputNormalText( page.OptionS2O4Text);
                    _curRow++;
                }
                if (page.OptionS2O5)
                {
                    OutputNormalText( page.OptionS2O5Text);
                    _curRow++;
                }
                if (page.OptionS2O6)
                {
                    OutputNormalText( page.OptionS2O6Text);
                    _curRow++;
                }
                _curRow++;


                // ## Section 3 ##

                // Output the title of the section
                OutputBlackBlueHeading( "Other Intervention");

                // Output selected skill
                OutputHeading3Text(page.OtherInterventionText);

                // List all checked items
                if (page.OptionS3O1)
                {
                    OutputNormalText( page.OptionS3O1Text);
                    _curRow++;
                }
                if (page.OptionS3O2)
                {
                    OutputNormalText( page.OptionS3O2Text);
                    _curRow++;
                }
                if (page.OptionS3O3)
                {
                    OutputNormalText( page.OptionS3O3Text);
                    _curRow++;
                }
                if (page.OptionS3O4)
                {
                    OutputNormalText( page.OptionS3O4Text);
                    _curRow++;
                }
                if (page.OptionS3O5)
                {
                    OutputNormalText( page.OptionS3O5Text);
                    _curRow++;
                }
                if (page.OptionS3O6)
                {
                    OutputNormalText( page.OptionS3O6Text);
                    _curRow++;
                }
                if (page.OptionS3O7)
                {
                    OutputNormalText( page.OptionS3O7Text);
                    _curRow++;
                }
                _curRow++;


                // ## Section 4 ##

                // Output the title of the section
                OutputBlackBlueHeading( "Graduated Rehearsal");

                // Output selected skill
                OutputHeading3Text(page.GraduatedText);

                // List all checked items
                if (page.OptionS4O1)
                {
                    OutputNormalText( page.OptionS4O1Text);
                    _curRow++;
                }
                _curRow++;
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }

        }

        /// <summary>
        /// Writes the text into the given range. Does not add a row.
        /// </summary>
        /// <param name="text">Text to be written out</param>
        private static void OutputNormalText(string text)
        {
            OutputNormalText(text,_minCol,_maxCol);
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
            rng.Value = text;
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
        /// Writes the heading out to the current row. Adds two rows. A black one, and a blue one with headings.
        /// </summary>
        /// <param name="text">Main heading</param>
        /// <param name="subCol">Starting column for subtext</param>
        /// <param name="subtext">Sub heading</param>
        static void OutputBlackBlueHeading(String text, int subCol, String subtext)
        {
            // black bar above
            Range rng = GetRange(_minCol, _curRow, _maxCol, _curRow);
            rng.Interior.Color = XlRgbColor.rgbBlack; //bg
            rng.RowHeight = 10;
            rng.Merge();
            ++_curRow;

            // main text
            rng = GetRange(_minCol, _curRow, _minCol + subCol - 1, _curRow);
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
    }
}

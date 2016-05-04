using System;
using System.Linq.Expressions;
using System.Windows;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace DOC_Forms
{
    public static class ExcelDataExporter
    {
        private static Application _application;
        private static Workbook _workbook;
        private static Worksheet _worksheet;
        private static int _curRow = 0;
        private static int _minCol = 0;
        private static int _maxCol = 8;


        public const XlRgbColor BarColor = XlRgbColor.rgbCornflowerBlue;

        public static void ExportData(IEpicForm form)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save excel export";
            saveFileDialog.DefaultExt = ".xlsx";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.AddExtension = false;

            if ((saveFileDialog.ShowDialog() != true)) return;

            _application = new Application();
            _application.DisplayAlerts = false;
            _application.Visible = false;
            _application.Workbooks.Add();

            _workbook = _application.ActiveWorkbook;
            _worksheet = (Worksheet) _application.ActiveSheet;
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

        private static void ExportPage(Page1ViewModel page)
        {
            Range rng = _worksheet.Range["A" + _curRow, "G" + _curRow];
            rng.Cells.Font.Size = 18;
            rng.Cells.Font.Bold = true;
            rng.Merge();
            rng.Value = "EPICS CODING FORM";
            _curRow++;

            rng = _worksheet.Range["A" + _curRow, "G" + _curRow];
            rng.Cells.Font.Size = 14;
            rng.Cells.Font.Bold = true;
            rng.Interior.Color = XlRgbColor.rgbBlack;//ColorTranslator.ToOle(Color.Black); //bg TODO: Fix this...
            rng.Font.Color = XlRgbColor.rgbWhite; // text
            rng.Merge();
            rng.Value = "Session Information";
            _curRow++;

            rng = _worksheet.Range["A" + _curRow];
            rng.Cells.Font.Size = 12;
            rng.Value = "Session date: " + page.SessionDate.ToString("d");
            _curRow++;

        }

        private static void ExportPage(Page5ViewModel page)
        {
            try
            {
                // ## Section 1 ##

                // Output the title of the section
                Range rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                rng.Cells.Font.Size = 18;
                rng.Cells.Font.Bold = true;
                rng.Merge();
                rng.Interior.Color = BarColor;
                rng.Value = "Skill Building or Problem Solving";
                _curRow++;
                // Output selected skill
                rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                rng.Cells.Font.Bold = true;
                rng.Cells.Font.Size = 14;
                rng.Value = page.SkillBuildingSkill;

                // List all checked items
                if (page.OptionS1O1)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS1O1Text;
                    _curRow++;
                }
                if (page.OptionS1O2)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS1O2Text;
                    _curRow++;
                }
                if (page.OptionS1O3)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS1O3Text;
                    _curRow++;
                }
                if (page.OptionS1O4)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS1O4Text;
                    _curRow++;
                }
                if (page.OptionS1O5)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS1O5Text;
                    _curRow++;
                }
                if (page.OptionS1O6)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS1O6Text;
                    _curRow++;
                }
                if (page.OptionS1O7)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS1O7Text;
                    _curRow++;
                }
                if (page.OptionS1O8)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS1O8Text;
                    _curRow++;
                }
                _curRow++;


                // ## Section 2 ##

                // Output the title of the section
                rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                rng.Cells.Font.Size = 18;
                rng.Cells.Font.Bold = true;
                rng.Merge();
                rng.Interior.Color = BarColor;
                rng.Value = "Carey Guide/Carey BIT";
                _curRow++;

                // Output selected skill
                rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                rng.Cells.Font.Bold = true;
                rng.Cells.Font.Size = 14;
                rng.Value = page.CareyText;
                    _curRow++;
                // List all checked items
                if (page.OptionS2O1)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS2O1Text;
                    _curRow++;
                }
                if (page.OptionS2O2)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS2O2Text;
                    _curRow++;
                }
                if (page.OptionS2O3)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS2O3Text;
                    _curRow++;
                }
                if (page.OptionS2O4)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS2O4Text;
                    _curRow++;
                }
                if (page.OptionS2O5)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS2O5Text;
                    _curRow++;
                }
                if (page.OptionS2O6)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS2O6Text;
                    _curRow++;
                }
                _curRow++;


                // ## Section 3 ##

                // Output the title of the section
                rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                rng.Cells.Font.Size = 18;
                rng.Cells.Font.Bold = true;
                rng.Merge();
                rng.Interior.Color = BarColor;
                rng.Value = "Other Intervention";
                _curRow++;

                // Output selected skill
                rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                rng.Cells.Font.Bold = true;
                rng.Cells.Font.Size = 14;
                rng.Value = page.OtherInterventionText;
                _curRow++;


                // List all checked items
                if (page.OptionS3O1)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS3O1Text;
                    _curRow++;
                }
                if (page.OptionS3O2)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS3O2Text;
                    _curRow++;
                }
                if (page.OptionS3O3)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS3O3Text;
                    _curRow++;
                }
                if (page.OptionS3O4)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS3O4Text;
                    _curRow++;
                }
                if (page.OptionS3O5)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS3O5Text;
                    _curRow++;
                }
                if (page.OptionS3O6)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS3O6Text;
                    _curRow++;
                }
                if (page.OptionS3O7)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS3O7Text;
                    _curRow++;
                }
                _curRow++;


                // ## Section 4 ##

                // Output the title of the section
                rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                rng.Cells.Font.Size = 18;
                rng.Cells.Font.Bold = true;
                rng.Merge();
                rng.Interior.Color = BarColor;
                rng.Value = "Graduated Rehearsal";
                _curRow++;

                // Output selected skill
                rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                rng.Cells.Font.Bold = true;
                rng.Cells.Font.Size = 14;
                rng.Value = page.GraduatedText;
                _curRow++;

                // List all checked items
                if (page.OptionS4O1)
                {
                    rng =  GetRange(_minCol,_curRow, _maxCol,_curRow);
                    rng.Value = page.OptionS4O1Text;
                    _curRow++;
                }
                _curRow++;
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }

        }

        private static void ExportPage(Page3ViewModel page)
        {
            OutputBlackWhiteHeading(page.TextArray[0]);
            _curRow++;
            OutputNormalText(page.TextArray[1] + page.CheckInTextInput[0], 0, 2);
            _curRow++;
        }

        private static void OutputNormalText(string text, int startColumn, int columns)
        {
            Range rng = GetRange(_minCol + startColumn, _curRow, _minCol + startColumn + columns, _curRow);
            rng.Cells.Font.Size = 12;
            rng.Merge();
            rng.Value = text;
        }

        static void OutputBlackWhiteHeading(String text)
        {
            Range rng = GetRange(_minCol,_curRow, _maxCol,_curRow);
            rng.Cells.Font.Size = 14;
            rng.Cells.Font.Bold = true;
            rng.Interior.Color = XlRgbColor.rgbBlack;//ColorTranslator.ToOle(Color.Black); //bg TODO: Fix this...
            rng.Font.Color = XlRgbColor.rgbWhite; // text
            rng.Merge();
            rng.Value = text;
        }


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

using System;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    public class ExcelDataExporter
    {
        private static Application _application;
        private static Workbook _workbook;
        private static Worksheet _worksheet;
        private static int currentRow = 0;
        
        public static bool ExportData(IEpicForm form)
        {
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Title = "Save excel export";
            //saveFileDialog.DefaultExt = ".xls";
            //saveFileDialog.OverwritePrompt = true;
            //saveFileDialog.AddExtension = false;


            //if ((saveFileDialog.ShowDialog() != true)) return false;

            bool success = true;

            _application = new Application();
            _application.Visible = true;
            //_application.Visible = false;

            _workbook = _application.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            _worksheet = (Worksheet)_workbook.Worksheets[1];

            form.ExportToExcel(_worksheet, out currentRow);

            //_workbook.SaveAs(saveFileDialog.FileName);
            //_workbook.Close();
            //_application.Quit();
            return success;
        }

        /// <summary>
        /// Used to translate integers 0-25 into capital characters used by Excel for columns.
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public static String GetColumn(int col)
        {
            String columnName = "";

            col = col%26; // make sure column is 0-25

            columnName += (char)('A' + col);

            return columnName;
        }
    }
}

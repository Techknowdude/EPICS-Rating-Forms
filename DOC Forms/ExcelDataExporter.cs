using System;
using System.Windows;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace DOC_Forms
{
    public class ExcelDataExporter
    {
        private static Application _application;
        private static Workbook _workbook;
        private static Worksheet _worksheet;

        public static void ExportData(IEpicForm form)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save excel export";
            saveFileDialog.DefaultExt = ".xls";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.AddExtension = false;

            if ((saveFileDialog.ShowDialog() != true)) return;

            DateTime start = DateTime.Now;

            _application = new Application();
            _application.DisplayAlerts = false;
            _application.Visible = true;
            _application.Workbooks.Add();

            _workbook = _application.ActiveWorkbook;
            _worksheet = (Worksheet)_application.ActiveSheet;

            form.ExportToExcel(_worksheet);


            _workbook.SaveAs(saveFileDialog.FileName);
            _application.Quit();

            TimeSpan time = DateTime.Now - start;

            MessageBox.Show(time.ToString());
        }
    }
    
}

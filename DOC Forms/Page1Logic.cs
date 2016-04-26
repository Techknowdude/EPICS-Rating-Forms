using System.Drawing;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    class Page1Logic
    {
        public Page1Logic()
        {
        }

        public int ExportToExcel(Page1ViewModel info, Worksheet worksheet, int curRow)
        {
            Range rng = worksheet.get_Range("A" + curRow, "G" + curRow);
            rng.Cells.Font.Size = 18;
            rng.Cells.Font.Bold = true;
            rng.Merge();
            rng.Value = "EPICS CODING FORM";
            curRow++;

            rng = worksheet.get_Range("A" + curRow, "G" + curRow);
            rng.Cells.Font.Size = 14;
            rng.Cells.Font.Bold = true;
            rng.Interior.Color = XlRgbColor.rgbBlack;//ColorTranslator.ToOle(Color.Black); //bg TODO: Fix this...
            rng.Font.Color = XlRgbColor.rgbWhite; // text
            rng.Merge();
            rng.Value = "Session Information";
            curRow++;

            rng = worksheet.get_Range("A" + curRow);
            rng.Cells.Font.Size = 12;
            rng.Value = "Session date: " + info.SessionDate.ToString("d");
            curRow++;

            return curRow;
        }
        
    }
}

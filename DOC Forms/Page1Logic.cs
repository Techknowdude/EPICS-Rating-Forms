using System;
using System.Drawing;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    class Page1Logic
    {
        public Page1Logic()
        {
        }

        public int ExportToExcel(Page1ExportInfo info, Worksheet worksheet, int curRow)
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
            rng.Cells.Font.Color = ColorTranslator.ToOle(Color.Black); //bg
            rng.Style.Font.Color = ColorTranslator.ToOle(Color.White); // text
            rng.Merge();
            rng.Value = "Session Information";
            curRow++;

            rng = worksheet.get_Range("A" + curRow);
            rng.Cells.Font.Size = 12;
            rng.Value = "Session date:";
            rng = worksheet.get_Range("B" + curRow);
            rng.Cells.Font.Size = 12;
            rng.Value = info.SessionDate.ToString("d");
            curRow++;


            return curRow;
        }
    }
}

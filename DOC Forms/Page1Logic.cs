using System;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    public class Page1Logic : IPageLogic
    {
        public IPageInterface PageInterface { get; set; }

        public bool Save(BinaryWriter writer)
        {
            throw new NotImplementedException();
        }

        public bool Load(BinaryReader reader)
        {
            throw new NotImplementedException();
        }

        public bool ExportToExcel(Worksheet worksheet, int curRow, out int outRow)
        {
            bool success = true;

            try
            {
                curRow = ExportSection1(worksheet, curRow) + 1;
            }
            catch (Exception)
            {
                success = false;
            }

            outRow = curRow;
            return success;
        }

        public void Connect(IPageInterface page)
        {
            page.Logic = this;
            PageInterface = page;
        }

        private int ExportSection1(Worksheet worksheet, int curRow)
        {
            throw new NotImplementedException();
        }
    }
}

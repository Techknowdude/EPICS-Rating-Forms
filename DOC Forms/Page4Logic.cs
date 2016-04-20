using System;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    class Page4Logic : IPageLogic
    {
        public IPageInterface PageInterface { get; set; }
        public bool Save(BinaryWriter writer)
        {
            //TODO: Fill this in
            return true;
        }

        public bool Load(BinaryReader reader)
        {
            //TODO: Fill this in
            return true;
        }

        public bool ExportToExcel(Worksheet worksheet, int curRow, out int outRow)
        {
            //TODO: Fill this in
            outRow = curRow;
            return true;
        }

        public void Connect(IPageInterface page)
        {
            page.Logic = this;
            PageInterface = page;
        }
    }
}

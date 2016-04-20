using System;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    class Page2Logic : IPageLogic
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
            throw new NotImplementedException();
        }

        public void Connect(IPageInterface page)
        {
            page.Logic = this;
            PageInterface = page;
        }
    }
}

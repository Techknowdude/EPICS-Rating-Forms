using System;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    class Page4ViewModel : IPageLogic
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

        public int ExportToExcel(Worksheet worksheet, int curRow)
        {
            //TODO: Fill this in
            return curRow;
        }

        public void Connect(IPageInterface page)
        {
            page.Logic = this;
            PageInterface = page;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

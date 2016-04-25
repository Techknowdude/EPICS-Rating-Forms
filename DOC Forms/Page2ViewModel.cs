using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    [Serializable]
    class Page2ViewModel : IPageViewModel
    {
        public override int ExportToExcel(Worksheet worksheet, int curRow)
        {
            //TODO: Fill this in
            return curRow;
        }

        public static Page2ViewModel Load(FileStream stream, BinaryFormatter formatter)
        {
            return (Page2ViewModel)formatter.Deserialize(stream);
        }
    }
}

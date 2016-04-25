using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    [Serializable]
    class Page3ViewModel : IPageViewModel
    {
        public override int ExportToExcel(Worksheet worksheet, int curRow)
        {
            //TODO: Fill this in
            return curRow;
        }

        public static Page3ViewModel Load(FileStream stream, BinaryFormatter formatter)
        {
            return (Page3ViewModel)formatter.Deserialize(stream);
        }
    }
}

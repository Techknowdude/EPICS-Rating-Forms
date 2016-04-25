using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    [Serializable]
    class Page4ViewModel : IPageViewModel
    {
        public Page4ViewModel()
        {
            
        }

        public override int ExportToExcel(Worksheet worksheet, int curRow)
        {
            //TODO: Fill this in
            return curRow;
        }

        public static Page4ViewModel Load(FileStream stream, BinaryFormatter formatter)
        {
            return (Page4ViewModel)formatter.Deserialize(stream);
        }
    }
}

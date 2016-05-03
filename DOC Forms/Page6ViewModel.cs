using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    public class Page6ViewModel : IPageViewModel
    {
        public override int ExportToExcel(Worksheet worksheet, int curRow)
        {
            throw new NotImplementedException();
        }

        public static Page6ViewModel Load(Stream stream, Formatter formatter)
        {
            return (Page6ViewModel)formatter.Deserialize(stream);
        }
    }
}

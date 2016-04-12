using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    public interface IEpicForm
    {
        bool ExportData(IDataExporter exporter);
        bool ExportToExcel(Worksheet worksheet, out int currentRow);
    }
}

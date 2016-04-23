using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    public interface IEpicForm
    {
        void ExportToExcel(Worksheet worksheet);
    }
}

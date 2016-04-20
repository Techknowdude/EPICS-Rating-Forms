using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    public interface IEpicForm
    {
        bool ExportToExcel(Worksheet worksheet, out int currentRow);
    }
}

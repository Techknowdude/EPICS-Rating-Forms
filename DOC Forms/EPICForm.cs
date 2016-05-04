using System.Collections;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    public interface IEpicForm
    {
        IEnumerable GetPages();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_Forms
{
    public interface IDataExporter
    {
        bool ExportData(IEpicForm page);
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    public interface IPageInterface
    {
        bool IsCompleted();

        bool Save(BinaryWriter writer);
        bool Load(BinaryReader reader);

        bool ExportToExcel(Worksheet worksheet, int curRow, out int outRow);
    }
}

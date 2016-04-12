using System.IO;
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

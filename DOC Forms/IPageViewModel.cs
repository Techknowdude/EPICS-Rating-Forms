using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    [Serializable]
    public abstract class IPageViewModel : ObservableObject
    {
        /// <summary>
        /// Used to save a form as a file. May be used to save partial forms
        /// </summary>
        /// <returns>true on a successful save. Any errors will cause it to return false</returns>
        public bool Save(FileStream stream, BinaryFormatter formatter)
        {
            try
            {
                formatter.Serialize(stream,this);
            }
            catch (Exception e )
            {
                return false;
            }
            return true;
        }

        public abstract int ExportToExcel(Worksheet worksheet, int curRow);
    }
}

using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    public interface IPageLogic : ICloneable
    {
        /// <summary>
        /// This is the page control. Communication is not normally back to the UI except through binding.
        /// </summary>
        IPageInterface PageInterface { get; set; }

        /// <summary>
        /// Used to save a form as a file. May be used to save partial forms
        /// </summary>
        /// <param name="writer">The stream that is written to</param>
        /// <returns>true on a successful save. Any errors will cause it to return false</returns>
        bool Save(BinaryWriter writer);

        /// <summary>
        /// Used to load a form from a file. May be used to load a partial or full form.
        /// </summary>
        /// <param name="reader">The stream that the form is loaded from</param>
        /// <returns>True upon a successful load. False if there were any errors</returns>
        bool Load(BinaryReader reader);

        int ExportToExcel(Worksheet worksheet, int curRow);
        void Connect(IPageInterface page);
    }
}

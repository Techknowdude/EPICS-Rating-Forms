using Microsoft.VisualStudio.TestTools.UnitTesting;
using DOC_Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_Forms.Tests
{
    [TestClass()]
    public class ExcelDataExporterTests
    {
        [TestMethod()]
        public void GetColumnTest()
        {
            char character = 'A';
            for (int c = 0; c < 25; c++)
            {
                Assert.AreEqual(((char)(character+c)).ToString(), ExcelDataExporter.GetColumn(c));
            }
        }
    }
}
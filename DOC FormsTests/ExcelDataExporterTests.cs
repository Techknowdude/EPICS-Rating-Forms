using Microsoft.VisualStudio.TestTools.UnitTesting;

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
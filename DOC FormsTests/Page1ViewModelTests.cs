using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DOC_Forms.Tests
{
    [TestClass()]
    public class Page1ViewModelTests
    {
        [TestMethod()]
        public void DeserializeTestShouldMatchSerializedData()
        {
            Page1ViewModel model = new Page1ViewModel();
            SetViewModelTestValues(model);

            // Use a BinaryFormatter or SoapFormatter.
            IFormatter formatter = new BinaryFormatter();
            //IFormatter formatter = new SoapFormatter();
            
            FileStream s = new FileStream("DeserializeTest", FileMode.Create);
            formatter.Serialize(s, model);
            s.Close();

            s = new FileStream("DeserializeTest", FileMode.Open);
            Page1ViewModel loadedModel = (Page1ViewModel)formatter.Deserialize(s);
            s.Close();

            Assert.IsTrue(model.Equals(loadedModel));
        }

        private void SetViewModelTestValues(Page1ViewModel model)
        {
            model.AdditionalCommentsText = "a";
            model.BehavioralScore = "b";
            model.CaseloadNumber = "c";
            model.CheckInScore = "d";
            model.ClientAgressiveNA = true;
            model.ClientDOB = DateTime.MaxValue;
            model.ClientHomelessYes = true;
            model.ClientName = "me";
            model.ClientSID = "19384";
        }
    }
}
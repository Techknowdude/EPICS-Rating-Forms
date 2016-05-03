using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    [Serializable]
    class Page4ViewModel : IPageViewModel
    {
        #region Fields

        private String[] _textArray;
        private ObservableBool[][] _sectionBools;
        private string[] _optionText;

        #endregion

        #region Properties
        public string[] TextArray
        {
            get
            {
                return _textArray;
            }

            set
            {
                _textArray = value;
                RaisePropertyChangedEvent("TextArray");
            }
        }

        public ObservableBool[][] SectionBools
        {
            get
            {
                return _sectionBools;
            }

            set
            {
                _sectionBools = value;
                RaisePropertyChangedEvent("SectionBools");
            }
        }

        public String[] OptionText
        {
            get { return _optionText; }
            set
            {
                _optionText = value;
                RaisePropertyChangedEvent("OptionText");
            }
        }

        #endregion
        public Page4ViewModel()
        {
            InitializeFields();
        }

        private void InitializeFields()
        {
            SectionBools = new[]
            {
                new[] { new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(),
                    new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(),
                    new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(),
                    new ObservableBool(), },

                new [] {new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(),
                    new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(),
                     },

                new [] {new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(),
                    new ObservableBool(), new ObservableBool(), new ObservableBool(),
                     },

                new [] {new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(),
                    new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(),
                    new ObservableBool(),
                     }
            };
            OptionText = new[] {"Situation", "Thoughts", "Feelings", "Behavior", "Consequences",
                "(+) Consequences","(-) Consequences","Short term","Long term" };

            TextArray = new[]
            {
                "Behavior Chain/ABC Model",
                "Introduced the intervention",
                "Discussed the importance or usefulness of the intervention",
                "Explained the difference or usefulness of the intervention",
                "Emphasized how the components are linked together",
                "Discussed how thoughts are linked to situations based on core values and beliefs",
                "Worked with the client to apply the tool to a specific situation and identified the clients:",

                "Restructuring of the Behavior Chain",
                "Introduced cognitive restructuring / tapes and counters thoughts",                "Discussed the importance or usefulness of restructuring",                "Taught the client how to identify specific pro-social replacement thoughts for negative thoughts",
                "Worked with the client to apply restructuring to the specific situation and identified the clients:",
                "Restructuring of the Behavior Chain",
                "Introduced cognitive restructuring / tapes and counters thoughts",
                "Discussed the importance or usefulness of restructuring",                "Taught the client how to identify specific pro-social replacement thoughts for negative thoughts",
                "Worked with the client to apply restructuring to the specific situation and identified the clients: ",
                "Summarized the results",

                "Cognitive Restructuring","(Tapes and Counters or Thinking Report)",
                "Introduced the intervention",                "Discussed the importance or usefulness of the intervention",                "Explained the different components of the intervention",
                "Helped the client recognize risky, anti-social thoughts",
                "Helped the client replace risky, anti-social thoughts with pro-social thoughts",
                "Modeled new pro-social thoughts",
                "Had the client role play / practice the new restructured thoughts",
                "Gave the client feedback about the role play / practice",

                "Cost Benefit Analysis",
                "Introduced the intervention",                "Discussed the importance or usefulness of the intervention",                "Explained the different components of the intervention",
                "Helped the client brainstorm pros and cons of chosen negative situation or decision",
                "Helped the client complete a CBA on an alternative pro - social behavior",
                "Helped the client brainstorm pros and cons of the alternative situation or decision",                "Helped the client summarize the results of the CBA",
                };
        }

        public override bool Save(Stream stream, BinaryFormatter formatter)
        {
            return base.Save(stream, formatter);
        }

        public override int ExportToExcel(Worksheet worksheet, int curRow)
        {
            //TODO: Fill this in
            return curRow;
        }

        public static Page4ViewModel Load(FileStream stream, BinaryFormatter formatter)
        {
            return (Page4ViewModel)formatter.Deserialize(stream);
        }
    }
}

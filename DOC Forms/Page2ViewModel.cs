using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    [Serializable]
    class Page2ViewModel : IPageViewModel
    {
        #region Fields
        private string _section1Comments;
        private string _quarterlies;
        private string _lastGoals;
        private string _currentGoals;

        private ObservableBool[] _section1Bools =
        {
            new ObservableBool(),new ObservableBool(),new ObservableBool(),new ObservableBool(),new ObservableBool(),
            new ObservableBool(),new ObservableBool(),new ObservableBool(),new ObservableBool(),new ObservableBool(),
            new ObservableBool(),new ObservableBool(),new ObservableBool(),new ObservableBool(),new ObservableBool(),
            new ObservableBool(),new ObservableBool(),new ObservableBool(),new ObservableBool(),new ObservableBool(),
        };

        private static readonly string[] _sectionText =
        {
            "Pro-criminal attitude/orientation", "Companions", "Antisocial pattern",
            "Education/Employment", "Family/Marital", "Alcohol/Drug problem",
            "Leisure/Recreation", "Criminal History", "Other criminogenic need"
        };

        #endregion


        #region Properties

        public static String[] SectionText
        {
            get { return _sectionText; }
        }

        public string Section1Comments
        {
            get
            {
                return _section1Comments;
            }

            set
            {
                _section1Comments = value;
                RaisePropertyChangedEvent("Section1Comments");
            }
        }

        public string Quarterlies
        {
            get
            {
                return _quarterlies;
            }

            set
            {
                _quarterlies = value;
                RaisePropertyChangedEvent("Quarterlies");
            }
        }

        public string LastGoals
        {
            get
            {
                return _lastGoals;
            }

            set
            {
                _lastGoals = value;
                RaisePropertyChangedEvent("LastGoals");
            }
        }

        public string CurrentGoals
        {
            get
            {
                return _currentGoals;
            }

            set
            {
                _currentGoals = value;
                RaisePropertyChangedEvent("CurrentGoals");
            }
        }

        public ObservableBool[] Section1Bools
        {
            get
            {
                return _section1Bools;
            }

            set
            {
                _section1Bools = value;
                RaisePropertyChangedEvent("Section1Bools");
            }
        }


        #endregion

        public Page2ViewModel()
        {
            PopulateLabelContent();
        }

        private void PopulateLabelContent()
        {
        }

        public override int ExportToExcel(Worksheet worksheet, int curRow)
        {
            //TODO: Fill this in
            return curRow;
        }

        public static Page2ViewModel Load(FileStream stream, BinaryFormatter formatter)
        {
            return (Page2ViewModel)formatter.Deserialize(stream);
        }

        
    }
}

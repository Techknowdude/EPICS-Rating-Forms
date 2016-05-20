using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

        private ObservableBool[][] _section1Bools =
        {
            new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), },
            new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), },
            new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), },
            new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), },
            new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), },
            new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), },
            new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), },
            new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), },
            new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), },
        };

        private ObservableBool[][] _section2Bools =
         {
            new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), },
            new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), },
            new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), },
            new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), },
            new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), },
            new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), },
            new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), },
            new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), },
            new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), },
            new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), },
            new []{ new ObservableBool() },
        };

        private static readonly string[] _sectionText =
        {
            "CASE MANAGEMENT PRACTICES/OMS", "Please select criminogenic needs identified in assessment and targeted in behavior change plans",
            "Needs Identified in Assessment", "Needs Targeted in Behavior Change Plans",
            "Pro-criminal attitude/orientation", "Companions", "Antisocial pattern",
            "Education/Employment", "Family/Marital", "Alcohol/Drug problem",
            "Leisure/Recreation", "Criminal History", "Other criminogenic need",
            "Risk assessment is current", "LS/CMI checklist is current", "BCP's are entered into OMS",
            "Road Map of interventions in the BCP's", "Intervention and homework from the session entered in BCP's",
            "Intervention used targets the criminogenic needs of the client", "Action Plan completed in OMS",
            "Action Plan focused on behavior change", "Homework assigned is entered into the action plan",
            "EPICS chrono completed", "EPICS Keyword used in chrono",

            "Please enter additional comments in the space below",

            "DEMONSTRATED SKILLS FOR QUARTERLIES\nQuarterlies",

            "GOALS",
            "Last Goal(s):",
            "Current Goal(s):"
            
        };

        #endregion


        #region Properties

        public String[] SectionText
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
                RaisePropertyChangedEvent();
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
                RaisePropertyChangedEvent();
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
                RaisePropertyChangedEvent();
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
                RaisePropertyChangedEvent();
            }
        }

        public ObservableBool[][] Section1Bools
        {
            get
            {
                return _section1Bools;
            }

            set
            {
                _section1Bools = value;
                RaisePropertyChangedEvent();
            }
        }

        public ObservableBool[][] Section2Bools
        {
            get { return _section2Bools; }
            set
            {
                _section2Bools = value;
                RaisePropertyChangedEvent();
            }
        }

        #endregion

        public Page2ViewModel()
        {

        }
        
        public static Page2ViewModel Load(Stream stream, BinaryFormatter formatter)
        {
            var loaded = (Page2ViewModel)formatter.Deserialize(stream);
            return loaded;
        }
    }
}

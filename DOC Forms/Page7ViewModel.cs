using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    [Serializable]
    public class Page7ViewModel : IPageViewModel
    {
        #region Fields

        private string[][] _textArray;
        private ObservableBool[][][] _boolArray;
        private ObservableDouble[] _totalScores;
        private String[] _inputText;
        private string[] _comments;

        #endregion
        #region Properties

        public string[][] TextArray
        {
            get
            {
                return _textArray;
            }

            set
            {
                _textArray = value;
                RaisePropertyChangedEvent();
            }
        }

        public ObservableBool[][][] BoolArray
        {
            get
            {
                return _boolArray;
            }

            set
            {
                _boolArray = value;
                RaisePropertyChangedEvent();
            }
        }

        public ObservableDouble[] TotalScores
        {
            get
            {
                return _totalScores;
            }

            set
            {
                _totalScores = value;
                RaisePropertyChangedEvent();
            }
        }

        public string[] InputText
        {
            get
            {
                return _inputText;
            }

            set
            {
                _inputText = value;
                RaisePropertyChangedEvent();
            }
        }

        public String[] Comments
        {
            get { return _comments; }
            set
            {
                _comments = value;
                RaisePropertyChangedEvent();
            }
        }

        #endregion

        public Page7ViewModel()
        {
            InitializeFields();
        }

        private void InitializeFields()
        {
            _comments = new string[2];
            _textArray = new[]
            {
                new[] {
                "GLOBAL PRACTICES",                "Please identify criminogenic needs that were targeted during the EPICS session (select any that apply)",
                "Pro-criminal attitude/orientation", "Family/Marital", "Leisure/Recreation",
                "Companions","Alcohol/Drug Problem","Criminal History",
                "Anti-social pattern","Education/Employment","",
                "Missed Opportunity (0)","(1)","(2)","(3)","Most Proficient (4)",
                "G1) Targeted criminogenic needs",
                "G2) Focused on primary criminogenic need",
                "G3) Spent more time on criminogenic needs than other needs",
                "G4) Made appropriate referrals to outside agencies",
                "G5) Integrated relapse prevention techniques for offending behavior",
                "G6) Completed session of adequate length",
                "G7) Communicated with client in a respectful manner",
                "G8) Communicated information to the client in a clear and concise manner",
                "G9) Elicited and gave appropriate feedback",
                "G10) Utilized role clarification",
                "CALCULATED TOTAL INTERVENTION SCORE = (G1 + G2 + G3 + G4 + G5 + G6 + G7 + G8 + G9 + G10)",
                "Please enter additional comments in the space below",
},
                new[] {
                "MOTIVATIONAL INTERVIEWING PRACTICES",
                "Behavior Counts",
                "MI Adherence –","Beginning competency is 90 % and","proficiency is 100 %",
                "Giving Information:", "MI Adherent:","MI non-adherent:","Total %: ",
                "% of Open Ended Questions","Beginning competency is 50 % or more","proficiency is 70 % or more",
                "Open:","Closed:","% of open ended: ",
                "% of Complex Reflections -","Beginning competency is 40 % or more","proficiency is 50 % or more",                "Complex:","Simple:","% of complex:",
                "% of Questions Divided by Reflections -Striving for 2:1 or 200 %:",
                "% of Questions Divided by Reflections: ",
                "Four Processes of MI",
                "Engagement happened ?","Focusing happened ?","Evoking happened ?","Planning happened ?",
                "Global Ratings",
                "Technical components", "LOW (1)","(2)","(3)","(4)", "HIGH (5)",
                "Cultivating change talk",
                "Sidestepping sustain talk",
                "Relational components","LOW (1)","(2)","(3)","(4)", "HIGH (5)",
                "Partnership",
                "Empathy",
                "Please enter additional comments in the space below"}
            };
            _boolArray = new[]
            {
                new[]
                {
                    new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), },
                    new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), },
                    new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), },
                    new []{ new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1),},
                    new []{ new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1),},
                    new []{ new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1),},
                    new []{ new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1),},
                    new []{ new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1),},
                    new []{ new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1),},
                    new []{ new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1),},
                    new []{ new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1),},
                    new []{ new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1),},
                    new []{ new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1),},
                },
                new[]
                {
                    new []{ new ObservableBool(), new ObservableBool(),},
                    new []{ new ObservableBool(), new ObservableBool(),},
                    new []{ new ObservableBool(), new ObservableBool(),},
                    new []{ new ObservableBool(),},
                    new []{ new ObservableBool(), new ObservableBool(),new ObservableBool(), new ObservableBool(),new ObservableBool(), new ObservableBool(),new ObservableBool(), new ObservableBool(),},
                    new []{ new ObservableBool(), new ObservableBool(),new ObservableBool(), new ObservableBool(),new ObservableBool(), },
                    new []{ new ObservableBool(), new ObservableBool(),new ObservableBool(), new ObservableBool(),new ObservableBool(), },
                    new []{ new ObservableBool(), new ObservableBool(),new ObservableBool(), new ObservableBool(),new ObservableBool(), },
                    new []{ new ObservableBool(), new ObservableBool(),new ObservableBool(), new ObservableBool(),new ObservableBool(), },
                },
            };
            _totalScores = new[]
            {
                new ObservableDouble(), 
            };
            _inputText = new string[20];
        }

        private void UpdateSection1(object sender, PropertyChangedEventArgs e)
        {
            if (BoolArray == null) return;
            int numNotNA = 0;

            int low = 0, high = 0;

            int numLow = 0;

            for (int row = 3; row < BoolArray[0]?.Length; row++)
            {
                var boolRow = BoolArray[0][row];
                if (boolRow[0]) continue; // skip if N/A
                ++numNotNA;
                for (int col = 1; col < boolRow?.Length; col++)
                {
                    if (boolRow[col])
                    {
                        if (col - 1 < 2)
                        {
                            low += col - 1;
                            ++numLow;
                        }
                        else
                            high += col - 1;
                    }
                }
            }

            TotalScores[0].Val = low + high;
            Page1ViewModel.Instance.GlobalLowScore = numLow;
            Page1ViewModel.Instance.GlobalHighScore = 10 - numLow;
            Page1ViewModel.Instance.GlobalScore = TotalScores[0].Val.ToString("N0");
        }

        public static Page7ViewModel Load(Stream stream, BinaryFormatter formatter)
        {
            var model = (Page7ViewModel)formatter.Deserialize(stream);
            model.RebindListeners();
            return model;
        }

        void RebindListeners()
        {
            if (BoolArray == null) return;

            for (int row = 3; row < BoolArray[0]?.Length; row++)
            {
                var boolRow = BoolArray[0][row];
                for (int col = 0; col < boolRow?.Length; col++)
                {
                    boolRow[col].AddListener(UpdateSection1);
                }
            }
        }
    }
}

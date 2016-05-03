using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    [Serializable]
    public class Page6ViewModel : IPageViewModel
    {
        #region Fields
        private String[][] _textArray;
        private ObservableBool[][][] _boolArray;
        private ObservableDouble[] _totalScores;
        private String[] _textInput;
        private String[] _comments;
        private String[] _commonText;

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
                RaisePropertyChangedEvent("TextArray");
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
                RaisePropertyChangedEvent("BoolArray");
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
                RaisePropertyChangedEvent("TotalScores");
            }
        }

        public string[] TextInput
        {
            get
            {
                return _textInput;
            }

            set
            {
                _textInput = value;
                RaisePropertyChangedEvent("TextInput");
            }
        }

        public string[] Comments
        {
            get
            {
                return _comments;
            }

            set
            {
                _comments = value;
                RaisePropertyChangedEvent("Comments");
            }
        }

        public string[] CommonText
        {
            get { return _commonText; }
            set
            {
                _commonText = value;
                RaisePropertyChangedEvent("CommonText");
            }
        }

        #endregion

        public Page6ViewModel()
        {
            InitializeFields();
        }

        void InitializeFields()
        {

            _commonText = new[] {"Missed Opportunity (0)", "(1)", "(2)", "(3)", "Most Proficient (4)",};
            _textArray = new[]
            {
                new[]
                {
                    "HOMEWORK/PLAN", "Time Stamp:","Total Time Spent:",
                    "Homework Assigned:",
                    "H1) Generalized the skill learned",
                    "H2) Assigned appropriate homework","CALCULATED TOTAL HOMEWORK SCORE = (H1+H2)/2",
                    "COMMENTS"
                },
                new[]
                {
                    "BEHAVIORAL PRACTICES SUMMARY",
                    "Please find and review specific behavioral practices (ER, ED, EUA) from the next table. Using the manual for reference be sure to note strengths and weaknesses for each behavioral practice in the comments box.When you have reviewed each type of behavioral practice, return to this summary table and determine an overall behavioral practices score.",
                    "Time Stamp:","Target:",
                    "B1) Used appropriate behavioral practices",
                    "B2) Completed the components of the behavioral practice",
                    "B3) Used behavioral practices effectively",
                    "CALCULATED TOTAL BEHAVIORAL PRACTICES SCORE = (B1 + B2 + B3) / 3"
                },
                new[]
                {
                    "Effective Reinforcement","Missed opportunity",
                    "Reinforced the pro-social behavior or comment",                    "Explained why they reinforced what was said or did (providing specific reasons)",                    "Explored the short term and long term benefits of continuing pro-social behavior",                    "Potential opportunities for reinforcement: ",
                    "COMMENTS"
                },
                new[]
                {
                    "Effective Disapproval","Missed opportunity",                    "Disapproved of anti-social behavior or comment",                    "Explained why they disapproved of what was said or did (providing specific reasons)",                    "Explored the short term and long term consequences of continuing anti-social behavior",                    "Discussed and identified pro-social alternatives that could be used in place of the unacceptable behavior",
                    "Potential opportunities for disapproval: ",
                    "COMMENTS"
                },
                new[]
                {
                    "Effective Use of Authority","Missed opportunity",                    "Focused on behavior",
                    "Kept a calm voice",                    "Specified choice and attendant consequences",
                    "Used role clarification",
                    "Potential opportunities for use of authority: ",
                    "COMMENTS"
                },
            };

            _comments = new string[5];
            _totalScores = new[] {new ObservableDouble(), new ObservableDouble(),};
            _textInput = new string[8];
            _boolArray = new[]
            {
                new[]
                {
                    new []{ new ObservableBool(UpdateTotalScore1), new ObservableBool(UpdateTotalScore1), new ObservableBool(UpdateTotalScore1), new ObservableBool(UpdateTotalScore1), new ObservableBool(UpdateTotalScore1), },
                    new []{ new ObservableBool(UpdateTotalScore1), new ObservableBool(UpdateTotalScore1), new ObservableBool(UpdateTotalScore1), new ObservableBool(UpdateTotalScore1), new ObservableBool(UpdateTotalScore1), },
                },
                new[]
                {
                    new []{ new ObservableBool(UpdateTotalScore2), new ObservableBool(UpdateTotalScore2), new ObservableBool(UpdateTotalScore2), new ObservableBool(UpdateTotalScore2), new ObservableBool(UpdateTotalScore2),},
                    new []{ new ObservableBool(UpdateTotalScore2), new ObservableBool(UpdateTotalScore2), new ObservableBool(UpdateTotalScore2), new ObservableBool(UpdateTotalScore2), new ObservableBool(UpdateTotalScore2),},
                    new []{ new ObservableBool(UpdateTotalScore2), new ObservableBool(UpdateTotalScore2), new ObservableBool(UpdateTotalScore2), new ObservableBool(UpdateTotalScore2), new ObservableBool(UpdateTotalScore2), },
                },
                new []
                {
                    new []{ new ObservableBool(), },
                    new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), }
                },
                new []
                {
                    new []{ new ObservableBool(), },
                    new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), }
                },
                new []
                {
                    new []{ new ObservableBool(), },
                    new []{ new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), new ObservableBool(), }
                },
            };
        }

        public void ResetListeners()
        {
            foreach (var observableBool in BoolArray[0])
            {
                foreach (var b in observableBool)
                {
                    b.AddListener(UpdateTotalScore1);
                }
            }
            foreach (var observableBool in BoolArray[1])
            {
                foreach (var b in observableBool)
                {
                    b.AddListener(UpdateTotalScore2);
                }
            }
        }

        public override int ExportToExcel(Worksheet worksheet, int curRow)
        {
            throw new NotImplementedException();
        }

        public static Page6ViewModel Load(Stream stream, BinaryFormatter formatter)
        {
            var model= (Page6ViewModel)formatter.Deserialize(stream);
            model.ResetListeners();
            return model;
        }

        private void UpdateTotalScore1(object sender, PropertyChangedEventArgs e)
        {
            if (BoolArray == null) return;
            int[] selections = new int[BoolArray[0].Length];

            for (int row = 0; row < BoolArray[0]?.Length; row++)
            {
                var boolRow = BoolArray[0][row];
                for (int col = 0; col < boolRow?.Length; col++)
                {
                    if (boolRow[col])
                        selections[row] = col;
                }
            }

            TotalScores[0].Val = selections.Sum() / (double)selections.Length;
        }

        private void UpdateTotalScore2(object sender, PropertyChangedEventArgs e)
        {
            if (BoolArray == null) return;
            int[] selections = new int[BoolArray[1].Length];

            for (int row = 0; row < BoolArray[1]?.Length; row++)
            {
                var boolRow = BoolArray[1][row];
                for (int col = 0; col < boolRow?.Length; col++)
                {
                    if (boolRow[col])
                        selections[row] = col;
                }
            }

            TotalScores[1].Val = selections.Sum() / (double)selections.Length;
        }
    }
}

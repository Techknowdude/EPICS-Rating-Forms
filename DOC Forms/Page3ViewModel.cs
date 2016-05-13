using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    [Serializable]
    class Page3ViewModel : IPageViewModel
    {

        #region Fields

        private ObservableBool[][] _section1Bools;

        private ObservableBool[][] _section2Bools;

        private ObservableBool[][] _section3Bools;

        private ObservableDouble[] _totalScores;

        private string[] _comments;
        private string[] _textArray;
        private string[] _checkInTextInput;
        private string[] _reviewTextInput;
        private string[] _interventionTextInput;

        #endregion

        #region Properties
        public ObservableBool[][] Section1Bools
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

        public ObservableBool[][] Section2Bools
        {
            get
            {
                return _section2Bools;
            }

            set
            {
                _section2Bools = value;
                RaisePropertyChangedEvent("Section2Bools");
            }
        }

        public ObservableBool[][] Section3Bools
        {
            get { return _section3Bools; }
            set
            {
                _section3Bools = value;
                RaisePropertyChangedEvent("Section3Bools");
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

        public string[] Comments
        {
            get
            {
                if(_comments == null)
                    _comments = new string[3];
                return _comments;
            }

            set
            {
                _comments = value;
                RaisePropertyChangedEvent("Comments");
            }
        }

        public String[] TextArray
        {
            get { return _textArray; }
            set
            {
                _textArray = value;
                RaisePropertyChangedEvent("TextArray");
            }
        }

        public String[] CheckInTextInput
        {
            get { return _checkInTextInput; }
            set
            {
                _checkInTextInput = value;
                RaisePropertyChangedEvent("TotalTimeSpent");
            }
        }

        public String[] ReviewTextInput
        {
            get { return _reviewTextInput; }
            set
            {
                _reviewTextInput = value;
                RaisePropertyChangedEvent("ReviewTextInput");
            }
        }

        public String[] InterventionTextInput
        {
            get { return _interventionTextInput; }
            set
            {
                _interventionTextInput = value;
                RaisePropertyChangedEvent("InterventionTextInput");
            }
        }

        #endregion

        public Page3ViewModel()
        {
            InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            _checkInTextInput = new string[1];
            _reviewTextInput = new string[2];
            _interventionTextInput = new string[5];

            _section1Bools = new[]
            {
                new[] { new ObservableBool(UpdateSection1CheckIn), new ObservableBool(UpdateSection1CheckIn), new ObservableBool(UpdateSection1CheckIn),new ObservableBool(UpdateSection1CheckIn),new ObservableBool(UpdateSection1CheckIn), },
                new[] { new ObservableBool(UpdateSection1CheckIn), new ObservableBool(UpdateSection1CheckIn), new ObservableBool(UpdateSection1CheckIn),new ObservableBool(UpdateSection1CheckIn),new ObservableBool(UpdateSection1CheckIn), },
                new[] { new ObservableBool(UpdateSection1CheckIn), new ObservableBool(UpdateSection1CheckIn), new ObservableBool(UpdateSection1CheckIn), new ObservableBool(UpdateSection1CheckIn), new ObservableBool(UpdateSection1CheckIn), }
            };

            _section2Bools = new[]
            {
                new[] { new ObservableBool(UpdateSection2Review), new ObservableBool(UpdateSection2Review), new ObservableBool(UpdateSection2Review), new ObservableBool(UpdateSection2Review),new ObservableBool(UpdateSection2Review),new ObservableBool(UpdateSection2Review), },
                new[] { new ObservableBool(UpdateSection2Review), new ObservableBool(UpdateSection2Review), new ObservableBool(UpdateSection2Review), new ObservableBool(UpdateSection2Review),new ObservableBool(UpdateSection2Review),new ObservableBool(UpdateSection2Review), },
                new[] { new ObservableBool(UpdateSection2Review), new ObservableBool(UpdateSection2Review), new ObservableBool(UpdateSection2Review), new ObservableBool(UpdateSection2Review),new ObservableBool(UpdateSection2Review),new ObservableBool(UpdateSection2Review), },
                new[] { new ObservableBool(UpdateSection2Review), new ObservableBool(UpdateSection2Review), new ObservableBool(UpdateSection2Review), new ObservableBool(UpdateSection2Review),new ObservableBool(UpdateSection2Review),new ObservableBool(UpdateSection2Review), },
            };

            _section3Bools = new[]
            {
                new[] { new ObservableBool(UpdateSection3Intervention), new ObservableBool(UpdateSection3Intervention), new ObservableBool(UpdateSection3Intervention), new ObservableBool(UpdateSection3Intervention), new ObservableBool(UpdateSection3Intervention),},
                new[] { new ObservableBool(UpdateSection3Intervention), new ObservableBool(UpdateSection3Intervention), new ObservableBool(UpdateSection3Intervention), new ObservableBool(UpdateSection3Intervention), new ObservableBool(UpdateSection3Intervention),},
                new[] { new ObservableBool(UpdateSection3Intervention), new ObservableBool(UpdateSection3Intervention), new ObservableBool(UpdateSection3Intervention), new ObservableBool(UpdateSection3Intervention), new ObservableBool(UpdateSection3Intervention),},
            };

            _textArray = new[]
            {
                "CHECK IN/ENGAGE", "Total Time Spent:", "Missed\nOpportunity\n(0)",
                "(1)","(2)","(3)","Most\nProficient\n(4)",
                "C1) Promoted a collaborative relationship/rapport with client",
                "C2) Assessed crisis/acute needs",
                "C3) Assessed for compliance with conditions",
                "CALCULATED TOTAL CHECK IN SCORE = (C1+C2+C3)",

                "REVIEW/FOCUS", "Time Stamp:", "Total Time Spent:",
                "Missed\nOpportunity\n(0)","(1)","(2)","(3)","Most\nProficient\n(4)",
                "R1) Set or reviewed short and long term goals",
                "R2) Discussed community agency referrals",
                "R3) Enhanced learning through repetition and feedback",
                "R4) Reviewed homework from the previous session",
                "CALCULATED TOTAL REVIEW SCORE = (R1+R2+R3+R4)",

                "INTERVENTION/EVOKE",
                "Find and review the intervention used in the session and delete unused interventions. Once you have reviewed the intervention, return to this Intervention/Evoke summary and provide a final score.",
                "Time Stamp:","Total Time Spent:","Intervention Focus:","Time Stamp:",
                "Potential areas of focus:",
                "i1) Used an appropriate intervention",
                "i2) Completed the steps of the intervention",
                "i3) Used the intervention effectively",
                "CALCULATE AND WRITE IN TOTAL INTERVENTION SCORE = (i1+i2+i3)"
            };
            _totalScores = new ObservableDouble[3] { new ObservableDouble(), new ObservableDouble(), new ObservableDouble(), };
            _comments = new string[3];
        }

        private void ResetListeners()
        {
            foreach (var observableBool in Section1Bools)
            {
                foreach (var b in observableBool)
                {
                    b.AddListener(UpdateSection1CheckIn);
                }
            }
            foreach (var observableBool in Section2Bools)
            {
                foreach (var b in observableBool)
                {
                    b.AddListener(UpdateSection2Review);
                }
            }
            foreach (var observableBool in Section3Bools)
            {
                foreach (var b in observableBool)
                {
                    b.AddListener(UpdateSection3Intervention);
                }
            }
        }

        public static Page3ViewModel Load(Stream stream, BinaryFormatter formatter)
        {
            var model = (Page3ViewModel)formatter.Deserialize(stream);
            model.ResetListeners();
            return model;
        }


        private void UpdateSection1CheckIn(object sender, PropertyChangedEventArgs e)
        {
            if (Section1Bools == null) return;
            int low = 0, high = 0, numLow = 0;

            for (int row = 0; row < Section1Bools?.Length; row++)
            {
                var boolRow = Section1Bools[row];
                for (int col = 0; col < boolRow?.Length; col++)
                {
                    if (boolRow[col])
                    {
                        if (col < 2)
                        {
                            low += col;
                            ++numLow;
                        }
                        else
                            high += col;
                    }
                }
            }

            TotalScores[0].Val = low + high;
            Page1ViewModel.Instance.CheckinLowScore = numLow;
            Page1ViewModel.Instance.CheckinHighScore = 3 - numLow;
            Page1ViewModel.Instance.CheckInScore = TotalScores[0].Val.ToString("N0");
        }

        private void UpdateSection2Review(object sender, PropertyChangedEventArgs e)
        {
            if (Section2Bools == null) return;

            double count = 0;
            int low = 0, high = 0, numLow = 0;

            for (int row = 0; row < Section2Bools?.Length; row++)
            {
                var boolRow = Section2Bools[row];
                if(boolRow[0]) continue;
                count++;

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

            TotalScores[1].Val = low + high;
            Page1ViewModel.Instance.ReviewLowScore = numLow;
            Page1ViewModel.Instance.ReviewHighScore = 4 - numLow;

            Page1ViewModel.Instance.ReviewScore = TotalScores[1].Val.ToString("N0");
        }

        private void UpdateSection3Intervention(object sender, PropertyChangedEventArgs e)
        {
            if (Section3Bools == null) return;

            int low = 0, high = 0, numLow = 0;

            for (int row = 0; row < Section3Bools?.Length; row++)
            {
                var boolRow = Section3Bools[row];
                for (int col = 0; col < boolRow?.Length; col++)
                {
                    if (boolRow[col])
                    {
                        if (col < 2)
                        {
                            low += col;
                            ++numLow;
                        }
                        else
                            high += col;
                    }
                }
            }

            Page1ViewModel.Instance.InterventionLowScore = numLow;
            Page1ViewModel.Instance.InterventionHighScore = 3-numLow;
            TotalScores[2].Val = low + high;
            Page1ViewModel.Instance.InterventionScore = TotalScores[2].Val.ToString("N0");
        }
    }
}

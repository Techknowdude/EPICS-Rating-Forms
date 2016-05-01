using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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

        private string _comments;
        private string[] _textArray;

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

        public string Comments
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

        public String[] TextArray
        {
            get { return _textArray; }
            set
            {
                _textArray = value;
                RaisePropertyChangedEvent("TextArray");
            }
        }

        #endregion

        public Page3ViewModel()
        {
            _section1Bools = new[]
            {
                new[] { new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1),new ObservableBool(UpdateSection1),new ObservableBool(UpdateSection1), },
                new[] { new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1),new ObservableBool(UpdateSection1),new ObservableBool(UpdateSection1), },
                new[] { new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), }
            };

            _section2Bools = new[]
            {
                new[] { new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2),new ObservableBool(UpdateSection2),new ObservableBool(UpdateSection2), },
                new[] { new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2),new ObservableBool(UpdateSection2),new ObservableBool(UpdateSection2), },
                new[] { new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2),new ObservableBool(UpdateSection2),new ObservableBool(UpdateSection2), },
                new[] { new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2),new ObservableBool(UpdateSection2),new ObservableBool(UpdateSection2), },
            };

            _section3Bools = new[]
            {
                new[] { new ObservableBool(UpdateSection3), new ObservableBool(UpdateSection3), new ObservableBool(UpdateSection3), new ObservableBool(UpdateSection3),},
                new[] { new ObservableBool(UpdateSection3), new ObservableBool(UpdateSection3), new ObservableBool(UpdateSection3), new ObservableBool(UpdateSection3),},
                new[] { new ObservableBool(UpdateSection3), new ObservableBool(UpdateSection3), new ObservableBool(UpdateSection3), new ObservableBool(UpdateSection3),},
            };

            _textArray = new[]
            {
                "CHECK IN/ENGAGE", "Total Time Spent:", "Missed\nOpportunity\n(0)",
                "(1)","(2)","(3)","Most\nProficient\n(4)",
                "C1) Promoted a collaborative relationship/rapport with client",
                "C2) Assessed crisis/acute needs",
                "C3) Assessed for compliance with conditions",
                "CALCULATED TOTAL CHECK IN SCORE = (C1+C2+C3)/3",

                "REVIEW/FOCUS", "Time Stamp:", "Total Time Spent:",
                "Missed\nOpportunity\n(0)","(1)","(2)","(3)","Most\nProficient\n(4)",
                "R1) Set or reviewed short and long term goals",
                "R2) Discussed community agency referrals",
                "R3) Enhanced learning through repetition and feedback",
                "R4) Reviewed homework from the previous session",
                "CALCULATED TOTAL REVIEW SCORE = (R1+R2+R3+R4)/(4-#N/A)"
            };
            _totalScores = new ObservableDouble[3] { new ObservableDouble(), new ObservableDouble(), new ObservableDouble(), };
        }


        public static Page3ViewModel Load(FileStream stream, BinaryFormatter formatter)
        {
            return (Page3ViewModel)formatter.Deserialize(stream);
        }


        public override int ExportToExcel(Worksheet worksheet, int curRow)
        {
            //TODO: Fill this in
            return curRow;
        }

        private void UpdateSection1(object sender, PropertyChangedEventArgs e)
        {
            if (Section1Bools == null) return;
            int[] selections = new int[Section1Bools.Length];

            for (int row = 0; row < Section1Bools?.Length; row++)
            {
                var boolRow = Section1Bools[row];
                for (int col = 0; col < boolRow?.Length; col++)
                {
                    if (boolRow[col])
                        selections[row] = col;
                }
            }

            TotalScores[0].Val = selections.Sum()/(double)selections.Length;
        }

        private void UpdateSection2(object sender, PropertyChangedEventArgs e)
        {
            if (Section2Bools == null) return;

            int[] selections = new int[Section2Bools.Length];
            double count = 0;

            for (int row = 0; row < Section2Bools?.Length; row++)
            {
                var boolRow = Section2Bools[row];
                if(boolRow[0]) continue;
                count++;

                for (int col = 1; col < boolRow?.Length; col++)
                {
                    if (boolRow[col])
                        selections[row] = col - 1;
                }
            }

            TotalScores[1].Val = selections.Sum() / count;
        }

        private void UpdateSection3(object sender, PropertyChangedEventArgs e)
        {
            if (Section3Bools == null) return;

            int[] selections = new int[Section3Bools.Length];

            for (int row = 0; row < Section3Bools?.Length; row++)
            {
                var boolRow = Section3Bools[row];
                for (int col = 0; col < boolRow?.Length; col++)
                {
                    if (boolRow[col])
                        selections[row] = col;
                }
            }

            TotalScores[0].Val = selections.Sum() / (double)selections.Count();
        }
    }
}

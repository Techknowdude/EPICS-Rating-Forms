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


        private double _checkInTotalScore;
        private string _section1Comments;

        private ObservableBool[][] _section2Bools;


        private double _reviewTotalScore;
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

        public double CheckInTotalScore
        {
            get
            {
                return _checkInTotalScore;
            }

            set
            {
                _checkInTotalScore = value;
                RaisePropertyChangedEvent("CheckInTotalScore");
            }
        }

        public double ReviewTotalScore
        {
            get
            {
                return _reviewTotalScore;
            }

            set
            {
                _reviewTotalScore = value;
                RaisePropertyChangedEvent("ReviewTotalScore");
            }
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
        public string Section2Comments
        {
            get
            {
                return _section1Comments;
            }

            set
            {
                _section1Comments = value;
                RaisePropertyChangedEvent("Section2Comments");
            }
        }

        #endregion

        public Page3ViewModel()
        {
            _section1Bools = new[]
            {
                new[] { new ObservableBool(UpdateSection1,true), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1),new ObservableBool(UpdateSection1), },
                new[] { new ObservableBool(UpdateSection1,true), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1),new ObservableBool(UpdateSection1), },
                new[] { new ObservableBool(UpdateSection1,true), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), new ObservableBool(UpdateSection1), }
            };

            _section2Bools = new[]
            {
                new[] { new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2),new ObservableBool(UpdateSection2),},
                new[] { new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2),new ObservableBool(UpdateSection2),new ObservableBool(UpdateSection2), },
                new[] { new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2),new ObservableBool(UpdateSection2),new ObservableBool(UpdateSection2), },
                new[] { new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2), new ObservableBool(UpdateSection2),new ObservableBool(UpdateSection2),new ObservableBool(UpdateSection2), },
            };
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
            int[] selections = new int[3] {0,0,0};

            for (int row = 0; row < Section1Bools?.Length; row++)
            {
                var boolRow = Section1Bools[row];
                for (int col = 0; col < boolRow?.Length; col++)
                {
                    if (boolRow[col])
                        selections[row] = col;
                }
            }

            CheckInTotalScore = selections.Sum()/(double)3;
        }

        private void UpdateSection2(object sender, PropertyChangedEventArgs e)
        {

        }
    }
}

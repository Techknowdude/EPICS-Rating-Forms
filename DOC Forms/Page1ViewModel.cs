using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    [Serializable]
    public class Page1ViewModel : IPageViewModel
    {

        private readonly Page1Logic _pageLogic;

        #region Fields

        private DateTime _sessionDate = DateTime.Today;
        private DateTime _reviewDate = DateTime.Today;
        private DateTime _clientDOB = DateTime.Today;
        private DateTime _nextTapeDueDate = DateTime.Today;

        private string _staffName;
        private string _reviewName;
        private string _caseloadNumber;
        private string _clientName;
        private string _sessionLength;
        private string _clientSID;
        private string _genderOtherText;
        private string _race;
        private string _checkInScore;
        private string _reviewScore;
        private string _interventionScore;
        private string _homeworkScore;
        private string _behavioralScore;
        private string _globalScore;
        private string _overallScore;
        private string _topStaffStrengths;
        private string _topStaffImprovements;
        private string _numberEpicsOver2;
        private string _percentEpicsOver2;
        private string _completedEpics;
        private string _totalEpics;
        private string _percentEpicsCompleted;
        private string _additionalCommentsText;

        private bool _genderMale;
        private bool _genderFemale;
        private bool _genderOther;
        private bool _firstMeetingYes;
        private bool _firstMeetingNo;
        private bool _firstMeetingNA;
        private bool _clientHomelessYes;
        private bool _clientHomelessNo;
        private bool _clientHomelessNA;
        private bool _clientAgressiveYes;
        private bool _clientAgressiveNo;
        private bool _clientAgressiveNA;
        private bool _genderOtherTextEnabled;


        #endregion


        #region Properties

        public DateTime SessionDate
        {
            get { return _sessionDate; }
            set
            {
                _sessionDate = value;
                RaisePropertyChangedEvent("SessionDate");
            }
        }

        public string StaffName
        {
            get
            {
                return _staffName;
            }

            set
            {
                _staffName = value;
                RaisePropertyChangedEvent("StaffName");
            }
        }


        public string ReviewName
        {
            get
            {
                return _reviewName;
            }

            set
            {
                _reviewName = value;
                RaisePropertyChangedEvent("ReviewName");
            }
        }

        public string CaseloadNumber
        {
            get
            {
                return _caseloadNumber;
            }

            set
            {
                _caseloadNumber = value;
                RaisePropertyChangedEvent("CaseloadNumber");
            }
        }

        public string ClientName
        {
            get
            {
                return _clientName;
            }

            set
            {
                _clientName = value;
                RaisePropertyChangedEvent("ClientName");
            }
        }

        public string SessionLength
        {
            get
            {
                return _sessionLength;
            }

            set
            {
                _sessionLength = value;
                RaisePropertyChangedEvent("SessionLength");
            }
        }

        public string ClientSID
        {
            get
            {
                return _clientSID;
            }

            set
            {
                _clientSID = value;
                RaisePropertyChangedEvent("ClientSID");
            }
        }

        public DateTime ReviewDate
        {
            get { return _reviewDate; }
            set
            {
                _reviewDate = value;
                RaisePropertyChangedEvent("ReviewDate");
            }
        }


        public DateTime ClientDOB
        {
            get
            {
                return _clientDOB;
            }

            set
            {
                _clientDOB = value;
                RaisePropertyChangedEvent("ClientDOB");
            }
        }

        public bool GenderMale
        {
            get
            {
                return _genderMale;
            }

            set
            {
                _genderMale = value;
                if (value)
                {
                    GenderFemale = false;
                    GenderOther = false;
                }
                RaisePropertyChangedEvent("GenderMale");
            }
        }

        public bool GenderFemale
        {
            get
            {
                return _genderFemale;
            }

            set
            {
                _genderFemale = value;
                if (value)
                {
                    GenderMale = false;
                    GenderOther = false;
                }
                RaisePropertyChangedEvent("GenderFemale");
            }
        }

        public bool GenderOther
        {
            get
            {
                return _genderOther;
            }

            set
            {
                _genderOther = value;
                if (value)
                {
                    GenderFemale = false;
                    GenderMale = false;
                }
                GenderOtherTextEnabled = value;
                RaisePropertyChangedEvent("GenderOther");
            }
        }

        public bool GenderOtherTextEnabled
        {
            get { return _genderOtherTextEnabled; }
            set
            {
                _genderOtherTextEnabled = value;
                RaisePropertyChangedEvent("GenderOtherTextEnabled");
            }
        }

        public string GenderOtherText
        {
            get
            {
                return _genderOtherText;
            }

            set
            {
                _genderOtherText = value;
                RaisePropertyChangedEvent("GenderOtherText");
            }
        }

        public string Race
        {
            get
            {
                return _race;
            }

            set
            {
                _race = value;
                RaisePropertyChangedEvent("Race");
            }
        }

        public bool FirstMeetingYes
        {
            get
            {
                return _firstMeetingYes;
            }

            set
            {
                _firstMeetingYes = value;
                if (value)
                {
                    FirstMeetingNo = false;
                    FirstMeetingNA = false;
                }
                RaisePropertyChangedEvent("FirstMeetingYes");
            }
        }

        public bool FirstMeetingNo
        {
            get
            {
                return _firstMeetingNo;
            }

            set
            {
                _firstMeetingNo = value;
                if (value)
                {
                    FirstMeetingYes = false;
                    FirstMeetingNA = false;
                }
                RaisePropertyChangedEvent("FirstMeetingNo");
            }
        }

        public bool FirstMeetingNA
        {
            get
            {
                return _firstMeetingNA;
            }

            set
            {
                _firstMeetingNA = value;
                if (value)
                {
                    FirstMeetingNo = false;
                    FirstMeetingYes = false;
                }
                RaisePropertyChangedEvent("FirstMeetingNA");
            }
        }

        public bool ClientHomelessYes
        {
            get
            {
                return _clientHomelessYes;
            }

            set
            {
                _clientHomelessYes = value;
                if (value)
                {
                    ClientHomelessNo = false;
                    ClientHomelessNA = false;
                }
                RaisePropertyChangedEvent("ClientHomelessYes");
            }
        }

        public bool ClientHomelessNo
        {
            get
            {
                return _clientHomelessNo;
            }

            set
            {
                _clientHomelessNo = value;
                if (value)
                {
                    ClientHomelessYes = false;
                    ClientHomelessNA = false;
                }
                RaisePropertyChangedEvent("ClientHomelessNo");
            }
        }

        public bool ClientHomelessNA
        {
            get
            {
                return _clientHomelessNA;
            }

            set
            {
                _clientHomelessNA = value;
                if (value)
                {
                    ClientHomelessNo = false;
                    ClientHomelessYes = false;
                }
                RaisePropertyChangedEvent("ClientHomelessNA");
            }
        }

        public bool ClientAgressiveYes
        {
            get
            {
                return _clientAgressiveYes;
            }

            set
            {
                _clientAgressiveYes = value;
                if (value)
                {
                    ClientAgressiveNo = false;
                    ClientAgressiveNA = false;
                }
                RaisePropertyChangedEvent("ClientAgressiveYes");
            }
        }

        public bool ClientAgressiveNo
        {
            get
            {
                return _clientAgressiveNo;
            }

            set
            {
                _clientAgressiveNo = value;
                if (value)
                {
                    ClientAgressiveYes = false;
                    ClientAgressiveNA = false;
                }
                RaisePropertyChangedEvent("ClientAgressiveNo");
            }
        }

        public bool ClientAgressiveNA
        {
            get
            {
                return _clientAgressiveNA;
            }

            set
            {
                _clientAgressiveNA = value;
                if (value)
                {
                    ClientAgressiveNo = false;
                    ClientAgressiveYes = false;
                }
                RaisePropertyChangedEvent("ClientAgressiveNA");
            }
        }

        public string CheckInScore
        {
            get
            {
                return _checkInScore;
            }

            set
            {
                _checkInScore = value;
                UpdateScores();
                RaisePropertyChangedEvent("CheckInScore");
            }
        }

        public string ReviewScore
        {
            get
            {
                return _reviewScore;
            }

            set
            {
                _reviewScore = value;
                UpdateScores();
                RaisePropertyChangedEvent("ReviewScore");
            }
        }

        public string InterventionScore
        {
            get
            {
                return _interventionScore;
            }

            set
            {
                _interventionScore = value;
                UpdateScores();
                RaisePropertyChangedEvent("InterventionScore");
            }
        }

        public string HomeworkScore
        {
            get
            {
                return _homeworkScore;
            }

            set
            {
                _homeworkScore = value;
                UpdateScores();
                RaisePropertyChangedEvent("HomeworkScore");
            }
        }

        public string BehavioralScore
        {
            get
            {
                return _behavioralScore;
            }

            set
            {
                _behavioralScore = value;
                UpdateScores();
                RaisePropertyChangedEvent("BehavioralScore");
            }
        }

        public string GlobalScore
        {
            get
            {
                return _globalScore;
            }

            set
            {
                _globalScore = value;
                UpdateScores();
                RaisePropertyChangedEvent("GlobalScore");
            }
        }

        public string OverallScore
        {
            get
            {
                return _overallScore;
            }

            set
            {
                _overallScore = value;
                RaisePropertyChangedEvent("OverallScore");
            }
        }

        public string TopStaffStrengths
        {
            get { return _topStaffStrengths; }
            set
            {
                _topStaffStrengths = value;
                RaisePropertyChangedEvent("TopStaffStrengths");
            }
        }

        public string TopStaffImprovements
        {
            get { return _topStaffImprovements; }
            set
            {
                _topStaffImprovements = value;
                RaisePropertyChangedEvent("TopStaffImprovements");
            }
        }

        public string NumberEpicsOver2
        {
            get { return _numberEpicsOver2; }
            set
            {
                _numberEpicsOver2 = value;
                RaisePropertyChangedEvent("NumberEpicsOver2");
            }
        }

        public string PercentEpicsOver2
        {
            get { return _percentEpicsOver2; }
            set
            {
                _percentEpicsOver2 = value;
                RaisePropertyChangedEvent("PercentEpicsOver2");
            }
        }

        public string CompletedEpics
        {
            get { return _completedEpics; }
            set
            {
                _completedEpics = value;
                UpdatePercentCompleted();
                RaisePropertyChangedEvent("CompletedEpics");
            }
        }


        public string TotalEpics
        {
            get { return _totalEpics; }
            set
            {
                _totalEpics = value;
                UpdatePercentCompleted();
                RaisePropertyChangedEvent("TotalEpics");
            }
        }

        public string PercentEpicsCompleted
        {
            get { return _percentEpicsCompleted; }
            set
            {
                _percentEpicsCompleted = value;
                RaisePropertyChangedEvent("PercentEpicsCompleted");
            }
        }

        public DateTime NextTapeDueDate
        {
            get { return _nextTapeDueDate; }
            set
            {
                _nextTapeDueDate = value;
                RaisePropertyChangedEvent("NextTapeDueDate");
            }
        }

        public string AdditionalCommentsText
        {
            get { return _additionalCommentsText; }
            set
            {
                _additionalCommentsText = value;
                RaisePropertyChangedEvent("AdditionalCommentsText");
            }
        }

        #endregion

        public Page1ViewModel()
        {
            _pageLogic = new Page1Logic();
            GenderOtherTextEnabled = false;
        }

        public override int ExportToExcel(Worksheet worksheet, int curRow)
        {
            return _pageLogic.ExportToExcel(BuildInfo(), worksheet, curRow);
        }

        private Page1ExportInfo BuildInfo()
        {
            var info = new Page1ExportInfo();

            info.SessionDate = SessionDate;
            return info;
        }
        
        private void UpdateScores()
        {
            double[] scores = new double[4];

            double behavior;
            double global;

            double.TryParse(CheckInScore, out scores[0]);
            double.TryParse(ReviewScore, out scores[1]);
            double.TryParse(InterventionScore, out scores[2]);
            double.TryParse(HomeworkScore, out scores[3]);
            double.TryParse(BehavioralScore, out behavior);
            double.TryParse(GlobalScore, out global);

            double overallScore = (scores.Sum() + behavior + global) / 6;
            double numHighScore = scores.Count(x => x >= 2.0);
            double percentageHighScore = numHighScore / 4;

            OverallScore = overallScore.ToString("N");
            NumberEpicsOver2 = numHighScore.ToString("N");
            PercentEpicsOver2 = percentageHighScore.ToString("P");
        }

        private void UpdatePercentCompleted()
        {
            int completed;
            int total;

            int.TryParse(CompletedEpics, out completed);
            int.TryParse(TotalEpics, out total);

            PercentEpicsCompleted = ((double)completed / total).ToString("P");
        }


        protected bool Equals(Page1ViewModel other)
        {
            return Equals(_pageLogic, other._pageLogic) &&
                   _sessionDate.Equals(other._sessionDate) &&
                   _reviewDate.Equals(other._reviewDate) &&
                   _clientDOB.Equals(other._clientDOB) &&
                   _nextTapeDueDate.Equals(other._nextTapeDueDate) &&
                   string.Equals(_staffName, other._staffName) &&
                   string.Equals(_reviewName, other._reviewName) &&
                   string.Equals(_caseloadNumber, other._caseloadNumber) &&
                   string.Equals(_clientName, other._clientName) &&
                   string.Equals(_sessionLength, other._sessionLength) &&
                   string.Equals(_clientSID, other._clientSID) &&
                   string.Equals(_genderOtherText, other._genderOtherText) &&
                   string.Equals(_race, other._race) &&
                   string.Equals(_checkInScore, other._checkInScore) &&
                   string.Equals(_reviewScore, other._reviewScore) &&
                   string.Equals(_interventionScore, other._interventionScore) &&
                   string.Equals(_homeworkScore, other._homeworkScore) &&
                   string.Equals(_behavioralScore, other._behavioralScore) &&
                   string.Equals(_globalScore, other._globalScore) &&
                   string.Equals(_overallScore, other._overallScore) &&
                   string.Equals(_topStaffStrengths, other._topStaffStrengths) &&
                   string.Equals(_topStaffImprovements, other._topStaffImprovements) &&
                   string.Equals(_numberEpicsOver2, other._numberEpicsOver2) &&
                   string.Equals(_percentEpicsOver2, other._percentEpicsOver2) &&
                   string.Equals(_completedEpics, other._completedEpics) &&
                   string.Equals(_totalEpics, other._totalEpics) &&
                   string.Equals(_percentEpicsCompleted, other._percentEpicsCompleted) &&
                   string.Equals(_additionalCommentsText, other._additionalCommentsText) &&
                   _genderMale == other._genderMale &&
                   _genderFemale == other._genderFemale &&
                   _genderOther == other._genderOther &&
                   _firstMeetingYes == other._firstMeetingYes &&
                   _firstMeetingNo == other._firstMeetingNo &&
                   _firstMeetingNA == other._firstMeetingNA &&
                   _clientHomelessYes == other._clientHomelessYes &&
                   _clientHomelessNo == other._clientHomelessNo &&
                   _clientHomelessNA == other._clientHomelessNA &&
                   _clientAgressiveYes == other._clientAgressiveYes &&
                   _clientAgressiveNo == other._clientAgressiveNo &&
                   _clientAgressiveNA == other._clientAgressiveNA &&
                   _genderOtherTextEnabled == other._genderOtherTextEnabled;
        }
        

        public static Page1ViewModel Load(FileStream stream, BinaryFormatter formatter)
        {
            return (Page1ViewModel)formatter.Deserialize(stream);
        }
        public new bool Save(FileStream stream, BinaryFormatter formatter)
        {
            try
            {
                formatter.Serialize(stream, this);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

    }
}

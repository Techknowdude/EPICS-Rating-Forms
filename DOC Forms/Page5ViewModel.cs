using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    [Serializable]
    public class Page5ViewModel : IPageViewModel
    {

        #region Fields
        private string _skillBuildingSkill;
        private string _careyText;
        private string _otherInterventionText;
        private string _graduatedText;
        private string _optionS1O1Text;
        private string _optionS4O1Text;
        private string _optionS1O2Text;
        private string _optionS1O3Text;
        private string _optionS1O4Text;
        private string _optionS1O5Text;
        private string _optionS1O6Text;
        private string _optionS1O7Text;
        private string _optionS1O8Text;
        private string _optionS2O1Text;
        private string _optionS2O2Text;
        private string _optionS2O3Text;
        private string _optionS2O4Text;
        private string _optionS2O5Text;
        private string _optionS2O6Text;
        private string _optionS3O1Text;
        private string _optionS3O2Text;
        private string _optionS3O3Text;
        private string _optionS3O4Text;
        private string _optionS3O5Text;
        private string _optionS3O6Text;
        private string _optionS3O7Text;
        private bool _optionS1O1;
        private bool _optionS1O2;
        private bool _optionS1O3;
        private bool _optionS1O4;
        private bool _optionS1O5;
        private bool _optionS1O6;
        private bool _optionS1O7;
        private bool _optionS1O8;
        private bool _optionS2O1;
        private bool _optionS2O2;
        private bool _optionS2O3;
        private bool _optionS2O4;
        private bool _optionS2O5;
        private bool _optionS2O6;
        private bool _optionS3O1;
        private bool _optionS3O2;
        private bool _optionS3O3;
        private bool _optionS3O4;
        private bool _optionS3O5;
        private bool _optionS3O6;
        private bool _optionS3O7;
        private bool _optionS4O1;

        #endregion
        #region Properties

        public ObservableCollection<String> FiftySkills => SharedResources.FiftySocialSkills;
        public ObservableCollection<String> BlueRedGuides => SharedResources.RedBlueGuides;


        public String SkillBuildingSkill
        {
            get { return _skillBuildingSkill; }
            set
            {
                _skillBuildingSkill = value;
                RaisePropertyChangedEvent("SkillBuildingSkill");
            }
        }

        public String CareyText
        {
            get { return _careyText; }
            set
            {
                _careyText = value;
                RaisePropertyChangedEvent("CareyText");
            }
        }

        public String OtherInterventionText
        {
            get { return _otherInterventionText; }
            set
            {
                _otherInterventionText = value;
                RaisePropertyChangedEvent("OtherInterventionText");
            }
        }

        public String GraduatedText
        {
            get { return _graduatedText; }
            set
            {
                _graduatedText = value;
                RaisePropertyChangedEvent("GraduatedText");
            }
        }

        public String OptionS1O1Text
        {
            get { return _optionS1O1Text; }
            set
            {
                _optionS1O1Text = value;
                RaisePropertyChangedEvent("OptionS1O1Text");
            }
        }

        public String OptionS1O2Text
        {
            get { return _optionS1O2Text; }
            set
            {
                _optionS1O2Text = value;
                RaisePropertyChangedEvent("OptionS1O2Text");
            }
        }

        public String OptionS1O3Text
        {
            get { return _optionS1O3Text; }
            set
            {
                _optionS1O3Text = value;
                RaisePropertyChangedEvent("OptionS1O3Text");
            }
        }

        public String OptionS1O4Text
        {
            get { return _optionS1O4Text; }
            set
            {
                _optionS1O4Text = value;
                RaisePropertyChangedEvent("OptionS1O4Text");
            }

        }

        public String OptionS1O5Text
        {
            get { return _optionS1O5Text; }
            set
            {
                _optionS1O5Text = value;
                RaisePropertyChangedEvent("OptionS1O5Text");
            }
        }

        public String OptionS1O6Text
        {
            get { return _optionS1O6Text; }
            set
            {
                _optionS1O6Text = value;
                RaisePropertyChangedEvent("OptionS1O6Text");
            }
        }

        public String OptionS1O7Text
        {
            get { return _optionS1O7Text; }
            set
            {
                _optionS1O7Text = value;
                RaisePropertyChangedEvent("OptionS1O7Text");
            }
        }

        public String OptionS1O8Text
        {
            get { return _optionS1O8Text; }
            set
            {
                _optionS1O8Text = value;
                RaisePropertyChangedEvent("OptionS1O8Text");
            }
        }

        public String OptionS2O1Text
        {
            get { return _optionS2O1Text; }
            set
            {
                _optionS2O1Text = value;
                RaisePropertyChangedEvent("OptionS2O1Text");
            }
        }

        public String OptionS2O2Text
        {
            get { return _optionS2O2Text; }
            set
            {
                _optionS2O2Text = value;
                RaisePropertyChangedEvent("OptionS2O2Text");
            }
        }

        public String OptionS2O3Text
        {
            get { return _optionS2O3Text; }
            set
            {
                _optionS2O3Text = value;
                RaisePropertyChangedEvent("OptionS2O3Text");
            }
        }

        public String OptionS2O4Text
        {
            get { return _optionS2O4Text; }
            set
            {
                _optionS2O4Text = value;
                RaisePropertyChangedEvent("OptionS2O4Text");
            }
        }

        public String OptionS2O5Text
        {
            get { return _optionS2O5Text; }
            set
            {
                _optionS2O5Text = value;
                RaisePropertyChangedEvent("OptionS2O5Text");
            }
        }

        public String OptionS2O6Text
        {
            get { return _optionS2O6Text; }
            set
            {
                _optionS2O6Text = value;
                RaisePropertyChangedEvent("OptionS2O6Text");
            }
        }

        public String OptionS3O1Text
        {
            get { return _optionS3O1Text; }
            set
            {
                _optionS3O1Text = value;
                RaisePropertyChangedEvent("OptionS3O1Text");
            }
        }

        public String OptionS3O2Text
        {
            get { return _optionS3O2Text; }
            set
            {
                _optionS3O2Text = value;
                RaisePropertyChangedEvent("OptionS3O2Text");
            }
        }

        public String OptionS3O3Text
        {
            get { return _optionS3O3Text; }
            set
            {
                _optionS3O3Text = value;
                RaisePropertyChangedEvent("OptionS3O3Text");
            }
        }

        public String OptionS3O4Text
        {
            get { return _optionS3O4Text; }
            set
            {
                _optionS3O4Text = value;
                RaisePropertyChangedEvent("OptionS3O4Text");
            }
        }

        public String OptionS3O5Text
        {
            get { return _optionS3O5Text; }
            set
            {
                _optionS3O5Text = value;
                RaisePropertyChangedEvent("OptionS3O5Text");
            }
        }

        public String OptionS3O6Text
        {
            get { return _optionS3O6Text; }
            set
            {
                _optionS3O6Text = value;
                RaisePropertyChangedEvent("OptionS3O6Text");
            }
        }

        public String OptionS3O7Text
        {
            get { return _optionS3O7Text; }
            set
            {
                _optionS3O7Text = value;
                RaisePropertyChangedEvent("OptionS3O7Text");
            }
        }

        public String OptionS4O1Text
        {
            get { return _optionS4O1Text; }
            set
            {
                _optionS4O1Text = value;
                RaisePropertyChangedEvent("OptionS4O1Text");
            }
        }

        public bool OptionS1O1
        {
            get { return _optionS1O1; }
            set
            {
                _optionS1O1 = value;
                RaisePropertyChangedEvent("OptionS1O1");
            }
        }

        public bool OptionS1O2
        {
            get { return _optionS1O2; }
            set
            {
                _optionS1O2 = value;
                RaisePropertyChangedEvent("OptionS1O2");
            }
        }

        public bool OptionS1O3
        {
            get { return _optionS1O3; }
            set
            {
                _optionS1O3 = value;
                RaisePropertyChangedEvent("OptionS1O3");
            }
        }

        public bool OptionS1O4
        {
            get { return _optionS1O4; }
            set
            {
                _optionS1O4 = value;
                RaisePropertyChangedEvent("OptionS1O4");
            }
        }

        public bool OptionS1O5
        {
            get { return _optionS1O5; }
            set
            {
                _optionS1O5 = value;
                RaisePropertyChangedEvent("OptionS1O5");
            }
        }

        public bool OptionS1O6
        {
            get { return _optionS1O6; }
            set
            {
                _optionS1O6 = value;
                RaisePropertyChangedEvent("OptionS1O6");
            }
        }

        public bool OptionS1O7
        {
            get { return _optionS1O7; }
            set
            {
                _optionS1O7 = value;
                RaisePropertyChangedEvent("OptionS1O7");
            }
        }

        public bool OptionS1O8
        {
            get { return _optionS1O8; }
            set
            {
                _optionS1O8 = value;
                RaisePropertyChangedEvent("OptionS1O8");
            }
        }

        public bool OptionS2O1
        {
            get { return _optionS2O1; }
            set
            {
                _optionS2O1 = value;
                RaisePropertyChangedEvent("OptionS2O1");
            }
        }

        public bool OptionS2O2
        {
            get { return _optionS2O2; }
            set
            {
                _optionS2O2 = value;
                RaisePropertyChangedEvent("OptionS2O2");
            }
        }

        public bool OptionS2O3
        {
            get { return _optionS2O3; }
            set
            {
                _optionS2O3 = value;
                RaisePropertyChangedEvent("OptionS2O3");
            }
        }

        public bool OptionS2O4
        {
            get { return _optionS2O4; }
            set
            {
                _optionS2O4 = value;
                RaisePropertyChangedEvent("OptionS2O4");
            }
        }

        public bool OptionS2O5
        {
            get { return _optionS2O5; }
            set
            {
                _optionS2O5 = value;
                RaisePropertyChangedEvent("OptionS2O5");
            }
        }

        public bool OptionS2O6
        {
            get { return _optionS2O6; }
            set
            {
                _optionS2O6 = value;
                RaisePropertyChangedEvent("OptionS2O6");
            }
        }

        public bool OptionS3O1
        {
            get { return _optionS3O1; }
            set
            {
                _optionS3O1 = value;
                RaisePropertyChangedEvent("OptionS3O1");
            }
        }

        public bool OptionS3O2
        {
            get { return _optionS3O2; }
            set
            {
                _optionS3O2 = value;
                RaisePropertyChangedEvent("OptionS3O2");
            }
        }

        public bool OptionS3O3
        {
            get { return _optionS3O3; }
            set
            {
                _optionS3O3 = value;
                RaisePropertyChangedEvent("OptionS3O3");
            }
        }

        public bool OptionS3O4
        {
            get { return _optionS3O4; }
            set
            {
                _optionS3O4 = value;
                RaisePropertyChangedEvent("OptionS3O4");
            }
        }

        public bool OptionS3O5
        {
            get { return _optionS3O5; }
            set
            {
                _optionS3O5 = value;
                RaisePropertyChangedEvent("OptionS3O5");
            }
        }

        public bool OptionS3O6
        {
            get { return _optionS3O6; }
            set
            {
                _optionS3O6 = value;
                RaisePropertyChangedEvent("OptionS3O6");
            }
        }

        public bool OptionS3O7
        {
            get { return _optionS3O7; }
            set
            {
                _optionS3O7 = value;
                RaisePropertyChangedEvent("OptionS3O7");
            }
        }

        public bool OptionS4O1
        {
            get { return _optionS4O1; }
            set
            {
                _optionS4O1 = value;
                RaisePropertyChangedEvent("OptionS4O1");
            }
        }


        public static readonly int BarColor = ColorTranslator.ToOle(Color.CornflowerBlue);

        #endregion

        public IPageInterface PageInterface { get; set; }

        public Page5ViewModel()
        {
            LoadText();
        }

        private void LoadText()
        {
            SkillBuildingSkill = String.Empty;
            CareyText = String.Empty;
            OtherInterventionText = String.Empty;
            GraduatedText = String.Empty;

            OptionS1O1Text = "Introduced the skill";
            OptionS1O2Text = "Discussed the importance or usefulness of the skill";
            OptionS1O3Text = "Taught and explained the different steps of the skill";
            OptionS1O4Text = "Elicited client input on the skill steps";
            OptionS1O5Text = "Applied the skill to a specific situation of the client";
            OptionS1O6Text = "Modeled the skill";
            OptionS1O7Text = "Had the client role play/practice the skill with the specific situation";
            OptionS1O8Text = "Provided feedback to the client about the role play/skill practice";

            OptionS2O1Text = "Introduced the Intervention";
            OptionS2O2Text = "Discussed the importance or usefulness of the intervention";
            OptionS2O3Text = "Walked through the steps/questions of the intervention using an example (Model)";
            OptionS2O4Text = "Provided an opportunity for the client to walk through some of the questions before assigning it as homework";
            OptionS2O5Text = "Provided feedback to the client about the new skill being used";
            OptionS2O6Text = "Provided instructions in a clean manner";

            OptionS3O1Text = "Introduced the Intervention";
            OptionS3O2Text = "Discussed the importance of usefulness of the intervention";
            OptionS3O3Text = "Taught and explained the different components/steps";
            OptionS3O4Text = "Applied the different components/steps to a specific situation";
            OptionS3O5Text = "Modeled the intervention to the client";
            OptionS3O6Text = "Had the client practice use of the intervention";
            OptionS3O7Text = "Provided feedback to the client on the use of the intervention (reinforced or constructive feedback";

            OptionS4O1Text = "Practiced a previously taught intervention again but in a different situation";
        }

        public void Connect(IPageInterface page)
        {
            page.ViewModel = this;
            PageInterface = page;
        }

        int ExportSection1(Worksheet worksheet, int curRow)
        {
            // ## Section 1 ##

            // Output the title of the section
            Range rng = worksheet.get_Range("A" + curRow, "E" + curRow);
            rng.Cells.Font.Size = 18;
            rng.Cells.Font.Bold = true;
            rng.Merge();
            rng.Interior.Color = BarColor;
            rng.Value = "Skill Building or Problem Solving";
            curRow++;
            // Output selected skill
            rng = worksheet.get_Range("A" + curRow++);
            rng.Cells.Font.Bold = true;
            rng.Cells.Font.Size = 14;
            rng.Value = SkillBuildingSkill;

            // List all checked items
            if (OptionS1O1)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS1O1Text;
            }
            if (OptionS1O2)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS1O2Text;
            }
            if (OptionS1O3)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS1O3Text;
            }
            if (OptionS1O4)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS1O4Text;
            }
            if (OptionS1O5)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS1O5Text;
            }
            if (OptionS1O6)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS1O6Text;
            }
            if (OptionS1O7)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS1O7Text;
            }
            if (OptionS1O8)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS1O8Text;
            }


            return curRow;
        }

        int ExportSection2(Worksheet worksheet, int curRow)
        {
            // ## Section 2 ##

            // Output the title of the section
            Range rng = worksheet.get_Range("A" + curRow, "E" + curRow++);
            rng.Cells.Font.Size = 18;
            rng.Cells.Font.Bold = true;
            rng.Merge();
            rng.Interior.Color = BarColor;
            rng.Value = "Carey Guide/Carey BIT";

            // Output selected skill
            rng = worksheet.get_Range("A" + curRow++);
            rng.Cells.Font.Bold = true;
            rng.Cells.Font.Size = 14;
            rng.Value = CareyText;
            // List all checked items
            if (OptionS2O1)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS2O1Text;
            }
            if (OptionS2O2)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS2O2Text;
            }
            if (OptionS2O3)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS2O3Text;
            }
            if (OptionS2O4)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS2O4Text;
            }
            if (OptionS2O5)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS2O5Text;
            }
            if (OptionS2O6)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS2O6Text;
            }


            return curRow;
        }

        int ExportSection3(Worksheet worksheet, int curRow)
        {
            // ## Section 3 ##

            // Output the title of the section
            Range rng = worksheet.get_Range("A" + curRow, "E" + curRow++);
            rng.Cells.Font.Size = 18;
            rng.Cells.Font.Bold = true;
            rng.Merge();
            rng.Interior.Color = BarColor;
            rng.Value = "Other Intervention";

            // Output selected skill
            rng = worksheet.get_Range("A" + curRow++);
            rng.Cells.Font.Bold = true;
            rng.Cells.Font.Size = 14;
            rng.Value = OtherInterventionText;


            // List all checked items
            if (OptionS3O1)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS3O1Text;
            }
            if (OptionS3O2)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS3O2Text;
            }
            if (OptionS3O3)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS3O3Text;
            }
            if (OptionS3O4)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS3O4Text;
            }
            if (OptionS3O5)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS3O5Text;
            }
            if (OptionS3O6)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS3O6Text;
            }
            if (OptionS3O7)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS3O7Text;
            }



            return curRow;
        }

        int ExportSection4(Worksheet worksheet, int curRow)
        {
            // ## Section 4 ##

            // Output the title of the section
            Range rng = worksheet.get_Range("A" + curRow, "E" + curRow++);
            rng.Cells.Font.Size = 18;
            rng.Cells.Font.Bold = true;
            rng.Merge();
            rng.Interior.Color = BarColor;
            rng.Value = "Graduated Rehearsal";

            // Output selected skill
            rng = worksheet.get_Range("A" + curRow++);
            rng.Cells.Font.Bold = true;
            rng.Cells.Font.Size = 14;
            rng.Value = GraduatedText;

            // List all checked items
            if (OptionS4O1)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = OptionS4O1Text;
            }

            return curRow;
        }

        public static Page5ViewModel Load(Stream stream, BinaryFormatter formatter)
        {
            var view = (Page5ViewModel)formatter.Deserialize(stream);

            return view;
        }
    }
}

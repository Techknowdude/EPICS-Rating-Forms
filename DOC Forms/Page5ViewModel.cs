using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    public class Page5ViewModel : DependencyObject, IPageLogic
    {
        #region DependencyProperties

        public static readonly DependencyProperty SkillBuildingProperty = DependencyProperty.Register("SkillBuildingSkill", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS1O1Property = DependencyProperty.Register("OptionS1O1", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS1O1TextProperty = DependencyProperty.Register("OptionS1O1Text", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS1O2Property = DependencyProperty.Register("OptionS1O2", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS1O2TextProperty = DependencyProperty.Register("OptionS1O2Text", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS1O3Property = DependencyProperty.Register("OptionS1O3", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS1O3TextProperty = DependencyProperty.Register("OptionS1O3Text", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS1O4Property = DependencyProperty.Register("OptionS1O4", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS1O4TextProperty = DependencyProperty.Register("OptionS1O4Text", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS1O5Property = DependencyProperty.Register("OptionS1O5", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS1O5TextProperty = DependencyProperty.Register("OptionS1O5Text", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS1O6Property = DependencyProperty.Register("OptionS1O6", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS1O6TextProperty = DependencyProperty.Register("OptionS1O6Text", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS1O7Property = DependencyProperty.Register("OptionS1O7", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS1O7TextProperty = DependencyProperty.Register("OptionS1O7Text", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS1O8Property = DependencyProperty.Register("OptionS1O8", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS1O8TextProperty = DependencyProperty.Register("OptionS1O8Text", typeof(String),
            typeof(Page5ViewModel));

        public static readonly DependencyProperty CareyTextProperty = DependencyProperty.Register("CareyText", typeof(String),
            typeof(Page5ViewModel));

        public static readonly DependencyProperty OptionS2O1Property = DependencyProperty.Register("OptionS2O1", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS2O1TextProperty = DependencyProperty.Register("OptionS2O1Text", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS2O2Property = DependencyProperty.Register("OptionS2O2", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS2O2TextProperty = DependencyProperty.Register("OptionS2O2Text", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS2O3Property = DependencyProperty.Register("OptionS2O3", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS2O3TextProperty = DependencyProperty.Register("OptionS2O3Text", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS2O4Property = DependencyProperty.Register("OptionS2O4", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS2O4TextProperty = DependencyProperty.Register("OptionS2O4Text", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS2O5Property = DependencyProperty.Register("OptionS2O5", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS2O5TextProperty = DependencyProperty.Register("OptionS2O5Text", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS2O6Property = DependencyProperty.Register("OptionS2O6", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS2O6TextProperty = DependencyProperty.Register("OptionS2O6Text", typeof(String),
            typeof(Page5ViewModel));

        public static readonly DependencyProperty OtherInterventionProperty = DependencyProperty.Register("OtherInterventionText", typeof(String),
            typeof(Page5ViewModel));


        public static readonly DependencyProperty OptionS3O1Property = DependencyProperty.Register("OptionS3O1", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS3O1TextProperty = DependencyProperty.Register("OptionS3O1Text", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS3O2Property = DependencyProperty.Register("OptionS3O2", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS3O2TextProperty = DependencyProperty.Register("OptionS3O2Text", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS3O3Property = DependencyProperty.Register("OptionS3O3", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS3O3TextProperty = DependencyProperty.Register("OptionS3O3Text", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS3O4Property = DependencyProperty.Register("OptionS3O4", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS3O4TextProperty = DependencyProperty.Register("OptionS3O4Text", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS3O5Property = DependencyProperty.Register("OptionS3O5", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS3O5TextProperty = DependencyProperty.Register("OptionS3O5Text", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS3O6Property = DependencyProperty.Register("OptionS3O6", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS3O6TextProperty = DependencyProperty.Register("OptionS3O6Text", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS3O7Property = DependencyProperty.Register("OptionS3O7", typeof(Boolean),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS3O7TextProperty = DependencyProperty.Register("OptionS3O7Text", typeof(String),
            typeof(Page5ViewModel));

        public static readonly DependencyProperty GradutaedTextProperty = DependencyProperty.Register("GraduatedText", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS4O1TextProperty = DependencyProperty.Register("OptionS4O1Text", typeof(String),
            typeof(Page5ViewModel));
        public static readonly DependencyProperty OptionS4O1Property = DependencyProperty.Register("OptionS4O1", typeof(Boolean),
            typeof(Page5ViewModel));
        #endregion
        #region Properties

        public ObservableCollection<String> FiftySkills => SharedResources.FiftySocialSkills;
        public ObservableCollection<String> BlueRedGuides => SharedResources.RedBlueGuides;

        public String SkillBuildingSkill { get { return (String)GetValue(SkillBuildingProperty); } set { SetValue(SkillBuildingProperty, value); } }

        public bool OptionS1O1 { get { return (bool)GetValue(OptionS1O1Property); } set { SetValue(OptionS1O1Property, value); } }
        public String OptionS1O1Text { get { return (String)GetValue(OptionS1O1TextProperty); } set { SetValue(OptionS1O1TextProperty, value); } }
        public bool OptionS1O2 { get { return (bool)GetValue(OptionS1O2Property); } set { SetValue(OptionS1O2Property, value); } }
        public String OptionS1O2Text { get { return (String)GetValue(OptionS1O2TextProperty); } set { SetValue(OptionS1O2TextProperty, value); } }
        public bool OptionS1O3 { get { return (bool)GetValue(OptionS1O3Property); } set { SetValue(OptionS1O3Property, value); } }
        public String OptionS1O3Text { get { return (String)GetValue(OptionS1O3TextProperty); } set { SetValue(OptionS1O3TextProperty, value); } }
        public bool OptionS1O4 { get { return (bool)GetValue(OptionS1O4Property); } set { SetValue(OptionS1O4Property, value); } }
        public String OptionS1O4Text { get { return (String)GetValue(OptionS1O4TextProperty); } set { SetValue(OptionS1O4TextProperty, value); } }
        public bool OptionS1O5 { get { return (bool)GetValue(OptionS1O5Property); } set { SetValue(OptionS1O5Property, value); } }
        public String OptionS1O5Text { get { return (String)GetValue(OptionS1O5TextProperty); } set { SetValue(OptionS1O5TextProperty, value); } }
        public bool OptionS1O6 { get { return (bool)GetValue(OptionS1O6Property); } set { SetValue(OptionS1O6Property, value); } }
        public String OptionS1O6Text { get { return (String)GetValue(OptionS1O6TextProperty); } set { SetValue(OptionS1O6TextProperty, value); } }
        public bool OptionS1O7 { get { return (bool)GetValue(OptionS1O7Property); } set { SetValue(OptionS1O7Property, value); } }
        public String OptionS1O7Text { get { return (String)GetValue(OptionS1O7TextProperty); } set { SetValue(OptionS1O7TextProperty, value); } }
        public bool OptionS1O8 { get { return (bool)GetValue(OptionS1O8Property); } set { SetValue(OptionS1O8Property, value); } }
        public String OptionS1O8Text { get { return (String)GetValue(OptionS1O8TextProperty); } set { SetValue(OptionS1O8TextProperty, value); } }

        public String CareyText { get { return (String)GetValue(CareyTextProperty); } set { SetValue(CareyTextProperty, value); } }

        public bool OptionS2O1 { get { return (bool)GetValue(OptionS2O1Property); } set { SetValue(OptionS2O1Property, value); } }
        public String OptionS2O1Text { get { return (String)GetValue(OptionS2O1TextProperty); } set { SetValue(OptionS2O1TextProperty, value); } }
        public bool OptionS2O2 { get { return (bool)GetValue(OptionS2O2Property); } set { SetValue(OptionS2O2Property, value); } }
        public String OptionS2O2Text { get { return (String)GetValue(OptionS2O2TextProperty); } set { SetValue(OptionS2O2TextProperty, value); } }
        public bool OptionS2O3 { get { return (bool)GetValue(OptionS2O3Property); } set { SetValue(OptionS2O3Property, value); } }
        public String OptionS2O3Text { get { return (String)GetValue(OptionS2O3TextProperty); } set { SetValue(OptionS2O3TextProperty, value); } }
        public bool OptionS2O4 { get { return (bool)GetValue(OptionS2O4Property); } set { SetValue(OptionS2O4Property, value); } }
        public String OptionS2O4Text { get { return (String)GetValue(OptionS2O4TextProperty); } set { SetValue(OptionS2O4TextProperty, value); } }
        public bool OptionS2O5 { get { return (bool)GetValue(OptionS2O5Property); } set { SetValue(OptionS2O5Property, value); } }
        public String OptionS2O5Text { get { return (String)GetValue(OptionS2O5TextProperty); } set { SetValue(OptionS2O5TextProperty, value); } }
        public bool OptionS2O6 { get { return (bool)GetValue(OptionS2O6Property); } set { SetValue(OptionS2O6Property, value); } }
        public String OptionS2O6Text { get { return (String)GetValue(OptionS2O6TextProperty); } set { SetValue(OptionS2O6TextProperty, value); } }

        public String OtherInterventionText { get { return (String)GetValue(OtherInterventionProperty); } set { SetValue(OtherInterventionProperty, value); } }

        public bool OptionS3O1 { get { return (bool)GetValue(OptionS3O1Property); } set { SetValue(OptionS3O1Property, value); } }
        public String OptionS3O1Text { get { return (String)GetValue(OptionS3O1TextProperty); } set { SetValue(OptionS3O1TextProperty, value); } }
        public bool OptionS3O2 { get { return (bool)GetValue(OptionS3O2Property); } set { SetValue(OptionS3O2Property, value); } }
        public String OptionS3O2Text { get { return (String)GetValue(OptionS3O2TextProperty); } set { SetValue(OptionS3O2TextProperty, value); } }
        public bool OptionS3O3 { get { return (bool)GetValue(OptionS3O3Property); } set { SetValue(OptionS3O3Property, value); } }
        public String OptionS3O3Text { get { return (String)GetValue(OptionS3O3TextProperty); } set { SetValue(OptionS3O3TextProperty, value); } }
        public bool OptionS3O4 { get { return (bool)GetValue(OptionS3O4Property); } set { SetValue(OptionS3O4Property, value); } }
        public String OptionS3O4Text { get { return (String)GetValue(OptionS3O4TextProperty); } set { SetValue(OptionS3O4TextProperty, value); } }
        public bool OptionS3O5 { get { return (bool)GetValue(OptionS3O5Property); } set { SetValue(OptionS3O5Property, value); } }
        public String OptionS3O5Text { get { return (String)GetValue(OptionS3O5TextProperty); } set { SetValue(OptionS3O5TextProperty, value); } }
        public bool OptionS3O6 { get { return (bool)GetValue(OptionS3O6Property); } set { SetValue(OptionS3O6Property, value); } }
        public String OptionS3O6Text { get { return (String)GetValue(OptionS3O6TextProperty); } set { SetValue(OptionS3O6TextProperty, value); } }
        public bool OptionS3O7 { get { return (bool)GetValue(OptionS3O7Property); } set { SetValue(OptionS3O7Property, value); } }
        public String OptionS3O7Text { get { return (String)GetValue(OptionS3O7TextProperty); } set { SetValue(OptionS3O7TextProperty, value); } }


        public String GraduatedText { get { return (String)GetValue(GradutaedTextProperty); } set { SetValue(GradutaedTextProperty, value); } }

        public String OptionS4O1Text { get { return (String)GetValue(OptionS4O1TextProperty); } set { SetValue(OptionS4O1TextProperty, value); } }
        public bool OptionS4O1 { get { return (bool)GetValue(OptionS4O1Property); } set { SetValue(OptionS4O1Property, value); } }

        public int BarColor = ColorTranslator.ToOle(Color.CornflowerBlue);

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

        public bool Save(BinaryWriter writer)
        {
            try
            {
                writer.Write(SkillBuildingSkill);
                writer.Write(CareyText);
                writer.Write(OtherInterventionText);
                writer.Write(GraduatedText);

                writer.Write(OptionS1O1);
                writer.Write(OptionS1O1Text);
                writer.Write(OptionS1O2);
                writer.Write(OptionS1O2Text);
                writer.Write(OptionS1O3);
                writer.Write(OptionS1O3Text);
                writer.Write(OptionS1O4);
                writer.Write(OptionS1O4Text);
                writer.Write(OptionS1O5);
                writer.Write(OptionS1O5Text);
                writer.Write(OptionS1O6);
                writer.Write(OptionS1O6Text);
                writer.Write(OptionS1O7);
                writer.Write(OptionS1O7Text);
                writer.Write(OptionS1O8);
                writer.Write(OptionS1O8Text);

                writer.Write(OptionS2O1);
                writer.Write(OptionS2O1Text);
                writer.Write(OptionS2O2);
                writer.Write(OptionS2O2Text);
                writer.Write(OptionS2O3);
                writer.Write(OptionS2O3Text);
                writer.Write(OptionS2O4);
                writer.Write(OptionS2O4Text);
                writer.Write(OptionS2O5);
                writer.Write(OptionS2O5Text);
                writer.Write(OptionS2O6);
                writer.Write(OptionS2O6Text);

                writer.Write(OptionS3O1);
                writer.Write(OptionS3O1Text);
                writer.Write(OptionS3O2);
                writer.Write(OptionS3O2Text);
                writer.Write(OptionS3O3);
                writer.Write(OptionS3O3Text);
                writer.Write(OptionS3O4);
                writer.Write(OptionS3O4Text);
                writer.Write(OptionS3O5);
                writer.Write(OptionS3O5Text);
                writer.Write(OptionS3O6);
                writer.Write(OptionS3O6Text);
                writer.Write(OptionS3O7);
                writer.Write(OptionS3O7Text);

                writer.Write(OptionS4O1);
                writer.Write(OptionS4O1Text);

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Load(BinaryReader reader)
        {
            try
            {
                SkillBuildingSkill = reader.ReadString();
                CareyText = reader.ReadString();
                OtherInterventionText = reader.ReadString();
                GraduatedText = reader.ReadString();

                OptionS1O1 = reader.ReadBoolean();
                OptionS1O1Text = reader.ReadString();
                OptionS1O2 = reader.ReadBoolean();
                OptionS1O2Text = reader.ReadString();
                OptionS1O3 = reader.ReadBoolean();
                OptionS1O3Text = reader.ReadString();
                OptionS1O4 = reader.ReadBoolean();
                OptionS1O4Text = reader.ReadString();
                OptionS1O5 = reader.ReadBoolean();
                OptionS1O5Text = reader.ReadString();
                OptionS1O6 = reader.ReadBoolean();
                OptionS1O6Text = reader.ReadString();
                OptionS1O7 = reader.ReadBoolean();
                OptionS1O7Text = reader.ReadString();
                OptionS1O8 = reader.ReadBoolean();
                OptionS1O8Text = reader.ReadString();

                OptionS2O1 = reader.ReadBoolean();
                OptionS2O1Text = reader.ReadString();
                OptionS2O2 = reader.ReadBoolean();
                OptionS2O2Text = reader.ReadString();
                OptionS2O3 = reader.ReadBoolean();
                OptionS2O3Text = reader.ReadString();
                OptionS2O4 = reader.ReadBoolean();
                OptionS2O4Text = reader.ReadString();
                OptionS2O5 = reader.ReadBoolean();
                OptionS2O5Text = reader.ReadString();
                OptionS2O6 = reader.ReadBoolean();
                OptionS2O6Text = reader.ReadString();

                OptionS3O1 = reader.ReadBoolean();
                OptionS3O1Text = reader.ReadString();
                OptionS3O2 = reader.ReadBoolean();
                OptionS3O2Text = reader.ReadString();
                OptionS3O3 = reader.ReadBoolean();
                OptionS3O3Text = reader.ReadString();
                OptionS3O4 = reader.ReadBoolean();
                OptionS3O4Text = reader.ReadString();
                OptionS3O5 = reader.ReadBoolean();
                OptionS3O5Text = reader.ReadString();
                OptionS3O6 = reader.ReadBoolean();
                OptionS3O6Text = reader.ReadString();
                OptionS3O7 = reader.ReadBoolean();
                OptionS3O7Text = reader.ReadString();

                OptionS4O1 = reader.ReadBoolean();
                OptionS4O1Text = reader.ReadString();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public int ExportToExcel(Worksheet worksheet, int curRow)
        {
            try
            {
                lock (this)
                {

                    curRow = ExportSection1(worksheet, curRow) + 1;
                    curRow = ExportSection2(worksheet, curRow) + 1;
                    curRow = ExportSection3(worksheet, curRow) + 1;
                    curRow = ExportSection4(worksheet, curRow) + 1;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("### Page 5 Logic Excel export error:" + exception.Message);

                curRow = -1;
            }

            return curRow;
        }

        public void Connect(IPageInterface page)
        {
            page.Logic = this;
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


        /// <summary>
        /// Creates a shallow copy of the logic.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

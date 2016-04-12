using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Windows.Controls;
using Microsoft.Office.Interop.Excel;
using Color = System.Drawing.Color;
using Page = System.Windows.Controls.Page;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for Page6.xaml
    /// </summary>
    public partial class Page6 : Page, IPageInterface
    {
        
        public ObservableCollection<String> FiftySkills => SharedResources.FiftySocialSkills;
        public ObservableCollection<String> BlueRedGuides => SharedResources.RedBlueGuides;
        public int BarColor = ColorTranslator.ToOle(Color.CornflowerBlue);

        public Page6()
        {
            DataContext = this;
            InitializeComponent();
        }

        public bool IsCompleted()
        {
            throw new NotImplementedException();
        }

        public bool Save(BinaryWriter writer)
        {
            throw new NotImplementedException();
        }

        public bool Load(BinaryReader reader)
        {
            throw new NotImplementedException();
        }

        public bool ExportToExcel(Worksheet worksheet, int curRow, out int outRow)
        {
            bool success = true;


            curRow = ExportSection1(worksheet, curRow);
            curRow = ExportSection2(worksheet, curRow);
            curRow = ExportSection3(worksheet, curRow);
            curRow = ExportSection4(worksheet, curRow);
        
            outRow = curRow;
            return success;
        }

        private void CbbSkillBuilding_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbbGraduated.SelectedIndex = CbbSkillBuilding.SelectedIndex;
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
            rng.Value = CbbSkillBuilding.SelectedValue;

            // List all checked items
            if (LcbS1O1.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS1O1.LabelContent;
            }
            if (LcbS1O2.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS1O2.LabelContent;
            }
            if (LcbS1O3.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS1O3.LabelContent;
            }
            if (LcbS1O4.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS1O4.LabelContent;
            }
            if (LcbS1O5.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS1O5.LabelContent;
            }
            if (LcbS1O6.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS1O6.LabelContent;
            }
            if (LcbS1O7.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS1O7.LabelContent;
            }
            if (LcbS1O8.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS1O8.LabelContent;
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
            rng.Value = CbbCarey.SelectedValue;

            // List all checked items
            if (LcbS2O1.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS2O1.LabelContent;
            }
            if (LcbS2O2.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS2O2.LabelContent;
            }
            if (LcbS2O3.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS2O3.LabelContent;
            }
            if (LcbS2O4.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS2O4.LabelContent;
            }
            if (LcbS2O5.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS2O5.LabelContent;
            }
            if (LcbS2O6.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS2O6.LabelContent;
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
            rng.Value = TxbOtherTextbox.Text;

            // List all checked items
            if (LcbS3O1.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS3O1.LabelContent;
            }
            if (LcbS3O2.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS3O2.LabelContent;
            }
            if (LcbS3O3.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS3O3.LabelContent;
            }
            if (LcbS3O4.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS3O4.LabelContent;
            }
            if (LcbS3O5.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS3O5.LabelContent;
            }
            if (LcbS3O6.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS3O6.LabelContent;
            }
            if (LcbS3O7.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS3O7.LabelContent;
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
            rng.Value = CbbGraduated.SelectedValue;

            // List all checked items
            if (LcbS4O1.Checked)
            {
                rng = worksheet.get_Range("A" + curRow++);
                rng.Value = LcbS4O1.LabelContent;
            }

            return curRow;
        }
    }
}

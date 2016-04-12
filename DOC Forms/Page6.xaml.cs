using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Office.Interop.Excel;
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

            Range rng = worksheet.get_Range("A" + curRow, "E" + curRow);
            rng.Cells.Font.Size = 18;
            rng.Merge();

            rng.Value = "Skill Building or Problem Solving";
            curRow++;

            rng = worksheet.get_Range("A" + curRow);
            rng.Cells.Font.Size = 14;
            rng.Value = CbbSkillBuilding.SelectedValue;

            curRow++;



            outRow = curRow;
            return success;
        }

        private void CbbSkillBuilding_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbbGraduated.SelectedIndex = CbbSkillBuilding.SelectedIndex;
        }
    }
}

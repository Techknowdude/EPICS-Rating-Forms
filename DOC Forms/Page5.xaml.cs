using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Color = System.Drawing.Color;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using Page = System.Windows.Controls.Page;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for Page6.xaml
    /// </summary>
    public partial class Page5 : Page, IPageInterface
    {
        private bool saving = false;
        private bool loading = false;
        private Page5Logic _pageLogic;

        public Page5Logic PageLogic
        {
            get { return _pageLogic; }
            set { _pageLogic = value; }
        }

        public Page5()
        {
            PageLogic = new Page5Logic();
            Logic = PageLogic;
            DataContext = PageLogic;
            InitializeComponent();

            
        }

        public bool IsCompleted()
        {
            // TODO: Check all of the fields to see if there is a blank one
            return true;
        }

        public IPageLogic Logic { get; set; }
        
        private void CbbSkillBuilding_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbbGraduated.SelectedIndex = CbbSkillBuilding.SelectedIndex;
            if (PageLogic != null) PageLogic.SkillBuildingSkill = CbbGraduated.SelectedValue.ToString();
        }

        //private void CbbCarey_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (PageLogic != null) PageLogic.CareyText = CbbCarey.SelectedValue.ToString();
        //}

        //private void CbbGraduated_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (PageLogic != null) PageLogic.GraduatedText = CbbGraduated.SelectedValue.ToString();
        //}
    }
}

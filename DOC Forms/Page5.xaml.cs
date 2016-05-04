using System.Windows.Controls;
using Page = System.Windows.Controls.Page;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for Page6.xaml
    /// </summary>
    public partial class Page5 : Page, IPageInterface
    {
        private Page5ViewModel _pageLogic;

        public Page5ViewModel PageLogic
        {
            get { return _pageLogic; }
            set { _pageLogic = value; }
        }

        public Page5()
        {
            InitializeComponent();

            PageLogic = Page5ViewModel;
            ViewModel = Page5ViewModel;
        }

        public void SetViewModel(IPageViewModel model)
        {
            ViewModel = model;
            DataContext = ViewModel;
        }
        public bool IsCompleted()
        {
            // TODO: Check all of the fields to see if there is a blank one
            return true;
        }

        public IPageViewModel ViewModel { get; set; }
        
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

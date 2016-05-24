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
            PageLogic = model as Page5ViewModel;
        }
        public bool IsCompleted()
        {
            // TODO: Check all of the fields to see if there is a blank one
            return true;
        }

        public IPageViewModel ViewModel { get; set; }

        private void SkillComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CbbGraduated.Text = CbbSkillBuilding.Text;
        }
    }
}

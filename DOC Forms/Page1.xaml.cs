using System;
using System.Windows.Controls;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page, IPageInterface
    {
        private bool doneLoading = false;
        public Page1()
        {
            //Logic = new Page1ViewModel();
            //Logic.PageInterface = this;
            //DataContext = Logic;

            InitializeComponent();
            doneLoading = true;
            ViewModel = PageViewModel;
        }

        public bool IsCompleted()
        {
            throw new NotImplementedException();
        }

        public IPageViewModel ViewModel { get; set; }

        public void SetViewModel(IPageViewModel model)
        {
            ViewModel = model;
            DataContext = ViewModel;
        }
    }
}

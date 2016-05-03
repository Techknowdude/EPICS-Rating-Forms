using System;
using System.Windows.Controls;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for Page7.xaml
    /// </summary>
    public partial class Page7 : Page, IPageInterface
    {
        public IPageViewModel ViewModel { get; set; }

        public Page7()
        {
            InitializeComponent();
            ViewModel = Page7ViewModel;
        }

        public bool IsCompleted()
        {
            throw new NotImplementedException();
        }

        public void SetViewModel(IPageViewModel model)
        {
            ViewModel = model;
            DataContext = ViewModel;
        }

    }
}

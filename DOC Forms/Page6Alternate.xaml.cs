using System;
using System.Windows.Controls;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for Page6.xaml
    /// </summary>
    public partial class Page6Alternate : Page, IPageInterface
    {
        public IPageViewModel ViewModel { get; set; }

        public Page6Alternate()
        {
            InitializeComponent();
            ViewModel = Page6ViewModel;
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

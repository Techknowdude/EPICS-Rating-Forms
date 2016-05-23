using System;
using System.IO;
using System.Windows.Controls;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for Page3Alternate.xaml
    /// </summary>
    public partial class Page3Alternate : Page, IPageInterface
    {
        public Page3Alternate()
        {
            InitializeComponent();
            ViewModel = PageViewModel;
        }

        public void SetViewModel(IPageViewModel model)
        {
            ViewModel = model;
            DataContext = ViewModel;
        }
        public bool IsCompleted()
        {
            throw new NotImplementedException();
        }

        public IPageViewModel ViewModel { get; set; }
    }
}

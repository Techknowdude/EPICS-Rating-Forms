using System;
using System.IO;
using System.Windows.Controls;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page , IPageInterface
    {
        public Page3()
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

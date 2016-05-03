using System;
using System.IO;
using System.Windows.Controls;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class Page4 : Page, IPageInterface
    {
        public Page4()
        {
            InitializeComponent();
            ViewModel = PageViewModel;
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
        public IPageViewModel ViewModel { get; set; }
    }
}

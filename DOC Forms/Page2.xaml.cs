using System;
using System.IO;
using System.Windows.Controls;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page, IPageInterface
    {
        public IPageViewModel ViewModel { get; set; }

        public Page2()
        {
            ViewModel = new Page2ViewModel();
            DataContext = ViewModel;
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

        public void SetViewModel(IPageViewModel model)
        {
            ViewModel = model;
            DataContext = ViewModel;
        }
        public bool Load(BinaryReader reader)
        {
            throw new NotImplementedException();
        }

    }
}

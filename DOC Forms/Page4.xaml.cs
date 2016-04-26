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
            ViewModel = new Page4ViewModel();
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

        public IPageViewModel ViewModel { get; set; }
    }
}

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
            Logic = new Page4ViewModel();
            DataContext = Logic;

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

        public bool Load(BinaryReader reader)
        {
            throw new NotImplementedException();
        }

        public IPageLogic Logic { get; set; }
    }
}

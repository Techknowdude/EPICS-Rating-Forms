using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page, IPageInterface
    {
        public IPageLogic Logic { get; set; }

        public Page2()
        {
            Logic = new Page2ViewModel();
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

    }
}

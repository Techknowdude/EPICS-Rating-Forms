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
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page , IPageInterface
    {
        public Page3()
        {
            Logic = new Page3ViewModel();
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

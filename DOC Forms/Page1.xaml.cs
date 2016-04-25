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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page, IPageInterface
    {
        private bool doneLoading = false;
        public Page1()
        {
            //Logic = new Page1ViewModel();
            //Logic.PageInterface = this;
            //DataContext = Logic;

            InitializeComponent();
            doneLoading = true;
            Logic = PageViewModel;
        }

        public bool IsCompleted()
        {
            throw new NotImplementedException();
        }

        public IPageViewModel Logic { get; set; }
    }
}

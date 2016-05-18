using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for UserAdminWindow.xaml
    /// </summary>
    public partial class UserAdminWindow : Window
    {
        public ICommand AddUserCommand
        {
            get { return new DelegateCommand(AddUser); }
        }

        private void AddUser()
        {
            
        }

        public UserAdminWindow()
        {
            InitializeComponent();
        }

            }
}

using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int maxFailedLogins = 10;

        private int failedLogins = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (LoginAccepted())
            {
                EpicsRatingFormA epicsRatingFormA = new EpicsRatingFormA();
                epicsRatingFormA.Show();
                Close();
            }
            else
            {
                failedLogins++;
                if(failedLogins >= maxFailedLogins) Close();

                MessageBox.Show("Login failed.");
            }
        }

        private bool LoginAccepted()
        {
            return true;
        }
    }
}

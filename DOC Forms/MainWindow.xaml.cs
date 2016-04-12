using System.Windows;

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

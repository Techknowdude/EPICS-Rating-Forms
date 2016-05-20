using System.Windows;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for UserAdminWindow.xaml
    /// </summary>
    public partial class UserAdminWindow : Window
    {
        public UserAdminWindow()
        {
            InitializeComponent();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SetPass_Click(object sender, RoutedEventArgs e)
        {
            UserHandler.SetPassword("admin",TxbNewPass.SecurePassword);
            MessageBox.Show("Password set!");
            TxbNewPass.Password = ""; // clear
        }
    }
}

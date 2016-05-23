using System.Windows;
using System.Windows.Input;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for UpdatePasswordWindow.xaml
    /// </summary>
    public partial class UpdatePasswordWindow : Window
    {
        public ICommand SubmitChangeCommand { get { return new DelegateCommand(ChangePassword);} }

        private void ChangePassword()
        {
            var current = PwbCurrentPass.SecurePassword;

            if (UserHandler.VerifyPass(LoginHandler.CurrentUser, current))
            {
                var pass1 = PwbNewPass.SecurePassword;
                var pass2 = PwbPassConfirm.SecurePassword;
                if (Authenticator.MatchPasswords(pass1, pass2))
                {
                    UserHandler.SetPassword(LoginHandler.CurrentUser,pass1);
                    MessageBox.Show("Password set!");
                    Close();
                }
                else
                {
                    MessageBox.Show("New passwords do not match.");
                }
            }
            else
            {
                MessageBox.Show("Current password is incorrect.");
            }
        }

        public UpdatePasswordWindow()
        {
            InitializeComponent();
        }
    }
}

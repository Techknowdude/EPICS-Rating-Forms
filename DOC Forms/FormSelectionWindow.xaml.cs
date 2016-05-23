using System.Windows;
using System.Windows.Input;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for FormSelectionWindow.xaml
    /// </summary>
    public partial class FormSelectionWindow : Window
    {
        public FormSelectionWindow()
        {
            InitializeComponent();
        }

        public ICommand CreateNormalFormCommand { get { return new DelegateCommand(OpenNormalForm);} }
        public ICommand CreateAlternateFormCommand { get { return new DelegateCommand(OpenAlternateForm);} }

        private void OpenAlternateForm()
        {
            EpicsRatingFormA form = new EpicsRatingFormA(true);
            form.Show();
            Close();
        }

        private void OpenNormalForm()
        {
            EpicsRatingFormA form = new EpicsRatingFormA(false);
            form.Show();
            Close();
        }
    }
}

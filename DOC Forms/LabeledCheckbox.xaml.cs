using System;
using System.Windows;
using System.Windows.Controls;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for LabeledCheckbox.xaml
    /// </summary>
    public partial class LabeledCheckbox : UserControl
    {
        private bool _checked;

        public bool Checked
        {
            get { return _checked; }
            set
            {
                CheckBox.IsChecked = value;
                _checked = value;
            }
        }

        public String LabelContent { get; set; }
        public event RoutedEventHandler CheckBoxChecked;

        public LabeledCheckbox()
        {
            InitializeComponent();
            MainPanel.DataContext = this;
        }

        private void CheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            CheckBoxChecked?.Invoke(sender, e);
        }
    }
}

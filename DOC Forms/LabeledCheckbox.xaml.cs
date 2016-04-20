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
        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("Checked", typeof(Boolean),
            typeof(LabeledCheckbox));
        public static readonly DependencyProperty LabelTextProperty = DependencyProperty.Register("LabelContent", typeof(String),
            typeof(LabeledCheckbox));

        public bool Checked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set
            {
                SetValue(IsCheckedProperty,value);
            }
        }

        public String LabelContent
        {
            get { return (String) GetValue(LabelTextProperty); }
            set
            {
                SetValue(LabelTextProperty,value);
            }
        }
        public event RoutedEventHandler CheckBoxChecked;

        public LabeledCheckbox()
        {
            InitializeComponent();
            MainPanel.DataContext = this;
        }

        private void CheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            Checked = true;
        }

        private void CheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            Checked = false;
        }
    }
}

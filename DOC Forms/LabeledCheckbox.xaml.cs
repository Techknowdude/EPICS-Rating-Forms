using System;
using System.Windows.Controls;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for LabeledCheckbox.xaml
    /// </summary>
    public partial class LabeledCheckbox : UserControl
    {
        public bool Checked { get; set; }
        public String LabelContent { get; set; }


        public LabeledCheckbox()
        {
            InitializeComponent();
            MainPanel.DataContext = this;
        }
    }
}

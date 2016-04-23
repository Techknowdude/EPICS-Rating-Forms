using System;
using System.Windows;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public static DependencyProperty MessageDependencyProperty = DependencyProperty.Register("Message",typeof(String),typeof(MessageWindow));

        public String Message
        {
            get
            {
                return (String) GetValue(MessageDependencyProperty);
            }
            set
            {
                SetValue(MessageDependencyProperty,value);
            }
        }

        public MessageWindow(String message = "")
        {
            Message = message;
            InitializeComponent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using Page = System.Windows.Controls.Page;
using Window = System.Windows.Window;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for EpicsRatingFormA.xaml
    /// </summary>
    public partial class EpicsRatingFormA : Window
    {
        private List<Page> Pages { get; set; }
        private List<IPageInterface> PageInterfaces { get; set; }
        private Page _currentlyDisplayedPage;
        private int _currentPage = -1;

        private EpicsRatingFormLogic logic;

        public EpicsRatingFormA()
        {
            DataContext = this;


            var p1 = new Page1();
            var p2 = new Page2();
            var p3 = new Page3();
            var p4 = new Page4();
            var p5 = new Page5();

            Pages = new List<Page>() {p1,p2,p3,p4,p5};
            PageInterfaces = new List<IPageInterface>() {p1,p2,p3,p4,p5};

            logic = EpicsRatingFormLogic.Create(PageInterfaces, this);
            InitializeComponent();
            CurrentPage = 0;
        }

        public int CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (value != _currentPage && value < Pages.Count && value >= 0)
                {
                    PageLabel.Content = (value + 1).ToString();
                    PageFrame.Content = Pages[value];
                    _currentPage = value;

                    ToggleButtons();
                }
            }
        }

        private void ToggleButtons()
        {
            PrevPageButton.IsEnabled = _currentPage > 0;
            NextPageButton.IsEnabled = _currentPage + 1 < Pages.Count;
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage++;
        }

        private void PrevPageButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage--;
        }

        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save EPIC form";
            saveDialog.Filter = "EPIC forms (*.ef)|*.ef|All Files (*.*)|*.*";

            if (saveDialog.ShowDialog() != true) return;

            try
            {

            }
            catch (Exception exception)
            {
                
            }
        }

        private void LoadMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ExcelMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            IDataExporter de = new ExcelDataExporter();
            de.ExportData(logic);
        }
    }
}

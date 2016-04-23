using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
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
                using (BinaryWriter writer = new BinaryWriter(new FileStream(saveDialog.FileName, FileMode.OpenOrCreate)))
                {
                    foreach (var pageInterface in PageInterfaces)
                    {
                        pageInterface.Logic.Save(writer);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("ERROR", "There was an issue opening or creating the file: " + exception.Message);
            }
        }

        private void LoadMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog loadDialog = new OpenFileDialog();
            loadDialog.Title = "Load EPIC form";
            loadDialog.Filter = "EPIC forms (*.ef)|*.ef|All Files (*.*)|*.*";

            if (loadDialog.ShowDialog() != true) return;

            try
            {
                using (BinaryReader reader = new BinaryReader(new FileStream(loadDialog.FileName, FileMode.Open)))
                {
                    foreach (var pageInterface in PageInterfaces)
                    {
                        pageInterface.Logic.Load(reader);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("ERROR", "There was an issue opening the file: " + exception.Message);
            }
        }

        private async void ExcelMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ExcelDataExporter.ExportData(logic);

                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }

}

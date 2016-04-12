using System.Windows;
using Microsoft.Office.Interop.Excel;
using Page = System.Windows.Controls.Page;
using Window = System.Windows.Window;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for EpicsRatingFormA.xaml
    /// </summary>
    public partial class EpicsRatingFormA : Window, IEpicForm
    {
        private Page[] Pages = new Page[] { new Page(), new Page(), new Page(), new Page(), new Page(), new Page6(), };

        private Page CurrentlyDisplayedPage;
        private int currentPage = -1;


        public EpicsRatingFormA()
        {

            DataContext = this;

            InitializeComponent();
            CurrentPage = 5;
        }

        public int CurrentPage
        {
            get { return currentPage; }
            set
            {
                if (value != currentPage && value <= Pages.Length && value >= 0)
                {
                    PageLabel.Content = (value + 1).ToString();
                    PageFrame.Content = Pages[value];
                    currentPage = value;

                    ToggleButtons();
                }
            }
        }

        private void ToggleButtons()
        {
            PrevPageButton.IsEnabled = currentPage > 0;
            NextPageButton.IsEnabled = currentPage < Pages.Length;
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

        }

        private void LoadMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            
        }


        public bool ExportData(IDataExporter exporter)
        {
            return exporter.ExportData(this);
        }

        public bool ExportToExcel(Worksheet worksheet, out int currentRow)
        {
            bool? success = true;
            int curRow = 1;
            int outRow = 1;

            foreach (var page1 in Pages)
            {
                var page = page1 as IPageInterface;
                success = page?.ExportToExcel(worksheet, curRow, out outRow);
                //if (success != true) break;
                curRow = outRow;
            }

            currentRow = curRow;
            return success == true;
        }

        private void ExcelMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            IDataExporter de = new ExcelDataExporter();
            ExportData(de);
        }
    }
}

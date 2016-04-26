using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Input;
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

        public EpicsRatingFormA()
        {
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

        public ICommand NextPageCommand
        {
            get { return new DelegateCommand(() => ++CurrentPage); }
        }

        public ICommand PrevPageCommand
        {
            get { return new DelegateCommand(() => --CurrentPage); }
        }



        private void ToggleButtons()
        {
            PrevPageButton.IsEnabled = _currentPage > 0;
            NextPageButton.IsEnabled = _currentPage + 1 < Pages.Count;
        }

        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save EPIC form";
            saveDialog.Filter = "EPIC forms (*.ef)|*.ef|All Files (*.*)|*.*";

            if (saveDialog.ShowDialog() != true) return;

            try
            {
                using (FileStream stream = File.OpenWrite(saveDialog.FileName))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    
                    foreach (var pageInterface in PageInterfaces)
                    {
                        pageInterface.ViewModel.Save(stream,formatter);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("There was an issue opening or creating the file: " + exception.Message,"ERROR");
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
                using (FileStream stream = File.OpenRead(loadDialog.FileName))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    ((Page1) Pages[0]).SetViewModel(Page1ViewModel.Load(stream, formatter));
                    ((Page2) Pages[1]).SetLogic(Page2ViewModel.Load(stream, formatter));
                    ((Page3) Pages[2]).SetLogic(Page3ViewModel.Load(stream, formatter));
                    ((Page4) Pages[3]).SetLogic(Page4ViewModel.Load(stream, formatter));
                    ((Page5) Pages[4]).SetLogic(Page5ViewModel.Load(stream, formatter));
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("There was an issue opening the file: " + exception.Message,"ERROR");
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

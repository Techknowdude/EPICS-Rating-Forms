using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using Page = System.Windows.Controls.Page;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;
using Window = System.Windows.Window;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for EpicsRatingFormA.xaml
    /// </summary>
    public partial class EpicsRatingFormA : Window
    {
        public ICommand SetPasswordCommand { get { return new DelegateCommand(SetPassword);} }

        private List<Page> Pages { get; set; }
        private List<IPageInterface> PageInterfaces { get; set; }
        private int _currentPage = -1;
        private bool _isAlternate;

        private EpicsRatingFormLogic logic;

        public void PrintPage()
        {
            // TODO: finish this -- currently not implemented.
            return;
            PrintDialog dlg = new PrintDialog();

            // Create doc
            FixedDocument document = new FixedDocument();
            document.DocumentPaginator.PageSize = new Size(dlg.PrintableAreaWidth,dlg.PrintableAreaHeight);

            // Create a page and set size...
            FixedPage page1 = new FixedPage();
            page1.Width = document.DocumentPaginator.PageSize.Width;
            page1.Height = document.DocumentPaginator.PageSize.Height;

            // add my page to the things to print

            var grid = Pages[0].Content as UIElement;
            if (grid != null)
            {
                Pages[0].Content = null;
                page1.Children.Add(grid); // this breaks
            }
                // Add that page to the doc
                PageContent page1Content = new PageContent();
                ((IAddChild) page1Content).AddChild(page1);
                document.Pages.Add(page1Content);

                // Repeat that in a loop...

                // Print the final document
                dlg.PrintDocument(document.DocumentPaginator, "EPICS form");

            Pages[0].Content = grid;
        }

        public int CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (value < Pages.Count && value >= 0)
                {
                    PageLabel.Content = (value + 1).ToString();
                    PageFrame.Content = Pages[value];
                    _currentPage = value;
                    MainScrollViewer.ScrollToVerticalOffset(0);
                    ToggleButtons();
                }
            }
        }

        public EpicsRatingFormA(bool alternate = false)
        {
            _isAlternate = alternate;
            if (!alternate)
            {
                var p1 = new Page1();
                var p2 = new Page2();
                var p3 = new Page3();
                var p4 = new Page4();
                var p5 = new Page5();
                var p6 = new Page6();
                var p7 = new Page7();

                Pages = new List<Page>() { p1, p2, p3, p4, p5, p6, p7 };
                PageInterfaces = new List<IPageInterface>() { p1, p2, p3, p4, p5, p6, p7 };
            }
            else
            {
                var p1 = new Page1();
                var p2 = new Page2();
                var p3 = new Page3Alternate();
                var p4 = new Page4();
                var p5 = new Page5();
                var p6 = new Page6Alternate();
                var p7 = new Page7();

                Pages = new List<Page>() { p1, p2, p3, p4, p5, p6, p7 };
                PageInterfaces = new List<IPageInterface>() { p1, p2, p3, p4, p5, p6, p7 };
            }

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
        public ICommand LogoutCommand
        {
            get { return new DelegateCommand(() =>
            {
                // TODO: ensure only one login window is ever opened.
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                LoginHandler.Logout();
                Close();
            }); }
        }

        public ICommand PrintCommand
        {
            get { return new DelegateCommand(PrintPage); }
        }


        private void SetPassword()
        {
            UpdatePasswordWindow window = new UpdatePasswordWindow();
            window.ShowDialog();

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

                    // save the type of form
                    formatter.Serialize(stream,_isAlternate);

                    foreach (var pageInterface in PageInterfaces)
                    {
                        pageInterface.ViewModel.Save(stream,formatter);
                    }
                }
                MessageBox.Show("Saving complete.");
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

                    // get the type
                    bool wasAlternate = _isAlternate;
                    _isAlternate = (bool) formatter.Deserialize(stream);

                    ((Page1)Pages[0]).SetViewModel(Page1ViewModel.Load(stream, formatter));
                    ((Page2)Pages[1]).SetViewModel(Page2ViewModel.Load(stream, formatter));
                    if (_isAlternate) // alternate page
                    {
                        if (!wasAlternate) // change page 3 to alternate
                        {
                            Pages[2] = new Page3Alternate();
                        }

                        ((Page3Alternate) Pages[2]).SetViewModel(Page3ViewModelAlternate.Load(stream, formatter));
                    }
                    else // Normal page now
                    {
                        if (wasAlternate) // change page 3 to the normal page
                        {
                            Pages[2] = new Page3();   
                        }
                    
                        ((Page3) Pages[2]).SetViewModel(Page3ViewModel.Load(stream, formatter));
                    }

                    ((Page4) Pages[3]).SetViewModel(Page4ViewModel.Load(stream, formatter));
                    ((Page5) Pages[4]).SetViewModel(Page5ViewModel.Load(stream, formatter));

                    if (_isAlternate) // alternate page
                    {
                        if (!wasAlternate) // change page 6 to alternate
                        {
                            Pages[5] = new Page6Alternate();
                        }

                        ((Page6Alternate)Pages[5]).SetViewModel(Page6ViewModelAlternate.Load(stream, formatter));
                    }
                    else // Normal page now
                    {
                        if (wasAlternate) // change page 6 to the normal page
                        {
                            Pages[5] = new Page6();
                        }

                        ((Page6)Pages[5]).SetViewModel(Page6ViewModel.Load(stream, formatter));
                    }


                    ((Page7) Pages[6]).SetViewModel(Page7ViewModel.Load(stream, formatter));

                    logic.Pages[0] = ((IPageInterface) Pages[0]).ViewModel;
                    logic.Pages[1] = ((IPageInterface) Pages[1]).ViewModel;
                    logic.Pages[2] = ((IPageInterface) Pages[2]).ViewModel;
                    logic.Pages[3] = ((IPageInterface) Pages[3]).ViewModel;
                    logic.Pages[4] = ((IPageInterface) Pages[4]).ViewModel;
                    logic.Pages[5] = ((IPageInterface) Pages[5]).ViewModel;
                    logic.Pages[6] = ((IPageInterface) Pages[6]).ViewModel;
                }
                CurrentPage = _currentPage;

                MessageBox.Show("Loading complete.");
            }
            catch (Exception exception)
            {
                MessageBox.Show("There was an issue opening the file: " + exception.Message,"ERROR");
            }
        }

        private void ExcelMenuItem_OnClick(object sender, RoutedEventArgs e)
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

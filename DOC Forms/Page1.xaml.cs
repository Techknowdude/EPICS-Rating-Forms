using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DOC_Forms
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page, IPageInterface
    {
        private bool doneLoading = false;
        public Page1()
        {
            Logic = new Page1Logic();
            Logic.PageInterface = this;
            DataContext = Logic;

            InitializeComponent();
            doneLoading = true;
            UpdateScores();
        }

        private void ClientMale_OnClick(object sender, RoutedEventArgs e)
        {
            ClientFemale.IsChecked = false;
            ClientOther.IsChecked = false;
            ClientOtherText.IsEnabled = false;
        }
        private void ClientFemale_OnClick(object sender, RoutedEventArgs e)
        {
            ClientMale.IsChecked = false;
            ClientOther.IsChecked = false;
            ClientOtherText.IsEnabled = false;
        }
        private void ClientOther_OnClick(object sender, RoutedEventArgs e)
        {
            ClientMale.IsChecked = false;
            ClientFemale.IsChecked = false;
            ClientOtherText.IsEnabled = true;
        }

        private void MeetingYes_OnCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            MeetingNo.Checked = false;
            MeetingNA.Checked = false;
        }
        private void MeetingNo_OnCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            MeetingYes.Checked = false;
            MeetingNA.Checked = false;
        }
        private void MeetingNA_OnCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            MeetingNo.Checked = false;
            MeetingYes.Checked = false;
        }

        private void HomelessYes_OnCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            HomelessNo.Checked = false;
            HomelessNA.Checked = false;
        }
        private void HomelessNo_OnCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            HomelessYes.Checked = false;
            HomelessNA.Checked = false;
        }
        private void HomelessNA_OnCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            HomelessNo.Checked = false;
            HomelessYes.Checked = false;
        }

        private void AgitationYes_OnCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            AgitationNA.Checked = false;
            AgitationNo.Checked = false;
        }

        private void AgitationNo_OnCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            AgitationNA.Checked = false;
            AgitationYes.Checked = false;
        }

        private void AgitationNA_OnCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            AgitationYes.Checked = false;
            AgitationNo.Checked = false;
        }

        private void CompletedBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdatePercentComplete();
        }

        private void OutOfBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdatePercentComplete();
        }

        private void UpdatePercentComplete()
        {
            int completed = 0;
            int total = 0;
            double percent = double.NaN;

            Int32.TryParse(CompletedBox.Text, out completed);
            Int32.TryParse(OutOfBox.Text, out total);

            if (completed != 0 && total != 0)
            {
                percent = completed/(double)total;
                PercentBox.Text = percent.ToString("P0");
            }

        }

        private void Score_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (doneLoading) UpdateScores();
        }

        private void UpdateScores()
        {
            double[] scores = new double[4];

            double behavior;
            double global;

            Double.TryParse(CheckInScore.Text, out scores[0]);
            Double.TryParse(ReviewScore.Text, out scores[1]);
            Double.TryParse(InterventionScore.Text, out scores[2]);
            Double.TryParse(HomeworkScore.Text, out scores[3]);
            Double.TryParse(BehavioralScore.Text, out behavior);
            Double.TryParse(GlobalPracticesScore.Text, out global);

            double overallScore = (scores.Sum()+behavior+global)/6;
            double numHighScore = scores.Count(x => x >= 2.0);
            double percentageHighScore = numHighScore/4;

            OverallSessionScore.Text = overallScore.ToString("N");
            NumberofHighScore.Text = numHighScore.ToString("N");
            PercentageHighScoring.Text = percentageHighScore.ToString("P");
        }

        public bool IsCompleted()
        {
            throw new NotImplementedException();
        }

        public IPageLogic Logic { get; set; }
    }
}

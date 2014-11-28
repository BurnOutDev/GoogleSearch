using GoogleSearchAPI;
using GoogleSearchAPI.Query;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace GoogleSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            WebQuery webQuery = new WebQuery(tbxSearch.Text);
            ImageQuery imageQuery = new ImageQuery(tbxSearch.Text);
            VideoQuery videoQuery = new VideoQuery(tbxSearch.Text);


            webQuery.ResultSetSize.Value = ResultSetSize.large;
            imageQuery.ResultSetSize.Value = ResultSetSize.large;
            videoQuery.ResultSetSize.Value = ResultSetSize.large;

            
            IGoogleResultSet<GoogleWebResult> resultSet_Web = GoogleService.Instance.Search<GoogleWebResult>(webQuery);
            IGoogleResultSet<GoogleImageResult> resultSet_Image = GoogleService.Instance.Search<GoogleImageResult>(imageQuery);
            IGoogleResultSet<GoogleVideoResult> resultSet_Video = GoogleService.Instance.Search<GoogleVideoResult>(videoQuery);

            lstResultsWeb.ItemsSource = resultSet_Web.Results;
            lstResultsImage.ItemsSource = resultSet_Image.Results;
            lstResultsVideo.ItemsSource = resultSet_Video.Results;

        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void tbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnSearch.IsEnabled = string.IsNullOrWhiteSpace(tbxSearch.Text) ? false : true;
        }
    }
}

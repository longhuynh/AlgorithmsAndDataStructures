using System.Text;
using System.Windows;
using StringSearching;
using StringSearching.BoyerMoore;
using Tracker;

namespace SimpleTextReplacement
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonReplaceClick(object sender, RoutedEventArgs e)
        {
            txtNaiveOutput.Clear();
            txtBoyerMooreOutput.Clear();


            var input = txtContent.Text;
            var find = txtFind.Text;
            var replace = txtReplace.Text;

            IStringSearchAlgorithm boyerMoore = new BoyerMoore();
            var boyerMooreResult = PerformSearchAndReplace(boyerMoore, input, find, replace);
            txtBoyerMooreOutput.Text = boyerMooreResult.ToString();
            lblBoyerMooreComparisonsOutput.Content = ((IPerformanceTracker) boyerMoore).Comparisons;

            IStringSearchAlgorithm naiveStringSearch = new NaiveStringSearch();
            var naiveResult = PerformSearchAndReplace(naiveStringSearch, input, find, replace);
            txtNaiveOutput.Text = naiveResult.ToString();
            lblNaiveComparisonsValue.Content = ((IPerformanceTracker) naiveStringSearch).Comparisons;
        }

        private static StringBuilder PerformSearchAndReplace(IStringSearchAlgorithm algorithm, string input, string find,
            string replace)
        {
            var result = new StringBuilder();
            var previousStart = 0;
            foreach (var match in algorithm.Search(find, input))
            {
                result.Append(input.Substring(previousStart, match.Start - previousStart));
                result.Append(replace);
                previousStart = match.Start + match.Length;
            }

            result.Append(input.Substring(previousStart));
            return result;
        }
    }
}
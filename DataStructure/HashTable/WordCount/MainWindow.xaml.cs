using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using HashTable;
using Microsoft.Win32;

namespace WordCount
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HashTable<string, int> wordCounts = new HashTable<string, int>();

        public MainWindow()
        {
            WordCountCollection = new ObservableCollection<WordCountData>();

            InitializeComponent();
        }

        public ObservableCollection<WordCountData> WordCountCollection { get; private set; }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var file = GetFileName();

            try
            {
                LoadFileData(file);
                DisplayTopWords();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayTopWords()
        {
            WordCountCollection.Clear();

            foreach (var key in wordCounts.Keys)
            {
                WordCountCollection.Add(new WordCountData(key, wordCounts[key]));
            }
        }

        private void LoadFileData(string file)
        {
            if (!string.IsNullOrEmpty(file))
            {
                using (var contents = File.OpenRead(file))
                using (var reader = new StreamReader(contents))
                {
                    wordCounts.Clear();

                    while (!reader.EndOfStream)
                    {
                        LoadLine(reader.ReadLine());
                    }
                }
            }
        }

        private void LoadLine(string line)
        {
            var words = line.Split(" \t,.;()\"\'".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                var wordLower = word.ToLower();

                int count;
                if (!wordCounts.TryGetValue(wordLower, out count))
                {
                    count = 0;
                    wordCounts.Add(wordLower, 0);
                }

                wordCounts[wordLower] = count + 1;
            }
        }

        private string GetFileName()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.FileName = "*";
            fileDialog.DefaultExt = ".txt";
            fileDialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            var result = fileDialog.ShowDialog();

            // Return open file dialog box results
            return result == true ? fileDialog.FileName : null;
        }

        #region ListView Column Sorting

        // ListView column sorting code taking directly from MSDN
        // http://msdn.microsoft.com/en-us/library/ms745786.aspx

        private GridViewColumnHeader lastHeaderClicked;
        private ListSortDirection lastDirection = ListSortDirection.Ascending;

        private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            var headerClicked =
                e.OriginalSource as GridViewColumnHeader;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    ListSortDirection direction;
                    if (headerClicked != lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    var header = headerClicked.Column.Header as string;
                    Sort(header, direction);

                    if (direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate =
                            Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate =
                            Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    }

                    // Remove arrow from previously sorted header
                    if (lastHeaderClicked != null && lastHeaderClicked != headerClicked)
                    {
                        lastHeaderClicked.Column.HeaderTemplate = null;
                    }


                    lastHeaderClicked = headerClicked;
                    lastDirection = direction;
                }
            }
        }

        private void Sort(string sortBy, ListSortDirection direction)
        {
            var dataView =
                CollectionViewSource.GetDefaultView(listView1.ItemsSource);

            dataView.SortDescriptions.Clear();
            var sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }

        #endregion
    }
}
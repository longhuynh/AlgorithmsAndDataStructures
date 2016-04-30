using System;
using System.Windows.Forms;
using Sorting;

namespace SortingVisualizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            comboBox1.Items.Add("Random");
            comboBox1.Items.Add("Sorted");
            comboBox1.Items.Add("Reversed");
        }

        private void ButtonExecuteClick(object sender, EventArgs e)
        {
            try
            {
                chart1.Series.Clear();

                Cursor = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    uint counts = 0;
                    if (uint.TryParse(textBox1.Text, out counts))
                    {
                        GraphPoints(counts);
                    }
                    else
                    {
                        //MessageBox.Show(string.Format("The value could not be parsed as an integer: {0}", textBox1.Text));
                        MessageBox.Show($"The value could not be parsed as an integer: {textBox1.Text}");
                    }
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private int[] GetRandomPoints(uint count)
        {
            var r = new Random();
            var points = new int[count];

            for (uint i = 0; i < count; i++)
            {
                points[i] = r.Next();
            }

            return points;
        }

        private void GraphPoints(uint count)
        {
            chart1.ResetAutoValues();

            int[] points;
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Random":
                    points = GetRandomPoints(count);
                    break;
                case "Sorted":
                    points = GetSortedPoints(count);
                    break;
                case "Reversed":
                    points = GetReversedPoints(count);
                    break;
                default:
                    points = new int[0];
                    break;
            }

            ISorter<int>[] algorithms =
            {
                new BubbleSort<int>(),
                new InsertionSort<int>(),
                new MergeSort<int>(),
                new SelectionSort<int>(),
                new QuickSort<int>()
            };

            foreach (var algorithm in algorithms)
            {
                Text = $"Running algorithm: {algorithm.GetType().Name}";

                var cloned = new int[points.Length];
                Array.Copy(points, cloned, points.Length);

                algorithm.Sort(cloned);

                var series = chart1.Series.Add(algorithm.GetType().Name);

                if (cbOperation.SelectedItem.ToString() == "Comparisons")
                {
                    series.Points.Add(algorithm.Comparisons);
                }
                else
                {
                    series.Points.Add(algorithm.Swaps);
                }
            }

            Text = $"Ready";
        }

        private int[] GetSortedPoints(uint count)
        {
            var points = new int[count];

            for (var i = 0; i < count; i++)
            {
                points[i] = i;
            }

            return points;
        }

        private int[] GetReversedPoints(uint count)
        {
            var points = new int[count];

            var current = 0;
            for (var i = (int) count - 1; i >= 0; i--)
            {
                points[current++] = i;
            }

            return points;
        }
    }
}

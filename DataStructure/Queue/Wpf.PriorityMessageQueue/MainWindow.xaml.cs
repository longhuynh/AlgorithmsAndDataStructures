using System;
using System.Windows;
using PriorityQueue;

namespace Wpf.PriorityVisualQueue
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PriorityQueue<int> queue = new PriorityQueue<int>();
        private readonly Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonCreateClick(object sender, RoutedEventArgs e)
        {
            queue.Enqueue(random.Next(0, 200));
            UpdateGrid();
        }

        private void ButtonProcessClick(object sender, RoutedEventArgs e)
        {
            if (queue.Count > 0)
            {
                listBox1.Items.Add(queue.Dequeue().ToString());
                UpdateGrid();
            }
        }

        private void UpdateGrid()
        {
            queueLabel1.Content = string.Empty;
            queueLabel2.Content = string.Empty;
            queueLabel3.Content = string.Empty;
            queueLabel4.Content = string.Empty;
            queueLabel5.Content = string.Empty;
            queueLabel6.Content = string.Empty;

            var index = 0;
            foreach (var message in queue)
            {
                switch (index)
                {
                    case 0:
                        queueLabel1.Content = message.ToString();
                        break;
                    case 1:
                        queueLabel2.Content = message.ToString();
                        break;
                    case 2:
                        queueLabel3.Content = message.ToString();
                        break;
                    case 3:
                        queueLabel4.Content = message.ToString();
                        break;
                    case 4:
                        queueLabel5.Content = message.ToString();
                        break;
                    case 5:
                        queueLabel6.Content = message.ToString();
                        break;
                }

                index++;

                if (index > 5)
                {
                    break;
                }
            }
        }
    }
}

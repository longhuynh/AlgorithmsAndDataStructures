using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Set;

namespace SetDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Set<Student> men = new Set<Student>();
        readonly Set<Student> women = new Set<Student>();

        readonly Set<Student> reading = new Set<Student>();
        readonly Set<Student> writing = new Set<Student>();
        readonly Set<Student> arithmetic = new Set<Student>();

        readonly Dictionary<string, Set<Student>> allSets = new Dictionary<string, Set<Student>>();

        public MainWindow()
        {
            Student james = new Student(1, "James", Gender.Male);
            Student robert = new Student(2, "Robert", Gender.Male);
            Student john = new Student(3, "John", Gender.Male);
            Student mark = new Student(4, "Mark", Gender.Male);
            Student otherMark = new Student(5, "Mark", Gender.Male);
            men.AddRange(new Student[] {james, robert, john, mark, otherMark});

            Student liz = new Student(6, "Elizabeth", Gender.Female);
            Student amy = new Student(7, "Amy", Gender.Female);
            Student eve = new Student(8, "Evelyn", Gender.Female);
            women.AddRange(new Student[] {liz, amy, eve});

            reading.AddRange(new Student[] {james, robert, liz});
            writing.AddRange(new Student[] {robert, mark, amy, eve, liz});
            arithmetic.AddRange(new Student[] {john, mark, otherMark, amy});

            allSets.Add("Men", men);
            allSets.Add("Women", women);
            allSets.Add("Reading", reading);
            allSets.Add("Writing", writing);
            allSets.Add("Arithmetic", arithmetic);

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string name in allSets.Keys)
            {
                leftSet.Items.Add(name);
                rightSet.Items.Add(name);
            }

            operation.Items.Add("UNION");
            operation.Items.Add("INTERSECTION");
            operation.Items.Add("DIFFERENCE");
            operation.Items.Add("SYMETRIC DIFF");
        }

        private void LeftSetSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            leftMembers.Items.Clear();

            if (e.AddedItems.Count > 0)
            {
                DisplaySetData(GetSetByName(e.AddedItems[0].ToString()), leftMembers);
            }
        }

        private void RightSetSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rightMembers.Items.Clear();

            if (e.AddedItems.Count > 0)
            {
                DisplaySetData(GetSetByName(e.AddedItems[0].ToString()), rightMembers);
            }
        }

        Set<Student> GetSetByName(string name)
        {
            return allSets[name];
        }

        void DisplaySetData(Set<Student> set, ListBox list)
        {
            list.Items.Clear();

            foreach (Student s in set.OrderBy(student => student.StudentId))
            {
                list.Items.Add(string.Format("{0}: {1}", s.StudentId, s.Name));
            }
        }

        private void EvaluateButtonClick(object sender, RoutedEventArgs e)
        {
            resultSet.Items.Clear();
            if (operation.SelectedItem != null)
            {
                Set<Student> results = UpdateResultSet(GetSetByName(leftSet.SelectedItem.ToString()),
                    GetSetByName(rightSet.SelectedItem.ToString()), operation.SelectedItem.ToString());
                DisplaySetData(results, resultSet);
            }
        }

        private Set<Student> UpdateResultSet(Set<Student> left, Set<Student> right, string op)
        {
            switch (op)
            {
                case "UNION":
                    return left.Union(right);
                case "INTERSECTION":
                    return left.Intersection(right);
                case "DIFFERENCE":
                    return left.Difference(right);
                case "SYMETRIC DIFF":
                    return left.SymmetricDifference(right);
                default:
                    Set<Student> set = new Set<Student>();
                    set.Add(new Student(-1, "ERROR", Gender.Unknown));
                    return set;
            }
        }
    }
}

using System.Collections.Generic;

namespace SetTests
{
    public class DifferenceTestData
    {
        public static IEnumerable<TestCaseData<int>> IntCases
        {
            get
            {
                yield return new TestCaseData<int>
                {
                    Left = new[] {1, 2, 3, 4},
                    Right = new[] {5, 6, 7, 8},
                    Expected = new[] {1, 2, 3, 4}
                };
                yield return new TestCaseData<int>
                {
                    Left = new[] {1, 2, 3},
                    Right = new[] {1, 7, 8},
                    Expected = new[] {2, 3}
                };
                yield return new TestCaseData<int>
                {
                    Left = new[] {1, 2, 3, 4},
                    Right = new[] {1, 2, 5, 6},
                    Expected = new[] {3, 4}
                };
                yield return new TestCaseData<int>
                {
                    Left = new[] {1, 2, 3, 4},
                    Right = new int[] {},
                    Expected = new[] {1, 2, 3, 4}
                };
                yield return new TestCaseData<int>
                {
                    Left = new int[] {},
                    Right = new[] {1, 2, 3, 4},
                    Expected = new int[] {}
                };
                yield return new TestCaseData<int>
                {
                    Left = new int[] {},
                    Right = new int[] {},
                    Expected = new int[] {}
                };
            }
        }

        public static IEnumerable<TestCaseData<string>> StringCases
        {
            get
            {
                yield return new TestCaseData<string>
                {
                    Left = new[] {"James", "Robert", "John", "Mark"},
                    Right = new[] {"Elizabeth", "Amy"},
                    Expected = new[] {"James", "John", "Mark", "Robert"}
                };
                yield return new TestCaseData<string>
                {
                    Left = new[] {"James", "Robert", "John", "Mark"},
                    Right = new[] {"John", "Steven", "James", "Reba"},
                    Expected = new[] {"Mark", "Robert"}
                };
            }
        }
    }
}
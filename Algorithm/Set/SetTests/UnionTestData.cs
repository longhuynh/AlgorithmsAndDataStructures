using System.Collections.Generic;

namespace SetTests
{
    public class UnionTestData
    {
        public static IEnumerable<TestCaseData<int>> IntCases
        {
            get
            {
                yield return new TestCaseData<int>
                {
                    Left = new[] {1, 2, 3, 4},
                    Right = new[] {5, 6, 7, 8},
                    Expected = new[] {1, 2, 3, 4, 5, 6, 7, 8}
                };
                yield return new TestCaseData<int>
                {
                    Left = new[] {1, 2, 3, 4},
                    Right = new[] {1, 2, 3, 5},
                    Expected = new[] {1, 2, 3, 4, 5}
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
                    Expected = new[] {1, 2, 3, 4}
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
                    Expected = new[] {"Amy", "Elizabeth", "James", "John", "Mark", "Robert"}
                };
            }
        }
    }
}
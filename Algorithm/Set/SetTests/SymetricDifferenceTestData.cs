namespace SetTests
{
    public class SymetricDifferenceTestData
    {
        public static System.Collections.Generic.IEnumerable<TestCaseData<int>> IntCases
        {
            get
            {
                yield return new TestCaseData<int>
                {
                    Left = new int[] {1, 2, 3, 4},
                    Right = new int[] {5, 6, 7, 8},
                    Expected = new int[] {1, 2, 3, 4, 5, 6, 7, 8}
                };
                yield return new TestCaseData<int>
                {
                    Left = new int[] {1, 2, 3, 4},
                    Right = new int[] {1, 2, 5, 6},
                    Expected = new int[] {3, 4, 5, 6}
                };
                yield return new TestCaseData<int>
                {
                    Left = new int[] {1, 2, 3, 4},
                    Right = new int[] {},
                    Expected = new int[] {1, 2, 3, 4}
                };
                yield return new TestCaseData<int>
                {
                    Left = new int[] {},
                    Right = new int[] {1, 2, 3, 4},
                    Expected = new int[] {1, 2, 3, 4}
                };
                yield return new TestCaseData<int>
                {
                    Left = new int[] {},
                    Right = new int[] {},
                    Expected = new int[] {}
                };
            }
        }

        public static System.Collections.Generic.IEnumerable<TestCaseData<string>> StringCases
        {
            get
            {
                yield return new TestCaseData<string>
                {
                    Left = new string[] {"James", "Robert", "John", "Mark"},
                    Right = new string[] {"Elizabeth", "Amy"},
                    Expected = new string[] {"Amy", "Elizabeth", "James", "John", "Mark", "Robert"}
                };
                yield return new TestCaseData<string>
                {
                    Left = new string[] {"James", "Robert", "John", "Mark"},
                    Right = new string[] {"John", "Steven", "James", "Reba"},
                    Expected = new string[] {"Mark", "Reba", "Robert", "Steven"}
                };
            }
        }
    }
}
﻿namespace SetTests
{
    public class IntersectionTestData
    {
        public static System.Collections.Generic.IEnumerable<TestCaseData<int>> IntCases
        {
            get
            {
                yield return new TestCaseData<int>
                {
                    Left = new int[] {1, 2, 3, 4},
                    Right = new int[] {5, 6, 7, 8},
                    Expected = new int[] {}
                };
                yield return new TestCaseData<int>
                {
                    Left = new int[] {1, 2, 3, 4},
                    Right = new int[] {1, 2, 5, 6},
                    Expected = new int[] {1, 2}
                };
                yield return new TestCaseData<int>
                {
                    Left = new int[] {1, 2, 3, 4},
                    Right = new int[] {},
                    Expected = new int[] {}
                };
                yield return new TestCaseData<int>
                {
                    Left = new int[] {},
                    Right = new int[] {1, 2, 3, 4},
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

        public static System.Collections.Generic.IEnumerable<TestCaseData<string>> StringCases
        {
            get
            {
                yield return new TestCaseData<string>
                {
                    Left = new string[] {"James", "Robert", "John", "Mark"},
                    Right = new string[] {"Elizabeth", "Amy"},
                    Expected = new string[] {}
                };
                yield return new TestCaseData<string>
                {
                    Left = new string[] {"James", "Robert", "John", "Mark"},
                    Right = new string[] {"John", "Steven", "James", "Reba"},
                    Expected = new string[] {"James", "John"}
                };
            }
        }
    }
}
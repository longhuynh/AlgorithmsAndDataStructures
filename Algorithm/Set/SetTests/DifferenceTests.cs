using System;
using System.Linq;
using NUnit.Framework;
using Set;

namespace SetTests
{
    [TestFixture]
    public class DifferenceTests
    {
        public void DifferenceTest<T>(Set<T> left, Set<T> right, T[] expected)
            where T : IComparable<T>
        {
            var actual = left.Difference(right);

            var actualAsSortedArray = actual.OrderBy(i => i).ToArray();

            CollectionAssert.AreEqual(expected, actualAsSortedArray,
                "The Difference set does not match the expected set");
        }

        [Test, TestCaseSource(typeof(DifferenceTestData), nameof(DifferenceTestData.IntCases))]
        public void IntTests(TestCaseData<int> data)
        {
            DifferenceTest(new Set<int>(data.Left), new Set<int>(data.Right), data.Expected);
        }

        [Test, TestCaseSource(typeof(DifferenceTestData), nameof(DifferenceTestData.StringCases))]
        public void StringTests(TestCaseData<string> data)
        {
            DifferenceTest(new Set<string>(data.Left), new Set<string>(data.Right), data.Expected);
        }
    }
}
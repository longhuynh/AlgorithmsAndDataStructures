using NUnit.Framework;
using System.Linq;
using Set;
using System;

namespace SetTests
{
    [TestFixture]
    public class DifferenceTests
    {
        [Test, TestCaseSource(typeof(DifferenceTestData), "IntCases")]
        public void IntTests(TestCaseData<int> data)
        {
            DifferenceTest<int>(new Set<int>(data.Left), new Set<int>(data.Right), data.Expected);
        }

        [Test, TestCaseSource(typeof(DifferenceTestData), "StringCases")]
        public void StringTests(TestCaseData<string> data)
        {
            DifferenceTest<string>(new Set<string>(data.Left), new Set<string>(data.Right), data.Expected);
        }

        public void DifferenceTest<T>(Set<T> left, Set<T> right, T[] expected)
            where T : IComparable<T>
        {
            Set<T> actual = left.Difference(right);

            T[] actualAsSortedArray = actual.OrderBy(i => i).ToArray();

            CollectionAssert.AreEqual(expected, actualAsSortedArray, "The Difference set does not match the expected set");
        }
    }
}

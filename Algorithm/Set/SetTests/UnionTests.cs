using System;
using System.Linq;
using NUnit.Framework;
using Set;

namespace SetTests
{
    [TestFixture]
    public class UnionTests
    {
        public void UnionTest<T>(Set<T> left, Set<T> right, T[] expected)
            where T : IComparable<T>
        {
            var actual = left.Union(right);

            var actualAsSortedArray = actual.OrderBy(i => i).ToArray();

            CollectionAssert.AreEqual(expected, actualAsSortedArray, "The union set does not match the expected set");
        }

        [Test, TestCaseSource(typeof(UnionTestData), nameof(UnionTestData.IntCases))]
        public void IntTests(TestCaseData<int> data)
        {
            UnionTest(new Set<int>(data.Left), new Set<int>(data.Right), data.Expected);
        }

        [Test, TestCaseSource(typeof(UnionTestData), nameof(UnionTestData.StringCases))]
        public void StringTests(TestCaseData<string> data)
        {
            UnionTest(new Set<string>(data.Left), new Set<string>(data.Right), data.Expected);
        }
    }
}
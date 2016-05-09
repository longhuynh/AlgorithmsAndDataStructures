using System;
using System.Linq;
using NUnit.Framework;
using Set;

namespace SetTests
{
    [TestFixture]
    public class IntersectionTests
    {
        public void IntersectionTest<T>(Set<T> left, Set<T> right, T[] expected)
            where T : IComparable<T>
        {
            var actual = left.Intersection(right);

            var actualAsSortedArray = actual.OrderBy(i => i).ToArray();

            CollectionAssert.AreEqual(expected, actualAsSortedArray,
                "The Intersection set does not match the expected set");
        }

        [Test, TestCaseSource(typeof(IntersectionTestData), nameof(IntersectionTestData.IntCases))]
        public void IntTests(TestCaseData<int> data)
        {
            IntersectionTest(new Set<int>(data.Left), new Set<int>(data.Right), data.Expected);
        }

        [Test, TestCaseSource(typeof(IntersectionTestData), nameof(IntersectionTestData.StringCases))]
        public void StringTests(TestCaseData<string> data)
        {
            IntersectionTest(new Set<string>(data.Left), new Set<string>(data.Right), data.Expected);
        }
    }
}
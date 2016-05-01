using NUnit.Framework;
using System.Linq;
using Set;
using System;

namespace SetTests
{
    [TestFixture]
    public class IntersectionTests
    {
        [Test, TestCaseSource(typeof(IntersectionTestData), "IntCases")]
        public void IntTests(TestCaseData<int> data)
        {
            IntersectionTest<int>(new Set<int>(data.Left), new Set<int>(data.Right), data.Expected);
        }

        [Test, TestCaseSource(typeof(IntersectionTestData), "StringCases")]
        public void StringTests(TestCaseData<string> data)
        {
            IntersectionTest<string>(new Set<string>(data.Left), new Set<string>(data.Right), data.Expected);
        }

        public void IntersectionTest<T>(Set<T> left, Set<T> right, T[] expected)
            where T : IComparable<T>
        {
            Set<T> actual = left.Intersection(right);

            T[] actualAsSortedArray = actual.OrderBy(i => i).ToArray();

            CollectionAssert.AreEqual(expected, actualAsSortedArray, "The Intersection set does not match the expected set");
        }
    }
}

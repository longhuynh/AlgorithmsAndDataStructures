using NUnit.Framework;
using System.Linq;
using Set;
using System;

namespace SetTests
{
    [TestFixture]
    public class UnionTests
    {
        [Test, TestCaseSource(typeof(UnionTestData), "IntCases")]
        public void IntTests(TestCaseData<int> data)
        {
            UnionTest(new Set<int>(data.Left), new Set<int>(data.Right), data.Expected);
        }

        [Test, TestCaseSource(typeof(UnionTestData), "StringCases")]
        public void StringTests(TestCaseData<string> data)
        {
            UnionTest(new Set<string>(data.Left), new Set<string>(data.Right), data.Expected);
        }

        public void UnionTest<T>(Set<T> left, Set<T> right, T[] expected)
            where T: IComparable<T>
        {
            Set<T> actual = left.Union(right);

            T[] actualAsSortedArray = actual.OrderBy(i => i).ToArray();

            CollectionAssert.AreEqual(expected, actualAsSortedArray, "The union set does not match the expected set");
        }
    }
}

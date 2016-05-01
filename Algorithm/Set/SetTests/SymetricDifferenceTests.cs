using NUnit.Framework;
using System.Linq;
using Set;
using System;

namespace SetTests
{
    [TestFixture]
    public class SymetricDifferenceTests
    {
        [Test, TestCaseSource(typeof(SymetricDifferenceTestData), "IntCases")]
        public void IntTests(TestCaseData<int> data)
        {
            SymetricDifferenceTest<int>(new Set<int>(data.Left), new Set<int>(data.Right), data.Expected);
        }

        [Test, TestCaseSource(typeof(SymetricDifferenceTestData), "StringCases")]
        public void StringTests(TestCaseData<string> data)
        {
            SymetricDifferenceTest<string>(new Set<string>(data.Left), new Set<string>(data.Right), data.Expected);
        }

        public void SymetricDifferenceTest<T>(Set<T> left, Set<T> right, T[] expected)
            where T : IComparable<T>
        {
            Set<T> actual = left.SymmetricDifference(right);

            T[] actualAsSortedArray = actual.OrderBy(i => i).ToArray();

            CollectionAssert.AreEqual(expected, actualAsSortedArray, "The SymetricDifference set does not match the expected set");
        }
    }
}

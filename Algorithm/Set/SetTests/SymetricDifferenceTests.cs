using System;
using System.Linq;
using NUnit.Framework;
using Set;

namespace SetTests
{
    [TestFixture]
    public class SymetricDifferenceTests
    {
        public void SymetricDifferenceTest<T>(Set<T> left, Set<T> right, T[] expected)
            where T : IComparable<T>
        {
            var actual = left.SymmetricDifference(right);

            var actualAsSortedArray = actual.OrderBy(i => i).ToArray();

            CollectionAssert.AreEqual(expected, actualAsSortedArray,
                "The SymetricDifference set does not match the expected set");
        }

        [Test, TestCaseSource(typeof(SymetricDifferenceTestData), nameof(SymetricDifferenceTestData.IntCases))]
        public void IntTests(TestCaseData<int> data)
        {
            SymetricDifferenceTest(new Set<int>(data.Left), new Set<int>(data.Right), data.Expected);
        }

        [Test, TestCaseSource(typeof(SymetricDifferenceTestData), nameof(SymetricDifferenceTestData.StringCases))]
        public void StringTests(TestCaseData<string> data)
        {
            SymetricDifferenceTest(new Set<string>(data.Left), new Set<string>(data.Right), data.Expected);
        }
    }
}
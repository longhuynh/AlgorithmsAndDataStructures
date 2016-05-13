using System;
using System.Linq;
using NUnit.Framework;
using StringSearching;
using StringSearching.BoyerMoore;

namespace StringSearchingTests
{
    [TestFixture]
    public class StringSearchingTests
    {
        private readonly IStringSearchAlgorithm[] SearchAlgoritms =
        {
            new NaiveStringSearch(),
            new BoyerMoore()
        };

        public void Example(IStringSearchAlgorithm algorithm)
        {
            var toFind = "he";
            var toSearch = "The brown cat ran through the kitchen";

            foreach (var match in algorithm.Search(toFind, toSearch))
            {
                Console.WriteLine("Match found at: {0}", match.Start);
            }
        }

        [TestCaseSource(nameof(SearchAlgoritms))]
        public void SearchForMissingMatch(IStringSearchAlgorithm algorithm)
        {
            var toFind = "missing data";
            var toSearch = "this string does not contain the missing string data";

            var matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.IsNotNull(matches, "The matches array should not be null.");
            Assert.AreEqual(0, matches.Length, "The matches array should have not items.");
        }

        [TestCaseSource(nameof(SearchAlgoritms))]
        public void EmptySourceString(IStringSearchAlgorithm algorithm)
        {
            var toFind = string.Empty;
            var toSearch = "this string does not contain the missing string data";

            var matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.IsNotNull(matches, "The matches array should not be null.");
            Assert.AreEqual(0, matches.Length, "The matches array should have not items.");
        }

        [TestCaseSource("SearchAlgoritms")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSourceString(IStringSearchAlgorithm algorithm)
        {
            string toFind = null;
            var toSearch = "this string does not contain the missing string data";

            var matches = algorithm.Search(toFind, toSearch).ToArray();
        }

        [TestCaseSource(nameof(SearchAlgoritms))]
        public void EmptyTargetString(IStringSearchAlgorithm algorithm)
        {
            var toFind = "missing data";
            var toSearch = string.Empty;

            var matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.IsNotNull(matches, "The matches array should not be null.");
            Assert.AreEqual(0, matches.Length, "The matches array should have not items.");
        }

        [TestCaseSource(nameof(SearchAlgoritms))]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTargetString(IStringSearchAlgorithm algorithm)
        {
            var toFind = "missing data";
            string toSearch = null;

            var matches = algorithm.Search(toFind, toSearch).ToArray();
        }

        [TestCaseSource(nameof(SearchAlgoritms))]
        public void EmptyEmpty(IStringSearchAlgorithm algorithm)
        {
            var toFind = string.Empty;
            var toSearch = string.Empty;

            var matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.IsNotNull(matches, "The matches array should not be null.");
            Assert.AreEqual(0, matches.Length, "The matches array should have not items.");
        }

        [TestCaseSource(nameof(SearchAlgoritms))]
        public void ExactSingleCharMatch(IStringSearchAlgorithm algorithm)
        {
            var toFind = "f";
            var toSearch = "f";

            var matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.IsNotNull(matches, "The matches array should not be null.");
            Assert.AreEqual(1, matches.Length, "The matches array should have not items.");
            Assert.AreEqual(0, matches[0].Start, "The start of the string match should be 0");
            Assert.AreEqual(toFind.Length, matches[0].Length,
                "The length of the string match should equal the string found");
        }

        [TestCaseSource(nameof(SearchAlgoritms))]
        public void ExactMatch(IStringSearchAlgorithm algorithm)
        {
            var toFind = "found";
            var toSearch = "found";

            var matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.IsNotNull(matches, "The matches array should not be null.");
            Assert.AreEqual(1, matches.Length, "The matches array should have not items.");
            Assert.AreEqual(0, matches[0].Start, "The start of the string match should be 0");
            Assert.AreEqual(toFind.Length, matches[0].Length,
                "The length of the string match should equal the string found");
        }

        [TestCaseSource(nameof(SearchAlgoritms))]
        public void MultipleMatchesExactString(IStringSearchAlgorithm algorithm)
        {
            var toFind = "found";
            var toSearch = "foundfound";

            var matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.IsNotNull(matches, "The matches array should not be null.");
            Assert.AreEqual(2, matches.Length, "The matches array should have not items.");

            Assert.AreEqual(0, matches[0].Start, "The start of the string match should be 0");
            Assert.AreEqual(toFind.Length, matches[0].Length,
                "The length of the string match should equal the string found");

            Assert.AreEqual(5, matches[1].Start, "The start of the string match should be 5");
            Assert.AreEqual(toFind.Length, matches[1].Length,
                "The length of the string match should equal the string found");
        }

        [TestCaseSource(nameof(SearchAlgoritms))]
        public void MultipleMatchesLeadingJunk(IStringSearchAlgorithm algorithm)
        {
            var toFind = "found";
            var toSearch = "leadingfoundfound";

            var matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.IsNotNull(matches, "The matches array should not be null.");
            Assert.AreEqual(2, matches.Length, "The matches array should have not items.");

            Assert.AreEqual(7, matches[0].Start, "The start of the string match should be 0");
            Assert.AreEqual(toFind.Length, matches[0].Length,
                "The length of the string match should equal the string found");

            Assert.AreEqual(12, matches[1].Start, "The start of the string match should be 5");
            Assert.AreEqual(toFind.Length, matches[1].Length,
                "The length of the string match should equal the string found");
        }

        [TestCaseSource(nameof(SearchAlgoritms))]
        public void MultipleMatchesTrailingString(IStringSearchAlgorithm algorithm)
        {
            var toFind = "found";
            var toSearch = "foundfoundtrailing";

            var matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.IsNotNull(matches, "The matches array should not be null.");
            Assert.AreEqual(2, matches.Length, "The matches array should have not items.");

            Assert.AreEqual(0, matches[0].Start, "The start of the string match should be 0");
            Assert.AreEqual(toFind.Length, matches[0].Length,
                "The length of the string match should equal the string found");

            Assert.AreEqual(5, matches[1].Start, "The start of the string match should be 5");
            Assert.AreEqual(toFind.Length, matches[1].Length,
                "The length of the string match should equal the string found");
        }

        [TestCaseSource(nameof(SearchAlgoritms))]
        public void MultipleMatchesMiddleString(IStringSearchAlgorithm algorithm)
        {
            var toFind = "found";
            var toSearch = "found and found";

            var matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.IsNotNull(matches, "The matches array should not be null.");
            Assert.AreEqual(2, matches.Length, "The matches array should have not items.");

            Assert.AreEqual(0, matches[0].Start, "The start of the string match should be 0");
            Assert.AreEqual(toFind.Length, matches[0].Length,
                "The length of the string match should equal the string found");

            Assert.AreEqual(10, matches[1].Start, "The start of the string match should be 10");
            Assert.AreEqual(toFind.Length, matches[1].Length,
                "The length of the string match should equal the string found");
        }

        [TestCaseSource(nameof(SearchAlgoritms))]
        public void MultipleMatchesLeadingMiddleTrailing(IStringSearchAlgorithm algorithm)
        {
            var toFind = "found";
            var toSearch = "leadingfound and foundtrailing";

            var matches = algorithm.Search(toFind, toSearch).ToArray();

            Assert.IsNotNull(matches, "The matches array should not be null.");
            Assert.AreEqual(2, matches.Length, "The matches array should have not items.");

            Assert.AreEqual(7, matches[0].Start, "The start of the string match should be 0");
            Assert.AreEqual(toFind.Length, matches[0].Length,
                "The length of the string match should equal the string found");

            Assert.AreEqual(17, matches[1].Start, "The start of the string match should be 10");
            Assert.AreEqual(toFind.Length, matches[1].Length,
                "The length of the string match should equal the string found");
        }
    }
}
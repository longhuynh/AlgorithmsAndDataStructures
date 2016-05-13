using System;
using System.Collections.Generic;
using Tracker;

namespace StringSearching.BoyerMoore
{
    public class BoyerMoore : Tracker<char>, IStringSearchAlgorithm
    {
        public IEnumerable<ISearchMatch> Search(string pattern, string toSearch)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException("toFind");
            }

            if (toSearch == null)
            {
                throw new ArgumentNullException("toSearch");
            }

            if (pattern.Length > 0 && toSearch.Length > 0)
            {
                var badMatchTable = new BadMatchTable(pattern);

                var currentStartIndex = 0;
                while (currentStartIndex <= toSearch.Length - pattern.Length)
                {
                    var charactersLeftToMatch = pattern.Length - 1;

                    while (charactersLeftToMatch >= 0 &&
                           Compare(pattern[charactersLeftToMatch], toSearch[currentStartIndex + charactersLeftToMatch]) ==
                           0)
                    {
                        charactersLeftToMatch--;
                    }

                    if (charactersLeftToMatch < 0)
                    {
                        yield return new StringSearchMatch(currentStartIndex, pattern.Length);
                        currentStartIndex += pattern.Length;
                    }
                    else
                    {
                        currentStartIndex += badMatchTable[toSearch[currentStartIndex + pattern.Length - 1]];
                    }
                }
            }
        }
    }
}
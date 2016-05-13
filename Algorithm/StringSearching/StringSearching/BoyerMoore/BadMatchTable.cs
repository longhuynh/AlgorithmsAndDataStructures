using System.Collections.Generic;

namespace StringSearching.BoyerMoore
{
    internal class BadMatchTable
    {
        private readonly int defaultValue;
        private readonly Dictionary<int, int> distances;

        public BadMatchTable(string pattern)
        {
            defaultValue = pattern.Length;
            distances = new Dictionary<int, int>();

            for (var i = 0; i < pattern.Length - 1; i++)
            {
                distances[pattern[i]] = pattern.Length - i - 1;
            }
        }

        public int this[int index]
        {
            get
            {
                int value;
                if (!distances.TryGetValue(index, out value))
                {
                    value = defaultValue;
                }

                return value;
            }
            set { distances[index] = value; }
        }
    }
}
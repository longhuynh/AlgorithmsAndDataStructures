namespace StringSearching
{
    internal class StringSearchMatch : ISearchMatch
    {
        public StringSearchMatch(int start, int length)
        {
            Start = start;
            Length = length;
        }

        public int Start { get; }

        public int Length { get; }
    }
}
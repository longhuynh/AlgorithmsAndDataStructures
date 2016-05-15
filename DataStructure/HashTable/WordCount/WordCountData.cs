namespace WordCount
{
    public class WordCountData
    {
        public WordCountData(string word, int count)
        {
            Word = word;
            Count = count;
        }

        public string Word { get; set; }
        public int Count { get; set; }
    }
}
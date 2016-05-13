using StringSearching;

namespace SimpleTextReplacement
{
    internal class AlgorithmSelector
    {
        public AlgorithmSelector(string name, IStringSearchAlgorithm algorithm)
        {
            Name = name;
            Algorithm = algorithm;
        }

        public string Name { get; }
        public IStringSearchAlgorithm Algorithm { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
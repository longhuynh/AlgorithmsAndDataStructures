using System;
using BinaryTree;

namespace WordSorter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var tree = new BinaryTree<string>();

            var input = string.Empty;

            while (!input.Equals("quit", StringComparison.CurrentCultureIgnoreCase))
            {
                // read the line from the user
                Console.Write("> ");
                input = Console.ReadLine();

                // split the line into words (on space)
                if (input != null)
                {
                    var words = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                    // add each word to the tree
                    foreach (var word in words)
                    {
                        tree.Add(word);
                    }
                }

                // print the number of words
                Console.WriteLine("{0} words", tree.Count);

                // and print each word using the default (in-order) enumerator
                foreach (var word in tree)
                {
                    Console.Write("{0} ", word);
                }

                Console.WriteLine();

                tree.Clear();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using HashTable;
using NUnit.Framework;

namespace HashTableTests
{
    [TestFixture]
    internal class Add
    {
        private readonly Random random = new Random();

        [Test]
        public void AddDuplicateThrows()
        {
            var table = new HashTable<string, int>();
            var added = new List<int>();

            for (var i = 0; i < 100; i++)
            {
                Assert.AreEqual(i, table.Count, "The count was incorrect");

                var value = random.Next();
                var key = value.ToString();

                // this ensure we should never throw on Add
                while (table.ContainsKey(key))
                {
                    value = random.Next();
                    key = value.ToString();
                }

                table.Add(key, value);
                added.Add(value);
            }

            // now make sure each attempt to re-add throws
            foreach (var value in added)
            {
                try
                {
                    table.Add(value.ToString(), value);
                    Assert.Fail("The Add operation should have thrown with the duplicate key");
                }
                catch (ArgumentException)
                {
                    // correct!
                }
            }
        }

        [Test]
        public void AddUniqueAdds()
        {
            var table = new HashTable<string, int>();
            var added = new List<int>();

            for (var i = 0; i < 100; i++)
            {
                Assert.AreEqual(i, table.Count, "The count was incorrect");

                var value = random.Next();
                var key = value.ToString();

                // this ensure we should never throw on Add
                while (table.ContainsKey(key))
                {
                    value = random.Next();
                    key = value.ToString();
                }

                table.Add(key, value);
                added.Add(value);
            }

            // now make sure all the keys and values are there
            foreach (var value in added)
            {
                Assert.IsTrue(table.ContainsKey(value.ToString()), "ContainsKey returned false?");
                Assert.IsTrue(table.ContainsValue(value), "ContainsValue returned false?");

                var found = table[value.ToString()];
                Assert.AreEqual(value, found, "The indexed value was incorrect");
            }
        }
    }
}
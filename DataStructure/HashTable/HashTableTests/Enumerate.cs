using System;
using System.Collections.Generic;
using HashTable;
using NUnit.Framework;

namespace HashTableTests
{
    [TestFixture]
    internal class Enumerate
    {
        private readonly Random rng = new Random();

        [Test]
        public void EnumerateKeysEmpty()
        {
            var table = new HashTable<string, string>();

            foreach (var key in table.Keys)
            {
                Assert.Fail("There should be nothing in the Keys collection");
            }
        }

        [Test]
        public void EnumerateKeysPopulated()
        {
            var table = new HashTable<int, string>();

            var keys = new List<int>();
            for (var i = 0; i < 100; i++)
            {
                var value = rng.Next();
                while (table.ContainsKey(value))
                {
                    value = rng.Next();
                }

                keys.Add(value);
                table.Add(value, value.ToString());
            }

            foreach (var key in table.Keys)
            {
                Assert.IsTrue(keys.Remove(key), "The key was missing from the keys collection");
            }

            Assert.AreEqual(0, keys.Count, "There were left over values in the keys collection");
        }

        [Test]
        public void EnumerateValuesEmpty()
        {
            var table = new HashTable<string, string>();

            foreach (var key in table.Values)
            {
                Assert.Fail("There should be nothing in the Values collection");
            }
        }

        [Test]
        public void EnumerateValuesPopulated()
        {
            var table = new HashTable<int, string>();

            var values = new List<string>();
            for (var i = 0; i < 100; i++)
            {
                var value = rng.Next();
                while (table.ContainsKey(value))
                {
                    value = rng.Next();
                }

                values.Add(value.ToString());
                table.Add(value, value.ToString());
            }

            foreach (var value in table.Values)
            {
                Assert.IsTrue(values.Remove(value), "The key was missing from the values collection");
            }

            Assert.AreEqual(0, values.Count, "There were left over values in the value collection");
        }
    }
}
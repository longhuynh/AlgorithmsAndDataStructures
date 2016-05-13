using System;
using HashTable;
using NUnit.Framework;

namespace HashTableTests
{
    [TestFixture]
    internal class Get
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFromEmpty()
        {
            var table = new HashTable<string, int>();
            var value = table["missing"];
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetMissing()
        {
            var table = new HashTable<string, int>();
            table.Add("100", 100);

            var value = table["missing"];
        }

        [Test]
        public void GetSucceeds()
        {
            var table = new HashTable<string, int>();
            table.Add("100", 100);

            var value = table["100"];
            Assert.AreEqual(100, value, "The returned value was incorrect");

            for (var i = 0; i < 100; i++)
            {
                table.Add(i.ToString(), i);

                value = table["100"];
                Assert.AreEqual(100, value, "The returned value was incorrect");
            }
        }

        [Test]
        public void TryGetFromEmpty()
        {
            var table = new HashTable<string, int>();
            int value;

            Assert.IsFalse(table.TryGetValue("missing", out value));
        }

        [Test]
        public void TryGetMissing()
        {
            var table = new HashTable<string, int>();
            table.Add("100", 100);

            int value;
            Assert.IsFalse(table.TryGetValue("missing", out value));
        }

        [Test]
        public void TryGetSucceeds()
        {
            var table = new HashTable<string, int>();
            table.Add("100", 100);

            int value;
            Assert.IsTrue(table.TryGetValue("100", out value));
            Assert.AreEqual(100, value, "The returned value was incorrect");

            for (var i = 0; i < 100; i++)
            {
                table.Add(i.ToString(), i);

                Assert.IsTrue(table.TryGetValue("100", out value));
                Assert.AreEqual(100, value, "The returned value was incorrect");
            }
        }
    }
}
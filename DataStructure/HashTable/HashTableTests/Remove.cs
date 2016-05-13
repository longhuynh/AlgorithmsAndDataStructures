using HashTable;
using NUnit.Framework;

namespace HashTableTests
{
    [TestFixture]
    internal class Remove
    {
        [Test]
        public void RemoveEmpty()
        {
            var table = new HashTable<string, int>();
            Assert.IsFalse(table.Remove("missing"), "Remove on an empty collection should return false");
        }

        [Test]
        public void RemoveFound()
        {
            var table = new HashTable<string, int>();
            for (var i = 0; i < 100; i++)
            {
                table.Add(i.ToString(), i);
            }

            for (var i = 0; i < 100; i++)
            {
                Assert.IsTrue(table.ContainsKey(i.ToString()), "The key was not found in the collection");
                Assert.IsTrue(table.Remove(i.ToString()), "The value was not removed (or remove returned false)");
                Assert.IsFalse(table.ContainsKey(i.ToString()), "The key should not have been found in the collection");
            }
        }

        [Test]
        public void RemoveMissing()
        {
            var table = new HashTable<string, int>();
            table.Add("100", 100);

            Assert.IsFalse(table.Remove("missing"), "Remove on an empty collection should return false");
        }
    }
}
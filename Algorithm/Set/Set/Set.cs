using System;
using System.Collections;
using System.Collections.Generic;

namespace Set
{
    public class Set<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private readonly List<T> items = new List<T>();

        public Set()
        {
        }

        public Set(IEnumerable<T> items)
        {
            AddRange(items);
        }

        public int Count => items.Count;

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public void Add(T item)
        {
            if (Contains(item))
            {
                throw new InvalidOperationException("Item already exists in Set");
            }

            items.Add(item);
        }

        public void AddRange(IEnumerable<T> enumerables)
        {
            foreach (var item in enumerables)
            {
                Add(item);
            }
        }

        private void AddSkipDuplicates(T item)
        {
            if (!Contains(item))
            {
                items.Add(item);
            }
        }

        private void AddRangeSkipDuplicates(IEnumerable<T> enumerables)
        {
            foreach (var item in enumerables)
            {
                AddSkipDuplicates(item);
            }
        }

        public bool Remove(T item)
        {
            return items.Remove(item);
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public Set<T> Union(Set<T> other)
        {
            var result = new Set<T>(items);
            result.AddRangeSkipDuplicates(other.items);

            return result;
        }

        public Set<T> Intersection(Set<T> other)
        {
            var result = new Set<T>();

            foreach (var item in items)
            {
                if (other.items.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public Set<T> Difference(Set<T> other)
        {
            var result = new Set<T>(items);

            foreach (var item in other.items)
            {
                result.Remove(item);
            }

            return result;
        }

        public Set<T> SymmetricDifference(Set<T> other)
        {
            var intersection = Intersection(other);
            var union = Union(other);

            return union.Difference(intersection);
        }
    }
}
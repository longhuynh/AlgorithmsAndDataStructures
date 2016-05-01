using System;
using System.Collections.Generic;

namespace Set
{
    public class Set<T> : IEnumerable<T>
        where T: IComparable<T>
    {
        private readonly List<T> items = new List<T>();

        public Set()
        {
        }

        public Set(IEnumerable<T> items)
        {
            AddRange(items);
        }

        public void Add(T item)
        {
            if (Contains(item))
            {
                throw new InvalidOperationException("Item already exists in Set");
            }

            items.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (T item in items)
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

        private void AddRangeSkipDuplicates(IEnumerable<T> items)
        {
            foreach (T item in items)
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

        public int Count
        {
            get
            {
                return items.Count;
            }
        }

        public Set<T> Union(Set<T> other)
        {
            Set<T> result = new Set<T>(items);
            result.AddRangeSkipDuplicates(other.items);

            return result;
        }

        public Set<T> Intersection(Set<T> other)
        {
            Set<T> result = new Set<T>();

            foreach (T item in items)
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
            Set<T> result = new Set<T>(items);

            foreach (T item in other.items)
            {
                result.Remove(item);
            }

            return result;
        }

        public Set<T> SymmetricDifference(Set<T> other)
        {
            Set<T> intersection = Intersection(other);
            Set<T> union = Union(other);

            return union.Difference(intersection);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}

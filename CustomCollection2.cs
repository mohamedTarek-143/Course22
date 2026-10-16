using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Course22
{
    internal class CustomCollection2<T> : ICollection<T>
    {
        private List<T> list = new List<T>();
        public int Count => list.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            list.Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {

            for (int i = 0; i < list.Count; i++)
            {
                array[arrayIndex + i] = list[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(var item in list)
            {
                yield return item;
            }
        }

        public bool Remove(T item)
        {
           return list.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course22
{
    internal class MyCustomCollection : IEnumerable<string>
    {
        private List<string> list = new List<string>();

        public IEnumerator<string> GetEnumerator()
        {
            foreach(var item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(string s)
        {
            list.Add(s);
        }
    }
}

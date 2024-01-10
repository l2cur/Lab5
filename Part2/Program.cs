using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Part2
{

    class Programm
    {
        static void Main()
        {
            int[] list = { 1, 2, 3, 4, 5, };
            MyList<int> list2 = new MyList<int>(list);
            Console.WriteLine(list2.Count);
            for (int i = 0; i < list2.Count; i++) { Console.Write(list2[i].ToString().PadRight(3)); }
            Console.WriteLine();

            list2.Add(6);
            Console.WriteLine(list2.Count);
            for (int i = 0; i < list2.Count; i++) { Console.Write(list2[i].ToString().PadRight(3)); }
            Console.WriteLine();

            MyList<int> ml = new MyList<int>() { 1, 2, 3, 4 };
            Console.WriteLine(list2.Count);
            for (int i = 0; i < ml.Count; i++) { Console.Write(ml[i].ToString().PadRight(3)); }
            Console.WriteLine();

        }
    }
    public class MyList<T> : IEnumerable<T>
    {
        T[] list = null;
        private int _count;
        public int Count { get { return _count; } }
        public MyList() { _count = 0; }
        public MyList(T[] list) { _count = list.Length; this.list = list; }
        public T this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                this.list[index] = value;
            }
        }
        public void Add(T item)
        {
            T[] tmp = new T[_count + 1];
            for (int i = 0; i < _count; i++) { tmp[i] = list[i]; }
            tmp[_count] = item;
            this.list = tmp;
            _count++;
        }
        public void Clear() { _count = 0; list = null; }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)list.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}

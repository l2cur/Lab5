using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3
{
    class Programm
    {
        static void Main()
        {
            MyDictionary<int, int> md = new MyDictionary<int, int>();
            md.Add(1, 5);
            md.Add(3, 5);
            md.Add(5, 7);
            md.Add(6, 55);
            //md.Add(1, 5);
            md.Print();
        }
    }
    public class MyDictionary<TKey, TValue>
    {
        private TKey[] _key;
        private TValue[] _value;
        private int _count;
        public int Count { get { return _count; } }
        public MyDictionary() { _count = 0; _key = new TKey[] { }; _value = new TValue[] { }; }
        public MyDictionary(int size) { _count = size; _key = new TKey[size]; _value = new TValue[size]; }
        public MyDictionary(MyDictionary<TKey, TValue> list) { _count = list.Count; _key = list._key; _value = list._value; }
        public TKey key(int index)
        {
            return _key[index];
        }
        public TValue this[TKey key]
        {
            get
            {
                return this[key];
            }
            set
            {
                this[key] = value;
            }
        }
        public void Add(TKey key, TValue value)
        {
            for (int i = 0; i < _key.Length; i++)
            {
                if (Equals(key, _key[i])) { throw new ArgumentException("This key is already use"); }
            }
            MyDictionary<TKey, TValue> tmp = new MyDictionary<TKey, TValue>(_count + 1);
            for (int i = 0; i < _count; i++)
            {
                tmp._key[i] = _key[i];
                tmp._value[i] = _value[i];
            }
            tmp._key[_count] = key;
            tmp._value[_count] = value;
            _key = tmp._key;
            _value = tmp._value;
            _count++;
        }
        public IEnumerator<TKey> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _key[i];
            }
        }
        public void Print()
        {
            foreach (var obj in _key)
            {
                Console.Write(obj.ToString().PadRight(3));
            }
        }
    }
}

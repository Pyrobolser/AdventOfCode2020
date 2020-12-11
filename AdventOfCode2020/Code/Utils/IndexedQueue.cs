using System.Collections.Generic;

namespace AdventOfCode2020.Code.Utils
{
    public class IndexedQueue<T>
    {
        private T[] _queue;
        private int _start;
        private int _length;

        public int Count => _length;

        public T this[int index] => _queue[(_start + index) % _queue.Length];

        public IndexedQueue(int initialSize)
        {
            _queue = new T[initialSize];
            _start = 0;
            _length = 0;
        }

        public IndexedQueue(T[] initialQueue)
        {
            _queue = initialQueue;
            _start = 0;
            _length = initialQueue.Length;
        }

        public void Enqueue(T item)
        {
            if (_length == _queue.Length)
            {
                T[] extendedQueue = new T[_queue.Length * 2];
                for(int i = 0; i < _length; i++)
                {
                    extendedQueue[i] = _queue[(_start + i) % _length];
                }
                _start = 0;
                _queue = extendedQueue;
            }
            _queue[(_start + _length) % _queue.Length] = item;
            _length++;
        }

        public T Dequeue()
        {
            var item = _queue[_start];
            _start = (_start + 1) % _queue.Length;
            _length--;

            return item;
        }

        public T Peak()
        {
            return _queue[_start];
        }

        public bool Contains(T item)
        {
            var result = false;
            for(int i = 0; i < _length; i++)
            {
                result = EqualityComparer<T>.Default.Equals(_queue[(_start + i) % _queue.Length], item);

                if (result)
                    break;
            }

            return result;
        }
    }
}

using System;
using System.Linq;

namespace NumberQueue
{
    public class Queue<Type>
    {
        private Type[] _buffer;
        private int _first;
        private int _last;
        private readonly int _bufferSize;

        /// <summary>
        /// Creates empty queue with buffer
        /// </summary>
        /// <param name="bufferSize">Initital size of stack buffer</param>
        public Queue(int bufferSize = 8)
        {
            if (bufferSize < 1)
            {
                throw new ArgumentException("bufferSize must be above Zero", nameof(bufferSize));
            }

            _buffer = new Type[bufferSize];
            _bufferSize = bufferSize;
        }

        /// <summary>
        /// Creates queue with "data" array and buffer multiple of "bufferSize"
        /// </summary>
        /// <param name="bufferSize">Initital size of stack buffer</param>
        public Queue(Type[] data, int bufferSize = 8)
        {
            if (bufferSize < 1)
            {
                throw new ArgumentException("bufferSize must be above Zero", nameof(bufferSize));
            }

            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            int size = data.Length + bufferSize;
            _buffer = new Type[size];
            Array.Copy(data, _buffer, data.Length);
            _bufferSize = bufferSize;
            _last = data.Length;
        }

        /// <summary>
        /// Elements amount
        /// </summary>
        public int Count
        {
            get
            {
                return _last - _first;
            }
        }

        /// <summary>
        /// Adds the object to the beginning of the Queue.
        /// </summary>
        public void Enqueue(Type element)
        {
            if (_last >= _buffer.Length)
            {
                Extend();
            }

            _buffer[_last++] = element;
        }

        /// <summary>
        /// Returns the object at the beginning of the Queue and removes it.
        /// </summary>
        public Type Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _buffer[_first++];
        }

        /// <summary>
        /// Returns the object at the beginning of the Queue without removing it.
        /// </summary>
        public Type Peek()
        {
            return _buffer[_first];
        }

        public bool Contains(Type searchingElement)
        {
            return _buffer.Skip(_first).Take(Count).Contains(searchingElement);
        }

        private void Extend()
        {
            var count = Count;
            var newBuffer = new Type[count + _bufferSize];
            Array.Copy(_buffer, _first, newBuffer, 0, count);
            _buffer = newBuffer;
            _first = 0;
            _last = count;
        }
    }
}

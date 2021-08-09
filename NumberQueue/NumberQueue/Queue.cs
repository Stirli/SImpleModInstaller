using System;

namespace NumberQueue
{
    public class Queue<Type>
    {
        /// <summary>
        /// Creates empty queue with buffer
        /// </summary>
        /// <param name="bufferSize">Initital size of stack buffer</param>
        public Queue(int bufferSize = 8)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates queue with "data" array and buffer multiple of "bufferSize"
        /// </summary>
        /// <param name="bufferSize">Initital size of stack buffer</param>
        public Queue(Type[] data, int bufferSize = 8)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Elements amount
        /// </summary>
        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Current size of buffer
        /// </summary>
        public int BufferSize
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Adds the object to the beginning of the Queue.
        /// </summary>
        public void Enqueue(Type element)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the object at the beginning of the Queue and removes it.
        /// </summary>
        public Type Dequeue()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the object at the beginning of the Queue without removing it.
        /// </summary>
        public Type Peek()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Type searchingElement)
        {
            throw new NotImplementedException();
        }

        private void Extend()
        {
            throw new NotImplementedException();
        }
    }
}

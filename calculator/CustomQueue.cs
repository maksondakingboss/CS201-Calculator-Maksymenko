namespace calculator
{
    using System;

    public class CustomQueue<T>
    {
        private T[] _array = new T[50];
        private int _pointer = 0;

        public void Enqueue(T element)
        {
            if (_pointer == _array.Length)
            {
                var extendedArray = new T[_array.Length * 2];
                for (var i = 0; i < _array.Length; i++)
                {
                    extendedArray[i] = _array[i];
                }
                _array = extendedArray;
            }

            _array[_pointer] = element;
            _pointer++;
        }

        public T Dequeue()
        {
            if (_pointer == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            T value = _array[0];

            for (var i = 0; i < _pointer - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            _pointer--;
            _array[_pointer] = default; 

            return value;
        }

        public bool IsEmpty()
        {
            return _pointer == 0;
        }

        public int Count()
        {
            return _pointer;
        }
        public T[] ToArray()
        {
            T[] result = new T[_pointer];
            for (int i = 0; i < _pointer; i++)
            {
                result[i] = _array[i];
            }
            return result;
        }
    }
}
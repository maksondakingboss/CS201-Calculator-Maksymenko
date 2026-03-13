namespace calculator
{
    using System;
    
    public class CustomStack<T>
    {
        private const int Capacity = 50;
        private T[] _array = new T[Capacity];
        private int _pointer;

        public void Push(T value)
        {
            if (_pointer == _array.Length)
            {
                throw new Exception("Stack overflowed");
            }

            _array[_pointer] = value;
            _pointer++;
        }

        public T Pop()
        {
            if (_pointer == 0)
            {
                throw new InvalidOperationException("Stack is empty!"); 
            }
            _pointer--;
            var value = _array[_pointer];
            return value;
        }
        
        public T Peek()
        {
            if (_pointer == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            return _array[_pointer - 1];
        }
        public bool IsEmpty()
        {
            return _pointer == 0;
        }
    }
}
namespace uniqueIpAddress
{
    public class UArray<T>
    {
        private readonly T[] _array1;
        private readonly T[] _array2;
        private readonly T[] _array3;
        private readonly T[] _array4;

        public UArray()
        {
            var _max = int.MaxValue / 2;

            _array1 = new T[_max];
            _array2 = new T[_max + 1];
            _array3 = new T[_max + 1];
            _array4 = new T[_max + 1];
        }

        public T this[uint index]
        {
            get
            {
                if (index < _array1.Length)
                    return _array1[index];

                index -= (uint)_array1.Length;

                if (index < _array2.Length)
                    return _array2[index];

                index -= (uint)_array2.Length;

                if (index < _array3.Length)
                    return _array3[index];

                return _array4[index - _array3.Length];
            }
            set
            {

                if (index < _array1.Length)
                {
                    _array1[index] = value;
                    return;
                }

                index -= (uint)_array1.Length;

                if (index < _array2.Length)
                {
                    _array2[index] = value;
                    return;
                }

                index -= (uint)_array2.Length;

                if (index < _array3.Length)
                {
                    _array3[index] = value;
                    return;
                }

                _array4[index - _array3.Length] = value;
            }
        }

        public IEnumerable<T> Items
        {
            get
            {
                foreach (var item in _array1)
                    yield return item;

                foreach (var item in _array2)
                    yield return item;

                foreach (var item in _array3)
                    yield return item;

                foreach (var item in _array4)
                    yield return item;
            }
        }
    }
}

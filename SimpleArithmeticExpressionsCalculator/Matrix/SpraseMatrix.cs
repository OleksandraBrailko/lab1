using System;

namespace SimpleArithmeticExpressionsCalculator
{
    class SpraseMatrix
    {
        #region Private fields

        private int _rowCount;
        private int _columnCount;        
        private int _elementColumnCount;
        private int _zeroColumnCount;
        private double[,] _array;

        #endregion

        #region Properties

        //public int RowCount
        //{
        //    get
        //    {
        //        return _rowCount;
        //    }
        //}        
        public int RowCount => _rowCount;
        public int ColumnCount => _columnCount;
        public double this[int i, int j]
        {
            get
            {
                if (j < _zeroColumnCount)
                {
                    return 0;
                }
                return _array[i, j - _zeroColumnCount];
            }
            set
            {
                if (j < _zeroColumnCount)
                {
                    throw new ArgumentException("You can't change left side elements");
                }
                _array[i - _zeroColumnCount, j] = value;
            }
        }

        #endregion

        #region Constructors

        public SpraseMatrix(double[,] array)
        {
            _rowCount = array.GetLength(0);
            _columnCount = array.GetLength(1);
            if (_columnCount % 2 == 0)
            {
                _elementColumnCount = _columnCount / 2;
            }
            else
            {
                _elementColumnCount = _columnCount / 2+1;
            }
            _zeroColumnCount = _columnCount - _elementColumnCount;
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _zeroColumnCount; j++)
                {
                    if (array[i, j] != 0)
                    {
                        throw new ArgumentException("Left side elements are not zero!!!");
                    }
                }
            }
            _array = new double[_rowCount, _elementColumnCount];
            for (int i = 0; i <_rowCount; i++)
            {
                for (int j = 0; j < _elementColumnCount; j++)
                {
                    _array[i, j] = array[i, j + _zeroColumnCount];
                }
            }
        }

        #endregion Constructors

        #region Methods             

        public SpraseMatrix Add(SpraseMatrix m)
        {
            var result = new double[this._rowCount, m._elementColumnCount];
            for (int row = 0; row < this._rowCount; row++)
            {
                for (int column = 0; column < this._elementColumnCount; column++)
                {
                    result[row, column] = this[row, column] + m[row, column];
                }
            }
            return new SpraseMatrix(result);
        }

        public SpraseMatrix Subtract(SpraseMatrix m)
        {
            var result = new double[this._rowCount, m._elementColumnCount];
            for (int row = 0; row < this._rowCount; row++)
            {
                for (int column = 0; column < this._elementColumnCount; column++)
                {
                    result[row, column] = this[row, column] - m[row, column];
                }
            }
            return new SpraseMatrix(result);
        }

        public SpraseMatrix Multiply(SpraseMatrix m)
        {
            var result = new double[this._rowCount, m._columnCount];
            for (int row = 0; row < this._rowCount; row++)
            {
                for (int column = 0; column < m._columnCount; column++)
                {
                    double sum = 0;
                    for (int iterator = 0; iterator < this._columnCount; iterator++)
                    {                                               
                        sum += this[row, iterator] * m[iterator, column];
                    }
                    result[row, column] = sum;
                }
            }
            return new SpraseMatrix(result);
        }

        #endregion

        #region Operators

        public static SpraseMatrix operator +(SpraseMatrix m1, SpraseMatrix m2)
        {           
            return m1.Add(m2);
        }
        public static SpraseMatrix operator -(SpraseMatrix m1, SpraseMatrix m2)
        {
            return m1.Subtract(m2);
        }
        public static SpraseMatrix operator *(SpraseMatrix m1, SpraseMatrix m2)
        {
            return m1.Multiply(m2);
        }

        #endregion
    }
}


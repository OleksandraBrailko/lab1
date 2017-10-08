namespace SimpleArithmeticExpressionsCalculator
{
    public class SimpleMatrix
    {
        #region Private fields

        private double[,] _array;

        #endregion

        #region Properties

        public int RowCount
        {
            get
            {
                return _array.GetLength(0);
            }
        }
        public int ColumCount
        {
            get
            {
                return _array.GetLength(1);
            }
        }
        public double this[int i, int j]
        {
            get
            {
                return _array[i, j];
            }
        }

        #endregion

        #region Constructors

        public SimpleMatrix(double[,] array)
        {
            _array = array;
        }

        #endregion Constructors

        #region Methods             

        public SimpleMatrix Add(SimpleMatrix m)
        {
            var result = new double[this.RowCount, m.ColumCount];
            for (int row = 0; row < this.RowCount; row++)
            {
                for (int column = 0; column < this.ColumCount; column++)
                {
                    result[row, column] = this[row, column] + m[row, column];

                }
            }
            return new SimpleMatrix(result);
        }
        public SimpleMatrix Subtract(SimpleMatrix m)
        {
            var result = new double[this.RowCount, m.ColumCount];
            for (int row = 0; row < this.RowCount; row++)
            {
                for (int column = 0; column < this.ColumCount; column++)
                {
                    result[row, column] = this[row, column] - m[row, column];

                }
            }
            return new SimpleMatrix(result);
        }
        public SimpleMatrix Multiply(SimpleMatrix m)
        {
            var result = new double[this.RowCount, m.ColumCount];
            for (int row = 0; row < this.RowCount; row++)
            {
                for (int column = 0; column < m.ColumCount; column++)
                {
                    double sum = 0;
                    for (int iterator = 0; iterator < this.ColumCount; iterator++)
                    {
                        sum += this[row, iterator] * m[iterator, column];
                    }
                    result[row, column] = sum;
                }
            }
            return new SimpleMatrix(result);
        }

        #endregion

        #region Operators

        public static SimpleMatrix operator +(SimpleMatrix m1, SimpleMatrix m2)
        {           
            return m1.Add(m2);
        }
        public static SimpleMatrix operator -(SimpleMatrix m1, SimpleMatrix m2)
        {
            return m1.Subtract(m2);
        }
        public static SimpleMatrix operator *(SimpleMatrix m1, SimpleMatrix m2)
        {
            return m1.Multiply(m2);
        }

        #endregion
    }
}

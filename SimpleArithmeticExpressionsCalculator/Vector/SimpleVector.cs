using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleArithmeticExpressionsCalculator
{
    public class SimpleVector: IVector
    {
        #region Private fields

        private List<double> _vector;

        #endregion

        #region Properties

        public int RowCount => _vector.Count;
        
        public double this[int i]
        {
            get
            {
                return _vector[i];
            }
            set
            {
                _vector[i] = value;
            }
        }

        #endregion

        #region Constructors

        public SimpleVector(List<double> vector)
        {
            _vector = vector;
        }

        #endregion 

        #region Methods 

        public IVector Add(IVector v)
        {
            var result = new List<double>();
            for (int i = 0; i < _vector.Count; i++)
            {
                result.Add(this[i] + v[i]);
            }   
            return new SimpleVector(result);
        }
        public IVector Substracrion(IVector v)
        {
            var result = new List<double>();
            for (int i = 0; i < _vector.Count; i++)
            {
                result.Add(this[i] - v[i]);
            }
            return new SimpleVector(result);
        }
        public IVector Multiplication(int number)
        {
            var result = new List<double>();
            
            for (int i = 0; i < _vector.Count; i++)
            {
                result.Add(this[i]*number);
            }
            return new SimpleVector(result);
        }
        public double ScalarProduct(IVector v)
        {
            var result = new List<double>();
            for (int i = 0; i < _vector.Count; i++)
            {
                result.Add(this[i]*v[i]);
            }
            return new SimpleVector(result)._vector.Sum();
        }

        #endregion
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleArithmeticExpressionsCalculator.Matrix
{
    public interface IMatrix
    {
        int RowCount { get; }
        int ColumnCount { get; }

        IMatrix Add(IMatrix m);
        IMatrix Subtract(IMatrix m);
        IMatrix Multiply(IMatrix m);        
    }
}

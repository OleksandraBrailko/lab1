using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleArithmeticExpressionsCalculator
{
    public interface IVector
    {
        double this[int i] { get; set; }
        IVector Add(IVector v);
        IVector Substracrion(IVector v);
        IVector Multiplication(int number);
        double ScalarProduct(IVector v);

    }
}

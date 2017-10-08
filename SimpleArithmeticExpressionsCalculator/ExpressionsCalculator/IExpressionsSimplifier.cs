using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleArithmeticExpressionsCalculator
{
     public interface IExpressionsSimplifier
    {
        double Simplify(List<string> tokens);       
    }
}

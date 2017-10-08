using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleArithmeticExpressionsCalculator
{
   public   class SimpleArithmeticExpressionsCalculator
    {
        private IExpressionsSimplifier _expressionsSimplifier;
        public SimpleArithmeticExpressionsCalculator(IExpressionsSimplifier expressionsSimplifier)
        {
            _expressionsSimplifier = expressionsSimplifier;
        }
        private  List<string> Parse(string input)
        {
            return Regex.Split(input, @"([*()\^\/]|(?<!E)[\+\-])").Where(t => t != "").ToList();
        }
        public  double Solve(string input)
        {
            Validate(input);
            var tokens = Parse(input);
            return _expressionsSimplifier.Simplify(tokens);
        }
        private void Validate(string input)
        {
            if (input == "")
            {
                throw new ArgumentException("Input can't be empty!");
            }
            
        }
    }
    
}

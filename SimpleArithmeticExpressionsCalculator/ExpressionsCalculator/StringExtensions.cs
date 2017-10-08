using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleArithmeticExpressionsCalculator
{
    public static class StringExtensions
    {
        public static int GetTokenPriority(this string token)
        {
            if (token == "(" || token == ")")
            {
                return 0;
            }
            if (token == "+" || token == "-")
            {
                return 1;
            }
            if (token == "*" || token == "/")
            {
                return 2;
            }
            if (token == "^")
            {
                return 3;
            }
            return 4;
        }
        public static bool IsTokenNumber(this string token)
        {
            double result;
            return double.TryParse(token, out result);
        }
        public static bool IsTokenOperator(this string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/" || token == "^";
        }
    }
}

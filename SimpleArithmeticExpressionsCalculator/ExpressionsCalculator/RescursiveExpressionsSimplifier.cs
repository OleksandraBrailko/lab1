using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleArithmeticExpressionsCalculator
{
    public class RescursiveExpressionsSimplifier : IExpressionsSimplifier
    {
        public List<string> SimplifyBreakets(List<string> tokens)
        {
            if (tokens.Count == 1)
            {
                return tokens;
            }
            if (!tokens.Any(t => t=="(" || t==")"))
            {
                return tokens;
            }
            int indexOfOpeningBreakets = tokens.IndexOf(tokens.Find(t=>t=="("));
            int indexOfClosingBreakets = 0;
            var iterator = indexOfOpeningBreakets+1;
            int openingBreaketsCount = 1;
            while (iterator < tokens.Count) 
            {
                if (tokens[iterator]=="(")
                {
                    openingBreaketsCount++;
                }
                if (tokens[iterator]==")")
                {
                    openingBreaketsCount--;
                }
                if (openingBreaketsCount == 0)
                {
                    indexOfClosingBreakets = iterator;
                    break;
                }
                iterator++;
            }
            var insideTokens = tokens.Skip(indexOfOpeningBreakets+1).Take(indexOfClosingBreakets - indexOfOpeningBreakets-1); // те, що всередині душок
            var leftTokens = tokens.Take(indexOfOpeningBreakets); 
            var rightTokens = tokens.Skip(indexOfClosingBreakets + 1);
            return  SimplifyBreakets(leftTokens.Concat(SimplifyPlusMinusArithmeticOperations(SimplifyDivideMultiplicationArithmeticOperations(insideTokens.ToList()))).Concat(rightTokens).ToList());
        }
        public List<string> SimplifyPlusMinusArithmeticOperations(List<string> tokens)
        {
            if (tokens.Count == 1)
            {
                return tokens;
            }
            var result = double.Parse(tokens.First());
            for (int i = 2; i < tokens.Count; i += 2)
            {
                var value = double.Parse(tokens[i]);
                if (tokens[i - 1]=="+")
                {
                    result += value;
                }
                else if (tokens[i - 1]=="-")
                {
                    result -= value;
                }

            }
            
            return new List<string>() { result.ToString() };
        }
        public List<string> SimplifyDivideMultiplicationArithmeticOperations(List<string> tokens)
        {
            if (tokens.Count == 1)
            { 
                return tokens;
            }
            var iterator = 1;
            while (tokens.Any(t => t=="*" || t=="/")) 
            {
                if (tokens[iterator]=="*")
                {
                    var leftValue = double.Parse(tokens[iterator - 1]);
                    var righttValue = double.Parse(tokens[iterator + 1]);
                    var result = leftValue * righttValue;
                    tokens.RemoveRange(iterator - 1, 3);
                    tokens.Insert(iterator - 1, result.ToString());
                }
                else if (tokens[iterator]=="/")
                {
                    var leftValue = double.Parse(tokens[iterator - 1]);
                    var righttValue = double.Parse(tokens[iterator + 1]);
                    var result = leftValue / righttValue;
                    tokens.RemoveRange(iterator - 1, 3);
                    tokens.Insert(iterator - 1, result.ToString());
                }
                else
                {
                    iterator+=2;
                }

            }
            return tokens;
        }
        public double Simplify(List<string> tokens)
        {        
           return double.Parse(SimplifyPlusMinusArithmeticOperations(SimplifyDivideMultiplicationArithmeticOperations(SimplifyBreakets( tokens))).First());
        }
    }
}

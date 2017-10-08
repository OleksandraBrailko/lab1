using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleArithmeticExpressionsCalculator
{
    public class PolishExpressionsSimplifier : IExpressionsSimplifier
    {
        private List<string> ContertToPolishExpression(List<string> tokens)
        {
            var result = new List<string>();
            var stack = new Stack<string>();
            //Пока есть ещё символы для чтения:
            //Читаем очередной символ.
            foreach (var token in tokens)
            {
                // Если символ является числом, добавляем его к выходной строке.
                if (token.IsTokenNumber())
                {
                    stack.Push(token);
                }
                // Если символ является открывающей скобкой, помещаем его в стек.
                if (token == "(")
                {
                    stack.Push(token);
                }
                // Если символ является закрывающей скобкой:
                if (token == ")")
                {
                    //До тех пор, пока верхним элементом стека не станет открывающая скобка, ...
                    while (stack.Peek() != "(")
                    {
                        // ...выталкиваем элементы из стека в выходную строку. 
                        result.Add(stack.Pop());
                    }
                    // При этом открывающая скобка удаляется из стека, но в выходную строку не добавляется.
                    stack.Pop();
                }
                // Если символ является оператором о1, тогда:
                if (token.IsTokenOperator())
                {
                    // Пока приоритет o1 меньше либо равен приоритету оператора, находящегося на вершине стека... 
                    while (stack.Any() && token.GetTokenPriority() <= stack.Peek().GetTokenPriority())
                    {
                        // ...выталкиваем верхний элемент стека в выходную строку;
                        result.Add(stack.Pop());
                    }
                    // помещаем оператор o1 в стек.
                    stack.Push(token);
                }
            }
            //Когда входная строка закончилась, ...
            while (stack.Any())
            {
                // ...выталкиваем все символы из стека в выходную строку.
                result.Add(stack.Pop());
            }
            return result;
        }

        private double CalculateResult(List<string> tokens)
        {
            var stack = new Stack<string>();
            // Пока есть символы для чтения:
            // Читаем очередной символ.
            foreach (var token in tokens)
            {
                // Если символ является числом, помещаем его в стек.
                if (token.IsTokenNumber())
                {
                    stack.Push(token);
                }
                //Если символ является оператором: ...
                if (token.IsTokenOperator())
                {
                    // ...  выталкиваем аргументы оператора из стека и помещаем в стек результат операции;
                    stack.Push(SolveSimleExpression(token, stack.Pop(), stack.Pop()).ToString());
                }
            }
            // После того, как всё выражение просмотрено, то, что осталось в стеке, является оптимизированым выражением.
            return double.Parse(stack.Pop());
        }

        private double SolveSimleExpression(string expressionOperator,string secondOperand, string firstOperand)
        {
            var a = double.Parse(firstOperand);
            var b = double.Parse(secondOperand);
            if (expressionOperator == "+")
            {
                return a + b;
            }
            if (expressionOperator == "-")
            {
                return a - b;
            }
            if (expressionOperator == "*")
            {
                return a * b;
            }
            if (expressionOperator == "/")
            {
                return a / b;
            }
        
            if (expressionOperator == "^")
            {
                return Math.Pow(a, b);
            }
            throw new ArgumentException("Invalid operator");
        }

        public double Simplify(List<string> tokens)
        {
            tokens = ContertToPolishExpression(tokens);

            return CalculateResult(tokens);
        }
    }
}

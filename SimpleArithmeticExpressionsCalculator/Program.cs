using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleArithmeticExpressionsCalculator
{
    class Program
    {
        public static void PrintMatrix(SpraseMatrix m)
        {
            for(int i=0; i<m.RowCount;i++)
            {
                for (int j = 0; j < m.ColumnCount; j++)
                {
                    Console.Write(m[i,j]+"\t");
                }
                Console.WriteLine();
            }
        }
        public static void PrintVector(SimpleVector v)
        {
                Console.Write("{");
                for (int i = 0; i < v.RowCount; i++)
                {
                    Console.Write(v[i] + " ");
                }
                Console.WriteLine("}");
                Console.WriteLine();
            
        }
        
        static void Main(string[] args)
        {

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter 1 if you want to work with matrixes, enter 2 if you want to work with simple expressions, enter 3 if you want to work with vectors");
                    string option=Console.ReadLine();
                    if (option == "1")
                    {
                        Console.WriteLine("Realisation of SpraseMatrix: ");
                        var m1 = new SpraseMatrix(new double[,] { { 0, 1, 1 }, { 0, 2, 4 } });
                        var m2 = new SpraseMatrix(new double[,] { { 0, 0, 1, 3 }, { 0, 0, 2, 4 }, { 0, 0, 1, 3 } });
                        var m3 = m1.Multiply(m2);

                        PrintMatrix(m3);
                    }
                    else if (option == "2")
                    {
                        Console.WriteLine("Enter expression: ");
                        var input = Console.ReadLine();
                        IExpressionsSimplifier recursiveExpresionsSimplifier = new RescursiveExpressionsSimplifier();
                        IExpressionsSimplifier polishExpresionsSimplifier = new PolishExpressionsSimplifier();
                        var calculator = new SimpleArithmeticExpressionsCalculator(recursiveExpresionsSimplifier);
                        Console.WriteLine($"Result: {calculator.Solve(input)}");
                    }
                    else if (option == "3")
                    {
                        var v1 = new SimpleVector(new List<double> { 1, 2, 3 });
                        var v2 = new SimpleVector(new List<double> { -4, 2, 6 });
                        var v3 = v1.Add(v2);
                        var v4 = v1.ScalarProduct(v2);
                        Console.Write("Result: ");
                        Console.WriteLine(v4);
                        //PrintVector(v3);
                    }
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch
                {
                    Console.WriteLine("Some error has happened(((");
                }
            }
           
        }
    }
}

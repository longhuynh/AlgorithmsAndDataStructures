using System;
using System.Collections.Generic;

namespace NetFxStackCalculator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var values = new Stack<int>();

            foreach (var token in args)
            {
                int value;
                if (int.TryParse(token, out value))
                {
                    values.Push(value);
                }
                else
                {
                    var right = values.Pop();
                    var left = values.Pop();

                    switch (token)
                    {
                        case "+":
                            values.Push(left + right);
                            break;
                        case "-":
                            values.Push(left - right);
                            break;
                        case "*":
                            values.Push(left*right);
                            break;
                        case "/":
                            values.Push(left/right);
                            break;
                        case "%":
                            values.Push(left%right);
                            break;
                        default:
                            throw new ArgumentException($"Unrecognized token: {token}");
                    }
                }
            }

            Console.WriteLine(values.Pop());
        }
    }
}
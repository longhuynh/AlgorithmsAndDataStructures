using System;
using Stack.List;

namespace Calculator
{
    internal class Program
    {
        // calc.exe 5 6 7 * + 1 -
        private static void Main(string[] args)
        {
            // The stack of integers not yet operated on
            var values = new Stack<int>();

            foreach (var token in args)
            {
                // if the value is an integer...
                int value;
                if (int.TryParse(token, out value))
                {
                    // ... push it to the stack
                    values.Push(value);
                }
                else
                {
                    // otherwise evaluate the expresion...
                    var right = values.Pop();
                    var left = values.Pop();

                    // ... and pop the result back to the stack
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

            // the last item on the stack is the result
            Console.WriteLine(values.Pop());
        }
    }
}
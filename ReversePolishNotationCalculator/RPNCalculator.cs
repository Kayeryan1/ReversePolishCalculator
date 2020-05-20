using System;
using System.Collections.Generic;
using System.Linq;

namespace ReversePolishNotationCalculator
{
    public class RPNCalculator
    {
        //display prompt
        //take user input
        //display result or error message
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter a space seperated list of operators and and operands.");
                Console.WriteLine("supported operators are +, -, *, /");
                Console.WriteLine("eg: 2 3 +");
                var input = Console.ReadLine();
                var result = Calculate(input);
                if (result != double.MinValue)
                {
                    Console.WriteLine($"= {result}\n\n");
                }
                else Console.WriteLine("Error detected. Restarting.\n\n");
            }
        }

        private const string Operators = "+-*/";

        //Input: string representing reverse polish notation expression
        //Output: result of calculation
        //Side effects: displays error messages in the console
        //Errors: returns double.MinValue when an error is encountered
        public static double Calculate(string input)
        {
            var cleanInput = CleanValidateInput(input);
            var stack = new Stack<double>();
            foreach (var term in cleanInput)
            {
                var operatorIndex = Operators.IndexOf(term);
                //term is not an operator
                if (operatorIndex == -1)
                {
                    double termDouble;
                    //term is not a number that can be expressed as a double
                    if (!Double.TryParse(term, out termDouble))
                    {
                        Console.WriteLine($"Error: invalid input format. '{term}' not recognized");
                        return double.MinValue;
                    }
                    stack.Push(termDouble);
                }
                //term is an operator
                else
                {
                    try
                    {
                        //pop two operands
                        var a = stack.Pop();
                        var b = stack.Pop();
                        //perform relevant arithmetic
                        switch (operatorIndex)
                        {
                            case 0://addition
                                stack.Push(b + a);
                                break;
                            case 1://subtraction
                                stack.Push(b - a);
                                break;
                            case 2://multiplication
                                stack.Push(b * a);
                                break;
                            case 3://division
                                stack.Push(b / a);
                                break;
                        }
                    }
                    //error was encountered when popping from the stack
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Error: invalid input. Not enough operands;");
                        return double.MinValue;
                    }
                }
            }
            if (stack.Count > 1)
            {
                Console.WriteLine($"Error: invalid input. Not enough operators;");
                return double.MinValue;
            }
            return stack.Pop();
        }

        //Input: string representing reverse polish notation expression
        //Output: array of expression terms split by spaces
        //Side effects: removes excess whitespace from expression
        private static string[] CleanValidateInput(string input)
        {
            var inputArray = input.Split(' ');
            //remove excess whitespace
            var trimmedArray = inputArray.Where(i => !string.IsNullOrWhiteSpace(i)).ToArray();
            return trimmedArray;
        }
    }
}

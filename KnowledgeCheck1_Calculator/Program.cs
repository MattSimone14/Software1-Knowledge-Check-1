using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck1_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello. Press 1 for addition, 2 for subtraction, 3 for multiplication, and 4 for division");

            var input = Console.ReadLine();
            var calculator = new Calculator();

            switch (input)
            {
                case "1":
                    PerformOperation(calculator.Add, "add");
                    break;

                case "2":
                    PerformOperation(calculator.Subtract, "subtract");
                    break;

                case "3":
                    PerformOperation(calculator.Multiply, "multiply");
                    break;

                case "4":
                    PerformDivision(calculator.Divide);
                    break;

                default:
                    Console.WriteLine("Unknown input");
                    break;
            }
        }

        static void PerformOperation(Func<int, int, int> operation, string operationName)
        {
            Console.WriteLine($"Enter 2 integers to {operationName}");
            var firstNumber = Console.ReadLine();
            var secondNumber = Console.ReadLine();

            if (int.TryParse(firstNumber, out int numOne) && int.TryParse(secondNumber, out int numTwo))
            {
                Console.Write($"{firstNumber} {GetOperationSymbol(operationName)} {secondNumber} = ");
                Console.Write(operation(numOne, numTwo));
            }
            else
            {
                Console.WriteLine("One or more of the numbers is not an int");
            }
        }

        static void PerformDivision(Func<double, double, double> operation)
        {
            Console.WriteLine("Enter 2 numbers to divide");
            var firstNumber = Console.ReadLine();
            var secondNumber = Console.ReadLine();

            if (double.TryParse(firstNumber, out double numOne) && double.TryParse(secondNumber, out double numTwo))
            {
                Console.Write($"{firstNumber} / {secondNumber} = ");
                Console.Write(operation(numOne, numTwo));
            }
            else
            {
                Console.WriteLine("One or more of the numbers is not a number");
            }
        }

        static string GetOperationSymbol(string operationName)
        {
            return operationName switch
            {
                "add" => "+",
                "subtract" => "-",
                "multiply" => "*",
                _ => string.Empty,
            };
        }
    }
}

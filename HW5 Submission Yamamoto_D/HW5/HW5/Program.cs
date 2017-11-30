using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CptS321;

namespace HW5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string variable;
            string value;
            string equation;
            double result;
            bool quit = false;
            ExpTree tree = new ExpTree("1+1");

            while (quit == false)
            {
                Console.WriteLine("Menu (Current Expression = " + tree.equation + ") \n");
                Console.WriteLine("\t 1 = Enter a new expression \n");
                Console.WriteLine("\t 2 = Set a variable value \n");
                Console.WriteLine("\t 3 = Evaluate Tree \n");
                Console.WriteLine("\t 4 = Quit");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Please enter new expression to be evauluated \r\n");
                        equation = Console.ReadLine();
                        tree = new ExpTree(equation);
                        Console.WriteLine("\r\n \r\n");
                        break;
                    case "2":
                        Console.WriteLine("Enter variable name: ");
                        variable = Console.ReadLine();
                        
                        Console.WriteLine("Enter the new value for: " + variable);
                        value = Console.ReadLine();

                        tree.SetVar(variable, Convert.ToDouble(value));
                        break;
                    case "3":
                        Console.WriteLine("Evaluating current expression \r\n");
                        result = tree.Eval();
                        Console.WriteLine("Answer = " + result.ToString() + "\r\n \r\n");
                        break;
                    case "4":
                        Console.WriteLine("Quitting program");
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input \r\n \r\n");
                        break;
                }
            }

            Console.ReadLine();
        }
    }
}

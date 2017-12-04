/* Name: Douglas Yamamoto
 * WSU ID: 11010249
 * CPTS321 HW6
 * November 29th, 2017
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CptS321;

namespace HW6_Douglas_Yamamoto
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            string value;
            string currentExpression = "a+b+c";
            double result;
            bool exit = false;
            ExpTree tree = new ExpTree(currentExpression);

            while (exit == false)
            {

                Console.WriteLine("Menu (Current Expression = " + currentExpression + ")");
                Console.WriteLine("1 - Enter a new expression");
                Console.WriteLine("2 - Set a variable value");
                Console.WriteLine("3 - Evaluate tree");
                Console.WriteLine("4 - Quit");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Write new expression with no spaces: ");
                        currentExpression = Console.ReadLine();
                        tree = new ExpTree(currentExpression);
                        Console.WriteLine("\r\n \r\n");

                        break;
                    case "2":
                        Console.WriteLine("What variable do you want to set?");
                        userInput = Console.ReadLine();
                        Console.WriteLine("What value do you want to set: " + userInput + " as?");
                        value = Console.ReadLine();
                        tree.SetVar(userInput, Convert.ToDouble(value));
                        Console.WriteLine("\r\n \r\n");

                        break;

                    case "3":
                        Console.WriteLine("Evaluating: " + currentExpression);
                        result = tree.Eval();
                        Console.WriteLine("Result = " + result.ToString());
                        Console.WriteLine("\r\n \r\n");

                        break;

                    case "4":
                        Console.WriteLine("Exit");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        Console.WriteLine("Please input '1', '2', '3', or '4'");
                        Console.WriteLine("\r\n \r\n");

                        break;
                }
            }
        }
    }
}

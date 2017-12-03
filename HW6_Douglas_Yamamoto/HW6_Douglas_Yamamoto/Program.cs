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
            bool exit = false;
            ExpTree defaultTree = new ExpTree("2+3*(1/1)");

            while (exit == false)
            {

                Console.WriteLine("Menu (Current Expression =");
                Console.WriteLine("1 - Enter a new expression");
                Console.WriteLine("2 - Set a variable value");
                Console.WriteLine("3 - Evaluate tree");
                Console.WriteLine("4 - Quit");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Write new expression with no spaces: ");
                        userInput = Console.ReadLine();
                        ExpTree newTree = new ExpTree(userInput);
                        break;
                    case "2":
                        Console.WriteLine("What variable do you want to set?");
                        userInput = Console.ReadLine();


                        break;

                    case "3":
                        Console.WriteLine();
                        break;

                    case "4":
                        Console.WriteLine("Exit");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        Console.WriteLine("Please input '1', '2', '3', or '4'");
                        break;
                }
            }

            Console.ReadLine();
        }
    }
}

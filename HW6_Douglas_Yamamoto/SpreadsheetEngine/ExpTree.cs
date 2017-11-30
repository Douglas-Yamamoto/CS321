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

namespace CptS321
{
    public class ExpTree
    {
        string variableName;
        double variableValue;
        Dictionary<string, double> variableDictionary;
        Node root;

        ExpTree(string expression)
        {

        }

        void SetVar(string varName, double varValue)
        {
            // If the dictionary already has the variable name stored
            if (variableDictionary.ContainsKey(varName))
            {
                variableDictionary.Remove(varName);
                variableDictionary.Add(varName, varValue);
            }
            else
            {
                variableDictionary.Add(varName, varValue);
            }
        }
        // Implement evaluate method in nodes
        // Shunting algorithm
        public double Eval()
        {
            double total = 0;

            if (root == null)
            {
                return 0;
            }

            else
            {

            }

            return total;
        }


    }
}

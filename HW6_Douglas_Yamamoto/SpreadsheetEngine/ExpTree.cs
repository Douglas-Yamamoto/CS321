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
        Stack<Node> operandStack = new Stack<Node>();
        Stack<OpNode> operatorStack = new Stack<OpNode>();
        Node root;
        private string userInput;

        public ExpTree(string expression)
        {
            int operandBegin = 0;

            for (int i = 0; i < expression.Length; i++)
            {
                string operandName = expression.Substring(operandBegin, i - operandBegin);
                char currentChar = expression[i];

                if (currentChar == '+' || currentChar == '-' || currentChar == '*' || currentChar == '/')
                {
                    OpNode newOp = new OpNode(currentChar.ToString());

                    // Figure out if operand is constant or variable valued
                    if (65 < expression[operandBegin])
                    {
                        // We know that the operand, left of current operator, is a variable
                        VarNode newVar = new VarNode(operandName, 0);
                        operandStack.Push(newVar);
                    }

                    else
                    {
                        // We know that the operand, left of current operator, is a constant
                        ConstNode newConst = new ConstNode(operandName, Convert.ToDouble(operandName));
                        operandStack.Push(newConst);
                    }

                    // Need to set beginning of next operand
                    if (expression[i+1] != '(')
                    {
                        // Should be beginning of operand after operator, if no ( to right of operator
                        operandBegin = i + 1;
                    }
                    
                    else
                    {
                        // We see a ( next to current operator, we don't want to include that as part of next operand
                        operandBegin = i + 2;
                    }

                    // Determine what to do with current and previous operators
                    if (operatorStack.Count > 0)
                    {
                        // Need to peak at top of operand stack, if higher precedence need to push current operand down
                        if (operatorStack.Peek().Precedence < newOp.Precedence)
                        {
                            operatorStack.Push(newOp);
                        }
                        // If lower precedence, need to pop and form node
                        else
                        {
                            OpNode newParent = operatorStack.Pop();
                            newParent.RightChild = operandStack.Pop();
                            newParent.LeftChild = operandStack.Pop();
                            operandStack.Push(newParent);
                            
                            operatorStack.Push(newOp);
                        }
                    }

                    else
                    {
                        // If the operator stack is empty, it is essentially a sentinal like the hint paper was describing
                        operatorStack.Push(newOp);
                    }
                }
                else if (currentChar == '(')
                {
                    // Need to form new tree
                    ExpTree newTree = new ExpTree(expression.Substring(i + 2));
                    operandStack.Push(newTree.root);
                }
                else if (currentChar == ')')
                {
                    // End new tree, pop back out
                    // Figure out if operand is constant or variable valued
                    if (65 < expression[operandBegin])
                    {
                        // We know that the operand, left of current operator, is a variable
                        VarNode newVar = new VarNode(operandName, 0);
                        operandStack.Push(newVar);
                    }

                    else
                    {
                        // We know that the operand, left of current operator, is a constant
                        ConstNode newConst = new ConstNode(operandName, Convert.ToDouble(operandName));
                        operandStack.Push(newConst);
                    }

                    OpNode newParent = operatorStack.Pop();
                    newParent.RightChild = operandStack.Pop();
                    newParent.LeftChild = operandStack.Pop();

                    break;
                }
            }

            while (operandStack.Count > 0)
            {
                OpNode newParent = operatorStack.Pop();
                newParent.RightChild = operandStack.Pop();
                newParent.LeftChild = operandStack.Pop();

                operandStack.Push(newParent);
            }
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

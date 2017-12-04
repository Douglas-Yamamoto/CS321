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
        string variableName;                // Used for menu interface, specifies which key to access in variableDictionary
        double variableValue;               // Used for menu interface, specifies the new value for variableDictionary
        Dictionary<string, double> variableDictionary = new Dictionary<string,double>();    // Create new instance of dictionary 
        Stack<Node> operandStack = new Stack<Node>();   // Create operand stack
        Stack<OpNode> operatorStack = new Stack<OpNode>();  // Create operator stack
        Node root;      // Provide a reference point for paranthesis
        private string userInput;       // Used for menu interface

        public ExpTree(string expression)
        {
            int operandBegin = 0;       // Index of where the first character of the operand exists
            bool exit = false;          // Used for logic with paranthesis and how they are placed onto appropriate stack
            bool paranthesis = false;   // If true, we know that the last paranthesis was placed onto stack and we do not need to create another operand for current operator
            
            // Iterate through length of given expression 
            for (int i = 0; i < expression.Length; i++)
            {
                char currentChar = expression[i];
                // If looking at an operator 
                if (currentChar == '+' || currentChar == '-' || currentChar == '*' || currentChar == '/')
                {
                    // Create an appropriate OpNode
                    OpNode newOp = new OpNode(currentChar.ToString());

                    // Last thing we looked at was not ')'
                    if (paranthesis == false)
                    {
                        //  Create an operand node with last operand and place onto stack 
                        Node newNode = determineNode(expression, operandBegin, i);
                        operandStack.Push(newNode);
                    }
                    // We know that there is no 'new' operand to be placed on stack, sub-tree contained in () is already placed onto operand stack
                    else
                    {
                        // Reset the paranthesis flag
                        paranthesis = false;
                    }
                    // Next operand should begin immediately after the operator, note this would be different if urnary operators were included
                    operandBegin = i + 1;

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
                    ExpTree newTree = new ExpTree(expression.Substring(i + 1));

                    //TEST
                    i = expression.IndexOf(')', i + 1);
                    paranthesis = true;

                    operandStack.Push(newTree.root);
                }
                else if (currentChar == ')')
                {
                    // End new tree, pop back out
                    Node newNode = determineNode(expression, operandBegin, i);
                    operandStack.Push(newNode);
                    root = formTree(operandStack, operatorStack);
                    exit = true;
                    break;
                }
            }

            // Since we are only using binary oprators, the operand stack must be even when expression is completely evaluated
            if (operandStack.Count > 0 & (operandStack.Count % 2 != 0) & exit == false)
            {
                Node newNode = determineNode(expression, operandBegin, expression.Length);
                operandStack.Push(newNode);
            }
            // Provide an entry point for outside world to access
            root = formTree(operandStack, operatorStack);
        }

        public void SetVar(string varName, double varValue)
        {
            // If the dictionary already has the variable name stored, update the value
            if (variableDictionary.ContainsKey(varName))
            {
                variableDictionary[varName] = varValue;
            }
            // Simply add the values to the dictionary
            else
            {
                variableDictionary.Add(varName, varValue);
            }
        }

        public double Eval()
        {
            // Call the node's evaluate function
            return root.evaluate(variableDictionary);
        }

        private Node determineNode(string expression, int operandBegin, int i)
        {
            string operandName = expression.Substring(operandBegin, i - operandBegin);
            // Figure out if operand is constant or variable valued
            if (65 < expression[operandBegin])
            {
                // We know that the operand, left of current operator, is a variable
                if (variableDictionary.ContainsKey(operandName) == true)
                {
                    VarNode newNode = new VarNode(operandName, variableDictionary[operandName]);
                    return newNode;
                }
                else
                {
                    VarNode newNode = new VarNode(operandName, 0);
                    variableDictionary.Add(operandName, newNode.NodeValue);
                    return newNode;
                }
            }

            else
            {
                // We know that the operand, left of current operator, is a constant
                ConstNode newNode = new ConstNode(operandName, Convert.ToDouble(operandName));
                return newNode;
            }
        }

        // Created this method to prevent bloat in code
        private Node formTree(Stack<Node> operands, Stack<OpNode> operators)
        {
            // While there are no OpNode on the operatorsStack, form appropriate branches and place in operands stack
            while (operators.Count > 0)
            {
                OpNode newParent = operators.Pop();
                newParent.RightChild = operands.Pop();
                newParent.LeftChild = operands.Pop();

                root = newParent;
                operandStack.Push(newParent);
            }

            return root;
        }
    }
}

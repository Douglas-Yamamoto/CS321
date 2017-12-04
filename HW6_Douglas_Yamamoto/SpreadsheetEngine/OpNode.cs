using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    class OpNode : Node
    {
        private int precedence;         // Attribute for stack procedures 
        private Node rightChild;        // OpNodes will always have to have two children to perform the binary operation
        private Node leftChild;         // Note: this program does not account for any urnary operators

        // Default constructor
        public OpNode (string operation)
        {
            this.NodeName = operation;      // Set NodeName attribute found in abstract class

            // Figure out what operation the node is being set to, and provide proper precedence
            switch (operation)
            {
                case "+" :
                this.Precedence = 0;
                break;

                case "-" :
                this.Precedence = 0;
                break;

                case "*" :
                this.Precedence = 1;
                break;

                case "/" :
                this.Precedence = 1;
                break;

                default :
                this.Precedence = -1;
                break;
            }
        }
        // Evaluate function takes the dictionary for the ExpTree so that the variables can find their values
        public override double evaluate(Dictionary<String, Double> variableDictionary)
        {
            // Peform appropriate operation in accordance to the Node's name
            // The way the tree is constructed an in-order traversal is needed
            switch (this.NodeName)
            {
                case "+":
                    return this.leftChild.evaluate(variableDictionary) + this.rightChild.evaluate(variableDictionary);

                case "-":
                    return this.leftChild.evaluate(variableDictionary) - this.rightChild.evaluate(variableDictionary);

                case "*":
                    return this.leftChild.evaluate(variableDictionary) * this.rightChild.evaluate(variableDictionary);

                case "/":
                    return this.leftChild.evaluate(variableDictionary) / this.rightChild.evaluate(variableDictionary);

                default:
                    return 0;
            }
        }

        // Standard getters and setters
        public Node RightChild
        {
            get { return rightChild; }
            set { rightChild = value; }
        }

        public Node LeftChild
        {
            get { return leftChild; }
            set { leftChild = value; }
        }

        public int Precedence
        {
            get { return precedence; }
            set { precedence = value; }
        }
    }
}

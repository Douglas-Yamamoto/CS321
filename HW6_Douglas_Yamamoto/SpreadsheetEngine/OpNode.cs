using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    class OpNode : Node
    {
        private int precedence;
        private Node rightChild;
        private Node leftChild;

        public OpNode (string operation)
        {
            this.NodeName = operation;

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

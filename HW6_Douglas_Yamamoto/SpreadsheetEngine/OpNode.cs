using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    class OpNode : Node
    {
        public OpNode (string operation)
        {
            this.nodeName = operation;
        }

        public Node rightChild
        {
            get { return this.rightChild; }
            set { this.rightChild = value; }
        }

        public Node leftChild
        {
            get { return this.leftChild; }
            set { this.leftChild = value; }
        }
    }
}

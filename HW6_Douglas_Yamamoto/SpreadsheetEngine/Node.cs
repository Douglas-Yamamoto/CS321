using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    abstract class Node
    {
        private string nodeName;
        private double nodeValue;
        protected Node()
        {
            // Default constructor
        }

        public string NodeName
        {
            get { return this.nodeName; }
            protected set { this.nodeName = value; }
        }

        public double NodeValue
        {
            get { return this.nodeValue; }
            protected set { this.nodeValue = value; }
        }
    }
}

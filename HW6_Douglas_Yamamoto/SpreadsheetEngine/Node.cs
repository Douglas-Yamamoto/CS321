using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    abstract class Node
    {
        protected Node()
        {
            // Default constructor
        }

        public string nodeName
        {
            get { return this.nodeName; }
            protected set { this.nodeName = value; }
        }

        public double nodeValue
        {
            get { return this.nodeValue; }
            protected set { this.nodeValue = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    class ConstNode : Node
    {
        public ConstNode(string name, double value)
        {
            this.NodeName = name;
            this.NodeValue = value;
        }
    }
}

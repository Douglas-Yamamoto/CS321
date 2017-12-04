using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    class VarNode : Node
    {
        // Constructor
        public VarNode(string name, double value)
        {
            this.NodeName = name;
            this.NodeValue = value;
        }

        // Takes the dictionary passed through the evaluate function to look up stored variable value
        public override double evaluate(Dictionary<String, Double> variableDictionary)
        {
            return variableDictionary[this.NodeName];
        }
    }
}

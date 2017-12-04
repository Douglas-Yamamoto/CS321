using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    class ConstNode : Node
    {
        // Default constructor
        public ConstNode(string name, double value)
        {
            this.NodeName = name;
            this.NodeValue = value;
        }

        // Evaluate function returns the stored value 
        public override double evaluate(Dictionary<String, Double> variableDictionary)
        {
            return this.NodeValue;
        }
    }
}

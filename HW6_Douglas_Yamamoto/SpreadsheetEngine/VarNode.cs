﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    class VarNode : Node
    {
        public VarNode(string name, double value)
        {
            this.NodeName = name;
            this.NodeValue = value;
        }
        
        public VarNode(string name)
        {
            this.NodeName = name;
        }
    }
}

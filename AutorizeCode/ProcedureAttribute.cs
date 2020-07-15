using System;
using System.Collections.Generic;
using System.Text;

namespace AutorizeCode
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ProcedureAttribute:Attribute
    {
        public ProcedureAttribute(string name) : this(name,"View")
        {
            
        }
        public ProcedureAttribute(string name, string action)
        {
            Name = name;
            Action = action;
        }
        public string Name { get; }
        public string Action { get; }
    }
}

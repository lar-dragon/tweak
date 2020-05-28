using System;

namespace Tweak
{
    [AttributeUsage(AttributeTargets.Property)]  
    public class Argument: Attribute
    {
        public string Name { get; }

        public Argument(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
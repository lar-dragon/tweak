using System;

namespace Tweak
{
    [AttributeUsage(AttributeTargets.Property)]  
    public class Argument: Attribute
    {
        private readonly string _name;

        public Argument(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
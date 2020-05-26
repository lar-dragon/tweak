using Microsoft.Win32;

namespace Tweak
{
    public class RegistryValue
    {
        private readonly string _name;
        private readonly object _defaultValue;
        
        public RegistryValue(string name, object defaultValue)
        {
            _name = name;
            _defaultValue = defaultValue;
        }

        public object GetValue()
        {
            return Registry.CurrentUser.GetValue(_name, _defaultValue);
        }

        public void SetValue(object value)
        {
            Registry.CurrentUser.SetValue(_name, value);
        }
    }
}
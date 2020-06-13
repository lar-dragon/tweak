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

        public T GetValue<T>()
        {
            return Registry.CurrentUser.GetValue(_name, _defaultValue) is T t ? t : default;
        }

        public void SetValue<T>(T value)
        {
            Registry.CurrentUser.SetValue(_name, value);
        }
    }
}
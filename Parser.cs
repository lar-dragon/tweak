using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tweak
{
    public class Parser
    {
        private Config Config { get; }

        public Form Form { get; }

        public Parser(ICollection<string> args)
        {
            Config = new Config();
            foreach (var arg in args)
            {
                var items = arg.Split("=".ToCharArray(), 2, StringSplitOptions.RemoveEmptyEntries);
                var name = items.First();
                var value = string.Join(" ", items.Skip(1).ToList());
                var property = Config
                    .GetType()
                    .GetProperties()
                    .First(a => a.GetCustomAttributes(typeof(Argument), true)
                        .First(b => b.ToString() == name) != null);
                if (property != null)
                    property.SetValue(
                        Config,
                        property.GetType().IsEnum
                            ? Enum.Parse(property.GetType(), value)
                            : bool.Parse(value),
                        null
                    );
            }
            
            if (args.Count > 0)
                Form = new ProgressForm(Config);
            else
                Form = new ConfigForm(Config);
        }
    }
}
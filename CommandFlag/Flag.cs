using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandFlag
{
    internal class FlagItem<T>
    {
        public string Name { get; set; }
        public T Value { get; set; }
    }

    public class Flag
    {
        private ICollection<object> _flagItems;
        public Flag()
        {
            _flagItems = new HashSet<object>();
        }

        public bool TryGet<T>(string flag, out T value)
        {
            var item = _flagItems.OfType<FlagItem<T>>().FirstOrDefault(f => string.Equals(f.Name, flag, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                value = item.Value;
                return true;
            }
            value = default(T);
            return false;
        }

        public bool Exsit(string flag)
        {
            return _flagItems.OfType<FlagItem<string>>().Any(f => string.Equals(f.Name, flag, StringComparison.OrdinalIgnoreCase));
        }

        public static bool TryParse(string args, out Flag flag)
        {
            try
            {
                flag = new Flag();
                ISpliter spliter = SpliterFactory.CreateSpilter(args);
                var results = spliter.Splite(args);
                foreach (var arg in results)
                {
                    var p = ParserFactory.CreateParser(arg);
                    flag._flagItems.Add(p.Parse(arg));
                }
                return true;
            }
            catch
            {
                flag = null;
                return false;
            }
        }
    }
}

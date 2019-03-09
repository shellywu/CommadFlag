using System;
using System.Collections.Generic;
using System.Text;

namespace CommandFlag.Parsers
{
    class EqualStringParser : IParser
    {
        public bool CanParse(string arg)
        {
            return arg.Split('=').Length > 0;
        }

        public object Parse(string arg)
        {
            var item = arg.Split('=');
            var value = "";
            if (item.Length == 2)
            {
                value = item[1];
            }
            return new FlagItem<string>
            {
                Name = item[0],
                Value = value.Trim()
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CommandFlag
{
    interface IParser
    {
        bool CanParse(string arg);
        object Parse(string arg);
    }

    class ParserFactory
    {
        private static IEnumerable<IParser> _parsers;
        static ParserFactory()
        {
            _parsers = new HashSet<IParser>() {
                new Parsers.EqualStringParser()
            };
        }
        public static IParser CreateParser(string arg)
        {
            foreach (var parser in _parsers)
            {
                if (parser.CanParse(arg))
                {
                    return parser;
                }
            }
            throw new NotSupportedException("参数转化不被支持");
        }
    }
}

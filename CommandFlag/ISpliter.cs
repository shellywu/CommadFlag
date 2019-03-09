using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CommandFlag
{
    interface ISpliter
    {
        bool CanSplit(string input);
        string[] Splite(string input);
    }

    class SpliterFactory
    {
        private static IEnumerable<ISpliter> _spliters;
        static SpliterFactory()
        {
            _spliters = new HashSet<ISpliter>() {
                new Spliters.SlashSpliter()
            };
        }
        public static ISpliter CreateSpilter(string input)
        {
            foreach (var spliter in _spliters)
            {
                if (spliter.CanSplit(input))
                {
                    return spliter;
                }
            }
            throw new NotImplementedException("can not splite args");
        }
    }
}

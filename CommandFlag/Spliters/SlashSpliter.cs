using System;
using System.Collections.Generic;
using System.Text;

namespace CommandFlag.Spliters
{
    class SlashSpliter : ISpliter
    {
        public bool CanSplit(string input)
        {
            var d1 = input.Replace("//", "|");
            return d1.IndexOf('/') > -1;
        }

        public string[] Splite(string input)
        {
            var d1 = input.Replace("//", "|");
            var stack = new Stack<string>();
            int startPos = d1.IndexOf('/');
            int endPos = 0;
            var d2 = d1.Substring(startPos+1);

            while ((endPos = d2.IndexOf('/')) > 0)
            {
                stack.Push(d2.Substring(0, endPos).Replace("|", "//"));
                d2 = d2.Substring(endPos+1);
            }
            if (d2.Length>0)
            {
                stack.Push(d2.Replace("|","//"));
            }
            return stack.ToArray();
        }
    }
}

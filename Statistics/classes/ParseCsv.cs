using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics.classes
{
    internal class ParseCsv
    {
        private int _current = -1;
        public string[] Lines { get; private set; }
        public string Separator { get; private set; }

        public ParseCsv(string[] line, string separator = ";")
        {
            Lines = line;
            Separator = separator;
        }

        public string[]? GetNextLine() => GetLine(++_current);

        public string[]? GetLine(int line)
        {
            if (line >= 0 && line < Lines.Length)
            {
                return Lines[line].Split(Separator.ToCharArray());
            }

            return null;
        }
    }
}

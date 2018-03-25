using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChat
{
    public static class HexConversion
    {
        public static int ToHexInt(this char c)
        {
            if(c >= '0' && c <= '9')
            {
                return c - '0';
            }
            if (c >= 'a' && c <= 'f')
            {
                return c - 'a' + 10;
            }
            if (c >= 'A' && c <= 'F')
            {
                return c - 'A' + 10;
            }

            return -1;
        }

        public static char ToHexChar(this int hex)
        {
            if (hex >= 0 && hex <= 9)
            {
                return (char)('0' + hex);
            }
            if (hex >= 10 && hex <= 15)
            {
                return (char)('a' + hex - 10);
            }
            return 'z';
        }
    }
}

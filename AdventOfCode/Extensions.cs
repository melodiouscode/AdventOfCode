using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Extensions
    {
        public static int ToInt32(this string value)
        {
            return int.Parse(value);
        }
    }
}

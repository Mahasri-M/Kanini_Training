using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    internal class Addition
    {
        private static int bon=6;
        
        internal static void add(int x, int y,
            out int a, out int b)
        {
            a = bon+x;
            b = bon+y;
            
        }
        internal static void add(double x, double y,
            out int a, out int b)
        {
            a = bon + (int)x;
            b = bon + (int)y;

        }
    }
}

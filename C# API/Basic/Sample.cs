using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    internal class Sample : AddCon
    {
        public int intadd(int n1 = 20, int n2 = 10)
        {
            return n1 + n2;
        }

        public string stradd(string s1, string s2)
        {
            return s1 + s2;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    public partial class PartialDemo
    {
        int n3,ans;

        public PartialDemo(int n1, int n2, int n3, 
            int ans)
        {
            N1 = n1;
            N2 = n2;
            N3 = n3;
            this.ans = ans;
        }

        public int N3 { get => n3; set => n3 = value; }

        public partial int calc()
        {
            Console.WriteLine("Adding : " + N1 +
                " & " + N2);
            this.ans = N1 + N2;
            return this.ans;
        }

    }
}

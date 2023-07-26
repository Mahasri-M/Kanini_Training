using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    internal class ExcepHandling
    {
        int n1, n2, ans;

        public ExcepHandling(int n1, int n2, 
            int ans)
        {
            this.n1 = n1;
            this.n2 = n2;
            this.ans = ans;
        }
        public int add()
        {
            this.ans = this.n1 + this.n2;
            return this.ans;
        }
        public int mul()
        {
            this.ans = this.n1 * this.n2;
            return this.ans;
        }
        public int div()
        {
            int[] num = { 10, 0 };
            try
            {
                this.ans = this.n1 / this.n2;
                int x = num[0] + num[1] + num[2];
            }
            catch (DivideByZeroException ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Dont give 0" +
                    "in the denominator");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Done");
            }
            return this.ans;
        }
        public void CheckVal(int val)
        {
            if (val < 0)
            {
                throw new ArgumentException(
                    "Dont pass 0");
            }
            else if (val < 18) 
            {
                throw new ArithmeticException(
                    "Val should be > 18");
            }
            else
            {
                Console.WriteLine("OK");
            }
        }
    }
}

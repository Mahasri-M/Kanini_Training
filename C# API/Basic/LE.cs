using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    internal class LE
    {
        public void evennum()
        {
            List<int> numbers = new List<int>()
                 { 10,5,3,7,8,11,65,76};

            List<int> evennum =
             numbers.FindAll(n => ((n % 2) == 0));
            foreach(int n in evennum) 
            {
                Console.WriteLine(n);
            }
        }

        public void BE()
        {
            List<BankDetails> accounts = 
                new List<BankDetails>()
                { 
                    new BankDetails(12345, "AAA", 10000, 0),
                    new BankDetails(12346, "BBB", 20000, 0)
                };
            var names = accounts.Select(x => x.Accname);
           // var bal = accounts.Select(x => x.Balance);

            foreach(var name  in names ) 
            {
                Console.WriteLine(name);
            }

        }


    }
}

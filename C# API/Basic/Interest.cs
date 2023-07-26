using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    internal class Interest : BankDetails
    {
        private double intpercent;

        public Interest(int intpercent, int accno, 
            string accname, double balance,
            double intamt)
            : base ( accno, accname,  balance,  intamt)
        {
            this.Intpercent = intpercent;
        }

        public double Intpercent { get => intpercent; set => intpercent = value; }

        public override double CalculateInterest()
        {
            Intamt = Balance * 1 * (Intpercent / 100);
            return Intamt;
        }

      
    }
}

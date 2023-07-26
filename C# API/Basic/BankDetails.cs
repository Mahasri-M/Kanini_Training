using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    internal class BankDetails
    {
        private int accno;
        private string accname;
        private double balance;
        private double intamt;

        public BankDetails(int accno, string accname, double balance, double intamt)
        {
            this.Accno = accno;
            this.Accname = accname;
            this.Balance = balance;
            this.Intamt = intamt;
        }

        public int Accno { get => accno; set => accno = value; }
        public string Accname { get => accname; set => accname = value; }
        public double Balance { get => balance; set => balance = value; }
        public double Intamt { get => intamt; set => intamt = value; }

        public virtual double CalculateInterest()
        {
            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace Basic { 
    internal class BankAccount
    {
        private int custid;
        private long accno;
        private string name;
        private double balance;
        private string status;

       public BankAccount()
        {
            this.Custid = 0;
            this.Accno = 0;
            this.Name = "";
            this.Balance = 0;
            this.Status = "";
        }
      
        public BankAccount(
            int custid, long accno, 
            string name, double balance, 
            string status = "Inactive")
        {
            this.Custid = custid;
            this.Accno = accno;
            this.Name = name;
            this.Balance = balance;
            this.Status = status;
        }

        public int Custid { get => custid; set => custid = value; }
        public long Accno { get => accno; set => accno = value; }
        public string Name { get => name; set => name = value; }
        public double Balance { get => balance; set => balance = value; }
        public string Status { get => status; set => status = value; }

        public void Checkaccstatus(int custid = 0)
        {
            if (custid == Custid)
            {
                accno = Accno;
                name = Name;
                balance = Balance;
                status = Status;
            }                  
        }
        public void Checkaccstatus(long accno)
        {
            if (accno == Accno)
            {
                custid = Custid;
                name = Name;
                balance = Balance;
                status = Status;
            }

        }
    }
}
*/
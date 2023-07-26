using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQtoSQL
{
    internal class Stud_Details
    {
        StudentClassesDataContext stucontext =
             new StudentClassesDataContext();

        SampleClassesDataContext samdbcntx = new SampleClassesDataContext();

        public void ReadDataFromSQLServer()
        {
           
            /*var res= from st in stucontext.stud_details
                     where st.rno >101
                     select st;*/

            var res = stucontext.stud_details.Where(st => st.rno > 101);

            foreach (var r in res)
            {
                Console.WriteLine(r.rno + " " + r.name);
            }


        }
        public void CountMinMaxAvg()
        {
            int cou = (from st in stucontext.stud_details select st). Count();
            Console.WriteLine("rows:"+cou);


            int min = (Int32)(from st in stucontext.stud_details select st.rno).Min();
            Console.WriteLine("min"+min);

            int max = (int)stucontext.stud_details.Max(st => st.rno);
            Console.WriteLine("max:" + max);

            double avg = (double)stucontext.stud_details.Average(st =>st.rno);
            Console.WriteLine("avg:"+ avg);

        }
        public void Joins()
        {
            var result = samdbcntx.emps.Join(samdbcntx.depts,
                e=>e.deptno,d=>d.deptno, (e,d)=>new
                {
                    empname=e.ename,
                    deptname=d.dname
                });
            foreach(var emp in result)
            {
                Console.WriteLine(emp.empname + " "+emp.deptname);
            }
        }
    }
}

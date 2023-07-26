using DBEFAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DBEFAPI.Service.Emp
{
    public class Empser : IEmp
    {
        public DbefapiContext _CompanyContext;
        public Empser (DbefapiContext CompanyContext)
        {
            _CompanyContext = CompanyContext;
        }


        public async Task<IEnumerable<Empser>> GetEmps()
        {
            var em = await _CompanyContext.Emps.ToListAsync();
            return em;
        }


        public async Task<Empser> GetEmp(int id)
        {
            var emp = await _CompanyContext.Emps.FindAsync(id);

            if (emp is null)
            {
                return null;
            }
            return emp;
        }

        public async Task<Empser> PutEmp(int id, Empser emp)
        {
            Empser em = await _CompanyContext.Emps.FirstOrDefaultAsync(x => x.EmpNo == id);
            em.EmpNo = emp.EmpNo;
            em.Ename = emp.Ename;
            em.Deptno = emp.Deptno;
            await _CompanyContext.SaveChangesAsync();
            return emp;
        }

        public string PostEmp(Empser emp)
        {
            _CompanyContext.Emps.Add(emp);
            _CompanyContext.SaveChanges();
            return "Added successfully";
        }

        public async Task<string> DeleteEmp(int id)
        {
            Empser em = await _CompanyContext.Emps.FirstOrDefaultAsync(x => x.EmpNo == id);
            _CompanyContext.Emps.Remove(em);
            _CompanyContext.SaveChanges();

            return "Deleted successfully";
        }
    }
}


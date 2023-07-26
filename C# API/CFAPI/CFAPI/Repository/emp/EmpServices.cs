using Microsoft.EntityFrameworkCore;
using CFAPI.Models;

namespace CFAPI.Repository.emp
{
    public class EmpServices : IEmpServices
    {

        public readonly CompanyContextCF _context;
        public EmpServices(CompanyContextCF context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Emp>> Getemps()
        {
            return await _context.emps.ToListAsync();
        }

        public async Task<Emp> GetEmp(int id)
        {
            Emp em= await _context.emps.FirstOrDefaultAsync(x=>x.EmpNo==id);
            return em;
        }

        public async  Task<Emp> PutEmp(int id, Emp emp)
        {
            Emp em= await _context.emps.FirstOrDefaultAsync(x=> x.EmpNo==id);
            em.EName = emp.EName;
            em.deptno = emp.deptno;
            await _context.SaveChangesAsync();
            return em;
        }

        public async Task<Emp> PostEmp(Emp emp)
        {
            await _context.emps.AddAsync(emp);
            _context.SaveChanges();
            return emp;

        }

        public async Task<string> DeleteEmp(int id)
        {
            Emp em = await _context.emps.FirstOrDefaultAsync(x => x.EmpNo == id);
             _context.emps.Remove(em);
            await _context.SaveChangesAsync();

            return "Deleted successfully";

        }

        }
}

using Microsoft.EntityFrameworkCore;
using CFAPI.Models;

namespace CFAPI.Repository.dept
{
    public class DeptServices : IDeptServices
    {

        private readonly CompanyContextCF _context;

        public DeptServices(CompanyContextCF context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Dept>> GetDepts()
        {
            return await _context.Depts.ToListAsync();
        }

        public async Task<Dept> GetDept(int id)
        {
            Dept dp= await _context.Depts.FirstOrDefaultAsync(x=>x.Deptno==id);
            return dp;
        }

        public async Task<Dept> PutDept(int id, Dept dept)
        {
            Dept dp=await _context.Depts.FirstOrDefaultAsync(x=>x.Deptno==id);
            dp.Ename = dept.Ename;
            return dp;
        }

        public async Task<Dept> PostDept(Dept dept)
        {
            await _context.Depts.AddAsync(dept);
            _context.SaveChanges();
            return dept;
        }

        public async Task<string> DeleteDept(int id)
        {
            Dept dp = await _context.Depts.FirstOrDefaultAsync(x => x.Deptno == id);
            _context.Remove(dp);
            _context.SaveChanges();
            return "deleted Successfully";
        }
    }
}

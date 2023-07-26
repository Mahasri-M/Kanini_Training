using DBEFAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace DBEFAPI.Service.Dept
{
    public class Deptser :IDept
    {
        private DbefapiContext _context;

        public Deptser (DbefapiContext context)
        {
            _context = context;
        }
        public async Task<List<Dept?>> GetDepts()
        {

            var dept = await _context.Depts.ToListAsync();
            return dept;
        }

       public async Task<Dept?> GetDept(int id)
        {
            var deptno = await _context.Depts.FirstOrDefaultAsync(x => x.Deptno == id);

            if (deptno is null)
            {
                return null;
            }
            return deptno;
        }

        public async Task<Dept> PutDept(int id, Dept dept)
        {
            var dp = await _context.Depts.FirstOrDefaultAsync(x => x.Deptno == id);
            dp.Ename = dept.Ename;
            dp.Deptno = dept.Deptno;
            await _context.SaveChangesAsync();
            return dept;
        }

        public async Task<Dept> PostDept(Dept dept)
        {
            _context.Depts.Add(dept);
            _context.SaveChanges();
            return dept;
        }

        public async Task<string> DeleteDept(int id)
        {
            var dep = await _context.Depts.FirstOrDefaultAsync(x => x.Deptno == id);
            _context.Remove(dep);
            _context.SaveChanges();

            return "Deleted successfully";
        }
      
    }
}

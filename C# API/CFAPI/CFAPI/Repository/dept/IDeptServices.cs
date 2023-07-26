using Microsoft.AspNetCore.Mvc;
using CFAPI.Models;

namespace CFAPI.Repository.dept
{
    public interface IDeptServices
    {

        Task<IEnumerable<Dept>> GetDepts();
        Task<Dept> GetDept(int id);
         Task<Dept> PutDept(int id, Dept dept);
        Task<Dept> PostDept(Dept dept);
        Task<string> DeleteDept(int id);
    }
}

using Microsoft.AspNetCore.Mvc;
using DBEFAPI.Controllers;
using DBEFAPI.Models;

namespace DBEFAPI.Service.Dept
{
    public interface IDept 
    {
        Task<List<Dept?>> GetDepts();
       Task<Dept?> GetDept(int id);
        Task<Dept> PutDept(int id, Dept dept);
        Task<Dept> PostDept(Dept dept);
        Task<string> DeleteDept(int id);
    }
}

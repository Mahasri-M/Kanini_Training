using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBEFAPI.Models;
using DBEFAPI.Service.Emp;

namespace DBEFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpsController : ControllerBase
    {
        public readonly IEmp ctx;
        public EmpsController(IEmp _ctx)
        {
            ctx = _ctx;
        }

        [HttpGet]
        public async Task<IEnumerable<Emp>> GetEmps()
        {
            return await ctx.GetEmps();
        }

        [HttpGet("{id}")]
        public async Task<Emp> GetEmp(int id)
        {
            return await ctx.GetEmp(id);
        }
        [HttpPost]
        public string PostEmp(Emp emp)
        {
            return ctx.PostEmp(emp);
        }

        [HttpPut("{id}")]
        public async Task<Emp> PutEmp(int id, Emp emp)
        {
            return await ctx.PutEmp(id, emp);
        }
        [HttpDelete("{id}")]
        public async Task<string> DeleteEmp(int id)
        {
            return await ctx.DeleteEmp(id);
        }

    }
}

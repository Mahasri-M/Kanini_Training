using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBEFAPI.Models;
using DBEFAPI.Service.Dept;

namespace DBEFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptsController : ControllerBase
    {
        public readonly IDept _context;

        public DeptsController(IDept context)
        {
            _context = context;
        }

        // GET: api/Depts
        [HttpGet]
        public async Task<List<Dept?>> GetDepts()
        {
            return await _context.GetDepts();
        }

        // GET: api/Depts/5
         [HttpGet("{id}")]
         public async Task<ActionResult<Dept>> GetDept(int id)
         {
        var dept=await _context.GetDept(id);
        if(dept==null){

             return NotFound("Not matching");
         }
        return Ok(dept);

         // PUT: api/Depts/5
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPut("{id}")]
         public async Task<ActionResult<List<Dept?>>> PutDept(int id, Dept dept)
         {
        var deptid=await _context.PutDept(id,dept);
        if(deptid==null){

             return NotFound("Not matching");
         }
        return Ok(deptid);

         }

         // POST: api/Depts
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPost]
         public async Task<ActionResult<Dept>> PostDept(Dept dept)
         {
        var udept =await _context.PostDept(dept);
        if(udept==null){
        return NotFound("not matching");
        }

             return Ok(udept);
         }

         // DELETE: api/Depts/5
         [HttpDelete("{id}")]
         public async Task<ActionResult<Dept>> DeleteDept(int id)
         {
         var ddept =await _context.DeleteDept(id);
        if(ddept==null){
        return NotFound("not matching");
        }

             return Ok(ddept);
         }
         }
    }
}

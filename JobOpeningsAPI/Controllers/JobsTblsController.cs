#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobOpeningsAPI.Model;

namespace JobOpeningsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsTblsController : ControllerBase
    {
        private readonly JobOpeningContext _context;

        public JobsTblsController(JobOpeningContext context)
        {
            _context = context;
        }

        // GET: api/JobsTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobsTbl>>> GetJobsTbls()
        {
            return await _context.JobsTbls.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobsTbl>> GetJobsTbl(int id)
        {
            var jobsTbl = await _context.JobsTbls.FindAsync(id);

            if (jobsTbl == null)
            {
                return NotFound();
            }

            return jobsTbl;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobsTbl(int id, JobsTbl jobsTbl)
        {
            if (id != jobsTbl.JobId)
            {
                return BadRequest();
            }

            _context.Entry(jobsTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobsTblExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<JobsTbl>> PostJobsTbl(JobsTbl jobsTbl)
        {
            _context.JobsTbls.Add(jobsTbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobsTbl", new { id = jobsTbl.JobId }, jobsTbl);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobsTbl(int id)
        {
            var jobsTbl = await _context.JobsTbls.FindAsync(id);
            if (jobsTbl == null)
            {
                return NotFound();
            }

            _context.JobsTbls.Remove(jobsTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobsTblExists(int id)
        {
            return _context.JobsTbls.Any(e => e.JobId == id);
        }
    }
}

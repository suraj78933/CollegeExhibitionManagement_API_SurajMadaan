using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollegeExhibitionManagement_API_SurajMadaan.Data;
using CollegeExhibitionManagement_API_SurajMadaan.Models;

namespace CollegeExhibitionManagement_API_SurajMadaan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassMastersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClassMastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ClassMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassMaster>>> GetClassMasters()
        {
            return await _context.ClassMasters.ToListAsync();
        }

        // GET: api/ClassMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassMaster>> GetClassMaster(int id)
        {
            var classMaster = await _context.ClassMasters.FindAsync(id);

            if (classMaster == null)
            {
                return NotFound();
            }

            return classMaster;
        }

        // PUT: api/ClassMasters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassMaster(int id, ClassMaster classMaster)
        {
            if (id != classMaster.ID)
            {
                return BadRequest();
            }

            _context.Entry(classMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassMasterExists(id))
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

        // POST: api/ClassMasters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClassMaster>> PostClassMaster(ClassMaster classMaster)
        {
            _context.ClassMasters.Add(classMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassMaster", new { id = classMaster.ID }, classMaster);
        }

        // DELETE: api/ClassMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClassMaster>> DeleteClassMaster(int id)
        {
            var classMaster = await _context.ClassMasters.FindAsync(id);
            if (classMaster == null)
            {
                return NotFound();
            }

            _context.ClassMasters.Remove(classMaster);
            await _context.SaveChangesAsync();

            return classMaster;
        }

        private bool ClassMasterExists(int id)
        {
            return _context.ClassMasters.Any(e => e.ID == id);
        }
    }
}

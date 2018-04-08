using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LmycAPI.Data;
using LmycAPI.Models;

namespace LmycAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/RoleModels")]
    public class RoleModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoleModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RoleModels
        [HttpGet]
        public IEnumerable<RoleModel> GetRoleModel()
        {
            return _context.RoleModel;
        }

        // GET: api/RoleModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleModel([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roleModel = await _context.RoleModel.SingleOrDefaultAsync(m => m.RoleId == id);

            if (roleModel == null)
            {
                return NotFound();
            }

            return Ok(roleModel);
        }

        // PUT: api/RoleModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoleModel([FromRoute] string id, [FromBody] RoleModel roleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roleModel.RoleId)
            {
                return BadRequest();
            }

            _context.Entry(roleModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleModelExists(id))
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

        // POST: api/RoleModels
        [HttpPost]
        public async Task<IActionResult> PostRoleModel([FromBody] RoleModel roleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RoleModel.Add(roleModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoleModel", new { id = roleModel.RoleId }, roleModel);
        }

        // DELETE: api/RoleModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleModel([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roleModel = await _context.RoleModel.SingleOrDefaultAsync(m => m.RoleId == id);
            if (roleModel == null)
            {
                return NotFound();
            }

            _context.RoleModel.Remove(roleModel);
            await _context.SaveChangesAsync();

            return Ok(roleModel);
        }

        private bool RoleModelExists(string id)
        {
            return _context.RoleModel.Any(e => e.RoleId == id);
        }
    }
}
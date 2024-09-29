using mf_api_gerenciamento_tarefas_G14.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata.Ecma335;

namespace mf_api_gerenciamento_tarefas_G14.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {

        private readonly AppDbContext _context;

        public NotasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Notas.ToListAsync();
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Nota model)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            {
                _context.Notas.Add(model);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetById", new { id = model.Id }, model);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Notas
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Nota model)
        {
            if (id != model.Id) return BadRequest();

            if (ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }

            var modeloDb = await _context.Notas.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (modeloDb == null) return NotFound();

            _context.Notas.Update(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Notas.FindAsync(id);

            if (model == null) return NotFound();

            _context.Notas.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }   
        
}

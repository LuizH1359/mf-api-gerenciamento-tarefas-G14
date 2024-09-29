using mf_api_gerenciamento_tarefas_G14.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mf_api_gerenciamento_tarefas_G14.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinasController : ControllerBase
    {


        private readonly AppDbContext _context;

        public DisciplinasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Disciplinas.ToListAsync();
            return Ok(model);

        }

        [HttpPost]
        public async Task<ActionResult> Create(Disciplina model)
        {
            _context.Disciplinas.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Disciplinas
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) NotFound();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Disciplina model)
        {
            if (id != model.Id) return BadRequest();

            var modeloDb = _context.Disciplinas.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (modeloDb == null) return NotFound();

            _context.Disciplinas.Update(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Disciplinas.FindAsync(id);
            if (model == null) NotFound();

            _context.Disciplinas.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();

        }

    }
}

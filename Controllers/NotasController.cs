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
            var model = await _context.Notas
                .Include(n => n.Usuario)
                .Include (n => n.Disciplina)
                .Select(n => new
                {
                    n.Id,
                    n.Valor,
                    Disciplina = n.Disciplina.Nome,
                    Usuario = n.Usuario.Nome
                })
                .ToListAsync();
            return Ok(model);


        }

        [HttpPost]
        public IActionResult PostarNotas(NotasDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nota = new Nota
            {
                Valor = model.Valor,
                DisciplinaId = model.DisciplinaId,
                UsuarioId = model.UsuarioId
            };

            _context.Notas.Add(nota);
            _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = nota.Id }, nota);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Notas
                .Include(n => n.Usuario) 
                .Include(n => n.Disciplina)
                .Select(n => new 
                {
                    n.Id,
                    n.Valor,
                    Disciplina = n.Disciplina.Nome,
                    Usuario = n.Usuario.Nome
                })
                .FirstOrDefaultAsync(n => n.Id == id);

            if (model == null) return NotFound();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, NotasDto dto)
        {
          
            if (id != dto.Id) return BadRequest("ID da URL não corresponde ao ID da requisição.");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notaDb = await _context.Notas.FindAsync(id);

            if (notaDb == null) return NotFound("Nota não encontrada.");

            notaDb.Valor = dto.Valor;
            notaDb.DisciplinaId = dto.DisciplinaId;
            notaDb.UsuarioId = dto.UsuarioId;

            _context.Notas.Update(notaDb);
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

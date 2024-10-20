using mf_api_gerenciamento_tarefas_G14.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mf_api_gerenciamento_tarefas_G14.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TarefasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Tarefas.ToListAsync();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);

            if (model == null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]

        public async Task<ActionResult> CreateTarefa(Tarefa model)
        {
            Tarefa nova = new Tarefa()
            {
                Id = model.Id,
                Nome = model.Nome,
                Realizada = model.Realizada,

            };

            _context.Tarefas.Add(nova);
            await _context.SaveChangesAsync();

            return Ok(nova);
        }


        [HttpPut]

        public async Task<ActionResult> Update(int id,Tarefa model)
        {
            if (id != model.Id) return BadRequest();
            var modeloDb = await _context.Tarefas.AsNoTracking().FirstOrDefaultAsync(t =>t.Id == id);
            if (modeloDb == null) return NotFound();

            modeloDb.Nome = model.Nome;
            modeloDb.Descricao = model.Descricao;
            modeloDb.Realizada = model.Realizada;

            _context.Tarefas.Update(modeloDb);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete]

        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);
            if (model == null) return NotFound();
            _context.Tarefas.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
using mf_api_gerenciamento_tarefas_G14.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mf_api_gerenciamento_tarefas_G14.Controllers
{
    //[Authorize]
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
            var model 
                = await _context.Disciplinas
                .Include(u => u.Usuario)
                .Include(n => n.Notas)
                .Select(d => new
                {
                    d.Id,
                    d.Nome,
                    Usuario = new
                    {
                        d.Usuario.Id,
                        d.Usuario.Nome,
                        d.Usuario.Email
                    },
                    Notas = d.Notas.Select(n => new
                    {
                        n.Id,
                        n.Valor,
                        DisciplinaNome = n.Disciplina.Nome
                    })
                })
                .ToListAsync();
            
            return Ok(model);

        }

        [HttpPost]
        public IActionResult CriarDisciplina(DisciplinasDto disciplinaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var disciplina = new Disciplina
            {
                Nome = disciplinaDto.Nome,
                UsuarioId = disciplinaDto.UsuarioId,
                MediaAprovacao = disciplinaDto.MediaAprovacao,
            };

            var usuario = _context.Usuarios.Find(disciplinaDto.UsuarioId);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            _context.Disciplinas.Add(disciplina);
            _context.SaveChanges();

            return StatusCode(201, disciplina);
        }

        



        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Disciplinas
                .Where(x => x.Id == id)
                .Select(d => new
                {
                    d.Id,
                    d.Nome,
                    Usuario = new
                    {
                        d.UsuarioId,
                        d.Usuario.Nome
                    },
                    Notas = d.Notas.Select(n => new
                    {
                        n.Id,
                        n.Valor
                    })
                })
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) NotFound();

            return Ok(model);
        }

        [HttpGet("{usuarioId}/notas-disciplina/{disciplinaId}")]
        public async Task<ActionResult> GetNotasByDisciplina(int usuarioId, int disciplinaId)
        {
            var notas = await _context.Notas
                .Where(n => n.UsuarioId == usuarioId && n.DisciplinaId == disciplinaId)
                .Select(n => new
                {
                    n.Id,
                    n.Valor,
                    Disciplina = n.Disciplina.Nome,
                    Usuario = n.Usuario.Nome
                })
                .ToListAsync();

            if (!notas.Any())
                return NotFound("Nenhuma nota encontrada para este usuário nesta disciplina.");

            return Ok(notas);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, DisciplinasDto dto)
        {

            if (id != dto.Id) return BadRequest("O ID informado não corresponde ao da disciplina.");


            var modeloDb = await _context.Disciplinas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);


            if (modeloDb == null) return NotFound();


            var disciplina = new Disciplina
            {
                Id = id,
                Nome = dto.Nome,
                UsuarioId = dto.UsuarioId
            };


            _context.Disciplinas.Update(disciplina);
            await _context.SaveChangesAsync();

            var resultado = await _context.Disciplinas
                .Where(d  => d.Id == id)
                .Select(d => new
                {
                    d.Id,
                    d.Nome,
                    Usuario = new
                    {
                        d.Usuario.Id,
                        d.Usuario.Nome
                    }
                } ).FirstOrDefaultAsync();

            return Ok(resultado);
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


        [HttpGet("{disciplinaId}/calcular-media/{usuarioId}")]
        public async Task<ActionResult> CalcularMedia(int disciplinaId, int usuarioId)
        {
            if (usuarioId <= 0)
            {
                return BadRequest("ID do usuário é obrigatório.");
            }

            var disciplina = await _context.Disciplinas
                .Include(d => d.Notas)
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(d => d.Id == disciplinaId);

            if (disciplina == null) return NotFound("Disciplina não encontrada.");

            if (!disciplina.Notas.Any())
                return BadRequest("Não há notas registradas para calcular a média.");

            decimal totalNotas = 0;
            decimal totalMaximas = 0;

            foreach (var nota in disciplina.Notas)
            {
                totalNotas += nota.Valor;
                totalMaximas += nota.NotaMaxima;
            }

            
            if (totalMaximas == 0)
            {
                return BadRequest("Não é possível calcular a média, pois a soma das notas máximas é zero.");
            }

            var media = totalNotas / totalMaximas * 100;
            var mediaNecessaria = disciplina.PorcentagemNecessaria;
            var aprovado = media >= mediaNecessaria;

            return Ok(new
            {
                Media = media,
                Status = aprovado ? "Aprovado" : "Reprovado",
                Usuario = new
                {
                    disciplina.Usuario.Id,
                    disciplina.Usuario.Nome,
                    disciplina.Usuario.Email
                }
            });
        }


    }
    }



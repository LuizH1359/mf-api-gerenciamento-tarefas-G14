﻿using mf_api_gerenciamento_tarefas_G14.Models;
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
            var model = await _context.Disciplinas.Include(t => t.Usuario)
                .Include(t => t.Notas).ToListAsync();
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
                UsuarioId = disciplinaDto.UsuarioId
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
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) NotFound();

            return Ok(model);
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


        [HttpGet("{disciplinaId}/media-notas")]
        public async Task<ActionResult<decimal>> CalcularMediaNotas(int disciplinaId)
        {
            var disciplina = await _context.Disciplinas.FindAsync(disciplinaId);
            if (disciplina == null)
            {
                return NotFound("Disciplina não encontrada.");
            }

            var notas = await _context.Notas
                .Where(n => n.DisciplinaId == disciplinaId)
                .ToListAsync();

            if (notas == null || notas.Count == 0)
            {
                return NotFound("Nenhuma nota encontrada para a disciplina.");
            }

            decimal media = notas.Average(n => n.Valor);

            string mensagemFinal = $"Sua média é {media}";


            return Ok(mensagemFinal);
        }

        [HttpGet("{disciplinaId}/aprovado-reprovado")]

        public async Task<ActionResult<decimal>> InformarStatus(int disciplinaId)
        {
            var disciplina = await _context.Disciplinas.FindAsync(disciplinaId);
            if (disciplina == null)
                return NotFound("Disciplina não encontrada.");


            var notas = await _context.Notas
                .Where(n => n.DisciplinaId == disciplinaId)
                .ToListAsync();

            if (notas == null || notas.Count == 0)
                return NotFound("Nenhuma nota foi encontrada para a disciplina.");

            decimal media = notas.Average(n => n.Valor);

            string resultado = media >= 6
             ? $"Aprovado com média {media:F2}."
             : $"Reprovado com média {media:F2}.";

            return Ok(resultado);




        }
    }
}


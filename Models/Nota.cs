using mf_api_gerenciamento_tarefas_G14.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace mf_api_gerenciamento_tarefas_G14.Models
{
    [Table("Notas")]
    public class Nota : BaseEntity, IValidatableObject
    {
        [Required(ErrorMessage = "O valor da nota é obrigatório.")]
        [Range(0, 100, ErrorMessage = "O valor da nota deve estar entre 0 e a nota máxima.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A nota máxima é obrigatória.")]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(0, 100, ErrorMessage = "O valor da nota máxima deve estar entre 0 e 100.")]
        public decimal NotaMaxima { get; set; }

        [Required(ErrorMessage = "A disciplina é obrigatória.")]
        public int DisciplinaId { get; set; }

        [Required(ErrorMessage = "O usuário é obrigatório.")]
        public int UsuarioId { get; set; }


        public Disciplina Disciplina { get; set; }
        public Usuario Usuario { get; set; }

        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (Valor > NotaMaxima)
            {
                validationResults.Add(new ValidationResult(
                    $"O valor da nota não pode ser maior do que a nota máxima {NotaMaxima}.",
                    new[] { nameof(Valor) }));
            }

            if (Valor < 0)
            {
                validationResults.Add(new ValidationResult(
                    "O valor da nota não pode ser negativo.",
                    new[] { nameof(Valor) }));
            }

            return validationResults;
        }
    }
}


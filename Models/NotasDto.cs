using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace mf_api_gerenciamento_tarefas_G14.Models
{
    public class NotasDto : BaseEntity, IValidatableObject
    {
        [Required(ErrorMessage = "É necessário informar o valor da nota.")]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A nota máxima é obrigatória.")]
        [Column(TypeName = "decimal(5, 2)")]
       
        public decimal NotaMaxima { get; set; }

        [Required(ErrorMessage = "A disciplina é obrigatória.")]
        public int DisciplinaId { get; set; }

        [Required(ErrorMessage = "É necessário informar o ID do usuário.")]
        public int UsuarioId { get; set; }

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

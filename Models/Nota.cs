using mf_api_gerenciamento_tarefas_G14.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_api_gerenciamento_tarefas_G14.Models
{
    [Table("Notas")]
    public class Nota : BaseEntity
    {
        [Required(ErrorMessage = "O valor da nota é obrigatório.")]
        [Range(0, 100, ErrorMessage = "O valor da nota deve estar entre 0 e a nota máxima.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A disciplina é obrigatória.")]
        public int DisciplinaId { get; set; }

        [Required(ErrorMessage = "A nota máxima é obrigatória.")]
        public decimal NotaMaxima { get; set; }

        [Required(ErrorMessage = "O usuário é obrigatório.")]
        public int UsuarioId { get; set; }


        public Disciplina Disciplina { get; set; }
        public Usuario Usuario { get; set; }
    }
}

